using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using V2EX.Client.Controls;
using V2EX.Client.ViewModels;
using V2EX.Client.ViewModels.Pages;

namespace V2EX.Client.Views.Pages
{
    public interface IPageBuilder
    {
        CommonPage Build(string url);
        IPageBuilder Initialize(Action<CommonPageViewModel> viewModelInitialize);
    }

    public interface IPageBuilder<out TView> : IPageBuilder
        where TView : CommonPage, new()
    {
        IPageBuilder<TView> Initialize(Action<TView> viewInitialize);
    }

    public static class PageBuilder
    {
        public static IPageBuilder<TView> Wrap<TView>()
            where TView : CommonPage, new()
        {
            return new PageBuilderImplement<TView>();
        }

        private class PageBuilderImplement<TView> : IPageBuilder<TView>
            where TView : CommonPage, new()
        {
            private TView _view;
            private Action<TView> _viewInitialize;
            private Action<CommonPageViewModel> _viewModelInitialize;

            public IPageBuilder<TView> Initialize(Action<TView> viewInitialize)
            {
                var oldInitialize = _viewInitialize;
                _viewInitialize = view =>
                {
                    oldInitialize?.Invoke(view);
                    viewInitialize?.Invoke(view);
                };
                return this;
            }

            public IPageBuilder Initialize(Action<CommonPageViewModel> viewModelInitialize)
            {
                var oldInitialize = viewModelInitialize;
                _viewModelInitialize = viewModel =>
                {
                    oldInitialize?.Invoke(viewModel);
                    viewModelInitialize?.Invoke(viewModel);
                };
                return this;
            }

            public CommonPage Build(string url)
            {
                _view = new TView();
                _viewInitialize?.Invoke(_view);
                if (_view.DataContext is CommonPageViewModel viewModel)
                {
                    _viewModelInitialize?.Invoke(viewModel);
                    viewModel.Initialize(url);
                }
                return _view;
            }
        }
    }
}
