using System.Collections.Generic;
using Veiling.ObjectsOfSale;

namespace Veiling
{
    class ConcreteBuyer : IBuyer
    {
        private int buyersNumber;
        private double wallet;
        private List<ObjectOfSale> boughtObjects;
        private double currentBid;
        private double buyersBid;
        private Auctioneer auctioneer;

        public ConcreteBuyer(int buyersNumber, double wallet)
        {
            this.buyersNumber = buyersNumber;
            this.wallet = wallet;
            boughtObjects = new List<ObjectOfSale>();
            currentBid = 0.00;
            buyersBid = 0.00;
        }

        public void bid(double price)
        {
            setCurrentBid(price);
            doBid();
        }

        public void doBid()
        {
            //Alleen een nieuw bod doen wanneer de oude niet van de buyer is en het huidige bod lager is dan de koper in de portemonee heeft
            if(currentBid != buyersBid && currentBid < wallet)
            {
                buyersBid = wallet; //Bied alles wat de buyer heeft, verander dit nog later
                getAuctioneer().notifiedByBuyer(buyersBid);
            }
        }

        public int getBuyersNumber()
        {
            return buyersNumber;
        }

        public void setBuyersNumber(int newBuyersNumber)
        {
            buyersNumber = newBuyersNumber;
        }

        public double getWallet()
        {
            return wallet;
        }

        public void setWallet(double newWallet)
        {
            wallet = newWallet;
        }

        public List<ObjectOfSale> GetBoughtObjects()
        {
            return boughtObjects;
        }

        public void addBoughtObject(ObjectOfSale newBoughtObject)
        {
            boughtObjects.Add(newBoughtObject);
        }

        public void setBoughtObjects(List<ObjectOfSale> newBoughtObjects)
        {
            boughtObjects = newBoughtObjects;
        }

        public double getCurrentBid()
        {
            return currentBid;
        }

        public void setCurrentBid(double newCurrentBid)
        {
            currentBid = newCurrentBid;
        }

        public double getDoneBid()
        {
            return buyersBid;
        }

        public void setDoneBid(double newDoneBid)
        {
            buyersBid = newDoneBid;
        }

        public void setAuctioneer(Auctioneer auctioneer)
        {
            this.auctioneer = auctioneer;
        }

        public Auctioneer getAuctioneer()
        {
            return auctioneer;
        }
    }
}
