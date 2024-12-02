using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MiddayMarketplace.Data;
using MiddayMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddayMarketplaceTests
{
    internal class FakeMarketItemRepository : IMarketItemRepository
    {
        private List<MarketItem> items = new List<MarketItem>();

        public bool DeleteMarketItem(int id)
        {
            return items.Remove(GetMarketItemById(id));
        }

        List<MarketItem> IMarketItemRepository.GetAllMarketItems()
        {
            return items;
        }

        public MarketItem GetMarketItemById(int id)
        {
            MarketItem item = items.Find(i => i.MarketItemId == id);
            return item;
        }

        public int StoreMarketItem(MarketItem model)
        {
            int status = 0;
            if (model != null && model.Lister != null)
            {
                model.MarketItemId = items.Count + 1;
                items.Add(model);
                status = 1;
            }
            return status;
        }
    }
}
