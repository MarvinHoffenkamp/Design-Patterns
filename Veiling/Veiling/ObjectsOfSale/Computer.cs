namespace Veiling.ObjectsOfSale
{
    class Computer : ObjectOfSale
    {
        public Computer(string brand, int[] measurements, double estimatedValue) : base(brand, measurements, estimatedValue)
        {

        }

        public override IObjectTest TestObject()
        {
            return new TestComputer();
        }
    }
}
