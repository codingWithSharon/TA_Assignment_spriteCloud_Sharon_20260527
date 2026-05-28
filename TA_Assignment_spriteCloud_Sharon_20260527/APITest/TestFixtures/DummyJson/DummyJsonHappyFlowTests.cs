using NUnit.Framework;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson;
using _001_AT_How_to_set_up_a_test_automation_project.APITests;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Responses;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Requests;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.TestFixtures.DummyJson
{
    [TestFixture]
    [Category("API")]
    public class DummyJsonHappyFlowTests : ApiSetup
    {
        [SetUp]
        public void SetUp()
        {
            dummyJsonRequestHelper = new DummyJsonRequestHelper(Api);
            dummyJsonResponseHelper = new DummyJsonResponseHelper();
        }

        [Test, Order(1)]
        public async Task POST_RequestLoginSuccesfully()
        {
            var credentials = DummyJsonRequestHelper.SelectUserCredentials.User1();
            var response = await dummyJsonRequestHelper.Login(credentials);
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine("POST Call for Successfull login");
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
        public async Task GET_RequestAndValidateProductSuccessfully()
        {
            var response = await dummyJsonRequestHelper.GetSingleProduct("products/1");
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine("GET Call for request product with id 1");
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
                Assert.That(productResponse.Price, Is.GreaterThan(0));
                Assert.That(productResponse.Rating, Is.InRange(0, 5));
                Assert.That(productResponse.Stock, Is.GreaterThanOrEqualTo(0));
            });
        }

        [Test, Order(3)]
        public async Task POST_Add3ProductsToCartSuccesfully()
        {
            var cartRequest = new AddProductToCartRequest
            {
                UserId = 1,
                Products = new List<CartProduct>
                {
                    new CartProduct { Id = 1, Quantity = 2 },
                    new CartProduct { Id = 2, Quantity = 1 },
                    new CartProduct { Id = 3, Quantity = 3 }
                }
            };

            var addResponse = await dummyJsonRequestHelper.AddProducts(cartRequest);
            var responseBody = await addResponse.TextAsync();

            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine("POST Call for add 3 products to cart");
            Console.WriteLine($"URL: {dummyJsonRequestHelper.DummyJsonBaseUrl}carts/add");
            Console.WriteLine($"UserId: {cartRequest.UserId}");
            Console.WriteLine($"Products: {string.Join(", ", cartRequest.Products.Select(p => $"Id={p.Id} Qty={p.Quantity}"))}");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status: {addResponse.Status}");
            Console.WriteLine($"Body: {responseBody}");

            Assert.That(addResponse.Status, Is.EqualTo(201),
                $"Expected 201 Created but got {addResponse.Status}");

            var cartResponse = await dummyJsonResponseHelper.GetCartResponse(addResponse);
            Assert.That(cartResponse, Is.Not.Null, "Response could not be deserialized into CartResponse");

            Assert.Multiple(() =>
            {
                Assert.That(cartResponse.Products, Has.Count.EqualTo(3),
                    "Cart should contain exactly 3 products");
                var returnedIds = cartResponse.Products.Select(p => p.Id);
                Assert.That(returnedIds, Is.EquivalentTo(new[] { 1, 2, 3 }),
                    "Returned product IDs should match the ones sent");
                Assert.That(cartResponse.UserId, Is.EqualTo(1),
                    "UserId should be 1");
                Assert.That(cartResponse.TotalProducts, Is.EqualTo(3),
                    "Cart should contain 3 products");
                Assert.That(cartResponse.TotalQuantity, Is.EqualTo(6),
                    "Total quantity should be 6 (2+1+3)");
                Assert.That(cartResponse.Total, Is.GreaterThan(0),
                    "Total should be greater than 0");
            });
        }

        [Test, Order(4)]
        public async Task DELETE_CartSuccessfully()
        {
            var response = await dummyJsonRequestHelper.DeleteCart("carts/1");
            var responseBody = await response.TextAsync();
            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine("DELETE Call for deleting entire cart");
            Console.WriteLine($"URL: {dummyJsonRequestHelper.DummyJsonBaseUrl}carts/1");
            Console.WriteLine("=== RESPONSE ===");
            Console.WriteLine($"Status: {response.Status}");
            Console.WriteLine($"Body: {responseBody}");

            Assert.That(response.Status, Is.EqualTo(200),
                $"Expected 200 OK but got {response.Status}");

            var deleteResponse = await dummyJsonResponseHelper.GetDeleteCartResponse(response);
            Assert.That(deleteResponse, Is.Not.Null, "Response could not be deserialized into CartResponse");
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.Id, Is.EqualTo(1),
                    "Deleted cart ID should be 1");
                Assert.That(deleteResponse.UserId, Is.EqualTo(1),
                    "Deleted cart UserId should be 1");
                Assert.That(deleteResponse.IsDeleted, Is.True,
                    "Deleted cart should have no products");
            });
        }
    }
}