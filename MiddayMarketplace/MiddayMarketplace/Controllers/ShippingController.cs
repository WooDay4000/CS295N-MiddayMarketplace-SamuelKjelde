using Microsoft.AspNetCore.Mvc;
using MiddayMarketplace.Calculator;

namespace MiddayMarketplace.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index()
        {
            Shipping model = new Shipping();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Shipping shipping)
        {
            Calculated calculated = new Calculated();
            shipping.ShippingCost = calculated.CalculateShippingByWeight(shipping);
            return View(shipping);
        }
    }
}
