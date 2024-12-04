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

        /* An HttpPost that will take the inputted information
         * from the form on the Shipping view index page. Where
         * it will run the information in the form of a Shipping
         * object though the CalculateShippingByWeight method
         * to calculate the shipping cost an item.
         */
        [HttpPost]
        public IActionResult Index(Shipping shipping)
        {
            /* Makes a insistence of the Calculated class 
             * to be able to use the methods from it in this
             * IActionResult method
             */
            Calculated model = new Calculated();
            /* Runs the shipping object though the 
             * CalculateShippingByWeight method, to
             * calculate the shipping cost based on
             * the item's weight, length, height,
             * and width. Setting the shipping cost
             * to the ShippingCost field of the Shipping
             * object.
             */
            shipping.ShippingCost = model.CalculateShippingByWeight(shipping);
            /* Which is then returned to the index
             * view where the information was first entered.
             */
            return View(shipping);
        }
    }
}
