using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using WashMachine.Core;
using WashMachine.Enums;
using GalaSoft.MvvmLight.Views;
using System;

namespace WashMachine.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool _isLogin;
        private string _email;
        private string _password;
        private readonly IUserRepository _userRepository;
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService, IUserRepository userRepository)
        {
             _navigationService = navigationService;
             _userRepository = userRepository;
        }

        public ICommand LoginCommand => new Command(async () => await LoginAsync());
        public ICommand RegisterCommand => new Command(Register);

        public bool IsLogin
        {
            get
            {
                return _isLogin;
            }
            set
            {
				SetProperty(ref _isLogin, value);
            }
        }

        public string Email 
		{
            get
			{
				return _email;
			}
			set
			{
				SetProperty(ref _email, value);
			}
		}

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        private async Task LoginAsync()
        {
            var user = await _userRepository.GetUserByEmail(Email);
            if(user !=null && user.Password == Password)
            {
                _navigationService.NavigateTo(AppPages.MainPage.ToString());
            }
        }


        private void Register()
        {
            _navigationService.NavigateTo(AppPages.RegisterPage.ToString());
        }
	}
}