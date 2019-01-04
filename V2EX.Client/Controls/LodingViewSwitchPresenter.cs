using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace V2EX.Client.Controls
{
    class LoadingViewSwitchPresenter : Control
    {
        public static readonly DependencyProperty LoadingViewProperty =
            DependencyProperty.Register(nameof(LoadingView), typeof(object), typeof(LoadingViewSwitchPresenter));
        
        public static readonly DependencyProperty LoadedContentProperty =
            DependencyProperty.Register(nameof(LoadedContent), typeof(object), typeof(LoadingViewSwitchPresenter));

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register(nameof(IsLoading), typeof(bool), typeof(LoadingViewSwitchPresenter));

        static LoadingViewSwitchPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingViewSwitchPresenter),
                new FrameworkPropertyMetadata(typeof(LoadingViewSwitchPresenter)));
        }

        public object LoadingView
        {
            get => GetValue(LoadingViewProperty);
            set => SetValue(LoadingViewProperty, value);
        }

        public object LoadedContent
        {
            get => GetValue(LoadedContentProperty);
            set => SetValue(LoadedContentProperty, value);
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }
    }
}
