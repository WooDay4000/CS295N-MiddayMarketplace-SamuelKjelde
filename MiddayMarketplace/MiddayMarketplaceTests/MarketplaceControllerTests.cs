using MiddayMarketplace.Controllers;
using MiddayMarketplace.Data;
using MiddayMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddayMarketplaceTests
{
    public class MarketplaceControllerTests
    {
        IMarketItemRepository repo = new FakeMarketItemRepository();

        MarketplaceController controller;

        MarketItem item = new MarketItem();

        public MarketplaceControllerTests()
        {
            controller = new MarketplaceController(repo);
        }

        [Fact]
        public void MarketItem_PostTest_Success()
        {
            // Arrange
            // Done in the constructor

            // Act
            item.Lister = new AppUser();
            var result = controller.Post(item);

            // Assert
            // Check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        public void MarketItem_PostTest_Failure()
        {
            // Arrange
            // Done in the constructor

            // Act
            var result = controller.Post(item);

            // Assert
            // Check to see if I got a ViewResult
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}