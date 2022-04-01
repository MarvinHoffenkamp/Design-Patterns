using System;
using System.Collections.Generic;
using System.Text;
using Veiling.Auctions;
using Veiling.ObjectsOfSale;
using Veiling.States;

namespace Veiling
{
    static class Simulator
    {
        public static void start()
        {
            Console.WriteLine("Welcome to the auction simulator.\nPlease press a key to choose an auction to simulate. Then press enter.");
            Console.WriteLine(" [1] Auction inside a small warehouse.\n [2] Auction inside a big warehouse.\n [3] An online auction.\n [4] Create your own auction.");
            var chosenAuction = Console.ReadLine();
            chooseTypeOfSimulation(chosenAuction);
        }

        private static void chooseTypeOfSimulation(String chosenSimulation)
        {
            switch (chosenSimulation)
            {
                case "1":
                    simulateSmallWarehouse();
                    break;
                case "2":
                    simulateBigWarehouse();
                    break;
                case "3":
                    simulateOnline();
                    break;
                case "4":
                    simulateOwnAuction();
                    break;
                default:
                    Console.WriteLine("Sorry, the chosen option does not exist. Please choose a correct option.");
                    Console.WriteLine(" [1] Auction inside a small warehouse.\n [2] Auction inside a big warehouse.\n [3] An online auction.\n [4] Create your own auction.");
                    var newChosenSimulation = Console.ReadLine();
                    chooseTypeOfSimulation(newChosenSimulation);
                    break;
            }
        }

        private static void chooseAuction(String chosenAuction)
        {
            Auction auction = null;
            switch (chosenAuction)
            {
                case "1":
                    auction = buildOwnAuction("SW");
                    break;
                case "2":
                    auction = buildOwnAuction("BW");
                    break;
                case "3":
                    auction = buildOwnAuction("O");
                    break;
                default:
                    Console.WriteLine("Sorry, this option does not exist. Please select an option that does.");
                    Console.WriteLine(" [1] Auction inside a small warehouse.\n [2] Auction inside a big warehouse.\n [3] An online auction.");
                    var newChosenAuction = Console.ReadLine();
                    chooseAuction(newChosenAuction);
                    break;
            }

            if (auction == null)
                return;

            simulateBuildAuction(auction);
        }

        private static void simulateBuildAuction(Auction auction)
        {
            var auctioneer = auction.getAuctioneer();
            var start = new StartAuction(auctioneer);
            var inProgress = new AuctionInProgress(auctioneer);
            var end = new EndAuction(auctioneer);

            Console.WriteLine("Time to simulate the auction. Type of auction that will be simulated: {0}", auction.getAuctionType());

            while (auction.getObjectsOfSale().Count != 0)
            {
                auctioneer.TransitionTo(start);
                do
                {
                    //nothing, wait untill state specific code is finished
                }
                while (auctioneer.getStartAuctionFinished() != true);

                auctioneer.TransitionTo(inProgress);
                do
                {
                    //nothing, wait untill state specific code is finished
                }
                while (auctioneer.getAuctionInProgressFinished() != true);

                auctioneer.TransitionTo(end);
                do
                {
                    //nothing, wait untill state specific code is finished
                }
                while (auctioneer.getEndAuctionFinished() != true);

                auctioneer.setStartAuctionFinished(false);
                auctioneer.setAuctionInProgressFinished(false);
                auctioneer.setEndAuctionFinished(false);
            }
        }

        private static void simulateSmallWarehouse()
        {
            Console.WriteLine("The small warehouse auction will be made.");

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            var auction = buildPredefinedAuction("SW", amountOfBuyers, amountOfObjects);
            simulateBuildAuction(auction);
        }

        private static void simulateBigWarehouse()
        {
            Console.WriteLine("The big warehouse auction will be made.");

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            var auction = buildPredefinedAuction("BW", amountOfBuyers, amountOfObjects);
            simulateBuildAuction(auction);
        }

