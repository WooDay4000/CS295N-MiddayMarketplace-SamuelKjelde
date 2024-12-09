using System;

namespace MiddayMarketplace.Calculator
{
    public class Calculated
    {
        // Values that are used with these calculations.
        private const decimal DIMENSIONAL_FACTOR = 139;
        private const decimal BASE_SHIPPING_COST = 5;
        private const decimal SHIPPING_RATE = 1.50m;

        /* This returns the shipping cost of the provided item, based on
         * it's weight and size. With 5 being the base cost for the shipping.
         * It uses the biggest of actual weight and dimensional weight for the
         * calculation, timing it by the shipping rate for the shipping cost.
         */
        public decimal CalculateShippingByWeight(Shipping shipping)
        {
            decimal dimensionalWeight = GetDimensionalWeight(shipping);
            decimal effectiveWeight = Math.Max(shipping.Weight, dimensionalWeight);
            return Math.Round(BASE_SHIPPING_COST + (effectiveWeight * SHIPPING_RATE), 2);
        }

        /* Calculates the dimensional weight of the item to be shipped.
         * Where it the dimensions of the item divided by a dimensional factor.
         */
        public decimal GetDimensionalWeight(Shipping shipping)
        {
            return (shipping.Length * shipping.Width * shipping.Height) / DIMENSIONAL_FACTOR;
        }
    }
}
