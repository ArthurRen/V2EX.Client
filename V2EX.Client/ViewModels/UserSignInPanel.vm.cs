using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using V2EX.Client.Commands;
using V2EX.Client.ViewModels.Infrastructure;
using V2EX.Foundation.Commands;

namespace V2EX.Client.ViewModels
{
    public class UserSignInPanelViewModel : ViewModelBase
    {
        public ICommand SignInCommand { get; }

        public ICommand ForgetPasswordCommand { get; }

        public UserSignInPanelViewModel()
        {
            SignInCommand = new RelayCommand(SignIn);
            ForgetPasswordCommand = new RelayCommand(ForgetPassword);
        }

        private void SignIn()
        {

        }

        private void ForgetPassword()
        {

        }
    }
}
