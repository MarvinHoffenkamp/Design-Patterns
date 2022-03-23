using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    interface IAuctionBuilder
    {
        void reset();
        void addAuctioneer(Auctioneer auctioneer);
        void addBuyer(String buyer);
        void addObjectOfSale(ObjectOfSale objectsOfSale);
        void setAuctionType();
        Auction getResult();
    }
}
