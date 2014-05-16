using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharpExamples.BigMassiveRocket
{
    class Program
    {
        static void Main(string[] args)
        {
            BigMassiveRocket rocket = new BigMassiveRocket();

            ButtonPushHandler handler = rocket.Launch;

            BigRedButton button = new BigRedButton();
            button.RegisterHandler(handler);

            string input = string.Empty;

            while (input != "quit" && input != "q")
            {
                Console.WriteLine("You are in a dark room. There is a big red button. Type \"push\" to push the big red button.");
                input = Console.ReadLine();
                if (input == "push")
                {
                    button.Push();
                }
            }
        }
    }

    delegate void ButtonPushHandler();

    class BigRedButton
    {
        private event ButtonPushHandler OnButtonPush;

        public void RegisterHandler(ButtonPushHandler handler)
        {
            OnButtonPush += handler;
        }

        public void Push()
        {
            OnButtonPush();
        }
    }

    class BigMassiveRocket
    {
        public void Launch()
        {
            Console.WriteLine("Launching Big Massive Rocket!!");
        }
    }
}
