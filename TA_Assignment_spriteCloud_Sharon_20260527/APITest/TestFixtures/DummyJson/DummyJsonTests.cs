using NUnit.Framework;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson;
using _001_AT_How_to_set_up_a_test_automation_project.APITests;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Responses;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.TestFixtures.DummyJson
{
    [TestFixture]
    public class AutomationExerciseApiTests : ApiSetup
    {
        [SetUp]
        public void SetUp()
        {
            dummyJsonRequestHelper = new DummyJsonRequestHelper(Api);
            dummyJsonResponseHelper = new DummyJsonResponseHelper();
        }

        [Test, Order(1)]
        [Category("API_POST")]
        public async Task POST_RequestLoginSuccesfully()
        {
            var credentials = DummyJsonRequestHelper.SelectUserCredentials.User1();
            var response = await dummyJsonRequestHelper.Login(credentials);
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine($"URL:      {dummyJsonRequestHelper.DummyJsonBaseUrl}/auth/login");
            Console.WriteLine($"Username: {credentials.username}");
            Console.WriteLine($"Password: {credentials.password}");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status:   {response.Status}");
            Console.WriteLine($"Body:     {responseBody}");
            
            Assert.That(response.Status, Is.EqualTo(200),
                $"Expected 200 OK but got {response.Status}");

            var loginResponse = await dummyJsonResponseHelper.GetLoginResponse(response);

            Assert.Multiple(() =>
            {
                Assert.That(loginResponse.AccessToken, Is.Not.Null.And.Not.Empty,
                    "AccessToken should not be empty");
                Assert.That(loginResponse.RefreshToken, Is.Not.Null.And.Not.Empty,
                    "RefreshToken should not be empty");
                Assert.That(loginResponse.Id, Is.GreaterThan(0),
                    "User Id should be a positive integer");
                Assert.That(loginResponse.Username, Is.EqualTo(credentials.username),
                    "Returned username should match the one sent");
            });
        }

        [Test, Order(2)]
        [Category("API_GET")]
        public async Task GET_RequestAndValidateProductSuccessfully()
        {
            var response = await dummyJsonRequestHelper.GetSingleProduct("products/1");
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine($"URL: {dummyJsonRequestHelper.DummyJsonBaseUrl}products/1");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status: {response.Status}");
            Console.WriteLine($"Body: {responseBody}");

            Assert.That(response.Status, Is.EqualTo(200),
                $"Expected 200 OK but got {response.Status}");

            var productResponse = await dummyJsonResponseHelper.GetProductResponse(response);

            Assert.That(productResponse, Is.Not.Null, "Response body could not be deserialized into ProductResponse");

            Assert.Multiple(() =>
            {
                Assert.That(productResponse.Id, Is.EqualTo(1),
                    "Product ID should be 1");
                Assert.That(productResponse.Title, Is.EqualTo("Essence Mascara Lash Princess"),
                    "Product title should be 'Essence Mascara Lash Princess'");
                Assert.That(productResponse.Brand, Is.EqualTo("Essence"),
                    "Product brand should be 'Essence'");
                Assert.That(productResponse.Category, Is.EqualTo("beauty"),
                    "Product category should be 'beauty'");
                Assert.That(productResponse.Sku, Is.EqualTo("BEA-ESS-ESS-001"),
                    "Product SKU should be 'BEA-ESS-ESS-001'");
                Assert.That(productResponse.Description, Is.Not.Null.And.Not.Empty,
                    "Description should not be empty");
            });
        }

        //[Test, Order(3)]
        //[Category("API_POST")]
        //public async Task POST_Add3ProductsToCartSuccesfully()
        //{

        //}


    }
}