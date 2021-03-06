﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace JohnDarv.CSharp.Examples.SelfHostedWebSiteAndApi
{
    public class StuffProducer
    {
        public static string ProduceHtml(string str)
        {
            string message = "Hello World";

            if (!string.IsNullOrEmpty(str))
            {
                message = str;
            }

            return 
                "<!DOCTYPE html>" +
                "<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">" +
                "<head>" +
                    "<meta charset=\"utf-8\" />" +
                    "<title>Hello World</title>" +
                "</head>" +
                "<body>" +
                    "<p>" + message + "</p>" +
                "</body>" +
                "</html>";
        }

        public static string ProduceString(string message)
        {
            return "Hello, you entered: " + message + "!";
        }
    }
}
