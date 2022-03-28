using System;
using Veiling.ObjectsOfSale;
using Veiling.Auctions;
using Veiling.States;
using System.Collections.Generic;

namespace Veiling
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Testing for Factory Method
             *
            int[] fordMeasurments = new int[3] {200, 150, 140};
            Car ford = new Car("Ford", fordMeasurments, 5000.00);
            Console.WriteLine("Car: "+ ford.turnOn());

            int[] yamahaMeasurments = new int[3] { 200, 150, 140 };
            Ship yamaha = new Ship("Yamaha", yamahaMeasurments, 25000.00);
            Console.WriteLine("Ship: " + yamaha.turnOn());

            int[] suzukiMeasurments = new int[3] { 200, 150, 140 };
            Motorcycle suzuki = new Motorcycle("Suzuki", suzukiMeasurments, 2500.00);
            Console.WriteLine("Motorcycle: " + suzuki.turnOn());
            */

            //testBuilder();
            testStates();
        }

        public static void testBuilder()
        {
            Random random = new Random();
            var builder = new ConcreteAuctionBuilderSW();
            Console.WriteLine("auction type: {0}", builder.getResult().getAuctionType());

            var randomAmountOfBuyers = random.Next(2, 20);
            for (int i = 1; i <= randomAmountOfBuyers; i++) //adds random amount of buyers to the auction
            {
                var wallet = 1000 + (random.NextDouble() * (10000 - 1000)); //add random amount of money to wallet between 1000 and 10000
                builder.addBuyer(new ConcreteBuyer(i, wallet)); //adds buyer to auction
            }

            Console.WriteLine("======================================");

            int[] fordMeasurments = new int[3] { 200, 150, 140 };
            int[] yamahaMeasurments = new int[3] { 200, 150, 140 };
            int[] suzukiMeasurments = new int[3] { 200, 150, 140 };
            int[] playstationMeasurements = new int[3] { 30, 30, 10 };
            int[] smartphoneMeasurements = new int[3] { 5, 15, 2 };
            int[] televisionMeasurements = new int[3] { 60, 50, 10 };
            int[] computerMeasurements = new int[3] { 50, 90, 30 };
            int[] headphoneMeasurements = new int[3] { 20, 20, 10 };

            var randomAmountOfObjectsToSell = random.Next(1, 20);
            for (int i = 0; i < randomAmountOfObjectsToSell; i++)
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

            Console.WriteLine("======================================");

            var auction = builder.getResult();

            Console.WriteLine("Amount of buyers: {0}", auction.getBuyers().Count);
            Console.WriteLine("Amount of objects to sell: {0}", auction.getObjectsOfSale().Count);
        }

        public static void testStates()
        {
            var state1 = new StartAuction();
            var state2 = new AuctionInProgress();
            var state3 = new EndAuction();


            Random random = new Random();

            int[] fordMeasurments = new int[3] { 200, 150, 140 };
            int[] yamahaMeasurments = new int[3] { 200, 150, 140 };
            int[] suzukiMeasurments = new int[3] { 200, 150, 140 };
            int[] playstationMeasurements = new int[3] { 30, 30, 10 };
            int[] smartphoneMeasurements = new int[3] { 5, 15, 2 };
            int[] televisionMeasurements = new int[3] { 60, 50, 10 };
            int[] computerMeasurements = new int[3] { 50, 90, 30 };
            int[] headphoneMeasurements = new int[3] { 20, 20, 10 };

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

            var notReallyRandomAmountOfBuyers = 16;

            Buyer[] buyers = new Buyer[notReallyRandomAmountOfBuyers];
            for (int i = 1; i < notReallyRandomAmountOfBuyers; i++) //adds random amount of buyers to the auction
            {
                var wallet = 1000 + (random.NextDouble() * (10000 - 1000)); //add random amount of money to wallet between 1000 and 10000
                buyers[i] = new ConcreteBuyer(i, wallet); //adds buyer to auction
            };
            var auctioneer1 = new Auctioneer(state1, objectToSell, 100.00, buyers);
            auctioneer1.TransitionTo(state2);
            auctioneer1.TransitionTo(state3);
        }
    }
}
