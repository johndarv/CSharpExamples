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
            Type urlSectionType = typeof(UrlSection);

            UrlSection configSection = (UrlSection)ConfigurationManager.GetSection("urls");

            Console.WriteLine(configSection.Url.Name);
        }
    }
}
