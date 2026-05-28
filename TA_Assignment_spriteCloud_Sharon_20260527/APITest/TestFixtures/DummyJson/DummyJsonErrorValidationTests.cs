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

        [Test, Order(1)]
        public async Task GET_NonExistentPost_Returns404()
        {
            var response = await dummyJsonRequestHelper.GetSinglePost("posts/99999");
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine($"URL: {dummyJsonRequestHelper.DummyJsonBaseUrl}posts/99999");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status: {response.Status}");
            Console.WriteLine($"Body: {responseBody}");

            Assert.That(response.Status, Is.EqualTo(404),
                $"Expected 404 Not Found but got {response.Status}");
        }

        [Test, Order(2)]
        public async Task GET_NonExistentComment_Returns404()
        {
            var response = await dummyJsonRequestHelper.GetSingleComment("comments/99999");
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine($"URL: {dummyJsonRequestHelper.DummyJsonBaseUrl}comments/99999");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status: {response.Status}");
            Console.WriteLine($"Body: {responseBody}");

            Assert.That(response.Status, Is.EqualTo(404),
                $"Expected 404 Not Found but got {response.Status}");
        }
    }
}

