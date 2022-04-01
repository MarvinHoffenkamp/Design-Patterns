namespace Veiling.States
{
    class AuctionInProgress : State
    {
        public AuctionInProgress(Auctioneer auctioneer) : base(auctioneer)
        {

        }

        public override void moveObjectOfSale()
        {
            //does nothing
        }

        public override void runState()
        {
            auctioneer.setState(this);
            auctioneer.notifyBuyers();
        }
    }
}
