using System;
using System.Globalization;

namespace LiskovSubst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ShippingCost {

        public decimal CalculateShippingCost(float packageWeightInKilograms,
            Size<float> packageDimensionsInInches,
            RegionInfo destination)
        {
            if (packageWeightInKilograms <= 0f) throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Pckage weight mustbe positive and non zero");
            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches",
                    "Pckage dimensions must be positive and non zero");
            var shippingcost = decimal.One;

            if (shippingcost <= decimal.Zero) {
                throw new ArgumentOutOfRangeException("return",
                  "The return of value is out of range");

            }
            return decimal.MinusOne;

        }

    }

     

    public class Size<T>
    {
        public float Y { get; set; }
        public float X { get; set; }
    }

    public class ShippingStrategy
    {
        protected decimal flatRate;
        public ShippingStrategy(decimal flatRate)
        {
            if (flatRate <= decimal.Zero)
            {

                throw new ArgumentOutOfRangeException("flatRate",
                  "Flat rate must be positive and non-zero");


            }
            this.flatRate = flatRate;



        }
    }
    public class ShippingStrategy2
    {
        private decimal flatRate;
        public decimal FlatRate { get {

                return this.FlatRate;
            } set {
                if (value <= decimal.Zero)
                    throw new ArgumentOutOfRangeException("flatRate",
                "Flat rate must be positive and non-zero");


                this.flatRate = value;

            } }
        public ShippingStrategy2(decimal flatRate)
        {

            this.flatRate = flatRate;



        }

        public virtual decimal CalculateShippingCost(float packageWeightInKilograms,
          Size<float> packageDimensionsInInches,
          RegionInfo destination)
        {
            if (packageWeightInKilograms <= 0f) throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Pckage weight mustbe positive and non zero");
            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches",
                    "Pckage dimensions must be positive and non zero");
            var shippingcost = decimal.One;

            if (shippingcost <= decimal.Zero)
            {
                throw new ArgumentOutOfRangeException("return",
                  "The return of value is out of range");

            }
            return decimal.MinusOne;

        }
    }


    public class WorldWideShippingStrategy : ShippingStrategy2
    {
        public WorldWideShippingStrategy(decimal flatRate) : base(flatRate)
        {
        }

        public override decimal CalculateShippingCost(float packageWeightInKilograms,
          Size<float> packageDimensionsInInches,
          RegionInfo destination)
        {
            if (packageWeightInKilograms <= 0f) throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Pckage weight mustbe positive and non zero");
            if (packageWeightInKilograms <= 0f) {

                throw new ArgumentOutOfRangeException("packageWeightInKilograms",
                  "Pckage dimensions must be positive and non zero");

            }


            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches",
                    "Pckage dimensions must be positive and non zero");

            var shippingCost = decimal.One;
            if (destination == RegionInfo.CurrentRegion)
            {
                shippingCost = decimal.Zero;
            }
            return shippingCost;

        }
    }
}
