using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;
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
        private HtmlNode _topicBoxNode;

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
            set
            {
                var isFirstLoad = _selectedTab == null;
                if (SetProperty(ref _selectedTab, value) && !isFirstLoad)
                {
                    CurrentUrl = _selectedTab.Uri;
                    LoadHtmlAsync();
                }
            }
        }

        protected override void OnHtmlLoading()
        {
            InvokeInUiThread(() =>
            {
                if (Topics == null)
                    Topics = new ObservableCollection<TopicItem>();
                else
                    Topics.Clear();

                if (SubLeftTabs == null)
                    SubLeftTabs = new ObservableCollection<TextLink>();
                else
                    SubLeftTabs.Clear();

                if (SubRightTabs == null)
                    SubRightTabs = new ObservableCollection<TextLink>();
                else
                    SubRightTabs.Clear();
            });
        }

        protected override void OnHtmlLoaded(HtmlDocument htmlDocument)
        {
            //_currentHtmlDocument = V2EXRequest.GetHtmlDoc(Urls.Instance.Home);
            _topicBoxNode = HtmlParseHelper.GetTopicBoxHtmlNode(htmlDocument);
            ParseTabItems(_topicBoxNode);
            ParseSubTabItems(_topicBoxNode);
            ParseTopicItems(_topicBoxNode);
        }

        protected void ParseTabItems(HtmlNode topicBoxNode)
        {
            if (Tabs != null)
                return;
            var tabs = new ObservableCollection<TextLink>();
            foreach (var node in HtmlParseHelper.GetTabHtmlNodes(topicBoxNode))
            {
                var tabItem = HtmlParseHelper.GetTabItemFromTabHtmlNode(node, out var isSelected);
                tabs.Add(tabItem);
                if (isSelected)
                    SelectedTab = tabItem;
            }
            Tabs = tabs;
        }

        protected void ParseSubTabItems(HtmlNode topicBoxNode)
        {
            var leftTabNodes = HtmlParseHelper.GetLeftSubTabHtmlNodes(topicBoxNode);
            if (leftTabNodes != null)
            {
                var leftTabItems = leftTabNodes.Select(HtmlParseHelper.GetTabItemFromTabHtmlNode);
                BeginInvokeInUiThread(() => SubLeftTabs.AddRange(leftTabItems));
            }
            
            var rightTabNodes = HtmlParseHelper.GetRightSubTabHtmlNodes(topicBoxNode);
            if (rightTabNodes != null)
            {
                var rightTabItems = rightTabNodes.Select(HtmlParseHelper.GetTabItemFromTabHtmlNode);
                BeginInvokeInUiThread(() => SubRightTabs.AddRange(rightTabItems));
            }
        }

        protected void ParseTopicItems(HtmlNode topicBoxNode)
        {
            var topicItemNodes = HtmlParseHelper.GetTopicItemsHtmlNodes(topicBoxNode);
            var topics = topicItemNodes.Select(HtmlParseHelper.GetTopicItemFromTopicItemNode);
            foreach (var topic in topics)
            {
                BeginInvokeInUiThread(() => { Topics.Add(topic); });
                Thread.Sleep(10);
            }
        }
    }
}
