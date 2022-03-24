using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    class ConcreteAuctionBuilderBW : IAuctionBuilder
    {
        private Auction result;

        public ConcreteAuctionBuilderBW()
        {
            this.result = new Auction();
        }

        public void addAuctioneer(Auctioneer auctioneer)
        {
            this.result.setAuctioneer(auctioneer);
        }

        public void addBuyer(String buyer)
        {
            this.result.addBuyer(buyer);
            Console.WriteLine("Buyer with number {0} started walking around the auction.", buyer/*.buyersNumber*/);
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            int[] measurements = objectOfSale.getMeasurements();
            int width = measurements[0];
            int height = measurements[1];
            int length = measurements[2];

            if (width <= 100 || height <= 100 || length <= 100)
            {
                Console.WriteLine("{0} is to small to be sold in this warehouse.", objectOfSale.getBrand());
                return;
            }

            this.result.addObjectOfSale(objectOfSale);
            Console.WriteLine("Added {0} to the auction list.", objectOfSale.getBrand());
        }

        public void reset()
        {
            this.result = new Auction();
        }

        public Auction getResult()
        {
            return this.result;
        }

        public void setAuctionType()
        {
            this.result.setAuctionType("Big warehouse auction");
        }
    }
}
