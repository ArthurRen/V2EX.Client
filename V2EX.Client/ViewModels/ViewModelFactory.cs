using System;
using System.Windows;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Unity;

namespace V2EX.Client.ViewModels
{
    public class ViewModelFactory
    {
        private readonly Func<IContainerProvider> _containerGetter;
        private Action<object, object> _viewModelConfiguration;

        public ViewModelFactory(Func<IContainerProvider> containerGetter)
        {
            _containerGetter = containerGetter;
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
            var viewModel = _containerGetter().Resolve(viewModelType);
            _viewModelConfiguration?.Invoke(view, viewModel);
            return viewModel;
        }
    }
}
