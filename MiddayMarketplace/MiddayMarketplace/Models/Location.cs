namespace MiddayMarketplace.Models
{
    /* Class used for storing the location
     * info of the listed item.
     */
    public class Location
    {
        // The primary key for the Location record in the table.
        public int LocationId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
