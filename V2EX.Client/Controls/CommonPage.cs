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
        public static readonly DependencyProperty RefreshCommandProperty =
            DependencyProperty.Register(nameof(RefreshCommand), typeof(ICommand), typeof(CommonPage));

        static CommonPage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommonPage),
                new FrameworkPropertyMetadata(typeof(CommonPage)));
        }

        public CommonPage()
        {
            EventManager.RegisterClassHandler(typeof(Control),
                Keyboard.KeyDownEvent, new KeyEventHandler(KeyDownHandler));

            EventManager.RegisterClassHandler(typeof(ScrollViewer),
                Keyboard.KeyDownEvent, new KeyEventHandler(KeyDownHandler));
        }

        private void KeyDownHandler(object sender , KeyEventArgs args)
        {
            if(args.Key == Key.F5 && (RefreshCommand?.CanExecute(null) ?? true))
                RefreshCommand?.Execute(null);
        }

        public ICommand RefreshCommand
        {
            get => GetValue(RefreshCommandProperty) as ICommand;
            set => SetValue(RefreshCommandProperty, value);
        }
    }
}
