using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    class ConcreteAuctionBuilderO : IAuctionBuilder
    {
        private Auction result;

        public ConcreteAuctionBuilderO()
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
            this.result.addObjectOfSale(objectOfSale);
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
            this.result.setAuctionType("Online auction");
        }
    }
}
