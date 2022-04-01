namespace Veiling.ObjectsOfSale
{
    class Television : ObjectOfSale
    {
        public Television(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override IObjectTest TestObject()
        {
            return new TestTelevision();
        }
    }
}
