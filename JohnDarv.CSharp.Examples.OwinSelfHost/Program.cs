using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace JohnDarv.CSharp.Examples.OwinSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8123");

            //using (WebApp.Start<Startup>(baseAddress.AbsoluteUri))
            //{
            //    Console.ReadLine();
            //}

            IDisposable host = WebApp.Start<Startup>("http://localhost:8123");

            Console.ReadLine();

            host.Dispose();
        }
    }
}
