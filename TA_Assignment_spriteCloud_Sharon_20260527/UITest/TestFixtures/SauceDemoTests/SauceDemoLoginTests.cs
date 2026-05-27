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
    public class LoginTests : Setup
    {
        [Test, Order(1), Retry(2)]
        public async Task Login_StandardUser()
        {
            await sauceDemoLoginPage.GoToLoginSauceDemoPage();
            await sauceDemoLoginPage.EnterUsername("standard_user");
            await sauceDemoLoginPage.EnterPassword("secret_sauce");
            await sauceDemoLoginPage.ClickLoginButton();
            await Expect(sauceDemoLoginPage._headerWebshop).ToBeVisibleAsync();
            Console.WriteLine("""   
                    Successful login with standard_user verified by checking the visibility of the webshop header.
                    """);
        }

        [Test, Order(2), Retry(2)]
        public async Task Login_locked_out_user()
        {
            await sauceDemoLoginPage.GoToLoginSauceDemoPage();
            await sauceDemoLoginPage.EnterUsername("locked_out_user");
            await sauceDemoLoginPage.EnterPassword("secret_sauce");
            await sauceDemoLoginPage.ClickLoginButton();
            await Expect(sauceDemoLoginPage._errorMessage).ToContainTextAsync("Epic sadface: Sorry, this user has been locked out.");
            Console.WriteLine("""   
                    Successful verification of locked out user by checking the error message displayed upon login attempt.
                    """);
        }

        [Test, Order(3), Retry(2)]
        public async Task Login_problem_user()
        {
            await sauceDemoLoginPage.GoToLoginSauceDemoPage();
            await sauceDemoLoginPage.EnterUsername("problem_user");
            await sauceDemoLoginPage.EnterPassword("secret_sauce");
            await sauceDemoLoginPage.ClickLoginButton();
            await Expect(sauceDemoLoginPage._headerWebshop).ToBeVisibleAsync();
            Console.WriteLine("""   
                    Successful login with problem_user verified by checking the visibility of the webshop header.
                    """);
        }
    }
}
