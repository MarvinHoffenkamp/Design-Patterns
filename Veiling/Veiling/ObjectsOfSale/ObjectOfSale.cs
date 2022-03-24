using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling.ObjectsOfSale
{
    abstract class ObjectOfSale
    {
        private String brand; //brand of the object
        private int[] measurements = new int[3]; //width, height and length of the object
        private double estimatedValue; //estimated value of the object at auction
        public abstract IObjectTest TestObject();

        public ObjectOfSale(string brand, int[] measurements, double estimatedValue)
        {
            this.brand = brand;
            this.measurements = measurements;
            this.estimatedValue = estimatedValue;
        }

        public String getBrand()
        {
            return this.brand;
        }

        public void setBrand(String newBrand)
        {
            brand = newBrand;
        }

        public int[] getMeasurements()
        {
            return this.measurements;
        }

        public void setMeasurements(int[] newMeasurements)
        {
            measurements = newMeasurements;
        }

        public void setMeasurement(int pos, int newMeasurement)
        {
            measurements[pos] = newMeasurement;
        }

        public double getEstimatedValue()
        {
            return this.estimatedValue;
        }

        public void setEstimatedValue(double newEstimatedValue)
        {
            estimatedValue = newEstimatedValue;
        }

        public bool turnOn()
        {
            var testObject = TestObject();
            return testObject.doTest();
        }
    }
}
