using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.LazyInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Thing thing = new Thing();
            stopwatch.Stop();
            Console.WriteLine("Time take to create thing: {0}", stopwatch.Elapsed);

            stopwatch.Start();
            OptimalThing optimalThing = new OptimalThing();
            stopwatch.Stop();
            Console.WriteLine("Time take to create optimal thing: {0}", stopwatch.Elapsed);

            Console.ReadLine();
        }
    }

    class Thing
    {
        private string str1 = "Hello";
        private string str2 = "World!";
        ThingThatTakesAgesToCreate thing = new ThingThatTakesAgesToCreate();
    }

    class OptimalThing
    {
        string str1 = "Hello";
        string str2 = "World!";
        Lazy<ThingThatTakesAgesToCreate> lazyThing = new Lazy<ThingThatTakesAgesToCreate>();
    }

    class ThingThatTakesAgesToCreate
    {
        public ThingThatTakesAgesToCreate()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
