using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class StartAuction : State
    {
        public StartAuction(Auctioneer auctioneer) : base(auctioneer)
        {
            
        }

        public override void moveObjectOfSale()
        {
            var OOS = this.auctioneer.getAuction().getObjectsOfSale();
            var firstOOS = OOS[0];
            OOS.RemoveAt(0);
            this.auctioneer.setObjectOfSale(firstOOS);
            this.auctioneer.setObjectsOfSale(OOS);
            Console.WriteLine("Object moved from auction");
        }

        public override void runState()
        {
            moveObjectOfSale();
            this.auctioneer.setState(this);
            this.auctioneer.setStartAuctionFinished(true);
            Console.WriteLine("Changed state to {0}", this.GetType().Name);
        }
    }
}
