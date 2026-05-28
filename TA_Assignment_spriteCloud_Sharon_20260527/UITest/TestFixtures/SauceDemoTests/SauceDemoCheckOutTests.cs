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
    public class SauceDemoCheckOutTests : Setup
    {
        [Test, Order(1), Retry(2)]
        public async Task FullCheckout()
        {
            await sauceDemoLoginPage.PageLauncher(sauceDemoLoginPage.SauceDemoBaseUrl);
            Console.WriteLine("=== ACTION ===");
            Console.WriteLine("Logging in with standard_user...");
            Console.WriteLine("Adding 2 items to cart");
            Console.WriteLine("And check out successfully");
            Console.WriteLine("=== RESULT ===");
            await sauceDemoLoginPage.EnterUsername("standard_user");
            await sauceDemoLoginPage.EnterPassword("secret_sauce");
            await sauceDemoLoginPage.ClickLoginButton();

            await Expect(sauceDemoInventoryPage._pageTitle).ToHaveTextAsync("Products");
            await sauceDemoInventoryPage.AddItemToCartByName("Sauce Labs Backpack");
            await sauceDemoInventoryPage.AddItemToCartByName("Test.allTheThings() T-Shirt (Red)");
            await Expect(sauceDemoInventoryPage._cartBadge).ToHaveTextAsync("2");
            await sauceDemoInventoryPage.ClickCartBadge();

            await Expect(sauceDemoCartPage._pageTitle).ToHaveTextAsync("Your Cart");
            var price1 = await sauceDemoCartPage.GetPriceByItemName("Sauce Labs Backpack").TextContentAsync();
            var price1Decimal = decimal.Parse(price1.Replace("$", ""), System.Globalization.CultureInfo.InvariantCulture);
            var qty1 = await sauceDemoCartPage.GetQuantityByItemName("Sauce Labs Backpack").TextContentAsync();
            Console.WriteLine($"Sauce Labs Backpack — Qty: {qty1}, Price: {price1}");
            var price2 = await sauceDemoCartPage.GetPriceByItemName("Test.allTheThings() T-Shirt (Red)").TextContentAsync();
            var price2Decimal = decimal.Parse(price2.Replace("$", ""), System.Globalization.CultureInfo.InvariantCulture);
            var qty2 = await sauceDemoCartPage.GetQuantityByItemName("Test.allTheThings() T-Shirt (Red)").TextContentAsync();
            Console.WriteLine($"Test.allTheThings() T-Shirt (Red) — Qty: {qty2}, Price: {price2}");
            var total = price1Decimal + price2Decimal;
            Console.WriteLine($"Total amount: ${total}");
            await sauceDemoCartPage.ClickCheckoutButton();

            await Expect(sauceDemoCheckoutStepOnePage._pageTitle).ToHaveTextAsync("Checkout: Your Information");
            await sauceDemoCheckoutStepOnePage.EnterFirstName("John");
            await sauceDemoCheckoutStepOnePage.EnterLastName("Doe");
            await sauceDemoCheckoutStepOnePage.EnterPostalCode("12345");
            await sauceDemoCheckoutStepOnePage.ClickContinueButton();

            await Expect(sauceDemoCheckoutStepTwoPage._pageTitle).ToHaveTextAsync("Checkout: Overview");
            var subTotalText = await sauceDemoCheckoutStepTwoPage._subTotal.TextContentAsync();
            var subTotal = decimal.Parse(subTotalText.Replace("Item total: $", ""), System.Globalization.CultureInfo.InvariantCulture);
            Assert.That(subTotal, Is.EqualTo(total), $"Subtotal ${subTotal} does not match expected cart total ${total}");
            Console.WriteLine($"Subtotal: ${subTotal}");
            var taxText = await sauceDemoCheckoutStepTwoPage._tax.TextContentAsync();
            var tax = decimal.Parse(taxText.Replace("Tax: $", ""), System.Globalization.CultureInfo.InvariantCulture);
            var expectedTax = Math.Round(total * 0.08m, 2);
            Assert.That(tax, Is.EqualTo(expectedTax), $"Tax ${tax} does not match expected 8% tax ${expectedTax}");
            Console.WriteLine($"Tax: ${tax}");
            var grandTotalText = await sauceDemoCheckoutStepTwoPage._total.TextContentAsync();
            var grandTotal = decimal.Parse(grandTotalText.Replace("Total: $", ""), System.Globalization.CultureInfo.InvariantCulture);
            var expectedTotal = subTotal + tax;
            Assert.That(grandTotal, Is.EqualTo(expectedTotal), $"Total ${grandTotal} does not match subtotal + tax ${expectedTotal}");
            Console.WriteLine($"Total: ${grandTotal}");
            await sauceDemoCheckoutStepTwoPage.ClickFinishButton();

            await Expect(sauceDemoCheckoutStepTwoPage._pageTitle).ToHaveTextAsync("Checkout: Complete!");
        }
    }
}
