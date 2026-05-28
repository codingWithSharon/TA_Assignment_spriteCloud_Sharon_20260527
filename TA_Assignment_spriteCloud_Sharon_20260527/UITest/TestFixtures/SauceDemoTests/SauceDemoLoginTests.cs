using Microsoft.Playwright;
using PagesSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages;
using TA_Assignment_spriteCloud_Sharon_20260527.UITests.PageObjectModels;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITest.TestFixtures.SauceDemoTests
{
    [TestFixture, Order(1)]
    [Parallelizable(ParallelScope.None)]
    public class SauceDemoLoginTests : Setup
    {
        [Test, Order(1), Retry(2)]
        public async Task LoginFailed()
        {
            await sauceDemoLoginPage.GoToLoginSauceDemoPage();
            await sauceDemoLoginPage.PageLauncher(sauceDemoLoginPage.SauceDemoBaseUrl);

            Console.WriteLine("=== ACTION ===");
            Console.WriteLine($"URL: {sauceDemoLoginPage.SauceDemoBaseUrl}");
            Console.WriteLine($"Username: InvalidUser");
            Console.WriteLine($"Password: InvalidPassword");

            await sauceDemoLoginPage.EnterUsername("InvalidUser");
            await sauceDemoLoginPage.EnterPassword("InvalidPassword");
            await sauceDemoLoginPage.ClickLoginButton();

            Console.WriteLine("=== RESULT ===");
            Console.WriteLine($"Error message: {sauceDemoLoginPage._errorMessage}");
            await Expect(sauceDemoLoginPage._errorMessage).ToContainTextAsync("Epic sadface: Username and password do not match any user in this service");
        }
    }
}
