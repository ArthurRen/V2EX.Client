using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.Client.Configurations
{
    public class RequestHeaders
    {
        public static RequestHeaders Instance { get; } = new RequestHeaders();

        private RequestHeaders() { }

        public string PrivateCookieName { get; set; } = "PB3_SESSION";

        public string PrivateCookie { get; set; }

        public string PublicCookie { get; set; } =
            "_ga=GA1.2.321464652.1516061590;_gid=GA1.2.560240796.1545402120; A2=\"2|1:0|10:1545460700|2:A2|56:MjhiNGFhZmU4Y2Q4NjQ5ZDljMzJkY2M2ZjY0YjViZWRmM2UxNzc3NA==|3beff1484a1a80b970b6b840027a4ef986595490cf9d68d9bb4eb69bd32e215d\"; V2EX_REFERRER=\"2|1:0|10:1545460700|13:V2EX_REFERRER|16:Q2hlbmdhbmdodWk=|88fa33a369a51795034dfdc82ae0f64a15326f52a9537d8d9a6b29d9c9c7991f\"; V2EX_LANG=zhcn; V2EX_TAB=\"2|1:0|10:1545551016|8:V2EX_TAB|8:ZGVhbHM=|9a7029c28e065f4a95fa02ea8ed5d6414f27559cab104de9fd40d4e3e44e59af\"";

        public string FullCookie =>
            $"{PrivateCookie}{(string.IsNullOrEmpty(PrivateCookie) ? string.Empty : ";")}{PublicCookie}";

        public string UserAgent =>
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";

        public string IfNoneMatch => "W/\"14564f0f7ec50ea44d16de924fb4ad501f9dc682\"";

        public string AcceptLanguage => "zh,en-US;q=0.9,en;q=0.8,zh-CN;q=0.7";

        public string AcceptEncoding => "deflate, br";

        public string UpgradeInsecureRequests => "1";

        public string Authority => "www.v2ex.com";

        public RequestCacheLevel CachePolicy => RequestCacheLevel.NoCacheNoStore;

        public string AcceptHtml => "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
    }
}
