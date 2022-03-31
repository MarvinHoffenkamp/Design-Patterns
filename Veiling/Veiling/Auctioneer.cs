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
        private double currentBid;
        private double lastBid;
        private List<Buyer> buyers;

        public Auctioneer(State state)
        {
            this.TransitionTo(state);
            this.currentBid = 0.00;
            this.lastBid = 0.00;
            this.buyers = new List<buyers>;
        }

        public double getCurrentBid()
        {
            return this.currentBid;
        }

        public void setCurrentBid(double newCurrentBid)
        {
            currentBid = newCurrentBid;
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
            Console.WriteLine("changing state to {0}", state.GetType().Name);
            this.state = state;
            this.state.setContext(this);
        }

        public void moveObjectOfSale(ObjectOfSale objectOfSale)
        {

        }

        public void setAuctionState()
        {

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
