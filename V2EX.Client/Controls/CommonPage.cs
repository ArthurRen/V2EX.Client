using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace V2EX.Client.Controls
{
    public class CommonPage : Page
    {
        static CommonPage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommonPage),
                new FrameworkPropertyMetadata(typeof(CommonPage)));
        }
    }
}
