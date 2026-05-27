using NUnit.Framework;
using Microsoft.Playwright;
using TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests;

public class ApiSetup
{
    protected IAPIRequestContext Api { get; private set; } = null!;

    protected DummyJsonRequestHelper dummyJsonRequestHelper = null!;
    protected DummyJsonResponseHelper dummyJsonResponseHelper = null!;

    [OneTimeSetUp]
    public async Task Setup()
    {
        var playwright = await Playwright.CreateAsync();

        Api = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            Timeout = 300000
        });
    }

    [OneTimeTearDown]
    public async Task Teardown()
    {
        await Api.DisposeAsync();
    }
}