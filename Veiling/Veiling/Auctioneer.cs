﻿using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;
using Veiling.States;

namespace Veiling
{
    class Auctioneer
    {
        /*
         * TODO: methods nu void, graag veranderen naar juiste return types wanneer mogelijk
         */
        private State state = null;
        private ObjectOfSale objectOfSale;
        private double currentBid;
        private double lastBid;
        private List<IBuyer> buyers;
        private Auction auction;
        private bool startAuctinoFinished;
        private bool auctionInProgressFinished;
        private bool endAuctionFinished;

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
        }

        public void setAuction(Auction auction)
        {
            this.auction = auction;
        }

        public double getCurrentBid()
        {
            return this.currentBid;
        }

        public void setCurrentBid(double newCurrentBid)
        {
            currentBid = newCurrentBid;
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
                this.state = state;
                Console.WriteLine("Changed state to {0}", this.state.GetType().Name);
            }
            else if (this.state.GetType().Name == "StartAuction")
            {
                if (state.GetType().Name == "AuctionInProgress")
                {
                    this.state = state;
                    Console.WriteLine("Changed state to {0}", this.state.GetType().Name);
                }
            }
            else if (this.state.GetType().Name == "AuctionInProgress")
            {
                if (state.GetType().Name == "EndAuction")
                {
                    this.state = state;
                    Console.WriteLine("Changed state to {0}", this.state.GetType().Name);
                }
            }
            else if (state.GetType().Name == "StartAuction")
            {
                //assume state is EndAuction, hence only check if incoming state is StartAuction
                this.state = state;
                Console.WriteLine("Changed state to {0}", this.state.GetType().Name);
            }
            else if (this.state.GetType().Name == "EndAuction")
            {
                this.state = null;
                Console.WriteLine("Changed state to {0}", this.state.GetType().Name);
            }
            this.state.setContext(this);
        }

        public void moveObjectOfSale(ObjectOfSale objectOfSale)
        {
            
        }

        public void setAuctionState()
        {

        }

        public ObjectOfSale getObjectOfSale()
        {
            return this.objectOfSale;
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
                buyer.bid(getCurrentBid());
            }
        }

        public void notifiedByBuyer(double bid)
        {
            setCurrentBid(bid);
            notifyBuyers();
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
    }
}
