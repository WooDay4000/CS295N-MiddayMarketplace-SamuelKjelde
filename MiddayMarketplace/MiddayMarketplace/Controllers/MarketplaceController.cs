﻿using Microsoft.AspNetCore.Mvc;

namespace MiddayMarketplace.Controllers
{
    public class MarketplaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Item()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }
    }
}
