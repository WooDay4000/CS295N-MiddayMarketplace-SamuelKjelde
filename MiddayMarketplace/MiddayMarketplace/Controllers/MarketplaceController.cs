using MiddayMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Extensions.Hosting;
using MiddayMarketplace.Data;
using Microsoft.EntityFrameworkCore;

namespace MiddayMarketplace.Controllers
{
    public class MarketplaceController : Controller
    {
        // private instance variable
        IMarketItemRepository repo;

        // constructor
        public MarketplaceController(IMarketItemRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            /* This gets all the current MarketItem
             * objects from a database, using the
             * GetAllMarketItems method from the
             * MessageRepository.
             */
            var marketItems = repo.GetAllMarketItems();
            /* Then it returns this list to the
             * Index view to have it's 
             * contents displayed to the user.
             */
            return View(marketItems);
        }

        /* A method that is called from the webpage
         * to filter the received records to include
         * only those that match the specified filter.
         * This being done with "Where" and the inputted
         * values.
         */
        public IActionResult Filter(string lister, string itemName, string deliveryType)
        {
            var marketItems = repo.GetAllMarketItems()
                .Where(i => lister == null || i.Lister.UserName.ToLower().Contains(lister.ToLower()))
                .Where(i => itemName == null || i.ItemName.ToLower().Contains(itemName.ToLower()))
                .Where(i => deliveryType == null || i.DeliveryType == deliveryType)
                .ToList();
            return View("Index", marketItems);
        }

        /* This is the Item IActionResult for the Marketplace view Item
         * cshtml, where it's called with an int value. Where the int
         * value is from the Index cshtml of the same view, here it's
         * the Market Item Id of the item that is going to be
         * displayed on this page.
         */
        public IActionResult Item(string value)
        {
            /* Where it's turned into an int value from a string
             * since it's being sent here with a "a" element html
             * code, it was turned into a string.
             */
            var marketItemId = int.Parse(value);
            /* Then the marketItemId is ran though the GetMarketItemById
             * from the MessageRepository, where it returns the MarketItem
             * record with the matching Market Item Id.
             */
            var marketItem = repo.GetMarketItemById(marketItemId);
            // Returning the grabbed object to this view, to be displayed.
            return View(marketItem);
        }

        /* A IActionResult method called Delete that is used in the
         * Item cshtml, where it's called using a form with the 
         * Market Item Id already set, with the value being from the
         * MarketItem that was displayed on the Item cshtml.
         */
        [HttpPost]
        public IActionResult Delete(int id)
        {
            /* Calls the DeleteMarketItem from the
             * MessageRepository with the Market Item Id
             * of the item that is going to be deleted,
             * returning a true if it was deleted and
             * a false if not.
             */
            if (repo.DeleteMarketItem(id))
            {
                /*Sending you back to the Index cshtml
                 * if it was successful.
                 */
                return RedirectToAction("Index");
            }
            else
            {
                /* Returning you back to the Item cshtml
                 * with a error message, telling you that
                 * the item was unable to be deleted.
                 */
                ViewBag.ErrorMessage = "There was an error deleting the item.";
                return View();
            }
        }

        public IActionResult Post()
        {
            return View();
        }

        /* A http post that take the form fields from the
         * Post page, puts them in the fields of the MarketItem
         * object, with automagically adding the current date and time
         * to the DateListed field of the object and then sending it
         * to database to be saved, all this done with the StoreMarketItem
         * from the MessageRepository.
         */
        [HttpPost]
        public IActionResult Post(MarketItem model)
        {
            /* If it returns a value higher then
             * zero when saving the MarketItem
             * to the database it has succeeded.
             */
            if (repo.StoreMarketItem(model) > 0)
            {
                // Return you back to the Index cshtml, with the created Market Item Id.
                return RedirectToAction("Index", new { marketItemId = model.MarketItemId });
            }
            else
            {
                /* Where if it didn't succeed it would send you back to the
                 * Post cshtml, with the error message that it failed to
                 * save.
                 */
                ViewBag.ErrorMessage = "There was an error saving the market item.";
                return View();
            }
        }
    }
}
