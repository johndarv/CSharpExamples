using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnDarv.CSharp.Examples.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveWhiteSpaces(this string str)
        {
            return new string(str.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string RemoveWhiteSpacesAndNewLines(this string str)
        {
            return new string(str.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c) && !c.Equals('\n') && !c.Equals('\r'))
                .ToArray());
        }

        public static string RemoveNewLineCharacters(this string str)
        {
            return new string(str.ToCharArray()
                .Where(c => !c.Equals('\n') && !c.Equals('\r'))
                .ToArray());
        }

        public static string RemoveWhiteSpacesUnlessInSpeechMarks(this string str)
        {
            int i = 0;
            string result = string.Empty;
            bool insideSpeechMarks = false;

            while (i < str.Length)
            {
                switch (str[i])
                {
                    case '"':
                        if (insideSpeechMarks == true)
                        {
                            insideSpeechMarks = false;
                        }
                        else
                        {
                            insideSpeechMarks = true;
                        }

                        result = result + str[i];
                        break;
                    case ' ':
                        if (insideSpeechMarks == true)
                        {
                            result = result + str[i];
                        }

                        break;
                    default:
                        result = result + str[i];
                        break;
                }

                i++;
            }

            return result;
        }

        public static IList<string> SplitOnSeparatorExceptInSpeechMarks(this string str, char separator)
        {
            IList<string> result = new List<string>();

            int i = 0;
            bool inSpeechMarks = false;
            string currentElement = string.Empty;

            while (i < str.Length)
            {
                char character = str[i];
                i++;

                if (char.Equals(character, separator))
                {
                    if (inSpeechMarks)
                    {
                        currentElement = currentElement + character;
                    }
                    else
                    {
                        result.Add(currentElement);
                        currentElement = string.Empty;
                    }
                }
                else if (char.Equals(character, '"'))
                {
                    if (inSpeechMarks)
                    {
                        currentElement = currentElement + character;
                        inSpeechMarks = false;
                    }
                    else
                    {
                        currentElement = currentElement + character;
                        inSpeechMarks = true;
                    }
                }
                else
                {
                    currentElement = currentElement + character;
                }
            }

            result.Add(currentElement);

            return result;
        }

        public static IList<string> SplitOnSeparatorExceptInCurlyBrackets(this string str, char separator)
        {
            IList<string> result = new List<string>();

            int i = 0;
            int curlyBracketsLevel = 0;
            string currentElement = string.Empty;

            while (i < str.Length)
            {
                char character = str[i];
                i++;

                if (char.Equals(character, separator))
                {
                    if (curlyBracketsLevel > 0)
                    {
                        currentElement = currentElement + character;
                    }
                    else
                    {
                        result.Add(currentElement);
                        currentElement = string.Empty;
                    }
                }
                else if (char.Equals(character, '{'))
                {
                    currentElement = currentElement + character;
                    curlyBracketsLevel++;
                }
                else if (char.Equals(character, '}'))
                {
                    currentElement = currentElement + character;
                    curlyBracketsLevel--;
                }
                else
                {
                    currentElement = currentElement + character;
                }
            }

            result.Add(currentElement);

            return result;
        }

        public static IList<string> SplitOnSeparatorUnlessWithinSpeechMarksOrSquareBrackets(this string str, char separator)
        {
            IList<string> result = new List<string>();

            int i = 0;
            int bracketsEscapedLevel = 0;
            int speechMarksEscapedLevel = 0;
            string currentElement = string.Empty;

            while (i < str.Length)
            {
                char character = str[i];
                i++;

                if (char.Equals(character, separator))
                {
                    if (bracketsEscapedLevel > 0 || speechMarksEscapedLevel > 0)
                    {
                        currentElement = currentElement + character;
                    }
                    else
                    {
                        result.Add(currentElement);
                        currentElement = string.Empty;
                    }
                }
                else
                {
                    switch (character)
                    {
                        case '"':
                            if (speechMarksEscapedLevel > 0)
                            {
                                currentElement = currentElement + character;
                                speechMarksEscapedLevel--;
                            }
                            else
                            {
                                currentElement = currentElement + character;
                                speechMarksEscapedLevel++;
                            }

                            break;
                        case '[':
                            currentElement = currentElement + character;
                            bracketsEscapedLevel++;
                            break;
                        case ']':
                            currentElement = currentElement + character;
                            bracketsEscapedLevel--;

                            if (bracketsEscapedLevel < 0)
                            {
                                bracketsEscapedLevel = 0;
                            }

                            break;
                        default:
                            currentElement = currentElement + character;
                            break;
                    }
                }
            }

            result.Add(currentElement);

            return result;
        }
    }
}
