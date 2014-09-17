using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Host;
using Microsoft.Owin.Hosting;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:5000");

            using (WebApp.Start<Startup>(baseAddress.AbsoluteUri))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}