using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddayMarketplace.Calculator;

namespace MiddayMarketplaceTests
{
    public class CalculatorTests
    {
        private Shipping shipping = new Shipping();
        // Access to the calculated
        private Calculated calculated = new Calculated();

        [Fact]
        // Check the CalculateShippingByWeight if it produces
        // the right result when actual weight is bigger then
        // dimensional weight.
        public void CheckCalculatedValueActualWeight()
        {
            // Arrange
            shipping.Length = 12;
            shipping.Width = 6;
            shipping.Height = 6;
            shipping.Weight = 4;

            // Act
            shipping.ShippingCost = calculated.CalculateShippingByWeight(shipping);

            // Assert
            Assert.Equal(11, shipping.ShippingCost);
        }

        [Fact]
        // Check the CalculateShippingByWeight if it produces
        // the right result when dimensional weight is bigger then
        // actual weight.
        public void CheckCalculatedValueDimensionalWeight()
        {
            // Arrange
            shipping.Length = 15;
            shipping.Width = 7;
            shipping.Height = 7;
            shipping.Weight = 2;

            // Act
            shipping.ShippingCost = calculated.CalculateShippingByWeight(shipping);

            // Assert
            Assert.Equal(12.93m, shipping.ShippingCost);
        }
    }
}