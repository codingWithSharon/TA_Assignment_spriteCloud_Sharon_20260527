using NUnit.Framework;
using Microsoft.Playwright;
//using _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.SpecificHelper;
//using _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.GenericHelper;
using TA_Assignment_spriteCloud_Sharon_20260527.UITest.PageObjectModels.SauceDemoPages;

namespace _001_AT_How_to_set_up_a_test_automation_project.APITests;

public class ApiSetup
{
    protected IAPIRequestContext Api { get; private set; } = null!;

    // protected RequestHelper requestHelper = null!;

    protected SauceDemoLoginPage sauceDemoHomePage = null!;
    //protected VroegPiekenHelper vroegPiekenHelper = null!;
    //protected AutomationExerciseHelper automationExerciseHelper = null!;

    [OneTimeSetUp]
    public async Task Setup()
    {
        var playwright = await Playwright.CreateAsync();

        Api = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            Timeout = 300000
        });

        // Generic API Helper initialization
        //RequestHelper requestHelper = new RequestHelper(Api);

        // API Specific helpers initialization
        //vroegPiekenHelper = new VroegPiekenHelper(Api);
        //automationExerciseHelper = new AutomationExerciseHelper(Api);
    }

    [OneTimeTearDown]
    public async Task Teardown()
    {
        await Api.DisposeAsync();
    }
}