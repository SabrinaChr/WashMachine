using WashMachine.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WashMachine
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public App()
        {
            InitializeComponent();
            ViewModelLocator.Initialize();

            var mainPage = new NavigationPage(new LoginView());
			MainPage = mainPage;
        }

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        protected override void OnStart()
        {
            //InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //private Task InitNavigation()
        //{
        //    var navigationService = ViewModelLocator.Resolve<INavigationService>();
        //    return navigationService.InitializeAsync();
        //}
    }
}
