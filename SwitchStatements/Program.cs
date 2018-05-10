namespace SwitchAndIfAndAlternatives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DoubleUsingIf("hello world"));
            Console.WriteLine(DoubleUsingIf(5));
        }

        private static object DoubleUsingSwitch(object obj)
        {
            object result = null;

            switch (obj.GetType().Name)
            {
                case "String":
                    result = string.Join("", ((string)obj).ToArray().Select(x => $"{x}{x}"));
                    break;
                case "Int32":
                    result = (int)obj * 2;
                    break;
            }

            return result;
        }

        private static object DoubleUsingIf(object obj)
        {
            object result = null;

            if (obj.GetType().Name == "String")
            {
                result = string.Join("", ((string)obj).ToArray().Select(x => $"{x}{x}"));
            }
            else if (obj.GetType().Name == "Int32")
            {
                result = (int)obj * 2;
            }

            return result;
        }

        private static object DoubleWithoutConditionals(object obj)
        {
            var data = new Dictionary<string, Func<object, object>>()
            {
                { "String", (thing) => string.Join("", ((string)thing).ToArray().Select(x => $"{x}{x}")) },
                { "Int32", (thing) => (int)thing * 2 },
            };

            try
            {
                return data[obj.GetType().Name](obj);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}