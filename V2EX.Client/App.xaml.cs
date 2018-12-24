using System;
using System.Linq;
using System.Windows;
using CommonServiceLocator;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using Unity;
using V2EX.Client.ViewModels.Infrastructure;

namespace V2EX.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void ConfigureViewModelLocator()
        {
            var factory =
                ViewModelFactory.Instance
                    .IfInheritFrom<FrameworkElement , ViewModelBase>((view , viewModel) => viewModel.Dispatcher = view.Dispatcher)
                    .IfInheritFrom<FrameworkElement, IAwareViewLoadedAndUnloaded>((view, viewModel) =>
                    {
                        view.Loaded += (sender, _) => viewModel.OnViewLoaded(sender);
                        view.Unloaded += (sender, _) => viewModel.OnViewUnloaded(sender);
                    })
                    .IfInheritFrom<FrameworkElement, IAwareViewInitialize>((view, viewModel) =>
                        view.Loaded += (sender, _) => viewModel.OnViewInitialize(sender));

            ViewModelLocationProvider.SetDefaultViewModelFactory(factory.GetViewModel);
        }
    }
}
