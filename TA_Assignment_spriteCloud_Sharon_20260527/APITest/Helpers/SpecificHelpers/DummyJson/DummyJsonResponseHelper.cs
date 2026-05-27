using Microsoft.Playwright;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Responses;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson
{
    public class DummyJsonResponseHelper
    {
        // Login methods
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

        // Product methods
        public async Task<ProductResponse> GetProductResponse(IAPIResponse response)
        {
            var responseBody = await response.TextAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ProductResponse>(responseBody, options);
        }

        // Cart methods
        public async Task<CartResponse> GetCartResponse(IAPIResponse response)
        {
            var responseBody = await response.TextAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<CartResponse>(responseBody, options);
        }

        public async Task<DeleteCartResponse> GetDeleteCartResponse(IAPIResponse response)
        {
            var responseBody = await response.TextAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<DeleteCartResponse>(responseBody, options);
        }

        // Error validation methods

        // Login error method
        public async Task<ErrorResponse> GetLoginErrorResponse(IAPIResponse response)
        {
            var json = await response.TextAsync();
            return JsonSerializer.Deserialize<ErrorResponse>(json, _jsonOptions)
                ?? throw new InvalidOperationException("Failed to deserialize ErrorResponse.");
        }
    }
}