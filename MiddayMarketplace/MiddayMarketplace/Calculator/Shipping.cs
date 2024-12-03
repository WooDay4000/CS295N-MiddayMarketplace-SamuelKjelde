namespace MiddayMarketplace.Calculator
{
    // Object that is used for storing
    // information for shipping.
    public class Shipping
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
