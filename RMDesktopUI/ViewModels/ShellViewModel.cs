using Caliburn.Micro;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        private LoginViewModel _loginViewModel;
        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;   
            ActivateItemAsync(_loginViewModel);
        }
    }
}
