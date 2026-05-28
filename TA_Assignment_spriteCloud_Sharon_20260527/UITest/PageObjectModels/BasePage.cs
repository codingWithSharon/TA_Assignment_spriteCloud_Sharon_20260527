using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace TA_Assignment_spriteCloud_Sharon_20260527.UITests.PageObjectModels;

public abstract class BasePage : ContextTest
{
    public IPage Page { get; private set; } = null!;

    public BasePage(IPage page)
    {
        Page = page;
    }

    public readonly string SauceDemoBaseUrl = Environment.GetEnvironmentVariable("SauceDemoBaseUrl");

    #region SauceDemo specific locators
    public ILocator _pageTitle => Page.Locator("[data-test='title']");
    #endregion

    public async Task PageLauncher(string baseUrl, string pageExtension = "")
    {
        var fullUrl = new Uri(new Uri(baseUrl), pageExtension).ToString();

        await Page.GotoAsync(fullUrl, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle,
            Timeout = 30_000
        });

        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }
}