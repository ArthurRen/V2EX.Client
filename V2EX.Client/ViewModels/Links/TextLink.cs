using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V2EX.Client.Utils;

namespace V2EX.Client.ViewModels.Links
{
    public class TextLink : Link
    {
        private string _displayText;

        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText , value);
        }

        public TextLink(string displayText, string uriAddress) : base(uriAddress)
        {
            Predication.IsTrue(!string.IsNullOrEmpty(displayText));
            DisplayText = displayText;
        }

        public TextLink(string displayText, Uri uri) : base(uri)
        {
            Predication.IsTrue(!string.IsNullOrEmpty(displayText));
            DisplayText = displayText;
        }

        public override string ToString()
        {
            return _displayText;
        }
    }
}
