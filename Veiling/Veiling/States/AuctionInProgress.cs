using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class AuctionInProgress : State
    {
        public AuctionInProgress(Auctioneer auctioneer) : base(auctioneer)
        {

        }

        /*implement notify stuff TODO*/
        public override void moveObjectOfSale()
        {
            this.auctioneer.notifyBuyers();
            Console.WriteLine("Auctioneer is keeping the auction in progress");
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
