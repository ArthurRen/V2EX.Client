using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HtmlAgilityPack;
using log4net;
using V2EX.Client.Infrastructure;
using V2EX.Client.Infrastructure.Commands;
using V2EX.Client.Network;

namespace V2EX.Client.ViewModels.Pages
{
    public abstract class CommonPageViewModel : ViewModelBase, IAwareViewLoadedAndUnloaded
    {
        private bool _isLoadingHtml;
        private bool _isRenderingHtml;
        private int _requestIndex;
        protected ILog Logger { get; }

        public bool IsLoadingHtml
        {
            get => _isLoadingHtml;
            set => SetProperty(ref _isLoadingHtml, value);
        }

        public bool IsRenderingHtml
        {
            get => _isRenderingHtml;
            set => SetProperty(ref _isRenderingHtml, value);
        }

        protected Uri CurrentUrl { get; set; }
    
        public ICommand RefreshPageCommand { get; }

        protected CommonPageViewModel()
        {
            Logger = LogManager.GetLogger(GetType());
            RefreshPageCommand = new AsyncCommand(LoadHtmlAsync , () => !IsLoadingHtml);
        }

        public void Initialize(string htmlUrl)
        {
            CurrentUrl = new Uri(htmlUrl , UriKind.Absolute);
        }

        protected async void LoadHtmlAsync()
        {
            if (IsLoadingHtml)
                return;
            IsLoadingHtml = true;

            _requestIndex++;
            try
            {
                await Task.Factory.StartNew(param =>
                {
                    if (!(param is int index))
                        return;

                    OnHtmlLoading();
                    var doc = V2EXRequest.GetHtmlDoc(CurrentUrl);
                    if (_requestIndex != index)
                        return;

                    IsRenderingHtml = true;
                    OnHtmlLoaded(doc);
                    IsRenderingHtml = false;

                } , _requestIndex);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
            
            IsLoadingHtml = false;
        } 

        void IAwareViewLoadedAndUnloaded.OnViewLoaded(object view)
        {
            LoadHtmlAsync();
        }

        void IAwareViewLoadedAndUnloaded.OnViewUnloaded(object view)
        {

        }

        protected virtual void OnHtmlLoaded(HtmlDocument htmlDocument) { }

        protected virtual void OnHtmlLoading() { }
    }
}
