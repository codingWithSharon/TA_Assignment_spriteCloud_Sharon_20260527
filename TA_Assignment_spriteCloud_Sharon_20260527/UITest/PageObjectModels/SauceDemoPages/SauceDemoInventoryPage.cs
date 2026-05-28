using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.UITests.PageObjectModels;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages
{
    public class SauceDemoInventoryPage : BasePage
    {
        public SauceDemoInventoryPage(IPage page) : base(page) { }

        #region general
        public ILocator _addToCartButton => Page.Locator("#add-to-cart");
        public ILocator _backToProductOverview => Page.Locator("#back-to-products");
        public ILocator _cartBadge => Page.Locator(".shopping_cart_badge");
        public ILocator _inventoryItemName => Page.Locator("#item_4_title_link");
        public ILocator _inventoryItemNames => Page.Locator("[data-test='inventory-item-name']");
        public ILocator _sortDropdown => Page.Locator("[data-test='product-sort-container']");
        public ILocator GetItemByName(string itemName) => Page.Locator("[data-test='inventory-item-name']", new() { HasText = itemName });
        public ILocator GetItemCardByName(string itemName) => Page.Locator("[data-test='inventory-item']").Filter(new() { HasText = itemName });
        public ILocator GetAddToCartByName(string itemName) => GetItemCardByName(itemName).Locator("button");
        #endregion

        #region basic operations
        public async Task ClickSauceLabBackpack() => await _inventoryItemName.ClickAsync();
        public async Task ClickAddToCartButton() => await _addToCartButton.ClickAsync();
        public async Task ClickItemByName(string itemName) => await GetItemByName(itemName).ClickAsync();
        public async Task AddItemToCartByName(string itemName) => await GetAddToCartByName(itemName).ClickAsync();
        public async Task ClickCartBadge() => await _cartBadge.ClickAsync();
        public async Task SortBy(string value) => await _sortDropdown.SelectOptionAsync(value);
        public async Task<string> GetSelectedSort() => await _sortDropdown.InputValueAsync();
        #endregion
    }
}