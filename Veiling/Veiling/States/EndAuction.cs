using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class EndAuction : State
    {
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
            Console.WriteLine("object moved!");
        }

        public override void setAuctionState(State state)
        {
            this.auctioneer.TransitionTo(state);
            Console.WriteLine("auction state set!");
        }
    }
}
