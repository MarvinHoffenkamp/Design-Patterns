using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling.ObjectsOfSale
{
    class TestCar : ObjectTest
    {
        public bool doTest()
        {
            //return true or false at random
            var random = new Random();
            return random.Next(2) == 1;
        }
    }
}
