using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSiteAndApi
{
    public class HtmlMiddleware : OwinMiddleware
    {
        public HtmlMiddleware(OwinMiddleware next)
            :base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            string message = UtilityMethods.RetrieveQueryString(context.Request.QueryString);

            UtilityMethods.SetResponse(context, message, "text/html");

            // Just returning a simple task that returns immediately.
            return Task.Factory.StartNew(() => { return; });
        }
    }
}
