using System;

namespace Veiling.States
{
    class EndAuction : State
    {
        public EndAuction(Auctioneer auctioneer) : base(auctioneer)
        {

        }

        public override void moveObjectOfSale()
        {
            var highestbid = auctioneer.getCurrentBid();
            foreach(IBuyer buyer in auctioneer.getBuyers())
            {
                if(buyer.getBuyersBid() == highestbid)
                {
                    buyer.addBoughtObject(auctioneer.getObjectOfSale());
                    break;
                }
            }
        }

        public override void runState()
        {
            moveObjectOfSale();
            auctioneer.setState(this);
            auctioneer.setEndAuctionFinished(true);
        }
    }
}
