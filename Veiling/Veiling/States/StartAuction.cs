using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class StartAuction : State
    {
        public override void moveObjectOfSale()
        {
            var OOS = this.auctioneer.getAuction().getObjectsOfSale();
            var firstOOS = OOS[0];
            OOS.RemoveAt(0);
            this.auctioneer.setObjectOfSale(firstOOS);
            this.auctioneer.setObjectsOfSale(OOS);
        }

        public override void setAuctionState(State state)
        {
            Console.WriteLine("auction state set!");
            this.auctioneer.TransitionTo(state);
        }
    }
}
