using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using V2EX.CommonLib.Utils;

namespace V2EX.Client.Helpers
{
    public static class CookieHelper
    {
        private const char PairSeparator = ';';
        private const char EqualChar = '=';

        public static Cookie Parse(string cookieString)
        {
            var pairs = cookieString.Split(PairSeparator);
            var dictionary = pairs.Select(x => x.Split(EqualChar))
                .ToDictionary(x => x[0].Trim(), x => x.Length == 2 ? x[1].Trim() : null);
            var cookie = new Cookie();
            foreach (var pair in dictionary)
            {
                switch (pair.Key)
                {
                    case "expires":
                        cookie.Expires = ParseExpiresValue(pair.Value);
                        break;
                    case "max-age":
                        throw new NotImplementedException();
                    case "domain":
                        cookie.Domain = pair.Value;
                        break;
                    case "path":
                        cookie.Path = pair.Value;
                        break;
                    case "secure":
                        cookie.Secure = true;
                        break;
                    case "httponly":
                        cookie.HttpOnly = true;
                        break;
                    default:
                        if (!string.IsNullOrEmpty(cookie.Name))
                            throw new InvalidDataException(
                                $"unexpected key : {pair.Key} , current name : {cookie.Name} , value : {cookie.Value}");
                        cookie.Name = pair.Key;
                        cookie.Value = pair.Value;
                        break;
                }
            }
            return cookie;
        }

        private static DateTime ParseExpiresValue(string value)
        {
            value = value.ToUpper();
            var diff = GetWeekInt(value) - GetWeekInt(DateTime.Now);
            if (diff < 0) diff += 7;
            return DateTime.Now.AddDays(diff);
        }

        private static int GetWeekInt(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday: return 7;
                case DayOfWeek.Saturday: return 6;
                case DayOfWeek.Friday: return 5;
                case DayOfWeek.Thursday: return 4;
                case DayOfWeek.Wednesday: return 3;
                case DayOfWeek.Tuesday: return 2;
                case DayOfWeek.Monday: return 1;
                default: throw new ArgumentException(date.DayOfWeek + " unexpected");
            }
        }

        private static int GetWeekInt(string value)
        {
            value = value.ToUpper();
            switch (value)
            {
                case "SUN": return 7;
                case "SAT": return 6;
                case "FRI": return 5;
                case "THUR": return 4;
                case "WED": return 3;
                case "TUES": return 2;
                case "Mon": return 1;
                default: throw new ArgumentException(value + " unexpected");
            }
        }
    }
}

namespace System.Net
{
    public static class CookieCollectionExtension
    {
        public static void AddRange(this CookieCollection @this, IEnumerable<Cookie> cookies)
        {
            Preconditions.CheckNotNull(@this);
            Preconditions.CheckNotNull(cookies);
            foreach (var cookie in cookies)
            {
                Preconditions.CheckNotNull(cookie);
                @this.Add(cookie);
            }
        }
    }
}
