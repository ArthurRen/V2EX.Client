using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using V2EX.Client.Configurations;
using V2EX.Client.Network;
using V2EX.Client.ViewModels.Infrastructure;
using V2EX.Client.ViewModels.Links;
using V2EX.Helpers;

namespace V2EX.Client.ViewModels.Pages
{
    public class MainPageViewModel : CommonPageViewModel
    {
        private ObservableCollection<TopicItem> _topics;
        private ObservableCollection<TextLink> _tabs;
        private ObservableCollection<TextLink> _subLeftTabs;
        private ObservableCollection<TextLink> _subRightTabs;
        private TextLink _selectedTab;

        public ObservableCollection<TopicItem> Topics
        {
            get => _topics;
            set => SetProperty(ref _topics, value);
        }

        public ObservableCollection<TextLink> Tabs
        {
            get => _tabs;
            set => SetProperty(ref _tabs, value);
        }

        public ObservableCollection<TextLink> SubRightTabs
        {
            get => _subRightTabs;
            set => SetProperty(ref _subRightTabs, value);
        }

        public ObservableCollection<TextLink> SubLeftTabs
        {
            get => _subLeftTabs;
            set => SetProperty(ref _subLeftTabs, value);
        }
        
        public TextLink SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }
        
        public MainPageViewModel()
        {
        }

        protected override void OnHtmlLoaded(HtmlDocument htmlDocument)
        {
            
            var doc = V2EXRequest.GetHtmlDoc(Urls.Instance.Home);
            var topicBoxNode = HtmlParseHelper.GetTopicBoxHtmlNode(doc);

            // Tabs
            var tabs = new ObservableCollection<TextLink>();
            foreach (var node in HtmlParseHelper.GetTabHtmlNodes(topicBoxNode))
            {
                var tabItem = HtmlParseHelper.GetTabItemFromTabHtmlNode(node, out var isSelected);
                tabs.Add(tabItem);
                if (isSelected)
                    SelectedTab = tabItem;
            }
            Tabs = tabs;

            // SubTabs
            SubLeftTabs = new ObservableCollection<TextLink>(
                HtmlParseHelper.GetLeftSubTabHtmlNodes(topicBoxNode)
                    .Select(HtmlParseHelper.GetTabItemFromTabHtmlNode));

            SubRightTabs = new ObservableCollection<TextLink>(
                HtmlParseHelper.GetRightSubTabHtmlNodes(topicBoxNode)
                    .Select(HtmlParseHelper.GetTabItemFromTabHtmlNode));

            // Topics
            var topicItemNodes = HtmlParseHelper.GetTopicItemsHtmlNodes(topicBoxNode);
            var topics = topicItemNodes.Select(HtmlParseHelper.GetTopicItemFromTopicItemNode);
            Topics = new ObservableCollection<TopicItem>(topics);
            
        }
    }
}
