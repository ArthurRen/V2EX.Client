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
using V2EX.Helpers;

namespace V2EX.Client.ViewModels.Pages
{
    public class MainPageViewModel : CommonPageViewModel
    {
        private ObservableCollection<TopicItem> _topics;

        public ObservableCollection<TopicItem> Topics
        {
            get => _topics;
            set => SetProperty(ref _topics, value);
        }

        protected override void OnHtmlLoaded(HtmlDocument htmlDocument)
        {
            var doc = V2EXRequest.GetHtmlDoc(Urls.Instance.Home);
            var topicBoxNode = HtmlParseHelper.GetTopicBoxHtmlNode(doc);
            var topicItemNodes = HtmlParseHelper.GetTopicItemsHtmlNodes(topicBoxNode);
            var topics = topicItemNodes.Select(HtmlParseHelper.GetTopicItemFromTopicItemNode);
            Topics = new ObservableCollection<TopicItem>(topics);
        }
    }
}
