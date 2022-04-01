using System;
using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    class ConcreteAuctionBuilderO : IAuctionBuilder
    {
        private Auction result;

        public ConcreteAuctionBuilderO()
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
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            result.addObjectOfSale(objectOfSale);
            Console.WriteLine("Added {0} {1} to the auction list.", objectOfSale.getBrand(), objectOfSale.GetType().Name); //allow all objects to be sold online
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
            result.setAuctionType("Online auction");
        }
    }
}
