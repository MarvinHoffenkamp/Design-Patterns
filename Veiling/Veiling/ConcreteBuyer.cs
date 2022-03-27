using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling
{
    class ConcreteBuyer : Buyer
    {
        private int buyersNumber;
        private double wallet;
        private List<ObjectOfSale> boughtObjects;

        public ConcreteBuyer()
        {

        }

        public void bit(double price)
        {
            throw new NotImplementedException();
        }
    }
}
