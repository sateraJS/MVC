using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Services
{
    public class TestService : ITestService
    {
        public string GetString()
        {
            return "Hello!";
        }
    }
}
