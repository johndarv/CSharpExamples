using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.EventWaitHandles
{
    class Program
    {
        private const string uniqueHandleName = "AUniqueName123";

        static void Main(string[] args)
        {
            EventWaitHandle handle = new EventWaitHandle(false, EventResetMode.AutoReset, uniqueHandleName);

            AppDomain appDomain1 = AppDomain.CreateDomain("App Domain 1");

            Thread thread1 = new Thread(new ThreadStart(() => appDomain1.DoCallBack(() =>
                {
                    EventHandleResponder responder = new EventHandleResponder();
                    responder.Run();
                })));

            thread1.Start();

            Console.WriteLine("Enter 1 to set the signal on the wait handle.");
            Console.WriteLine("Enter q to quit.");

            string input = string.Empty;

            while (input != "quit" && input != "q")
            {
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        handle.Set();
                        break;
                }
            }
        }
    }

    class EventHandleResponder
    {
        private const string uniqueHandleName = "AUniqueName123";

        public void Run()
        {
            EventWaitHandle handle = new EventWaitHandle(false, EventResetMode.AutoReset, uniqueHandleName);

            bool timedOut = false;

            while (!timedOut)
            {
                if (!handle.WaitOne(TimeSpan.FromSeconds(5)))
                {
                    timedOut = true;
                    Console.WriteLine("Timed out...");
                }
                else
                {
                    Console.WriteLine("Signal has been set!");
                }
            }
        }
    }
}
