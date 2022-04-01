namespace Veiling.ObjectsOfSale
{
    class Motorcycle : ObjectOfSale
    {
        public Motorcycle(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override IObjectTest TestObject()
        {
            return new TestMotorcycle();
        }
    }
}
