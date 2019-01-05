using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using V2EX.Client.Controls;
using V2EX.Client.Helpers;
using V2EX.Client.ViewModels.Infrastructure;
using V2EX.Client.Views;
using V2EX.Client.Views.Pages;
using V2EX.Foundation.Commands;

namespace V2EX.Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase , IAwareViewLoadedAndUnloaded
    {
        private CommonPage _currentPage;
        private FrameworkElement _userPanel;

        public CommonPage CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public FrameworkElement UserPanel
        {
            get => _userPanel;
            set => SetProperty(ref _userPanel, value);
        }

        public ICommand UserCommand { get; }
        public ICommand SettingCommand { get; }

        public MainWindowViewModel()
        {
            UserCommand = new RelayCommand(ShowUserPanel);
            SettingCommand = new RelayCommand(ShowSettingPanel);
        }

        public void OnViewLoaded(object view)
        {
            CurrentPage = PageBuilder
                            .Wrap<MainPage>()
                            .Build(UrlHelper.HomeAddress);
        }

        public void ShowUserPanel()
        {
            UserPanel = new UserSignInPanel();
        }

        public void ShowSettingPanel()
        {

        }

        public void OnViewUnloaded(object view) { }
    }
}
