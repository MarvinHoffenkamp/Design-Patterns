using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling.Auctions
{
    interface IAuctionBuilder
    {
        void reset();
        void addAuctioneer();
        void addBuyer();
        void addObjectOfSale();
    }
}
