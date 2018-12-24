using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using V2EX.Client.Network;
using V2EX.Client.ViewModels.Infrastructure;

namespace V2EX.Client.ViewModels.Pages
{
    public abstract class CommonPageViewModel : ViewModelBase , IAwareViewLoadedAndUnloaded , IAwareViewInitialize
    {
        protected string HtmlUrl { get; private set; }
        
        protected CommonPageViewModel()
        {

        }

        public void Initialize(string htmlUrl)
        {
            HtmlUrl = htmlUrl;
        }

        protected virtual HtmlDocument GetHtml()
        {
            return V2EXRequest.GetHtmlDoc(HtmlUrl);
        }

        async void IAwareViewLoadedAndUnloaded.OnViewLoaded(object view)
        {
            var htmlDoc = await Task.Factory.StartNew(GetHtml);
            OnHtmlLoaded(htmlDoc);
        }

        void IAwareViewLoadedAndUnloaded.OnViewUnloaded(object view)
        {
        }

        void IAwareViewInitialize.OnViewInitialize(object view)
        {
        }

        protected virtual void OnHtmlLoaded(HtmlDocument htmlDocument) { }
    }
}
