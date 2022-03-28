using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class AuctionInProgress : State
    {
        public override void moveObjectOfSale(ObjectOfSale objectOfSale)
        {
            Console.WriteLine("object moved!");
        }

        public override void setAuctionState(State state)
        {
            Console.WriteLine("auction state set!");
            this.auctioneer.TransitionTo(state);
        }
    }
}
