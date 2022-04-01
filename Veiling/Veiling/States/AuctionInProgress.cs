namespace Veiling.States
{
    class AuctionInProgress : State
    {
        public AuctionInProgress(Auctioneer auctioneer) : base(auctioneer)
        {

        }

        public override void moveObjectOfSale()
        {
            //does nothing, object is being sold in this state so no need to move it, move it
        }

        public override void runState()
        {
            auctioneer.setState(this);
            auctioneer.notifyBuyers();
        }
    }
}
