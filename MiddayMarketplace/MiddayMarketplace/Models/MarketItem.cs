using Microsoft.AspNetCore.Components.Routing;

namespace MiddayMarketplace.Models
{
    /* The class that will be handing the MarketItems that will
     * be sent. With the AppUser being the Lister, the
     * person listing this item, and the DateListed,
     * being where this item is located.
     */
    public class MarketItem
    {
        // The primary key for the MarketItem record in the table.
        public int MarketItemId { get; set; }
        public AppUser Lister { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string DeliveryType { get; set; }
        public Location ItemLocation { get; set; }
        public DateTime DateListed { get; set; }
    }
}
