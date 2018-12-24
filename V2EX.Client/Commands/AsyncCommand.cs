using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace V2EX.Client.Commands
{
    internal class AsyncCommand<TParam> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<TParam> _execute;
        private readonly Func<TParam, bool> _canExecute;

        public AsyncCommand(Action execute, Func<bool> canExecute)
        {
            _execute = async _ => await Task.Factory.StartNew(execute);
            _canExecute = _ => canExecute?.Invoke() ?? true;
        }

        public AsyncCommand(Action<TParam> execute, Func<TParam , bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is TParam param)
            {
                return _canExecute?.Invoke(param) ?? true;
            }

            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter is TParam param)
            {
                await Task.Factory.StartNew(() => { _execute?.Invoke(param); });
            }
        }
    }
}
