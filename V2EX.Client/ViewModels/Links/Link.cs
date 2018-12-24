using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using V2EX.Client.Utils;
using V2EX.Client.ViewModels.Infrastructure;

namespace V2EX.Client.ViewModels.Links
{
    public abstract class Link : ViewModelBase
    {
        private Uri _uri;

        public Uri Uri
        {
            get => _uri;
            set => SetProperty(ref _uri, value);
        }

        protected Link(Uri uri)
        {
            Predication.CheckNotNull(uri);
            Uri = uri;
        }

        protected Link(string address)
        {
            Predication.IsTrue(!string.IsNullOrEmpty(address));
            Uri = new Uri(address);
        }
    }
}
