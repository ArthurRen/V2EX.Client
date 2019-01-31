using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using V2EX.Client.Controls;
using V2EX.Client.Helpers;
using V2EX.Client.Infrastructure;
using V2EX.Client.Infrastructure.Commands;
using V2EX.Client.Views;
using V2EX.Client.Views.Pages;

namespace V2EX.Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase , IAwareViewLoadedAndUnloaded
    {
        private CommonPage _currentPage;

        public CommonPage CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public MainWindowViewModel()
        {
        }

        public void OnViewLoaded(object view)
        {
            CurrentPage = PageBuilder.Wrap<MainPage>().Build(UrlHelper.HomeAddress);
        }

        public void ShowSettingPanel()
        {

        }

        public void OnViewUnloaded(object view) { }
    }
}
