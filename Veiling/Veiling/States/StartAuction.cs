using System;

namespace Veiling.States
{
    class StartAuction : State
    {
        public StartAuction(Auctioneer auctioneer) : base(auctioneer)
        {
            
        }

        public override void moveObjectOfSale()
        {
            var OOS = auctioneer.getAuction().getObjectsOfSale();
            var firstOOS = OOS[0];
            OOS.RemoveAt(0);
            auctioneer.setObjectOfSale(firstOOS);
            auctioneer.setObjectsOfSale(OOS);
            Console.WriteLine("Object moved from auction");
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
