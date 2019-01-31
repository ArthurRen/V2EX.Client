using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using V2EX.Client.Configurations;
using V2EX.Client.Helpers;
using V2EX.CommonLib.Utils;

namespace V2EX.Client.Network
{
    public class V2EXRequest
    {
        public static HtmlDocument GetHtmlDoc(Uri uri)
        {
            var isCookieEmpty = string.IsNullOrEmpty(RequestHeaders.Instance.PrivateCookie);
            var request = new V2EXRequest(uri, V2EXRequestMethod.Get);
            if (isCookieEmpty)
            {
                var doc = request.Load(out var cookies);
                var privateCookie = cookies.Cast<Cookie>()
                    .First(x => x.Name == RequestHeaders.Instance.PrivateCookieName);
                RequestHeaders.Instance.PrivateCookie = $"{privateCookie.Name}={privateCookie.Value}";
                return doc;
            }
            return request.Load();
        }

        private readonly HtmlWeb _htmlWeb;
        private readonly Uri _uri;

        public V2EXRequest(Uri uri , V2EXRequestMethod method)
        {
            Preconditions.CheckNotNull(uri);
            _uri = uri;
            _htmlWeb = new HtmlWeb();
            _htmlWeb.PreRequest += request =>
            {
                request.Method = method == V2EXRequestMethod.Get ? HttpHelper.GetMethod : HttpHelper.PostMethod;
                HttpHelper.AttachRequestHeaders(request);
                return true;
            };
        }

        public HtmlDocument Load()
        {
            return _htmlWeb.Load(_uri);
        }

        public HtmlDocument Load(out CookieCollection cookies)
        {
            CookieCollection result = null;
            _htmlWeb.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();
                return true;
            };
            _htmlWeb.PostResponse += (request, response) =>
            {
                result = response.Cookies;
            };
            var doc = _htmlWeb.Load(_uri);
            cookies = result;
            return doc;
        }

        public async Task<HtmlDocument> LoadAsync()
        {
            return await Task.Factory.StartNew(() => _htmlWeb.Load(_uri));
        }
    }
}