        private static void simulateOnline()
        {
            Console.WriteLine("The online auction will be made.");

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            var auction = buildPredefinedAuction("O", amountOfBuyers, amountOfObjects);
            simulateBuildAuction(auction);
        }

        private static void simulateOwnAuction()
        {
            Console.WriteLine("You will create your own auction. What type of auction would you like to create?");
            Console.WriteLine(" [1] Auction inside a small warehouse.\n [2] Auction inside a big warehouse.\n [3] An online auction.");

            var auctionType = Console.ReadLine();
            chooseAuction(auctionType);
        }

        private static Auction buildPredefinedAuction(String auctionType, int amountOfBuyers, int amountOfObjects)
        {
            IAuctionBuilder builder = auctionType switch
            {
                "SW" => new ConcreteAuctionBuilderSW(),
                "BW" => new ConcreteAuctionBuilderBW(),
                _ => new ConcreteAuctionBuilderO(),
            };

            addChosenBuyers(builder, amountOfBuyers);
            addChosenObjectsOfSale(builder, amountOfObjects);
            addOwnObjectOfSale(builder, auctionType);

            var auctioneer = new Auctioneer();
            builder.addAuctioneer(auctioneer);

            return builder.getResult();
        }

        private static Auction buildOwnAuction(String auctionType)
        {
            IAuctionBuilder builder = auctionType switch
            {
                "SW" => new ConcreteAuctionBuilderSW(),
                "BW" => new ConcreteAuctionBuilderBW(),
                _ => new ConcreteAuctionBuilderO(),
            };

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            addChosenBuyers(builder, amountOfBuyers);
            addChosenObjectsOfSale(builder, amountOfObjects);
            addOwnObjectOfSale(builder, auctionType);

            var auctioneer = new Auctioneer();
            builder.addAuctioneer(auctioneer);

            return builder.getResult();
        }

        private static void addChosenBuyers(IAuctionBuilder builder, int amountOfBuyers)
        {
            Random random = new Random();
            for (int i = 1; i <= amountOfBuyers; i++) //adds  amount of buyers to the auction
            {
                var wallet = 10000 + (random.NextDouble() * (100000 - 10000)); //add random amount of money to wallet between 10.000 and 100.000
                builder.addBuyer(new ConcreteBuyer(i, wallet)); //adds buyer to auction
            }
        }

        private static void addChosenObjectsOfSale(IAuctionBuilder builder, int amountOfObjects)
        {
            Random random = new Random();
            int[] fordMeasurments = new int[3] { 200, 150, 140 };
            int[] yamahaMeasurments = new int[3] { 200, 150, 140 };
            int[] suzukiMeasurments = new int[3] { 200, 150, 140 };
            int[] playstationMeasurements = new int[3] { 30, 30, 10 };
            int[] smartphoneMeasurements = new int[3] { 5, 15, 2 };
            int[] televisionMeasurements = new int[3] { 60, 50, 10 };
            int[] computerMeasurements = new int[3] { 50, 90, 30 };
            int[] headphoneMeasurements = new int[3] { 20, 20, 10 };

            for (int i = 0; i < amountOfObjects; i++)
            {
                var randomInt = random.Next(1, 8);
                ObjectOfSale objectToSell = randomInt switch
                {
                    1 => new Car("Ford", fordMeasurments, 5000.00),
                    2 => new Ship("Yamaha", yamahaMeasurments, 25000.00),
                    3 => new Motorcycle("Suzuki", suzukiMeasurments, 2500.00),
                    4 => new GameConsole("Playstation 4", playstationMeasurements, 250.00),
                    5 => new Smartphone("Xiaomi", smartphoneMeasurements, 150.00),
                    6 => new Television("Salora", televisionMeasurements, 100.00),
                    7 => new Computer("HP", computerMeasurements, 600.00),
                    //randomInt === 8
                    _ => new Headphone("Sony", headphoneMeasurements, 250.00),
                };
                builder.addObjectOfSale(objectToSell);
            }

            if (builder.getResult().getObjectsOfSale().Count == 0)
            {
                Console.WriteLine("No random object added to list");
                if (builder.getResult().getAuctionType() == "Big warehouse auction")
                {
                    builder.addObjectOfSale(new Car("Ford", fordMeasurments, 5000.00));
                    return;
                }

                builder.addObjectOfSale(new GameConsole("Playstation 4", playstationMeasurements, 250.00));
            }
        }

