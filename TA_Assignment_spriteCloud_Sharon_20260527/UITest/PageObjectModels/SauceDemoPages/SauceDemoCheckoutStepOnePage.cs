using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.UITests.PageObjectModels;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages
{
    public class SauceDemoCheckoutStepOnePage : BasePage
    {
        public SauceDemoCheckoutStepOnePage(IPage page) : base(page) { }

        #region general
        public ILocator _firstNameInput => Page.Locator("#first-name");
        public ILocator _lastNameInput => Page.Locator("#last-name");
        public ILocator _postalCodeInput => Page.Locator("#postal-code");
        public ILocator _continueButton => Page.Locator("#continue");
        #endregion

        #region basic operations
        public async Task EnterFirstName(string firstName) => await _firstNameInput.FillAsync(firstName);
        public async Task EnterLastName(string lastName) => await _lastNameInput.FillAsync(lastName);
        public async Task EnterPostalCode(string postalCode) => await _postalCodeInput.FillAsync(postalCode);
        public async Task ClickContinueButton() => await _continueButton.ClickAsync();
        #endregion
    }
}
