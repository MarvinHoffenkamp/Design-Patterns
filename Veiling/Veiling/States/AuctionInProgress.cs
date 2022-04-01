using System;

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
            Console.WriteLine("Auctioneer is keeping the auction in progress");
        }

        public override void runState()
        {
            auctioneer.setState(this);
            Console.WriteLine("Changed state to {0}", this.GetType().Name);
            auctioneer.notifyBuyers();
            //Set finished bool in auctioneer
        }
    }
}
