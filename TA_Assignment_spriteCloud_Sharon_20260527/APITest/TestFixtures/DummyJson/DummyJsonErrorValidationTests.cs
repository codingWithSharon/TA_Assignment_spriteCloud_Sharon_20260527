using NUnit.Framework;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson;
using _001_AT_How_to_set_up_a_test_automation_project.APITests;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Responses;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Requests;


namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.TestFixtures.DummyJson
{
    [TestFixture]
    [Category("API")]
    public class DummyJsonErrorValidationTests : ApiSetup
    {
        [SetUp]
        public void SetUp()
        {
            dummyJsonRequestHelper = new DummyJsonRequestHelper(Api);
            dummyJsonResponseHelper = new DummyJsonResponseHelper();
        }

        // ===================================[ TEST DISABLED DUE TO A BUG, REPORTED ON 27-05-2026 ]
        //[Test, Order(1)]
        //public async Task POST_RequestLoginIncorrectUsernameFailed()
        //{
        //    var credentials = DummyJsonRequestHelper.SelectUserCredentials.User2();
        //    var response = await dummyJsonRequestHelper.Login(credentials);
        //    var responseBody = await response.TextAsync();
        //    Console.WriteLine("=== REQUEST ===");
        //    Console.WriteLine($"URL:      {dummyJsonRequestHelper.DummyJsonBaseUrl}/auth/login");
        //    Console.WriteLine($"Username: {credentials.username}");
        //    Console.WriteLine($"Password: {credentials.password}");
        //    Console.WriteLine("=== RESPONSE ===");
        //    Console.WriteLine($"Status:   {response.Status}");
        //    Console.WriteLine($"Body:     {responseBody}");


        //    var loginErrorResponse = await dummyJsonResponseHelper.GetLoginErrorResponse(response);

        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(response.Status, Is.EqualTo(400),
        //            $"Expected 400 OK but got {response.Status}");
        //        Assert.That(loginErrorResponse.Message, Is.Not.Null.And.Not.Empty,
        //            "Error response should contain a message");
        //    });
        // }

        [Test, Order(1)]
        public async Task POST_RequestLoginIncorrectEmailFailed()
        {
            var credentials = DummyJsonRequestHelper.SelectUserCredentials.User3();
            var response = await dummyJsonRequestHelper.Login(credentials);
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine($"URL:      {dummyJsonRequestHelper.DummyJsonBaseUrl}/auth/login");
            Console.WriteLine($"Username: {credentials.username}");
            Console.WriteLine($"Password: {credentials.password}");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status:   {response.Status}");
            Console.WriteLine($"Body:     {responseBody}");
            var loginErrorResponse = await dummyJsonResponseHelper.GetLoginErrorResponse(response);
            Assert.Multiple(() =>
            {
                Assert.That(response.Status, Is.EqualTo(400),
                    $"Expected 400 Bad Request but got {response.Status}");
                Assert.That(loginErrorResponse.Message, Is.EqualTo("Invalid credentials"),
                    "Error response message should be 'Invalid credentials'");
            });
        }
    }
}

