using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSiteAndApi
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

            UtilityMethods.SetResponse(context, message, "application/json; charset=utf-8");

            return Task.Factory.StartNew(() => { return; });
        }
    }
}
