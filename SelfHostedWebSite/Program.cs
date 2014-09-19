using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    class Program
    {
        static void Main(string[] args)
        {
            // In order self host, we need to install Microsoft.Owin.SelfHost and use the static
            // start method of this WebApp class.
            using (WebApp.Start<CustomStartup>("http://localhost:5000"))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}