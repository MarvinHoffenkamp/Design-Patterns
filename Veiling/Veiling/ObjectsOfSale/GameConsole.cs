using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling.ObjectsOfSale
{
    class GameConsole : ObjectOfSale
    {
        public GameConsole(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override IObjectTest TestObject()
        {
            return new TestGameConsole();
        }
    }
}
