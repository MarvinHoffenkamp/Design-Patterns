using Veiling.ObjectsOfSale;

namespace Veiling
{
    interface IBuyer
    {
        void bid(double price);
        void doBid();
        int getBuyersNumber();
        void setAuctioneer(Auctioneer auctioneer);
        double getDoneBid();
        void addBoughtObject(ObjectOfSale newBoughtObject);
    }
}
