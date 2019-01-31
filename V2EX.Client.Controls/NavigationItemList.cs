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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace V2EX.Client.Controls
{
    public class NavigationItemList : Control
    {
        public static readonly DependencyProperty NavigationItemsProperty =
            DependencyProperty.Register(nameof(NavigationItems), typeof(ObservableCollection<NavigationItem>),
                typeof(NavigationItemList), new PropertyMetadata(new ObservableCollection<NavigationItem>()));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(NavigationItem), typeof(NavigationItemList));
        
        public static readonly DependencyProperty NavigationItemMouseHoverColorProperty =
            DependencyProperty.Register(nameof(NavigationItemMouseHoverColor) , typeof(Color) , typeof(NavigationItemList));

        static NavigationItemList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationItemList), new FrameworkPropertyMetadata(typeof(NavigationItemList)));
        }

        public ObservableCollection<NavigationItem> NavigationItems
        {
            get => GetValue(NavigationItemsProperty) as ObservableCollection<NavigationItem>;
            set => SetValue(NavigationItemsProperty, value);
        }

        public NavigationItem SelectedItem
        {
            get => GetValue(SelectedItemProperty) as NavigationItem;
            set => SetValue(SelectedItemProperty, value);
        }

        public Color NavigationItemMouseHoverColor
        {
            get => (Color)GetValue(NavigationItemMouseHoverColorProperty);
            set => SetValue(NavigationItemMouseHoverColorProperty, value);
        }
        
    }
}
