using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Prism.Mvvm;

namespace V2EX.Client.ViewModels.Infrastructure
{
    public abstract class ViewModelBase : BindableBase
    {
        public Dispatcher Dispatcher { get; set; }

        protected void InvokeInUiThread(Action method , params object[] args) => Dispatcher?.Invoke(method , args);
        protected void BeginInvokeInUiThread(Action method, params object[] args) => Dispatcher?.BeginInvoke(method, args);

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (Dispatcher?.CheckAccess() ?? true)
            {
                base.OnPropertyChanged(args);
            }
            else
            {
                InvokeInUiThread(() => base.OnPropertyChanged(args));
            }
        }
    }
}
