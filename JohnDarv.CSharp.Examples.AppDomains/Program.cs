using JohnDarv.CSharp.Examples.Mutexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.AppDomains
{
    class Program
    {
        private const string uniqueMutexName = "MutexExample";

        static void Main(string[] args)
        {
            AppDomain appDomain1 = AppDomain.CreateDomain("App Domain 1");
            AppDomain appDomain2 = AppDomain.CreateDomain("App Domain 2");
            AppDomain appDomain3 = AppDomain.CreateDomain("App Domain 3");

            // Create a MutexMonopolizer that grabs the Mutex after 1 second
            Thread thread1 = new Thread(new ThreadStart(() => appDomain1.DoCallBack(() => Something("MutexMonopolizer1", 1))));

            // Create a MutexMonopolizer that attempts to grab the Mutex after 3 seconds, but will fail
            Thread thread2 = new Thread(new ThreadStart(() => appDomain2.DoCallBack(() => Something("MutexMonopolizer2", 3))));

            // // Create a MutexMonopolizer that attempts to grab the Mutex after 7 seconds, and will succeed
            Thread thread3 = new Thread(new ThreadStart(() => appDomain3.DoCallBack(() => Something("MutexMonopolizer3", 7))));

            // Start all of the MutexMonopolizers in all the different AppDomains
            // The Thread.Sleeps seem to be necessary to stop the threads starting in a random order (?!)
            thread1.Start();
            Thread.Sleep(TimeSpan.FromSeconds(0.01));
            thread2.Start();
            Thread.Sleep(TimeSpan.FromSeconds(0.01));
            thread3.Start();

            Console.ReadLine();
        }

        static void Something(string name, int delayInSeconds)
        {
            MutexMonopolizer mutexMonopolizer = new MutexMonopolizer(name, uniqueMutexName);

            mutexMonopolizer.OnlyMutexTesterRunning();

            Thread.Sleep(TimeSpan.FromSeconds(delayInSeconds));

            mutexMonopolizer.TryMonopoilzeMutex(TimeSpan.FromSeconds(5));
        }
    }
}
