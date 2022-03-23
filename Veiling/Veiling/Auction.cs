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
        //TODO change datatype to Buyer
        private List<String> buyers;
        private String auctionType;

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

        public void setBuyers(List<String> buyers)
        {
            this.buyers = buyers;
        }

        public List<String> getBuyers()
        {
            return this.buyers;
        }

        public void addBuyer(String buyer)
        {
            this.buyers.Add(buyer);
        }

        public void setAuctionType(String type)
        {
            this.auctionType = type;
        }

        public String getAuctionType()
        {
            return this.auctionType;
        }
    }
}
