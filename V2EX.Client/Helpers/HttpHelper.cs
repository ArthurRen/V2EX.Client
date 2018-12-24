using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using V2EX.Client.Configurations;
using V2EX.Client.Utils;
using WebRequest = System.Net.WebRequest;

namespace V2EX.Client.Helpers
{
    public static class HttpHelper
    {
        public const string GetMethod = "GET";
        public const string PostMethod = "POST";

        public static string GetResponseContent(string url, string method , CookieCollection cookies = null)
        {
            using (var stream = GetResponseStream(url , method , cookies))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
        
        public static Stream GetResponseStream(string url , string method , CookieCollection cookies = null)
        {
            var response = GetHttpResponse(url, method, cookies);
            return response.GetResponseStream();
        }

        public static WebResponse GetHttpResponse(string url , string method , CookieCollection cookies = null)
        {
            Predication.CheckNotNull(url);
            Predication.CheckNotNull(method);
            if (!(WebRequest.Create(url) is HttpWebRequest request))
                throw new InvalidOperationException($"URL : {url} is invalid because request is not HttpWebRequest");
            request.Method = method;
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            return request.GetResponse();
        }

        public static string GetResponseContent(WebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static void AttachRequestHeaders(HttpWebRequest request)
        {
            request.Headers.Clear();
            request.Accept = RequestHeaders.Instance.AcceptHtml;
            request.UserAgent = RequestHeaders.Instance.UserAgent;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.CachePolicy = new RequestCachePolicy(RequestHeaders.Instance.CachePolicy);
            request.Headers.Add("if-none-match", RequestHeaders.Instance.IfNoneMatch);
            request.Headers.Add("cookie", RequestHeaders.Instance.FullCookie);
            request.Headers.Add("accept-language", RequestHeaders.Instance.AcceptLanguage);
            request.Headers.Add("accept-encoding", RequestHeaders.Instance.AcceptEncoding);
            request.Headers.Add("upgrade-insecure-requests", RequestHeaders.Instance.UpgradeInsecureRequests);
            request.Headers.Add("authority", RequestHeaders.Instance.Authority);
        }
    }
}
