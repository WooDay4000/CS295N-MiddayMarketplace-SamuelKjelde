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
    /* A Fake Repository used to test database operation
     * without having to interact with the real database.
     */
    public class FakeMarketItemRepository : IMarketItemRepository
    {
        private List<MarketItem> items = new List<MarketItem>(); // Uses a list as a data store

        /* Method used to delete a MarketItem object
         * with the corresponding id from the list.
         */
        public bool DeleteMarketItem(int id)
        {
            return items.Remove(GetMarketItemById(id));
        }

        /* Retrieves all messages stored in the items list,
         * and returns it to where this method was called.
         */
        List<MarketItem> IMarketItemRepository.GetAllMarketItems()
        {
            return items;
        }

        /* Method used to get a MarketItem object
         * with the corresponding id from the list.
         */
        public MarketItem GetMarketItemById(int id)
        {
            MarketItem item = items.Find(i => i.MarketItemId == id);
            return item;
        }

        /* This is used to mimic saving to the
         * database, having the created MarketItem
         * object be stored to a list instead
         * assign a unique ID while doing so.
         * Producing a 0 if it failed, and a 1
         * if it succeeded.
         */
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
