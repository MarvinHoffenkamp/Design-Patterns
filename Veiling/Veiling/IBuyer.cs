using Veiling.ObjectsOfSale;

namespace Veiling
{
    interface IBuyer
    {
        void bid(double price);
        void doBid();
        int getBuyersNumber();
        void setAuctioneer(Auctioneer auctioneer);
        double getBuyersBid();
        void addBoughtObject(ObjectOfSale newBoughtObject);
        double getWallet();
        void setWallet(double newWallet);
    }
}
