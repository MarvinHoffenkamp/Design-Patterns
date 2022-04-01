using System;
using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    class ConcreteAuctionBuilderBW : IAuctionBuilder
    {
        private Auction result;

        public ConcreteAuctionBuilderBW()
        {
            result = new Auction();
            setAuctionType();
        }

        public void addAuctioneer(Auctioneer auctioneer)
        {
            result.setAuctioneer(auctioneer);
        }

        public void addBuyer(IBuyer buyer)
        {
            result.addBuyer(buyer);
            Console.WriteLine("Buyer with number {0} started walking around the auction.", buyer.getBuyersNumber());
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            int[] measurements = objectOfSale.getMeasurements();
            int width = measurements[0];
            int height = measurements[1];
            int length = measurements[2];

            //only allow objects bigger then 1 meter to be sold in a big warehouse
            if (width <= 100 || height <= 100 || length <= 100)
            {
                Console.WriteLine("{0} {1} is to small to be sold in this auction.", objectOfSale.getBrand(), objectOfSale.GetType().Name);
                return;
            }

            result.addObjectOfSale(objectOfSale);
            Console.WriteLine("Added {0} {1} to the auction list.", objectOfSale.getBrand(), objectOfSale.GetType().Name);
        }

        public void reset()
        {
            result = new Auction();
        }

        public Auction getResult()
        {
            return result;
        }

        private void setAuctionType()
        {
            result.setAuctionType("Big warehouse auction");
        }
    }
}
