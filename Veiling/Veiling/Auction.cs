using System;
using System.Collections.Generic;
using System.Text;
using Veiling.Auctions;
using Veiling.ObjectsOfSale;

namespace Veiling
{
    class Auction
    {
        private Auctioneer auctioneer;
        private List<ObjectOfSale> objectsOfSale;
        private List<Buyer> buyers;
        private string auctionType;

        public Auction()
        {
            this.objectsOfSale = new List<ObjectOfSale>();
            this.buyers = new List<Buyer>();
        }

        public void setAuctioneer(Auctioneer auctioneer)
        {
            this.auctioneer = auctioneer;
        }

        public Auctioneer getAuctioneer()
        {
            return this.auctioneer;
        }

        public void setObjectsOfSale(List<ObjectOfSale> objectsOfSale)
        {
            this.objectsOfSale = objectsOfSale;
        }

        public List<ObjectOfSale> getObjectsOfSale()
        {
            return this.objectsOfSale;
        }

        public void addObjectOfSale(ObjectOfSale objectOfSale)
        {
            this.objectsOfSale.Add(objectOfSale);
        }

        public void setBuyers(List<Buyer> buyers)
        {
            this.buyers = buyers;
        }

        public List<Buyer> getBuyers()
        {
            return this.buyers;
        }

        public void addBuyer(Buyer buyer)
        {
            this.buyers.Add(buyer);
        }

        public void setAuctionType(string type)
        {
            this.auctionType = type;
        }

        public string getAuctionType()
        {
            return this.auctionType;
        }
    }
}
