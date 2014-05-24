using JohnDarv.CSharp.Examples.Mutexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.AppDomains
{
    class Program
    {
        private const string uniqueMutexName = "MutexExample";

        static void Main(string[] args)
        {
            AppDomain appDomain1 = AppDomain.CreateDomain("App Domain 1");

            MutexMonopolizer mutexMonopolizer1 = (MutexMonopolizer)appDomain1.CreateInstanceAndUnwrap(
                (typeof(MutexMonopolizer)).Assembly.FullName,
                (typeof(MutexMonopolizer)).FullName);
        }
    }
}
