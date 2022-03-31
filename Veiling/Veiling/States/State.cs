using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    abstract class State
    {
        protected Auctioneer auctioneer;

        public void setContext(Auctioneer auctioneer)
        {
            this.auctioneer = auctioneer;
        }
        public abstract void moveObjectOfSale();
        public abstract void setAuctionState(State state);
    }
}
