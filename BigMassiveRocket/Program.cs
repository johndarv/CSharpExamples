using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.BigMassiveRocket
{
    class Program
    {
        static void Main(string[] args)
        {
            BigMassiveRocket rocket = new BigMassiveRocket();

            BigRedButton redButton = new BigRedButton();
            BigBlueButton blueButton = new BigBlueButton();
            
            // Here we can subscribe to the OnButtonPush event from outside of the class, because the event is public.
            // HOWEVER we do not have permissions to call redButton.OnButtonPush() to invoke all subscribers.
            // The ability to invoke like this is nicely hidden away within the class.
            redButton.OnButtonPush += rocket.Launch;

            // Here we have had to use a RegisterHandler method to separate the private delegate away from anything outside of the class.
            // If we had made blueButton.onButtonPush public, then we would be able to invoke it with blueButton.OnButtonPush().
            // This is the main difference between events and delegates. Events provide a nice clean way of hiding the ability to invoke
            // from anything outside of the "publisher" class. This is similar to the way that properties differ from fields.
            blueButton.RegisterHandler(rocket.Launch);

            Console.WriteLine("You are in a dark room. There is a big red button and a big blue button.");
            
            TypeIntructions();

            ReceiveInput(redButton, blueButton);
        }

        private static void ReceiveInput(BigRedButton redButton, BigBlueButton blueButton)
        {
            string input = string.Empty;

            while (input != "quit" && input != "q")
            {
                input = Console.ReadLine();
                if (input == "push red")
                {
                    redButton.Push();
                }
                else if (input == "push blue")
                {
                    blueButton.Push();
                }
                else
                {
                    TypeIntructions();
                }
            }
        }

        private static void TypeIntructions()
        {
            Console.WriteLine("Type \"push red\" to push the big red button and \"push blue\" to push the big blue button.");
        }
    }

    delegate void ButtonPushHandler();

    /// <summary>
    /// A class that demonstrates delegates.
    /// <remarks>
    /// /// It implements IButtonThatUsesDelegates to demonstrate that we can't specify delegate instances in interfaces, we have to
    /// use a method instead.
    /// </remarks>
    /// </summary>
    class BigBlueButton : IButton, IButtonThatUsesDelegates
    {
        private ButtonPushHandler onButtonPush;

        public void RegisterHandler(ButtonPushHandler handler)
        {
            this.onButtonPush += handler;
        }

        public void Push()
        {
            this.onButtonPush();
        }
    }

    /// <summary>
    /// A class that demonstrates events.
    /// <remarks>
    /// It implements IButtonThatUsesEvents to demonstrate that events can be specified in interfaces.
    /// <remarks>
    /// </summary>
    class BigRedButton : IButton, IButtonThatUsesEvents
    {
        public event ButtonPushHandler OnButtonPush;

        public void Push()
        {
            this.OnButtonPush();
        }
    }

    class BigMassiveRocket
    {
        public void Launch()
        {
            Console.WriteLine("Launching Big Massive Rocket!!");
        }
    }

    interface IButtonThatUsesEvents
    {
        event ButtonPushHandler OnButtonPush;
    }

    interface IButtonThatUsesDelegates
    {
        void RegisterHandler(ButtonPushHandler handler);
    }

    interface IButton
    {
        void Push();
    }
}
