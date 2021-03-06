using System;
using System.Collections.Generic;
using Veiling.ObjectsOfSale;
using Veiling.States;

namespace Veiling
{
    class Auctioneer
    {
        private State state;
        private ObjectOfSale objectOfSale;
        private double currentBid;
        private List<IBuyer> buyers;
        private Auction auction;
        private bool startAuctionFinished;
        private bool auctionInProgressFinished;
        private bool endAuctionFinished;
        private double startBidPercentage;
        private int buyersNumberOfLastBid = 0;

        public Auctioneer()
        {
            this.currentBid = 0.00;
            this.buyers = new List<IBuyer>();
            this.objectOfSale = null;
            this.auction = null;
            this.startAuctionFinished = false;
            this.auctionInProgressFinished = false;
            this.endAuctionFinished = false;
            this.state = null;
            this.startBidPercentage = generateStartBidPercentage();
        }

        public void setAuction(Auction auction)
        {
            this.auction = auction;
        }

        public double getCurrentBid()
        {
            return currentBid;
        }

        public void getMoney()
        {
            double highestbid = getCurrentBid();
            double subtractedAmount = 0;
            foreach (IBuyer buyer in getBuyers())
            {
                if (buyer.getBuyersBid() == highestbid)
                {
                    subtractedAmount = buyer.getWallet() - highestbid;
                    buyer.setWallet(subtractedAmount);
                    break;
                }
            }
            Console.WriteLine("Subtracted {0} from the wallet.", subtractedAmount);
        }

        public void setCurrentBid(double newCurrentBid)
        {
            currentBid = newCurrentBid;
        }

        public ObjectOfSale getObjectOfSale()
        {
            return objectOfSale;
        }

        public void setObjectOfSale(ObjectOfSale objectOfSale)
        {
            this.objectOfSale = objectOfSale;
        }

        public void setObjectsOfSale(List<ObjectOfSale> ObjectsOfSale)
        {
            auction.setObjectsOfSale(ObjectsOfSale);
        }

        public List<IBuyer> getBuyers()
        {
            return buyers;
        }

        public void addBuyer(IBuyer buyer)
        {
            buyer.setAuctioneer(this);
            buyers.Add(buyer);
        }

        public void setBuyers(List<IBuyer> newBuyers)
        {
            List<IBuyer> buyersWithAuctioneer = new List<IBuyer>();
            foreach (IBuyer buyer in newBuyers)
            {
                buyer.setAuctioneer(this);
                buyersWithAuctioneer.Add(buyer);
            }
            buyers = buyersWithAuctioneer;
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine("Changing state to {0}", state.GetType().Name);
            state.runState();
        }

        public State getState()
        {
            return state;
        }

        public void setState(State newState)
        {
            state = newState;
        }
        
        public Auction getAuction()
        {
            return auction;
        }

        public void joinAuction(IBuyer joiningBuyer)
        {
            addBuyer(joiningBuyer);
        }

        public void leaveAuction(IBuyer leavingBuyer)
        {
            getBuyers().Remove(leavingBuyer);
        }

        public void notifyBuyers()
        {
            foreach (IBuyer buyer in getBuyers())
            {
                double current = getCurrentBid();
                buyer.bid(current);

                if (current != getCurrentBid())
                {
                    Console.WriteLine("The current bid is: {0}", getCurrentBid());
                    setBuyersNumberOfLastBid(buyer.getBuyersNumber());
                }
            }

            lastBidCheck();
        }

        public void notifiedByBuyer(double bid)
        {
            setCurrentBid(bid);
        }

        private void lastBidCheck()
        {
            var buyer = getBuyers()[getBuyersNumberOfLastBid() - 1];
            if (buyer.getBuyersBid() == getCurrentBid())
            {
                Console.WriteLine("Sold to the buyer with number {0}", getBuyersNumberOfLastBid());
                Console.WriteLine("The object of sale has been sold for: {0}", getCurrentBid());
                getMoney();
                setAuctionInProgressFinished(true);
            }
        }

        public bool getStartAuctionFinished()
        {
            return startAuctionFinished;
        }

        public void setStartAuctionFinished(bool finished)
        {
            startAuctionFinished = finished;
        }

        public bool getAuctionInProgressFinished()
        {
            return auctionInProgressFinished;
        }

        public void setAuctionInProgressFinished(bool finished)
        {
            auctionInProgressFinished = finished;
        }

        public bool getEndAuctionFinished()
        {
            return endAuctionFinished;
        }
        public void setEndAuctionFinished(bool finished)
        {
            endAuctionFinished = finished;
        }

        public double getStartBidPercentage()
        {
            return startBidPercentage;
        }

        public int generateStartBidPercentage()
        {
            //Start bid can be between 10 - 70% of the estemated value
            Random startBidPercentage = new Random();
            return startBidPercentage.Next(10, 70);
        }

        public int getBuyersNumberOfLastBid()
        {
            return buyersNumberOfLastBid;
        }

        public void setBuyersNumberOfLastBid(int buyersNumber)
        {
            buyersNumberOfLastBid = buyersNumber;
        }
    }
}
