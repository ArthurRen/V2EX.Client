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
using V2EX.Client.ViewModels;

namespace V2EX.Client.Controls
{
    /// <summary>
    /// Interaction logic for TopicList.xaml
    /// </summary>
    public partial class TopicList : ItemsControl
    {
        public static readonly DependencyProperty TopicsProperty =
            DependencyProperty.Register(nameof(Topics), typeof(ObservableCollection<TopicItem>), typeof(TopicList));

        public static readonly DependencyProperty ViewTopicCommandProperty =
            DependencyProperty.Register(nameof(ViewTopicCommand), typeof(ICommand), typeof(TopicList));

        public static readonly DependencyProperty ViewAuthorInfoCommandProperty =
            DependencyProperty.Register(nameof(ViewAuthorInfoCommand), typeof(ICommand), typeof(TopicList));

        public static readonly DependencyProperty ViewNodeInfoCommandProperty =
            DependencyProperty.Register(nameof(ViewNodeInfoCommand), typeof(ICommand), typeof(TopicList));

        public static readonly DependencyProperty ViewLastReplyMemberInfoCommandProperty =
            DependencyProperty.Register(nameof(ViewLastReplyMemberInfoCommand), typeof(ICommand), typeof(TopicList));

        public TopicList()
        {
            InitializeComponent();
        }
        
        public ObservableCollection<TopicItem> Topics
        {
            get => GetValue(TopicsProperty) as ObservableCollection<TopicItem>;
            set => SetValue(TopicsProperty, value);
        }

        public ICommand ViewTopicCommand
        {
            get => GetValue(ViewTopicCommandProperty) as ICommand;
            set => SetValue(ViewTopicCommandProperty, value);
        }

        public ICommand ViewAuthorInfoCommand
        {
            get => GetValue(ViewAuthorInfoCommandProperty) as ICommand;
            set => SetValue(ViewAuthorInfoCommandProperty, value);
        }

        public ICommand ViewNodeInfoCommand
        {
            get => GetValue(ViewNodeInfoCommandProperty) as ICommand;
            set => SetValue(ViewNodeInfoCommandProperty, value);
        }

        public ICommand ViewLastReplyMemberInfoCommand
        {
            get => GetValue(ViewLastReplyMemberInfoCommandProperty) as ICommand;
            set => SetValue(ViewLastReplyMemberInfoCommandProperty, value);
        }
    }
}
