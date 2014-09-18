using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

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

        public static void SetResponse(IOwinContext context, string message, string contentType)
        {
            string str = StuffProducer.ProduceString(message);

            string json = JsonConvert.SerializeObject(str);

            context.Response.ContentType = contentType;
            context.Response.ContentLength = json.Length;

            context.Response.Write(json);
        }
    }
}
