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
            auctioneer.notifyBuyers();
            Console.WriteLine("Auctioneer is keeping the auction in progress");
        }

        public override void runState()
        {
            moveObjectOfSale();
            auctioneer.setState(this);
            auctioneer.setStartAuctionFinished(true);
            Console.WriteLine("Changed state to {0}", GetType().Name);
        }
    }
}
