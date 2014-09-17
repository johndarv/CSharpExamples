using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    public class UtilityMethods
    {
        public static string RetrieveQueryString(QueryString queryString)
        {
            string message = string.Empty;

            if (queryString.HasValue)
            {
                message = queryString.Value;
            }

            return message;
        }
    }
}
