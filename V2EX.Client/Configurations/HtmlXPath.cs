using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.Client.Configurations
{
    public class HtmlXPath
    {
        public static HtmlXPath Instance { get; } = new HtmlXPath();

        private HtmlXPath() { }

        #region MainPage

        #region TopicsBox
        
        public string MainPage_TopicBox =>
            "//html/body/div[@id='Wrapper']/div[@class='content']/div[@id='Main']/div[@class='box']";

        // Tab items
        public string MainPage_TopicBox_Tabs => "./div[@id='Tabs']/a";
        public string SelectedTabClassName => "tab_current";

        // Sec tab items
        public string MainPage_TopicBox_SecTabs => "./div[@id='SecondaryTabs']/a";


        #region TopicItems

        public string MainPage_TopicBox_TopicItems => "./div[@class='cell item']/table/tr";

        #region Avatar

        public string MainPage_TopicBox_TopicItems_Avatar => "./td[1]/a";

        public string MainPage_TopicBox_TopicItems_Avatar_Image => "./img";

        #endregion

        #region Middel td
        
        public string MainPage_TopicBox_TopicItems_MiddleDiv => "./td[3]";

        // Topic
        public string MainPage_TopicBox_TopicItems_MiddleDiv_Title => "./span[@class='item_title']/a";

        // TopicInfo
        public string MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo => "./span[@class='topic_info']";

        // Node
        public string MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo_Node => "./a[@class='node']";

        // Author 
        public string MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo_Author => "./strong[1]/a";
        
        // LastReply 
        public string MainPage_TopicBox_TopicItems_MiddleDiv_TopicInfo_LastReplyMember => "./strong[2]/a";

        #endregion
        
        // Reply count
        public string MainPage_TopicBox_TopicItems_MiddleDiv_ReplyCount => "./td[4]/a";

        #endregion

        #endregion


        #endregion
    }
}
