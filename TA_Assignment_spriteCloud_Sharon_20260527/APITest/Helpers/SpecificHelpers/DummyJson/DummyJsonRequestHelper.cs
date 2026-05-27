using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Requests;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson
{
    public class DummyJsonRequestHelper
    {
        private readonly IAPIRequestContext _context;

        public readonly string DummyJsonBaseUrl =
           Environment.GetEnvironmentVariable("DummyJsonBaseUrl")
           ?? throw new InvalidOperationException("DummyJsonBaseUrl not set.");

        public DummyJsonRequestHelper(IAPIRequestContext context)
        {
            _context = context;
        }

        // GET request methods
        public async Task<IAPIResponse> GetSingleProduct(string endpoint)
        {
            return await _context.GetAsync($"{DummyJsonBaseUrl}{endpoint}");
        }

        // POST request methods
        public async Task<IAPIResponse> Login(LoginRequest credentials)
        {
            var requestBody = new
            {
                username = credentials.username,
                password = credentials.password
            };
            return await _context.PostAsync($"{DummyJsonBaseUrl}/auth/login", new APIRequestContextOptions
            {
                DataObject = requestBody
            });
        }

        public async Task<IAPIResponse> AddProducts(AddProductToCartRequest request)
        {
            var requestBody = new
            {
                userId = request.UserId,
                products = request.Products.Select(p => new
                {
                    id = p.Id,
                    quantity = p.Quantity
                }).ToList()
            };

            return await _context.PostAsync($"{DummyJsonBaseUrl}carts/add", new APIRequestContextOptions
            {
                DataObject = requestBody
            });
        }

        // DELETE request methods
        public async Task<IAPIResponse> DeleteCart(string endpoint)
        {
            return await _context.DeleteAsync($"{DummyJsonBaseUrl}{endpoint}");
        }

        // Helper request functions
        public static class SelectUserCredentials
        {
            public static LoginRequest User1() => new() { username = "emilys", password = "emilyspass" };
            public static LoginRequest User2() => new() { username = "Michaelw", password = "michaelwpass" };
            public static LoginRequest User3() => new() { username = "emilys", password = "pasword" };
        }
    }
}