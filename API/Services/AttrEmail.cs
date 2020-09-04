using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class AttrEmail
    {
        public string mail = "Your email";
        public string pass = "Your Pass";
    }

    public class RandomDigit
    {
        private Random _random = new Random();
        public string GenerateRandom()
        {
            return _random.Next(0, 9999).ToString("D4");
        }
    }
}
