using PagesSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITest.TestFixtures.SauceDemoTests
{
    [TestFixture, Order(1)]
    [Parallelizable(ParallelScope.None)]
    public class SauceDemoInventoryTests : Setup
    {
        [Test, Order(2), Retry(2)]
        public async Task SortProducts()
        {
            await sauceDemoLoginPage.PageLauncher(sauceDemoLoginPage.SauceDemoBaseUrl);
            Console.WriteLine("=== ACTION ===");
            Console.WriteLine("Logging in with standard_user...");
            Console.WriteLine("Sorting products from Z to A");
            await sauceDemoLoginPage.EnterUsername("standard_user");
            await sauceDemoLoginPage.EnterPassword("secret_sauce");
            await sauceDemoLoginPage.ClickLoginButton();

            var pageTitle = await sauceDemoInventoryPage._pageTitle.TextContentAsync();
            Assert.That(pageTitle, Is.EqualTo("Products"), $"Expected page title 'Products' but got '{pageTitle}'");
            Console.WriteLine($"✓ Page title verified: '{pageTitle}'");

            await sauceDemoInventoryPage.SortBy("za");
            Console.WriteLine("✓ Sort option 'Z to A' selected");

            var actualNames = await sauceDemoInventoryPage._inventoryItemNames.AllTextContentsAsync();
            var expectedNames = actualNames.OrderByDescending(name => name).ToList();

            Console.WriteLine("=== RESULT ===");
            Console.WriteLine($"Total products found: {actualNames.Count}");
            Console.WriteLine($"Actual order:   {string.Join(", ", actualNames)}");
            Console.WriteLine($"Expected order: {string.Join(", ", expectedNames)}");

            Assert.That(actualNames, Is.EqualTo(expectedNames),
                $"Products are not sorted Z to A.\nActual:   {string.Join(", ", actualNames)}\nExpected: {string.Join(", ", expectedNames)}");

            Console.WriteLine("✓ Products are correctly sorted from Z to A");
        }
    }
}
