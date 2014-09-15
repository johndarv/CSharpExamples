using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace JohnDarv.CSharp.Examples.OwinSelfHost
{
    public class TestController : ApiController
    {
        // GET api/test
        public string Get()
        {
            return "I am working!";
        }

        // GET api/test/john
        public string Get(string name)
        {
            return string.Format("I am working, {0}!", name);
        }
    }
}
