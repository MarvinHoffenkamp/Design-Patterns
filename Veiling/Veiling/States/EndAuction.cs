using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class EndAuction : State
    {
        public EndAuction(Auctioneer auctioneer) : base(auctioneer)
        {

        }

        //todo find out highest bid and move object to there
        public override void moveObjectOfSale()
        {
            var highestbid = auctioneer.getCurrentBid();
            foreach(IBuyer buyer in auctioneer.getBuyers())
            {
                if(buyer.getDoneBid() == highestbid)
                {
                    buyer.addBoughtObject(auctioneer.getObjectOfSale());
                    break;
                }
            }
            Console.WriteLine("Object moved to buyer");
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
