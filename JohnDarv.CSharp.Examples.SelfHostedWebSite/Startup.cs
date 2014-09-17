using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    public class Startup
    {
        private HtmlProducer htmlProducer;
        private StringProducer stringProducer;

        public Startup()
        {
            this.htmlProducer = new HtmlProducer();
            this.stringProducer = new StringProducer();
        }

        public void Configuration(IAppBuilder app)
        {
            // When we call the base address + /stringPage
            app.Map(
                "/stringPage",
                (app2 =>
                {
                    app2.Use(InvokeStringResponder);
                })
            );

            // When we call the base address + /htmlPage
            app.Map(
                "/htmlPage",
                (app2 =>
                {
                    // Use the InvokeHtmlResponder method to handle requests.
                    app2.Use(InvokeHtmlResponder);
                })
            );
        }

        /// <summary>
        /// Takes an Owin context and writes some html to the response.
        /// Doesn't call the next function in the chain.
        /// </summary>
        /// <returns>Returns a Task that just returns 0.</returns>
        private Task InvokeHtmlResponder(IOwinContext context, Func<Task> next)
        {
            string message = RetrieveQueryString(context.Request.QueryString);

            string html = this.htmlProducer.ProduceHtml(message);

            context.Response.ContentType = "text/html";
            context.Response.Write(html);

            return Task.FromResult(0);
        }

        private Task InvokeStringResponder(IOwinContext context, Func<Task> next)
        {
            string message = RetrieveQueryString(context.Request.QueryString);

            string str = this.stringProducer.ProduceString(message);

            context.Response.ContentType = "text/plain";

            Task writeStringToResponseBody = context.Response.WriteAsync(str);

            return writeStringToResponseBody;
        }

        private string RetrieveQueryString(QueryString queryString)
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
