using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson;
using TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages;

namespace PagesSetup;

public class Setup : ContextTest
{
    public IAPIRequestContext IAPIRequestContext { get; private set; } = null!;
    public IPage Page { get; private set; } = null!;

    // UI
    public SauceDemoLoginPage sauceDemoLoginPage = null!;

    // API
    public DummyJsonRequestHelper dummyJsonRequestHelper = null!;
    public DummyJsonResponseHelper dummyJsonResponseHelper = null!;

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            Locale = "nl-NL",
            TimezoneId = "Europe/Amsterdam",
            ViewportSize = new() { Width = 1920, Height = 1080 },
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
            BypassCSP = true,
            Permissions = new[] { "geolocation" },
            Geolocation = new() { Latitude = 52.3702f, Longitude = 4.8952f },
        };
    }

    public bool _tracingStarted = false;

    [SetUp]
    public async Task StartTracing()
    {
        await Context.Tracing.StartAsync(new() { Screenshots = true, Snapshots = true, Sources = true });

        Page = await Context.NewPageAsync();

        IAPIRequestContext = await GlobalSetup.Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            Timeout = 150000
        });

        sauceDemoLoginPage = new SauceDemoLoginPage(Page);
    }

    [TearDown]
    public async Task StopTracing()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var path = Path.Combine(TestContext.CurrentContext.WorkDirectory,
                "traces",
                $"{TestContext.CurrentContext.Test.Name}.zip");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await Context.Tracing.StopAsync(new() { Path = path });
        }
        else
        {
            await Context.Tracing.StopAsync();
        }

        await IAPIRequestContext.DisposeAsync();
    }
}