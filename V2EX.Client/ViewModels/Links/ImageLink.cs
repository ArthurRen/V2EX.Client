using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using V2EX.Client.Extensions;
using V2EX.Client.Helpers;

namespace V2EX.Client.ViewModels.Links
{
    public class ImageLink : Link
    {
        private Uri _imageUri;
        
        public Uri ImageUri
        {
            get => _imageUri;
            set => SetProperty(ref _imageUri, value);
        }

        public ImageLink(string imageUrl, string hyperLinkAddress) : base(hyperLinkAddress)
        {
            ImageUri = new Uri(imageUrl);
            //if (!MemoryCacheHelper.TryGet(imageUrl, out ImageUri image))
            //{
            //    MemoryCacheHelper.Add(imageUrl, ImageUri);
            //    return;
            //}
            //ImageUri = image;
        }
    }
}
