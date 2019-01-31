using System.Windows.Input;
using V2EX.Client.Infrastructure;
using V2EX.Client.Infrastructure.Commands;

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
