using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.CustomConfigSection
{
    public class AppInfoSection : ConfigurationSection
    {
        [ConfigurationProperty(name: "name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty(name: "timeoutInSeconds", IsRequired = true)]
        public int TimeoutInSeconds
        {
            get
            {
                return (int)this["timeoutInSeconds"];
            }
            set
            {
                this["timeoutInSeconds"] = value;
            }
        }
    }
}
