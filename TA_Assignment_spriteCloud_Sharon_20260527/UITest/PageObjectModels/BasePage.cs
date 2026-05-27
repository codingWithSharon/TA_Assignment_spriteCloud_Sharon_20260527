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
}