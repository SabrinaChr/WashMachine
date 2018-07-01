using Xamarin.Forms;
using System.Windows.Input;

namespace WashMachine.Views
{
	public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = App.Locator.LoginViewModel;
        }
     }
}
