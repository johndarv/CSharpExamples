using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.CustomConfigSection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type appInfoSectionType = typeof(AppInfoSection);

            var appInfoSection = (AppInfoSection)ConfigurationManager.GetSection("appInfo");

            Console.WriteLine(string.Format("App Name: {0}.", appInfoSection.Name));
            Console.WriteLine(string.Format("Timeout: {0} seconds.", appInfoSection.TimeoutInSeconds));
            Console.ReadLine();
        }
    }
}