        private static void addOwnObjectOfSale(IAuctionBuilder builder, String auctionType)
        {
            Console.WriteLine("Would you like to add an(other) object that will be sold at this auction?\n [yes] Add an object to the list\n [no] Do not add an object to the list.");
            var answer = Console.ReadLine();

            if (answer == "yes")
            {
                switch (auctionType)
                {
                    case "SW":
                        Console.WriteLine("The small warehouse offers space for objects that are smaller than 100 centimeter for all dimentions (width, height and length).");
                        break;
                    case "BW":
                        Console.WriteLine("The big warehouse offers space for objects that are bigger than 100 centimeter for all dimentions (width, height and length).");
                        break;
                    default:
                        Console.WriteLine("The online auction allows for objects to be sold no matter their dimensions.");
                        break;
                }

                var createdObject = askObjectToAdd();
                builder.addObjectOfSale(createdObject);
                addOwnObjectOfSale(builder, auctionType);
            }
        }

        private static ObjectOfSale askObjectToAdd()
        {
            Console.WriteLine("What for object do you want to add to the list of objects that will be sold at this auction?");
            Console.WriteLine("You can pick between:\n [1] Car\n [2] Ship\n [3] Motorcycle\n [4] Gameconsole\n [5] Smartphone\n [6] Television\n [7] Computer\n [8] Headphones");

            var chosenObject = checkChosenObjectOfSale();
            Console.WriteLine("Please specify the brand of your {0}", chosenObject);
            var brand = Console.ReadLine();

            var estimatedValue = checkEstimatedValueOfOOS();
            Console.WriteLine("Your given estimated value is {0}", estimatedValue);

            var chosenObjectMeasurements = checkChosenOOSMeasurements();

            var createdObject = createChosenObject(chosenObject, brand, chosenObjectMeasurements, estimatedValue);
            return createdObject;
        }

        private static ObjectOfSale createChosenObject(String chosenObject, String brand, int[] measurements, double estimatedValue)
        {
            ObjectOfSale objectOfSale = chosenObject switch
            {
                "car" => new Car(brand, measurements, estimatedValue),
                "ship" => new Ship(brand, measurements, estimatedValue),
                "motorcycle" => new Motorcycle(brand, measurements, estimatedValue),
                "gameconsole" => new GameConsole(brand, measurements, estimatedValue),
                "smartphone" => new Smartphone(brand, measurements, estimatedValue),
                "television" => new Television(brand, measurements, estimatedValue),
                "computer" => new Computer(brand, measurements, estimatedValue),
                _ => new Headphone(brand, measurements, estimatedValue),
            };

            return objectOfSale;
        }

        private static int askAmountOfBuyers()
        {
            Console.WriteLine("Please fill in a number of the amount of different buyers walking around the auction.\nThe minimum amount is 2 and the maximum is 25.");
            var amountOfBuyers = checkAmountOfBuyers();
            Console.WriteLine("The chosen amount of buyers are {0}", amountOfBuyers);

            return amountOfBuyers;
        }

        private static int askAmountOfObjects()
        {
            Console.WriteLine("Please fill in a number of the amount of different random objects this auction could possibly sell.\nThe minimum amount is 1 and the maximum is 30.");
            var amountOfObjects = checkAmountOfObjectsToSell();
            Console.WriteLine("The chosen amount of objects to sell are {0}", amountOfObjects);

            return amountOfObjects;
        }

