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
        IMarketItemRepository repo;

        public MarketplaceController(IMarketItemRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            var marketItems = repo.GetAllMarketItems();
            return View(marketItems);
        }

        public IActionResult Item(string value)
        {
            var MarketItemId = int.Parse(value);
            var marketItem = repo.GetMarketItemById(MarketItemId);
            return View(marketItem);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(repo.DeleteMarketItem(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error deleting the item.";
                return View();
            }

        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(MarketItem model)
        {
            if (repo.StoreMarketItem(model) > 0)
            {
                return RedirectToAction("Index", new { marketItemId = model.MarketItemId });
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the market item.";
                return View();
            }
        }
    }
}
