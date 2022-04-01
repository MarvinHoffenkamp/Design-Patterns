using System.Collections.Generic;
using Veiling.ObjectsOfSale;

namespace Veiling
{
    class Auction
    {
        private Auctioneer auctioneer;
        private List<ObjectOfSale> objectsOfSale;
        private List<IBuyer> buyers;
        private string auctionType;

        public Auction()
        {
            this.objectsOfSale = new List<ObjectOfSale>();
            this.buyers = new List<IBuyer>();
        }

        public void setAuctioneer(Auctioneer auctioneer)
        {
            this.auctioneer = auctioneer;
        }

        public Auctioneer getAuctioneer()
        {
            return auctioneer;
        }

        public void setObjectsOfSale(List<ObjectOfSale> objectsOfSale)
        {
            this.objectsOfSale = objectsOfSale;
        }

        public List<ObjectOfSale> getObjectsOfSale()
        {
            return objectsOfSale;
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            objectsOfSale.Add(objectOfSale);
        }

        public void setBuyers(List<IBuyer> buyers)
        {
            this.buyers = buyers;
        }

        public List<IBuyer> getBuyers()
        {
            return buyers;
        }

        public void addBuyer(IBuyer buyer)
        {
            buyers.Add(buyer);
        }

        public void setAuctionType(string type)
        {
            auctionType = type;
        }

        public string getAuctionType()
        {
            return auctionType;
        }
    }
}