        private static int checkAmountOfBuyers()
        {
            int amountOfBuyers;
            do
            {
                do
                {
                    var amountOfBuyersInput = Console.ReadLine();

                    if (!int.TryParse(amountOfBuyersInput, out amountOfBuyers))
                        Console.WriteLine("Sorry, the given input is not a number. Please try again.");
                }
                while (amountOfBuyers == 0);

                if (amountOfBuyers != 0 && (amountOfBuyers < 2 || amountOfBuyers > 25))
                    Console.WriteLine("Sorry, this number is out of bounds. Please make sure to pick a number between 2 and 25.");
            }
            while (amountOfBuyers < 2 || amountOfBuyers > 25);

            return amountOfBuyers;
        }

        private static int checkAmountOfObjectsToSell()
        {
            int amountOfObjects;
            do
            {
                do
                {
                    var amountOfObjectsInput = Console.ReadLine();

                    if (!int.TryParse(amountOfObjectsInput, out amountOfObjects))
                        Console.WriteLine("Sorry, the given input is not a number. Please try again.");
                }
                while (amountOfObjects == 0);

                if (amountOfObjects != 0 && amountOfObjects > 30)
                    Console.WriteLine("Sorry, this number is out of bounds. Please make sure to pick a number lower then 31.");
            }
            while (amountOfObjects > 30);

            return amountOfObjects;
        }

        private static double checkEstimatedValueOfOOS()
        {
            double estimatedValue;

            do
            {
                Console.WriteLine("Please fill in the price you estimate your object is worth.");
                Console.WriteLine("The price can be 2 digits after the dot. For example: 1,23. 0 is not allowed.");
                Console.WriteLine("When filling in cents, make sure to use a ',' (comma) and not a '.' (dot).");

                var input = Console.ReadLine();

                if (!double.TryParse(input, out estimatedValue))
                    Console.WriteLine("Sorry, the given input is not a number. Please try again.");
            }
            while (estimatedValue == 0);

            return estimatedValue;
        }

        private static String checkChosenObjectOfSale()
        {
            String chosenObject = null;

            do
            {
                var input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "car":
                        chosenObject = "car";
                        break;
                    case "2":
                    case "ship":
                        chosenObject = "ship";
                        break;
                    case "3":
                    case "motorcycle":
                        chosenObject = "motorcycle";
                        break;
                    case "4":
                    case "gameconsole":
                        chosenObject = "gameconsole";
                        break;
                    case "5":
                    case "smartphone":
                        chosenObject = "smartphone";
                        break;
                    case "6":
                    case "television":
                        chosenObject = "television";
                        break;
                    case "7":
                    case "computer":
                        chosenObject = "computer";
                        break;
                    case "8":
                    case "headphones":
                        chosenObject = "headphones";
                        break;
                    default:
                        Console.WriteLine("The input is not an option. Please select a correct option.");
                        Console.WriteLine("You can pick between:\n [1] Car\n [2] Ship\n [3] Motorcycle\n [4] Gameconsole\n [5] Smartphone\n [6] Television\n [7] Computer\n [8] Headphones");
                        break;
                }
            }
            while (null == chosenObject);

            return chosenObject;
        }

        private static int[] checkChosenOOSMeasurements()
        {
            int length, width, height;
            int[] measurements = new int[3];

            do
            {
                Console.WriteLine("Please fill in de width of your chosen object in centimeters.");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out width))
                    Console.WriteLine("Sorry, the given input is not a number. Please try again.");
            }
            while (width == 0);

            do
            {
                Console.WriteLine("Please fill in de height of your chosen object in centimeters.");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out height))
                    Console.WriteLine("Sorry, the given input is not a number. Please try again.");
            }
            while (height == 0);

            do
            {
                Console.WriteLine("Please fill in de length of your chosen object in centimeters.");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out length))
                    Console.WriteLine("Sorry, the given input is not a number. Please try again.");
            }
            while (length == 0);

            measurements[0] = width;
            measurements[1] = height;
            measurements[2] = length;

            Console.WriteLine("width: {0}, height: {1}, length: {2}", measurements[0], measurements[1], measurements[2]);

            return measurements;
        }
    }
}
