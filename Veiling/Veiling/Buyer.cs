using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling
{
    interface Buyer
    {
        void bid(double price);
        void doBid();
        int getBuyersNumber();
        void setAuctioneer(Auctioneer auctioneer);
        double getDoneBid();
        void addBoughtObject(ObjectOfSale newBoughtObject);
        double getWallet();
        void setWallet(double newWallet);
    }
}
