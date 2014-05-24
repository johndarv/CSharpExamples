using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.AppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain appDomain1 = AppDomain.CreateDomain("App Domain 1");

            appDomain1.CreateInstanceAndUnwrap(
                "JohnDarv.CSharp.Examples.MutexProgram",
                "JohnDarv.CSharp.Examples.MutexProgram.MutexTester");
        }
    }
}
