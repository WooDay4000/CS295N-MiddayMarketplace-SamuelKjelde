using MiddayMarketplace.Controllers;
using MiddayMarketplace.Data;
using MiddayMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddayMarketplaceTests
{
    /* This class is series of tests for the MarketplaceController,
     */
    public class MarketplaceControllerTests
    {
        /* This allows access to the FakeMarketItemRepository
         * to use the methods to perform tests on database
         * operations without messing with the real database.
         */
        IMarketItemRepository repo = new FakeMarketItemRepository();
        // Makes a instance of the MarketplaceController for testing.
        MarketplaceController controller;
        // Makes a MarketItem object to be used in testing.
        MarketItem item = new MarketItem();

        /* This is a constructor sets up the MarketplaceController
         * instance with the FakeMarketItemRepository, so that
         * with each tests it has fresh instance of both.
         */
        public MarketplaceControllerTests()
        {
            controller = new MarketplaceController(repo);
        }

        [Fact]
        /* This test checks to see if a MarketItem that what would
         * be successful is able to be committed to the
         * database.
         */
        public void Post_PostTest_Success()
        {
            /* Arrange
             * Done in the constructor
             */

            // Act
            item.Lister = new AppUser();
            item.ItemLocation = new Location();
            var result = controller.Post(item);

            /* Assert
             * Check to see if I got a RedirectToActionResult
             */
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        /* This test checks to see if a MarketItem that what would
         * be unsuccessful won't be able to be added to the database.
         */
        public void Post_PostTest_Failure()
        {
            /* Arrange
             * Done in the constructor
             */

            // Act
            var result = controller.Post(item);

            /* Assert
             * Check to see if I got a ViewResult
             */
            Assert.True(result.GetType() == typeof(ViewResult));
        }

        [Fact]
        /* This test checks to see if a MarketItem that what would
         * be deleted successful is able to be committed to the
         * database.
         */
        public void Item_DeleteTest_Success()
        {
            /* Arrange
             * Done in the constructor
             */

            // Act
            item.Lister = new AppUser();
            item.ItemLocation = new Location();
            // Checks to see if it was saved.
            if (1 == repo.StoreMarketItem(item))
            {
                /* Tries to delete the record with the
                 * given Market Item Id of 1, Which 
                 * should be the record that was 
                 * just created. 
                 */
                var result = controller.Delete(1);

                /* Assert
                 * Check to see if I got a RedirectToActionResult
                 */
                Assert.True(result.GetType() == typeof(RedirectToActionResult));
            }
        }

        [Fact]
        /* This test checks to see if a MarketItem that what would
         * be deleted unsuccessful won't be able to be added to the
         * database.
         */
        public void Item_DeleteTest_Failure()
        {
            /* Arrange
             * Done in the constructor
             */

            /* Act
             * Tries to delete a record with
             * a Market Item Id of 4, which
             * does not exist.
             */
            var result = controller.Delete(4);

            /* Assert
             * Check to see if I got a ViewResult
             */
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}