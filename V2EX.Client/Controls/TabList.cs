using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using V2EX.Client.ViewModels;
using V2EX.Client.ViewModels.Links;

namespace V2EX.Client.Controls
{
    public class TabList : Control
    {
        public static readonly DependencyProperty TabsProperty =
            DependencyProperty.Register(nameof(Tabs), typeof(ObservableCollection<TextLink>), typeof(TabList));

        public static readonly DependencyProperty SelectedTabProperty =
            DependencyProperty.Register(nameof(SelectedTab), typeof(TextLink), typeof(TabList));
        
        static TabList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabList),
                new FrameworkPropertyMetadata(typeof(TabList)));
        }

        public ObservableCollection<TextLink> Tabs
        {
            get => GetValue(TabsProperty) as ObservableCollection<TextLink>;
            set => SetValue(TabsProperty, value);
        }

        public TextLink SelectedTab
        {
            get => GetValue(SelectedTabProperty) as TextLink;
            set => SetValue(SelectedTabProperty, value);
        }
    }
}