﻿using System;
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
            Console.WriteLine("Time taken to create thing: {0}.", stopwatch.Elapsed.ToString(@"s\.ffffff"));

            stopwatch.Reset();

            stopwatch.Start();
            OptimalThing optimalThing = new OptimalThing();
            stopwatch.Stop();
            Console.WriteLine("Time taken to create thing: {0}.", stopwatch.Elapsed.ToString(@"s\.ffffff"));

            Console.ReadLine();
        }
    }

    class Thing
    {
        ThingThatTakesAgesToCreate thing = new ThingThatTakesAgesToCreate();
    }

    class OptimalThing
    {
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
