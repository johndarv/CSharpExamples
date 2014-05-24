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
            if (OnlyMutexExampleProgramRunning())
            {
                Console.WriteLine("This is the only Mutex Example Program running on this computer.");
            }
            else
            {
                Console.WriteLine("There is another Mutex Example Program running on this computer.");
            }

            Console.WriteLine("Please specify in seconds how long you want to get the mutex signal for...");

            string input = string.Empty;

            while (input != "quit" && input != "q")
            {
                input = Console.ReadLine();

                int seconds;
                bool isNumber = int.TryParse(input, out seconds);

                if (isNumber)
                {
                    TryMonopoilzeMutex(TimeSpan.FromSeconds(seconds));
                }
            }

            Program.mutex.Close();
            Program.mutex.Dispose();
        }

        static bool OnlyMutexExampleProgramRunning()
        {
            try
            {
                Program.mutex = Mutex.OpenExisting(uniqueMutexName);
            }
            catch (Exception ex)
            {
                Program.mutex = new Mutex(false, uniqueMutexName);

                // This must be the only instance running
                return true;
            }

            // There was at least one other instance running
            return false;
        }

        static void TryMonopoilzeMutex(TimeSpan timespan)
        {
            Console.WriteLine("Trying to Monopolize Mutex...");
            bool wasAbleToMonopolize = Program.mutex.WaitOne(0);

            if (wasAbleToMonopolize)
            {
                Console.WriteLine("I got a signal! Waiting for {0} seconds...", timespan.Seconds);
                
                Thread.Sleep(timespan);

                Console.WriteLine("Releasing Mutex now!");
                Program.mutex.ReleaseMutex();
            }
            else
            {
                Console.WriteLine("Another program has the signal for now...");
            }
        }
    }
}
