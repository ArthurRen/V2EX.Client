using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using V2EX.Client.Infrastructure;

namespace V2EX.Client.Controls
{
    public class NavigationItem : ViewModelBase
    {
        private object _displayContent;
        private string _displayText;
        private ImageSource _displayImage;

        public NavigationItem(object displayContent, string displayText, ImageSource displayImage)
        {
            _displayContent = displayContent;
            _displayText = displayText;
            _displayImage = displayImage;
        }

        public object DisplayContent
        {
            get => _displayContent;
            set => SetProperty(ref _displayContent, value);
        }

        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

        public ImageSource DisplayImage
        {
            get => _displayImage;
            set => SetProperty(ref _displayImage, value);
        }
    }
}
