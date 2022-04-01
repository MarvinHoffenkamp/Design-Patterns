using System;
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
        private List<Buyer> buyers;
        private Auction auction;

        public Auctioneer(State state)
        {
            this.TransitionTo(state);
            this.currentBid = 0.00;
            this.lastBid = 0.00;
            this.buyers = new List<Buyer>();
            this.objectOfSale = null;
            this.auction = null;
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
            foreach (Buyer buyer in this.getBuyers())
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

        public void setObjectOfSale(ObjectOfSale objectOfSale)
        {
            this.objectOfSale = objectOfSale;
        }

        public void setObjectsOfSale(List<ObjectOfSale> ObjectsOfSale)
        {
            this.auction.setObjectsOfSale(ObjectsOfSale);
        }

        public List<Buyer> getBuyers()
        {
            return this.buyers;
        }

        public void addBuyer(Buyer buyer)
        {
            buyer.setAuctioneer(this);
            this.buyers.Add(buyer);
        }

        public void setBuyers(List<Buyer> newBuyers)
        {
            List<Buyer> buyersWithAuctioneer = new List<Buyer>();
            foreach (Buyer buyer in buyers)
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

        public void joinAuction(Buyer joiningBuyer)
        {
            addBuyer(joiningBuyer);
        }

        public void leaveAuction(Buyer leavingBuyer)
        {
            getBuyers().Remove(leavingBuyer);
        }

        public void notifyBuyers()
        {
            foreach (Buyer buyer in getBuyers())
            {
                buyer.bid(getCurrentBid());
            }
        }

        public void notifiedByBuyer(double bid)
        {
            setCurrentBid(bid);
            notifyBuyers();
        }
    }
}
