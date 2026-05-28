using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.UITests.PageObjectModels;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages
{
    public class SauceDemoCartPage : BasePage
    {
        public SauceDemoCartPage(IPage page) : base(page) { }

        #region general
        public ILocator GetPriceByItemName(string itemName) => Page.Locator("[data-test='inventory-item']")
        .Filter(new() { HasText = itemName })
        .Locator("[data-test='inventory-item-price']");
        public ILocator GetQuantityByItemName(string itemName) => Page.Locator("[data-test='inventory-item']")
        .Filter(new() { HasText = itemName })
        .Locator("[data-test='item-quantity']");
        public ILocator _CheckoutButton => Page.Locator("#checkout");
        #endregion

        #region basic operations login page
        public async Task ClickCheckoutButton() => await _CheckoutButton.ClickAsync();
        #endregion
    }
}
