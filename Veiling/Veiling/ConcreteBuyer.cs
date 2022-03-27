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

        public ConcreteBuyer(int buyersNumber, double wallet)
        {
            this.buyersNumber = buyersNumber;
            this.wallet = wallet;
            this.boughtObjects = new List<ObjectOfSale>();
        }

        public void bit(double price)
        {
            throw new NotImplementedException();
        }

        public int getBuyersNumber()
        {
            return this.buyersNumber;
        }
    }
}
