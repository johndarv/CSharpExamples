using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.CustomConfigSection
{
    public class UrlSection : ConfigurationSection
    {
        [ConfigurationProperty("url")]
        public UrlElement Url
        {
            get
            {
                return (UrlElement)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }
    }

    public class UrlElement : ConfigurationElement
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

        [ConfigurationProperty(name: "url", IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }

        [ConfigurationProperty(name: "port", IsRequired = true)]
        public string Port
        {
            get
            {
                return (string)this["port"];
            }
            set
            {
                this["port"] = value;
            }
        }
    }
}
