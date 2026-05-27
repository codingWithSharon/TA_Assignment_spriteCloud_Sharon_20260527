using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.Helpers.SpecificHelpers.DummyJson
{
    public class DummyJsonResponseHelper
    {
        private readonly IAPIRequestContext _context;

        public DummyJsonResponseHelper(IAPIRequestContext context)
        {
            _context = context;
        }

        // GET request methods
        //public async Task<IAPIResponse> PostAsyncJson(string endpoint, object? data = null, Dictionary<string, string>? headers = null)
        //{
        //    var requestOptions = new APIRequestContextOptions
        //    {
        //        DataObject = data,
        //        Headers = headers
        //    };

        //    return await _context.PostAsync($"{AutomationExerciseBaseUrl}{endpoint}", requestOptions);
        //}
    }
}