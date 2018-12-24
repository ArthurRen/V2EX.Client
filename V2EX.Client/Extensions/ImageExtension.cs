using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace V2EX.Client.Extensions
{
    public static class ImageExtension
    {
        public static BitmapImage ToBitmapImage(this Image @this)
        {
            var bitmapImage = new BitmapImage();
            using (var memoryStream = new System.IO.MemoryStream())
            {
                @this.Save(memoryStream, @this.RawFormat);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }
    }
}
