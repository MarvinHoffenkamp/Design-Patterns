using System;

namespace Veiling.ObjectsOfSale
{
    class TestCar : IObjectTest
    {
        public bool doTest()
        {
            //return true or false at random
            var random = new Random();
            return random.Next(2) == 1;
        }
    }
}
