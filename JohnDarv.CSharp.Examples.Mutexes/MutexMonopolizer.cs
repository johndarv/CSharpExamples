using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.Mutexes
{
    public sealed class MutexMonopolizer : IDisposable
    {
        private readonly string name; 
        private readonly string uniqueMutexName;
        private Mutex mutex;

        public MutexMonopolizer(string name, string uniqueMutexName)
        {
            this.name = name;
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
                Console.WriteLine("'{0}' is the only MutexTester running on this computer.", this.name);

                this.mutex = new Mutex(false, uniqueMutexName);

                return true;
            }

            Console.WriteLine("'{0}' detects that there is another MutexTester running on this computer.", this.name);

            return false;
        }

        public void TryMonopoilzeMutex(TimeSpan timespan)
        {
            Console.WriteLine("'{0}' is trying to monopolize the Mutex...", this.name);
            bool wasAbleToMonopolize = this.mutex.WaitOne(0);

            if (wasAbleToMonopolize)
            {
                Console.WriteLine("'{0}' got a signal! Waiting for {1} seconds...", this.name, timespan.Seconds);

                Thread.Sleep(timespan);

                Console.WriteLine("'{0}' is releasing the Mutex now!", this.name);
                this.mutex.ReleaseMutex();
            }
            else
            {
                Console.WriteLine("'{0}' detects that another MutexMonopolizer has the signal right now...", this.name);
            }
        }

        public void Dispose()
        {
            this.mutex.Close();
            this.mutex.Dispose();
        }
    }
}
