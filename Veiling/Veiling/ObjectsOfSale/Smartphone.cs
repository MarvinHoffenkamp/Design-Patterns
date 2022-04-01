namespace Veiling.ObjectsOfSale
{
    class Smartphone : ObjectOfSale
    {
        public Smartphone(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override IObjectTest TestObject()
        {
            return new TestSmartphone();
        }
    }
}
