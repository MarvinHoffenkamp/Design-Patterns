namespace Veiling.ObjectsOfSale
{
    class Ship : ObjectOfSale
    {
        public Ship(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override IObjectTest TestObject()
        {
            return new TestShip();
        }
    }
}
