using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using V2EX.Client.Network;
using V2EX.Client.Utils;
using V2EX.Client.ViewModels.Infrastructure;

namespace V2EX.Client.ViewModels.Pages
{
    public abstract class CommonPageViewModel : ViewModelBase , IAwareViewLoadedAndUnloaded , IAwareViewInitialize
    {
        private bool _isLoadingHtml;

        public bool IsLoadingHtml
        {
            get => _isLoadingHtml;
            set => SetProperty(ref _isLoadingHtml, value);
        }

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
#if DEBUG
            var result = FuncUtil.GetFuncExecuteTime(() => V2EXRequest.GetHtmlDoc(HtmlUrl), out var milliseconds);
            Console.WriteLine($"It takes {milliseconds} milliseconds to load html");
            return result;
#else
            return V2EXRequest.GetHtmlDoc(HtmlUrl);
#endif
        }

        async void IAwareViewLoadedAndUnloaded.OnViewLoaded(object view)
        {
            IsLoadingHtml = true;
            var htmlDoc = await Task.Factory.StartNew(GetHtml);
            await Task.Factory.StartNew(() => OnHtmlLoaded(htmlDoc));
            IsLoadingHtml = false;
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
