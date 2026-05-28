using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using TA_Assignment_spriteCloud_Sharon_20260527.UITests.PageObjectModels;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages
{
    public class SauceDemoCheckoutStepTwoPage: BasePage
    {
        public SauceDemoCheckoutStepTwoPage(IPage page) : base(page) { }

        #region general
        public ILocator _subTotal => Page.Locator("[data-test='subtotal-label']");
        public ILocator _tax => Page.Locator("[data-test='tax-label']");
        public ILocator _total => Page.Locator("[data-test='total-label']");
        public ILocator _finishButton => Page.Locator("#finish");
        #endregion

        #region basic operations login page
        public async Task ClickFinishButton() => await _finishButton.ClickAsync();
        #endregion
    }
}
