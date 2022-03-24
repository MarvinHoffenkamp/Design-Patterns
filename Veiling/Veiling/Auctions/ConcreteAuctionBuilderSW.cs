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
        }

        public void addAuctioneer(Auctioneer auctioneer)
        {
            this.result.setAuctioneer(auctioneer);
        }

        public void addBuyer(String buyer)
        {
            this.result.addBuyer(buyer);
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            int[] measurements = objectOfSale.getMeasurements();
            //TODO make condition to only add small objects
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
            this.result.setAuctionType("Small warehouse auction");
        }
    }
}
