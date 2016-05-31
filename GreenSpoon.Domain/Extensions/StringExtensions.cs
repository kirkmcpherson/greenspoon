using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GreenSpoon.Domain.Extensions
{
    public static class StringExtensions
    {
        public static Guid? AsNGuid(this string input)
        {
            Guid guid;
            if (Guid.TryParse(input, out guid))
            {
                return guid;
            }

            return null;
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return String.IsNullOrEmpty(input);
        }

        public static bool IsNullOrWhiteSpace(this string input)
        {
            return String.IsNullOrWhiteSpace(input);
        }

        public static string UrlEncode(this string input)
        {
            return WebUtility.UrlEncode(input);
        }

    }
}
