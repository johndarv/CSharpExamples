using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ThingWithUniqueId> things = new List<ThingWithUniqueId>()
            {
                new ThingWithUniqueId(10),
                new ThingWithUniqueId(55)
            };

            IList<Thread> threads = new List<Thread>();

            SharedResourceWithoutLock withoutLock = new SharedResourceWithoutLock(0);
            SharedResourceWithLock withLock = new SharedResourceWithLock(0);

            things.OrderBy(t => t.Id);

            foreach (ThingWithUniqueId thing in things)
            {
                threads.Add(new Thread(new ThreadStart(() => withoutLock.UpdateTheNumber(thing.Id))));
                threads.Add(new Thread(new ThreadStart(() => withLock.UpdateTheNumber(thing.Id))));
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Console.WriteLine("The number of shared resource *without* the lock is: {0}", withoutLock.GetTheNumber());
                Console.WriteLine("The number of shared resource *with* the lock is: {0}", withLock.GetTheNumber());
            }

            Console.ReadLine();
        }
    }

    interface ISharedResource
    {
        int GetTheNumber();

        void UpdateTheNumber(int updatedNumber);
    }

    abstract class BaseSharedResource : ISharedResource
    {
        protected  int number;

        protected BaseSharedResource(int initialNumber)
        {
            this.number = initialNumber;
        }
    
        public int GetTheNumber()
        {
 	        return this.number;
        }

        public abstract void UpdateTheNumber(int updatedNumber);

        protected void BaseUpdateTheNumber(int updatedNumber)
        {
            Console.WriteLine("Starting to update the number to {0}...", updatedNumber);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            this.number = updatedNumber;
            Console.WriteLine("Finished updating the number to {0}.", updatedNumber);
        }
    }

    class SharedResourceWithoutLock : BaseSharedResource
    {
        public SharedResourceWithoutLock(int initialNumber)
            : base(initialNumber)
        {
        }

        public override void UpdateTheNumber(int updatedNumber)
        {
            BaseUpdateTheNumber(updatedNumber);
        }
    }

    class SharedResourceWithLock : BaseSharedResource
    {
        private object lockObject = new Object();

        public SharedResourceWithLock(int initialNumber)
            : base(initialNumber)
        {
        }

        public override void UpdateTheNumber(int updatedNumber)
        {
 	        lock(lockObject)
            {
                BaseUpdateTheNumber(updatedNumber);
            }
        }
    }

    class ThingWithUniqueId
    {
        public ThingWithUniqueId(int id)
        {
            this.Id = id;
        }

        public readonly int Id;
    }
}
