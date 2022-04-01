using Veiling.ObjectsOfSale;

namespace Veiling.Auctions
{
    interface IAuctionBuilder
    {
        void reset();
        void addAuctioneer(Auctioneer auctioneer);
        void addBuyer(IBuyer buyer);
        void addObjectOfSale(ObjectOfSale objectsOfSale);
        Auction getResult();
    }
}
