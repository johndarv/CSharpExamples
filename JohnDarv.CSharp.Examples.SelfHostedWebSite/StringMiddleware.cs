using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    public class StringMiddleware : OwinMiddleware
    {
        public StringMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            string message = UtilityMethods.RetrieveQueryString(context.Request.QueryString);

            string html = StuffProducer.ProduceString(message);

            context.Response.ContentType = "text/html";
            context.Response.Write(html);

            return Task.FromResult(0);
        }
    }
}
