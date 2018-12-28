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
        private ImageSource _imageSource;

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public ImageLink(string imageUrl, string hyperLinkAddress) : base(hyperLinkAddress)
        {
            var policy = new RequestCachePolicy(RequestCacheLevel.Revalidate);
            ImageSource = new BitmapImage(new Uri(imageUrl) , policy);
            //if (!MemoryCacheHelper.TryGet(imageUrl, out ImageSource imageSource))
            //{
            //    MemoryCacheHelper.Add(imageUrl, ImageSource);
            //    return;
            //}
            //ImageSource = imageSource;
        }

        public ImageLink(Image image, string hyperLinkAddress) : base(hyperLinkAddress)
        {
            ImageSource = image.ToBitmapImage();
        }

        public ImageLink(ImageSource imageSource, string hyperLinkAddress) : base(hyperLinkAddress)
        {
            ImageSource = imageSource;
        }
    }
}
