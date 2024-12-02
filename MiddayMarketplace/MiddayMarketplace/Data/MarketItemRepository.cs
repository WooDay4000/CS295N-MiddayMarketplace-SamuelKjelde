using MiddayMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace MiddayMarketplace.Data
{
    public class MarketItemRepository : IMarketItemRepository
    {
        private ApplicationDbContext context;

        public MarketItemRepository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public List<MarketItem> GetAllMarketItems()
        {
            var marketItems = context.MarketItems
                .Include(marketItem => marketItem.Lister)
                .Include(marketItem => marketItem.ItemLocation)
                .ToList();
            return marketItems;
        }

        public MarketItem GetMarketItemById(int id)
        {
            var marketItem = context.MarketItems
                .Include(marketItem => marketItem.Lister)
                .Include(marketItem => marketItem.ItemLocation)
                .Where(marketItem => marketItem.MarketItemId == id)
                .SingleOrDefault();
            return marketItem;
        }

        public int StoreMarketItem(MarketItem model)
        {
            model.DateListed = DateTime.Now;
            model.Lister.SignUpDate = DateTime.Now;
            context.MarketItems.Add(model);
            return context.SaveChanges();
        }

        public bool DeleteMarketItem(int id)
        {
            var marketItem = GetMarketItemById(id);
            if (marketItem == null)
            {
                return false;
            }
            else
            {
                context.MarketItems.Remove(marketItem);
                context.SaveChanges();
                return true;
            }
        }
    }
}
