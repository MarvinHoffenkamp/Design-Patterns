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
            this.setAuctionType();
        }

        public void addAuctioneer(Auctioneer auctioneer)
        {
            this.result.setAuctioneer(auctioneer);
        }

        public void addBuyer(IBuyer buyer)
        {
            this.result.addBuyer(buyer);
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            this.result.addObjectOfSale(objectOfSale);
            Console.WriteLine("Added {0} {1} to the auction list.", objectOfSale.getBrand(), objectOfSale.GetType().Name); //allow all objects to be sold online
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
            this.result.setAuctionType("Online auction");
        }
    }
}
