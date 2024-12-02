using MiddayMarketplace.Models;

namespace MiddayMarketplace.Data
{
    public interface IMarketItemRepository
    {
        public List<MarketItem> GetAllMarketItems(); // Returns all message objects
        public MarketItem GetMarketItemById(int id); // Returns a model object
        public int StoreMarketItem(MarketItem model); // Saves a model in the DbContext.
        public bool DeleteMarketItem(int id);
    }
}
