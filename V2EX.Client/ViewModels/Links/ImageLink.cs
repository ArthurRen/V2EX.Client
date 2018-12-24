using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using V2EX.Client.Extensions;

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
            ImageSource = new BitmapImage(new Uri(imageUrl));
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
