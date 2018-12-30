using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.Client.Configurations
{
    public class Urls
    {
        public static Urls Instance { get; } = new Urls();

        private Urls() { }

        public string Https = "https:";
        
        public string Home => Https + "//www.v2ex.com";

        public string SignInPage => Home + "/signin";
        
    }
}
