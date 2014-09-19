using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.Mutexes
{
    class Program
    {
        private const string uniqueMutexName = "MutexExample";

        static void Main(string[] args)
        {
            using (MutexMonopolizer mutexTester = new MutexMonopolizer(SetMutexTesterName(args), uniqueMutexName))
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

        private static string SetMutexTesterName(string[] args)
        {
            if (args.Length > 0)
            {
                return args[0];
            }
            else
            {
                return "MutexMonopolizer" + DateTime.Now.Ticks;
            }
        }
    }
}
