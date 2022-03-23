using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    class StartAuction : State
    {
        public StartAuction(Auctioneer auctioneer)
        {

        }
        public void moveObjectOfSale(ObjectOfSale objectOfSale)
        {
            throw new NotImplementedException();
        }

        void State.announceActionState()
        {
            throw new NotImplementedException();
        }
    }
}
