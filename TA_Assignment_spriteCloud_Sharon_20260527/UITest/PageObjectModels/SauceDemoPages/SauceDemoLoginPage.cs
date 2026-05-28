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
    public class SauceDemoLoginPage : BasePage
    {
        public SauceDemoLoginPage(IPage page) : base(page) { }

        #region general
        public ILocator _inputUsername => Page.Locator("#user-name");
        public ILocator _inputPassword => Page.Locator("#password");
        public ILocator _loginButton => Page.Locator("#login-button");
        public ILocator _errorMessage => Page.Locator("[data-test='error']");
        #endregion

        #region basic operations
        public async Task GoToLoginSauceDemoPage() => await Page.GotoAsync(SauceDemoBaseUrl);
        public async Task EnterUsername(string username) => await _inputUsername.FillAsync(username);
        public async Task EnterPassword(string password) => await _inputPassword.FillAsync(password);
        public async Task ClickLoginButton() => await _loginButton.ClickAsync();
        #endregion
    }
}