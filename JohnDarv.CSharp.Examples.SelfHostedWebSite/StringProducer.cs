using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    public class StringProducer
    {
        public string ProduceString(string message)
        {
            return "Hello, you entered: " + message + "!";
        }
    }
}
