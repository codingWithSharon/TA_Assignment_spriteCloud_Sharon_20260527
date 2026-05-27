using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Assignment_spriteCloud_Sharon_20260527.APITest.Models.Requests
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class AddProductToCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
