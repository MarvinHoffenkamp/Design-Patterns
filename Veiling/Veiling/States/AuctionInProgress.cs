using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class AuctionInProgress : State
    {
        /*implement notify stuff TODO*/
        public override void moveObjectOfSale()
        {
            this.auctioneer.notifyBuyers();
            Console.WriteLine("nothing moved between switching states from start to inProgress!");
        }

        public override void setAuctionState(State state)
        {
            Console.WriteLine("auction state set!");
            this.auctioneer.TransitionTo(state);
        }
    }
}
