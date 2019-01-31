using System;
using V2EX.CommonLib.Utils;

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
            Preconditions.IsTrue(!string.IsNullOrEmpty(displayText));
            DisplayText = displayText;
        }

        public TextLink(string displayText, Uri uri) : base(uri)
        {
            Preconditions.IsTrue(!string.IsNullOrEmpty(displayText));
            DisplayText = displayText;
        }

        public override string ToString()
        {
            return _displayText;
        }
    }
}
