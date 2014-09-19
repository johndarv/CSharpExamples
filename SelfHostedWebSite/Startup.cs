using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSite
{
    /// <summary>
    /// Because this class is not called 'Startup' we need an assembly attribute entry
    /// in the AssemblyInfo.cs file that specifies that this is an Owin Startup class.
    /// </summary>
    public class CustomStartup
    {
        private StuffProducer htmlProducer;
        private StringProducer stringProducer;

        public CustomStartup()
        {
            this.htmlProducer = new StuffProducer();
            this.stringProducer = new StringProducer();
        }

        public void Configuration(IAppBuilder app)
        {
            // When we call the base address + /stringPage
            app.Map("/stringPage", UseTheStringResponder);

            // When we call the base address + /htmlPage
            app.Map("/htmlPage", UseTheHtmlResponder);
        }

        private void UseTheHtmlResponder(IAppBuilder app)
        {
            app.Use<HtmlMiddleware>();
        }

        private void UseTheStringResponder(IAppBuilder app)
        {
            app.Use<StringMiddleware>();
        }
    }
}
