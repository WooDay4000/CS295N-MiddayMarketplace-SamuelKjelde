namespace MiddayMarketplace.Calculator
{
    /* Object that is used for storing
     * information for shipping calculation.
     */
    public class Shipping
    {
        /* The getter and setter properties for the
         * Shipping class
         */
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
