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
        }

        public override void runState()
        {
            moveObjectOfSale();
            auctioneer.setCurrentBid(auctioneer.getObjectOfSale().getEstimatedValue() * (auctioneer.getStartBidPercentage() / 100));
            Console.WriteLine("The auction will start soon with the selling of the next object: {0} {1}", auctioneer.getObjectOfSale().getBrand(), auctioneer.getObjectOfSale().GetType().Name);
            Console.WriteLine("The auction has started with the current bid: {0}", auctioneer.getCurrentBid());
            auctioneer.setState(this);
            auctioneer.setStartAuctionFinished(true);
        }
    }
}
