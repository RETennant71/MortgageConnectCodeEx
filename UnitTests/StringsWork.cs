using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class StringsWork
    {
        public static string ReverseTestCase(string exampleStr)
        {
            string retval = string.Empty;
            try
            {
                //make sure the string has something in it
                if (string.IsNullOrEmpty(exampleStr))
                {
                    return null;
                }
                //make sure not whitespace item
                if (string.IsNullOrWhiteSpace(exampleStr.Trim()))
                {
                    return string.Empty;
                }

                //get reversed string without any non alphanumeric chars
                string reversedStrAlphaOnly = ReverseAStringAlphanumericOnly(exampleStr);

                //reverse the string keeping the non alphanumberic characters in original spots
                for (int i = 0, j = 0; i < exampleStr.Length; i++)
                {
                    if (!(char.IsLetter(exampleStr[i])) && (!(char.IsNumber(exampleStr[i]))))
                    {
                        //not an alphanumeric character keep in place
                        string val = exampleStr[i].ToString();
                        retval += val;
                    }
                    else
                    {
                        //alphanumeric character so use reverse string val
                        retval += reversedStrAlphaOnly[j].ToString();
                        j++;
                    }
                }

                return retval;
            }
            catch (Exception ex)
            {
                //on error
                return "Error in String - " + ex.Message;
            }
        }
        private static string ReverseAStringAlphanumericOnly(string input)
        {
            try
            {
                //convert to character array and strip no alphanumeric characters
                char[] arr = input.ToCharArray();
                string returnStr = string.Empty;

                arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                                  || char.IsWhiteSpace(c)
                                                  || c == '-')));
                returnStr = new string(arr);

                //reverse the stripped string and return
                IEnumerable<char> rev = returnStr.Reverse();
                return string.Concat(rev);
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }
    }
}
