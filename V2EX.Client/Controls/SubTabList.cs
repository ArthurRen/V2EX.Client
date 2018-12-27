using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using V2EX.Client.ViewModels.Links;

namespace V2EX.Client.Controls
{
    class SubTabList : Control
    {
        public static readonly DependencyProperty SubTabsProperty =
            DependencyProperty.Register(nameof(SubTabs), typeof(ObservableCollection<TextLink>), typeof(SubTabList));
        
        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register(nameof(ClickCommand), typeof(ICommand), typeof(SubTabList));

        static SubTabList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SubTabList),
                new FrameworkPropertyMetadata(typeof(SubTabList)));
        }

        public ObservableCollection<TextLink> SubTabs
        {
            get => GetValue(SubTabsProperty) as ObservableCollection<TextLink>;
            set => SetValue(SubTabsProperty, value);
        }

        public ICommand ClickCommand
        {
            get => GetValue(ClickCommandProperty) as ICommand;
            set => SetValue(ClickCommandProperty, value);
        }
    }
}
