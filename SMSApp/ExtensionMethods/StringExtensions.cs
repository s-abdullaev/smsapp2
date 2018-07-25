using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string xPluralize(this string str)
        {
            return str+"s";
        }
    }
}
