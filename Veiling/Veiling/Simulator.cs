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
                    //simulateBigWarehouse();
                    Console.WriteLine("Not fully implemented yet.");
                    break;
                case "3":
                    //simulateOnline();
                    Console.WriteLine("Not fully implemented yet.");
                    break;
                case "4":
                    //simulateOwnAuction();
                    Console.WriteLine("Not fully implemented yet.");
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
            switch (chosenAuction)
            {
                case "1":
                    buildOwnAuction("SW");
                    break;
                case "2":
                    buildOwnAuction("BW");
                    break;
                case "3":
                    buildOwnAuction("O");
                    break;
                default:
                    Console.WriteLine("Sorry, this option does not exist. Please select an option that does.");
                    Console.WriteLine(" [1] Auction inside a small warehouse.\n [2] Auction inside a big warehouse.\n [3] An online auction.");
                    var newChosenAuction = Console.ReadLine();
                    chooseAuction(newChosenAuction);
                    break;
            }
        }

        private static void simulateSmallWarehouse()
        {
            Console.WriteLine("The small warehouse auction will be made.");

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            var auction = buildPredefinedAuction("SW", amountOfBuyers, amountOfObjects);
        }

        private static void simulateBigWarehouse()
        {
            Console.WriteLine("The big warehouse auction will be made.");

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            var auction = buildPredefinedAuction("BW", amountOfBuyers, amountOfObjects);
        }

        private static void simulateOnline()
        {
            Console.WriteLine("The online auction will be made.");

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            var auction = buildPredefinedAuction("O", amountOfBuyers, amountOfObjects);
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

            Random random = new Random();
            for (int i = 1; i <= amountOfBuyers; i++) //adds  amount of buyers to the auction
            {
                var wallet = 10000 + (random.NextDouble() * (100000 - 10000)); //add random amount of money to wallet between 10.000 and 100.000
                builder.addBuyer(new ConcreteBuyer(i, wallet)); //adds buyer to auction
            }

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

            var auctioneer = new Auctioneer(new StartAuction(), builder.getResult().getBuyers());

            builder.addAuctioneer(auctioneer);

            return builder.getResult();
        }

        private static void buildOwnAuction(String auctionType)
        {
            IAuctionBuilder builder = auctionType switch
            {
                "SW" => new ConcreteAuctionBuilderSW(),
                "BW" => new ConcreteAuctionBuilderBW(),
                _ => new ConcreteAuctionBuilderO(),
            };

            var amountOfBuyers = askAmountOfBuyers();
            var amountOfObjects = askAmountOfObjects();

            Console.WriteLine("Would you like to add an object that will be sold at this auction?\n [yes] Add an object to the list\n [no] Do not add an object to the list.");
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
            }
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
            Console.WriteLine("Please fill in a number of the amount of different random objects this auction could possibly sell.\nThe maximum is 30.");
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
    }
}
