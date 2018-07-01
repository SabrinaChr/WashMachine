using System;
using Autofac;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using WashMachine.Core;
using WashMachine.Enums;
using WashMachine.Infrastructure;
using WashMachine.ViewModels;
using WashMachine.Views;

namespace WashMachine
{
    public class ViewModelLocator
    {
       // private static IContainer _container;

        public static void Initialize()
        {
            RegisterDependencies();   
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public static void Cleanup()
        {
            
        }

        private static void RegisterDependencies()
		{
			//var builder = new ContainerBuilder();

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IUserRepository, UserRepository>();

            var navigationService = new NavigationService();

            navigationService.Configure(AppPages.LoginPage.ToString(), typeof(LoginView));
            navigationService.Configure(AppPages.RegisterPage.ToString(), typeof(RegisterView));
            navigationService.Configure(AppPages.MainPage.ToString(), typeof(MainPage));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
           
			//builder.RegisterType<LoginViewModel>();
			//builder.RegisterType<MainViewModel>();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance(); 

           // _container= builder.Build();

		}

        internal static object Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}
