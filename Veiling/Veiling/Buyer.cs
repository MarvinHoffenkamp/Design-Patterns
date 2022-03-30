using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling
{
    interface Buyer
    {
        void bid(double price);
        void doBid();
        int getBuyersNumber();
        void setAuctioneer(Auctioneer auctioneer);
    }
}
