using System;
using System.Windows;
using Prism;
using Prism.Unity;
using Unity;

namespace V2EX.Client.ViewModels.Infrastructure
{
    public class ViewModelFactory
    {
        private static ViewModelFactory _instance;
        private static readonly object Lock = new object();

        public static ViewModelFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ViewModelFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        private readonly PrismApplicationBase _application;
        private Action<object , object> _viewModelConfiguration;

        private ViewModelFactory()
        {
            // TODO : Optimization
            if (Application.Current is PrismApplicationBase application)
                _application = application;
            else
                throw new InvalidOperationException("Application.Current is not PrismApplicationBase");
        }

        public ViewModelFactory IfViewModelInheritFrom<TViewModel>(Action<object, TViewModel> configuration)
        {
            var previous = _viewModelConfiguration;
            _viewModelConfiguration = (view, viewModel) =>
            {
                previous?.Invoke(view, viewModel);
                if (viewModel is TViewModel tViewModel)
                    configuration?.Invoke(view, tViewModel);
            };
            return this;
        }

        public ViewModelFactory IfViewInheritFrom<TView>(Action<TView, object> configuration)
        {
            var previous = _viewModelConfiguration;
            _viewModelConfiguration = (view, viewModel) =>
            {
                previous?.Invoke(view, viewModel);
                if (view is TView tView)
                    configuration?.Invoke(tView, viewModel);
            };
            return this;
        }

        public ViewModelFactory IfInheritFrom<TView , TViewModel>(Action<TView, TViewModel> configuration)
        {
            var previous = _viewModelConfiguration;
            _viewModelConfiguration = (view, viewModel) =>
            {
                previous?.Invoke(view, viewModel);
                if (view is TView tView && viewModel is TViewModel tViewModel)
                    configuration?.Invoke(tView, tViewModel);
            };
            return this;
        }
        
        public object GetViewModel(object view , Type viewModelType)
        {
            var viewModel = _application.Container.GetContainer().Resolve(viewModelType);
            _viewModelConfiguration?.Invoke(view, viewModel);
            return viewModel;
        }
    }
}
