﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;
using Veiling.ObjectsOfSale;
using Veiling.States;

namespace Veiling
{
    class Auctioneer
    {
        /*
         * TODO: methods nu void, graag veranderen naar juiste return types wanneer mogelijk
         */
        private State state;
        private ObjectOfSale objectOfSale;
        private double currentBid;
        private double lastBid;
        private List<IBuyer> buyers;
        private Auction auction;
        private bool startAuctinoFinished;
        private bool auctionInProgressFinished;
        private bool endAuctionFinished;
        private int startBidPercentage;

        public Auctioneer()
        {
            this.currentBid = 0.00;
            this.lastBid = 0.00;
            this.buyers = new List<IBuyer>();
            this.objectOfSale = null;
            this.auction = null;
            this.startAuctinoFinished = false;
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
            return this.currentBid;
        }

        public void getMoney()
        {
            var highestbid = this.getCurrentBid();
            foreach (IBuyer buyer in this.getBuyers())
            {
                if (buyer.getDoneBid() == highestbid)
                {
                    buyer.setWallet(buyer.getWallet() - highestbid);
                    break;
                }
            }
            Console.WriteLine("Wallet subtracted!");
        }

        public void setCurrentBid(double newCurrentBid)
        {
            currentBid = newCurrentBid;
        }

        public ObjectOfSale getObjectOfSale()
        {
            return this.objectOfSale;
        }

        public void setObjectOfSale(ObjectOfSale objectOfSale)
        {
            this.objectOfSale = objectOfSale;
        }

        public void setObjectsOfSale(List<ObjectOfSale> ObjectsOfSale)
        {
            this.auction.setObjectsOfSale(ObjectsOfSale);
        }

        public List<IBuyer> getBuyers()
        {
            return this.buyers;
        }

        public void addBuyer(IBuyer buyer)
        {
            buyer.setAuctioneer(this);
            this.buyers.Add(buyer);
        }

        public void setBuyers(List<IBuyer> newBuyers)
        {
            List<IBuyer> buyersWithAuctioneer = new List<IBuyer>();
            foreach (IBuyer buyer in buyers)
            {
                buyer.setAuctioneer(this);
                buyersWithAuctioneer.Add(buyer);
            }
            buyers = buyersWithAuctioneer;
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine("Changing state to {0}", state.GetType().Name);
            //get current state, then check
            if (this.state == null)
            {
                state.runState();
            }
            else if (this.state.GetType().Name == "StartAuction")
            {
                if (state.GetType().Name == "AuctionInProgress")
                {
                    state.runState();
                }
            }
            else if (this.state.GetType().Name == "AuctionInProgress")
            {
                if (state.GetType().Name == "EndAuction")
                {
                    state.runState();
                }
            }
            else if (state.GetType().Name == "StartAuction")
            {
                state.runState();
            }
            else if (this.state.GetType().Name == "EndAuction")
            {
                this.state = null;
                Console.WriteLine("Changed state to idle");
            }
        }

        public State getState()
        {
            return this.state;
        }

        public void setState(State newState)
        {
            this.state = newState;
        }
        
        public Auction getAuction()
        {
            return this.auction;
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
                buyer.bid(getCurrentBid());
            }

            Console.WriteLine("The current bid is: {0}", getCurrentBid());
        }

        public void notifiedByBuyer(double bid)
        {
            setCurrentBid(bid);
            notifyBuyers();

            Timer lastBidCheckTimer = new Timer();
            lastBidCheckTimer.Elapsed += new ElapsedEventHandler(lastBidCheck);
            lastBidCheckTimer.Interval = 30000;
            lastBidCheckTimer.Enabled = true;
        }

        private void lastBidCheck(object source, ElapsedEventArgs e)
        {
            if (lastBid == getCurrentBid())
            {
                Console.WriteLine("Sold!");
                getMoney();
                setAuctionInProgressFinished(true);
            }
        }

        public double getLastBid()
        {
            return this.lastBid;
        }

        public void setLastBid(double lastBid)
        {
            this.lastBid = lastBid;
        }

        public bool getStartAuctionFinished()
        {
            return this.startAuctinoFinished;
        }

        public void setStartAuctionFinished(bool finished)
        {
            this.startAuctinoFinished = finished;
        }

        public bool getAuctionInProgressFinished()
        {
            return this.auctionInProgressFinished;
        }

        public void setAuctionInProgressFinished(bool finished)
        {
            this.auctionInProgressFinished = finished;
        }

        public bool getEndAuctionFinished()
        {
            return this.endAuctionFinished;
        }
        public void setEndAuctionFinished(bool finished)
        {
            this.endAuctionFinished = finished;
        }

        public int getStartBidPercentage()
        {
            return this.startBidPercentage;
        }

        public int generateStartBidPercentage()
        {
            //Start bid can be between 10 - 70% of the estemated value
            Random startBidPercentage = new Random();
            return startBidPercentage.Next(10, 70);
        }
    }
}
