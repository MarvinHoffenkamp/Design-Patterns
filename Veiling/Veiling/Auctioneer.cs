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

        public Auctioneer(State state, ObjectOfSale objectOfSale, double currentBid, Buyer[] buyers)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine("changing state to {0}", state);
            this.state = state;
            this.state.setContext(this);
        }

        public void moveObjectOfSale(ObjectOfSale objectOfSale)
        {

        }

        public void setAuctionState()
        {

        }

        public void joinAuction()
        {

        }

        public void leaveAuction()
        {

        }

        public void notifyBuyers()
        {

        }
    }

}
