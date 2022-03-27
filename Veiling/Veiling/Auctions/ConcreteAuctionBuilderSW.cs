using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    class ConcreteAuctionBuilderSW : IAuctionBuilder
    {
        private Auction result;

        public ConcreteAuctionBuilderSW()
        {
            this.result = new Auction();
            this.setAuctionType();
        }

        public void addAuctioneer(Auctioneer auctioneer)
        {
            this.result.setAuctioneer(auctioneer);
        }

        public void addBuyer(Buyer buyer)
        {
            this.result.addBuyer(buyer);
            Console.WriteLine("Buyer with number {0} started walking around the auction.", buyer.getBuyersNumber());
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            int[] measurements = objectOfSale.getMeasurements();
            int width = measurements[0];
            int height = measurements[1];
            int length = measurements[2];

            //only allow objects smaller then 1 meter to be sold in a small warehouse
            if (width >= 100 || height >= 100 || length >= 100)
            {
                Console.WriteLine("{0} is to big to be sold in this auction.", objectOfSale.GetType().Name);
                return;
            }

            this.result.addObjectOfSale(objectOfSale);
            Console.WriteLine("Added {0} to the auction list.", objectOfSale.GetType().Name);
        }

        public void reset()
        {
            this.result = new Auction();
        }

        public Auction getResult()
        {
            return this.result;
        }

        private void setAuctionType()
        {
            this.result.setAuctionType("Small warehouse auction");
        }
    }
}
