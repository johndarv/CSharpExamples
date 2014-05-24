using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.MutexProgram
{
    class Program
    {
        private const string uniqueMutexName = "MutexExample";

        private static Mutex mutex;

        static void Main(string[] args)
        {
            using (MutexTester mutexTester = new MutexTester(uniqueMutexName))
            {
                mutexTester.OnlyMutexTesterRunning();

                Console.WriteLine("Please specify in seconds how long you want to get the mutex signal for...");

                string input = string.Empty;

                while (input != "quit" && input != "q")
                {
                    input = Console.ReadLine();

                    int seconds;
                    bool isNumber = int.TryParse(input, out seconds);

                    if (isNumber)
                    {
                        mutexTester.TryMonopoilzeMutex(TimeSpan.FromSeconds(seconds));
                    }
                }
            }
        }
    }
}
