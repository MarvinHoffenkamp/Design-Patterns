using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling.ObjectsOfSale
{
    class Ship : ObjectOfSale
    {
        public Ship(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override ObjectTest TestObject()
        {
            return new TestShip();
        }
    }
}
