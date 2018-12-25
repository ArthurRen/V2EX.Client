using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using V2EX.Client.Configurations;
using V2EX.Client.Utils;
using V2EX.Client.ViewModels;
using V2EX.Client.ViewModels.Links;

namespace V2EX.Helpers
{
    public static class HtmlParseHelper
    {
        private static readonly Regex BackgroundImageRegex = new Regex("background-image[\\s]*[:][\\s]*url[\\s]*\\((.*?)\\);");
        private const string DotSplit = "&nbsp;•&nbsp;";

        private static string GetAbsoluteAddress(string relativeAddress) => Urls.Instance.Home + relativeAddress;

        public static string GetVerificationImageUrl(string cssString)
        {
            Predication.CheckNotNull(cssString);
            var result = BackgroundImageRegex.Match(cssString);
            if (result.Value == string.Empty)
                return null;
            var start = result.Value.IndexOf('\'');
            var end = result.Value.LastIndexOf('\'');
            return result.Value.Substring(start + 1, end - start);
        }

        public static IEnumerable<HtmlNode> GetTabHtmlNodes(HtmlNode doc)
        {
            Predication.CheckNotNull(doc);
            return doc.SelectNodes(HtmlXPath.Instance.MainPage_TopicBox_Tabs);
        }

        public static TextLink GetTabItemFromTabHtmlNode(HtmlNode tabHtmlNode , out bool isSelected)
        {
            isSelected = tabHtmlNode.Attributes["class"]?.Value == HtmlXPath.Instance.SelectedTabClassName;
            return new TextLink(tabHtmlNode.InnerText, GetAbsoluteAddress(tabHtmlNode.Attributes["href"].Value));
        }

        public static HtmlNode GetTopicBoxHtmlNode(HtmlDocument doc)
        {
            Predication.CheckNotNull(doc);
            return doc.DocumentNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox);
        }

        public static HtmlNodeCollection GetTopicItemsHtmlNodes(HtmlNode topicBoxHtmlNode)
        {
            Predication.CheckNotNull(topicBoxHtmlNode);
            return topicBoxHtmlNode.SelectNodes(HtmlXPath.Instance.MainPage_TopicBox_TopicItems);
        }

        public static TopicItem GetTopicItemFromTopicItemNode(HtmlNode topicItemHtmlNode)
        {
            var result = new TopicItem();
            Predication.CheckNotNull(topicItemHtmlNode);

            // avatar
            var avatarNode =
                topicItemHtmlNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox_TopicItems_Avatar);
            var hyperLinkAddress = avatarNode.Attributes["href"].Value;
            var imageNode = avatarNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox_TopicItems_Avatar_Image);
            var imageUrl = imageNode.Attributes["src"].Value;

            var middleNode =
                topicItemHtmlNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox_TopicItems_MiddleDiv);

            // Title
            var titleNode =
                middleNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox_TopicItems_MiddleDiv_Title);
            var titleHyperLink = titleNode.Attributes["href"].Value;
            var titleText = titleNode.InnerText;
           
            // Title info
            {
                var titleInfoNode =
                    middleNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo);

                var nodeNode =
                    titleInfoNode.SelectSingleNode(HtmlXPath.Instance
                        .MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo_Node);
                var nodeText = nodeNode.InnerText;
                var nodeHyperLink = nodeNode.Attributes["href"].Value;

                var authorNode =
                    titleInfoNode.SelectSingleNode(HtmlXPath.Instance
                        .MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo_Author);
                var authorName = authorNode.InnerText;
                var authorHyperText = authorNode.Attributes["href"].Value;

                var lastReplyNode =
                    titleInfoNode.SelectSingleNode(HtmlXPath.Instance
                        .MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo_LastReplyMember);
                
                if (lastReplyNode != null)
                {
                    var lastReplyText = lastReplyNode.InnerText;
                    var lastReplyTextHyperText = lastReplyNode.Attributes["href"].Value;

                    var index2 = titleInfoNode.InnerText.LastIndexOf(DotSplit , StringComparison.Ordinal);
                    if (index2 != -1)
                    {
                        var index1 = titleInfoNode.InnerText.LastIndexOf(DotSplit, index2 , StringComparison.Ordinal);
                        if (index1 != -1)
                        {
                            var startIndex = index1 + DotSplit.Length;
                            var len = index2 - startIndex;
                            result.LastReplyTime = titleInfoNode.InnerText.Substring(startIndex, len).Trim();
                        }
                    }

                    result.LastReplyMember = new TextLink(lastReplyText, GetAbsoluteAddress(lastReplyTextHyperText));
                }

                result.Node = new TextLink(nodeText, GetAbsoluteAddress(nodeHyperLink));
                result.Author = new TextLink(authorName, GetAbsoluteAddress(authorHyperText));
                
            }

            // Reply count
            var replyCountNode =
                topicItemHtmlNode.SelectSingleNode(HtmlXPath.Instance.MainPage_TopicBox_TopicItems_MiddleDiv_ReplyCount);
            if (replyCountNode != null)
            {
                var replyCountNodeText = replyCountNode.InnerText;
                var replyCountNodeHyperText = replyCountNode.Attributes["href"].Value;
                result.RepliesCount = new TextLink(replyCountNodeText, GetAbsoluteAddress(replyCountNodeHyperText));
            }

            result.Avatar = new ImageLink(Urls.Instance.Https + imageUrl, GetAbsoluteAddress(hyperLinkAddress));
            result.Title = new TextLink(titleText , GetAbsoluteAddress(titleHyperLink));

            return result;
        }
    }
}
