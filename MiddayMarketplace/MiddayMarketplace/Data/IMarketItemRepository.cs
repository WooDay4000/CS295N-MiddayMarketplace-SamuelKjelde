using MiddayMarketplace.Models;

namespace MiddayMarketplace.Data
{
    // This is an interface, which defines a set of methods 
    // that must be implemented by a class to provide functionality.
    // It promotes abstraction, allowing the behavior of methods 
    // to be defined differently depending on the implementing class. 
    // This demonstrates polymorphism by enabling flexibility in 
    // how the methods are executed in different contexts.
    public interface IMarketItemRepository
    {
        public List<MarketItem> GetAllMarketItems(); // Returns all message objects
        public MarketItem GetMarketItemById(int id); // Returns a model object
        public int StoreMarketItem(MarketItem model); // Saves a model in the DbContext.
        public bool DeleteMarketItem(int id); // Deletes a model in the DbContext
    }
}
