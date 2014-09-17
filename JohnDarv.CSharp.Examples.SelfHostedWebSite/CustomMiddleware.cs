using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    public class CustomMiddleware : OwinMiddleware
    {
        public CustomMiddleware(OwinMiddleware next)
            :base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            string html = new HtmlProducer().ProduceHtml(string.Empty);

            context.Response.ContentType = "text/html";
            context.Response.Write(html);

            throw new NotImplementedException();
        }
    }
}
