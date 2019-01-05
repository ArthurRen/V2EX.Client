using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace V2EX.Client.Helpers
{
    public static class UrlHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UrlHelper));
        
        public const string Scheme = "https:";
        public const string HomeAddress = Scheme + "//www.v2ex.com";
        public const string SignInPageAddress = HomeAddress + "/signin";
        
        public static void OpenAccountRegisterPage()
        {
            try
            {

            }
            catch (Exception e)
            {
                Log.Error("OpenAccountRegisterPage failed!", e);
            }
        }
    }
}
