using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling.Auctions
{
    class ConcreteAuctionBuilderSW : IAuctionBuilder
    {
        //TODO change datatype of list to ObjectOfSale once class implemented
        private ConcreteAuctionBuilderSW result;
        private List<String> objectsOfSale;

        public void addAuctioneer()
        {
            throw new NotImplementedException();
        }

        public void addBuyer()
        {
            throw new NotImplementedException();
        }

        public void addObjectOfSale()
        {
            throw new NotImplementedException();
        }

        public void reset()
        {
            throw new NotImplementedException();
        }

        public ConcreteAuctionBuilderSW getResult()
        {
            return this.result;
        }

        public List<String> getObjectsOfSale()
        {
            return this.objectsOfSale;
        }
    }
}
