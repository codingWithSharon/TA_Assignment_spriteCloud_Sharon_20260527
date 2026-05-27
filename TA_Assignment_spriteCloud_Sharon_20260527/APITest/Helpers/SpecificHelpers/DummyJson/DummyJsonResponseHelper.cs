//using Microsoft.Playwright;
using Microsoft.Playwright;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Responses;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson
{
    public class DummyJsonResponseHelper
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<LoginResponse> GetLoginResponse(IAPIResponse response)
        {
            var json = await response.TextAsync();

            return JsonSerializer.Deserialize<LoginResponse>(json, _jsonOptions)
                ?? throw new InvalidOperationException("Failed to deserialize LoginResponse.");
        }

        public async Task<string> GetAccessToken(IAPIResponse response)
        {
            var loginResponse = await GetLoginResponse(response);

            return loginResponse.AccessToken
                ?? throw new InvalidOperationException("AccessToken was null in login response.");
        }

        public async Task<ProductResponse> GetProductResponse(IAPIResponse response)
        {
            var responseBody = await response.TextAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ProductResponse>(responseBody, options);
        }
    }
}