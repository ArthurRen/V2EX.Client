using System;
using V2EX.Client.Infrastructure;
using V2EX.CommonLib.Utils;

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
            Preconditions.CheckNotNull(uri);
            Uri = uri;
        }

        protected Link(string address)
        {
            Preconditions.IsTrue(!string.IsNullOrEmpty(address));
            Uri = new Uri(address);
        }
    }
}
