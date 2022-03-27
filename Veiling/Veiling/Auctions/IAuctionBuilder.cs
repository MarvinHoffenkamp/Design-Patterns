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
        void addBuyer(Buyer buyer);
        void addObjectOfSale(ObjectOfSale objectsOfSale);
        Auction getResult();
    }
}
