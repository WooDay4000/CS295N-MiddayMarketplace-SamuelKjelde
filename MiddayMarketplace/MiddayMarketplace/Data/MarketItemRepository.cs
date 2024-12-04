using MiddayMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace MiddayMarketplace.Data
{
    /* This is a class that is used to manage MarketItem
     * objects, having methods used interact with the
     * ApplicationDbContext which in turn the database.
     */
    public class MarketItemRepository : IMarketItemRepository
    {
        /* A private variable used to access the
         * database.
         */
        private ApplicationDbContext context;
        /* This makes a instance of the MarketItemRepository
         * class, having the ApplicationDbContext set to
         * this instance to be used throughout this class.
         */
        public MarketItemRepository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        /* This is used to receive all MarketItems from the
         * database, with there related Lister
         * and ItemLocation data, and returning a list.
         */
        public List<MarketItem> GetAllMarketItems()
        {
            // Get the MarketItem objects and put them into a list.
            var marketItems = context.MarketItems
                // Includes the related data of the Lister AppUser object
                .Include(marketItem => marketItem.Lister)
                // Includes the related data of the ItemLocation Location object
                .Include(marketItem => marketItem.ItemLocation)
                /* Makes the the returned MarketItems from the database
                 * into a list that is returned to the view this was called.
                 */
                .ToList();
            return marketItems;
        }

        /* This is used to grab a specific MarketItem
         * record from the database using the
         * MarketItemId field of the record, entering
         * a corresponding int number to bring the
         * corresponding record with the MarketItemId.
         */
        public MarketItem GetMarketItemById(int id)
        {
            var marketItem = context.MarketItems
                .Include(marketItem => marketItem.Lister)
                .Include(marketItem => marketItem.ItemLocation)
                /* Specifying that we went a record that
                 * has the matching MarketItemId to what was
                 * entered.
                 */
                .Where(marketItem => marketItem.MarketItemId == id)
                // As well that we are expecting only one record to be returned.
                .SingleOrDefault();
            return marketItem;
        }

        /* This method is used to save the MarketItem
         * object to the database, adding the current
         * time, saving it to the database context,
         * and then commit to the database to be
         * saved.
         */
        public int StoreMarketItem(MarketItem model)
        {
            model.DateListed = DateTime.Now;
            model.Lister.SignUpDate = DateTime.Now;
            context.MarketItems.Add(model);
            // Returns a positive when it's successful
            return context.SaveChanges();
        }

        /* This method is used to delete a MarketItem
         * record from the database, grabbing the record
         * to be deleted by the id, using remove to
         * remove the record from the database context,
         * and then SaveChanges to commit to the database
         * the deleted record.
         */
        public bool DeleteMarketItem(int id)
        {
            // Grabs the MarketItem with the matching id.
            var marketItem = GetMarketItemById(id);
            // If null it returns a false.
            if (marketItem == null)
            {
                return false;
            }
            else
            {
                /* Where if not null, it removes and saves
                 * this change to the database, returning
                 * true.
                 */
                context.MarketItems.Remove(marketItem);
                context.SaveChanges();
                return true;
            }
        }
    }
}
