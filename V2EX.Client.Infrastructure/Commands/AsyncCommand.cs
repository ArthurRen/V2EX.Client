using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace V2EX.Client.Infrastructure.Commands
{
    public class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public AsyncCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = async () => await Task.Factory.StartNew(execute);
            _canExecute = () => canExecute?.Invoke() ?? true;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public async void Execute(object parameter)
        {
            await Task.Factory.StartNew(_execute);
        }
    }

    public class AsyncCommand<TParam> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<TParam> _execute;
        private readonly Func<TParam, bool> _canExecute;
        
        public AsyncCommand(Action<TParam> execute, Func<TParam , bool> canExecute = null)
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
