using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.MutexProgram
{
    public sealed class MutexTester : IDisposable
    {
        private readonly string uniqueMutexName;
        private Mutex mutex;

        public MutexTester(string uniqueMutexName)
        {
            this.uniqueMutexName = uniqueMutexName;
        }

        public bool OnlyMutexTesterRunning()
        {
            try
            {
                this.mutex = Mutex.OpenExisting(uniqueMutexName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                Console.WriteLine("This is the only MutexTester running on this computer.");

                this.mutex = new Mutex(false, uniqueMutexName);

                return true;
            }

            Console.WriteLine("There is another Mutex Example Program running on this computer.");

            return false;
        }

        public void TryMonopoilzeMutex(TimeSpan timespan)
        {
            Console.WriteLine("Trying to Monopolize Mutex...");
            bool wasAbleToMonopolize = this.mutex.WaitOne(0);

            if (wasAbleToMonopolize)
            {
                Console.WriteLine("I got a signal! Waiting for {0} seconds...", timespan.Seconds);

                Thread.Sleep(timespan);

                Console.WriteLine("Releasing Mutex now!");
                this.mutex.ReleaseMutex();
            }
            else
            {
                Console.WriteLine("Another program has the signal for now...");
            }
        }

        public void Dispose()
        {
            this.mutex.Close();
            this.mutex.Dispose();
        }
    }
}
