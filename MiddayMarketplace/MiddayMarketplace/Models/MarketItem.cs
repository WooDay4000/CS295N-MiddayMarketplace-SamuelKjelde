using Microsoft.AspNetCore.Components.Routing;

namespace MiddayMarketplace.Models
{
    public class MarketItem
    {
        public int MarketItemId { get; set; }
        public AppUser Lister { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string DeliveryType { get; set; }
        public Location ItemLocation { get; set; }
        public DateTime DateListed { get; set; }
    }
}
