using AppTECLIBRAS.Clients;
using AppTECLIBRAS.ViewModels;
using AppTECLIBRAS.Views;
using Refit;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppTECLIBRAS
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();
            bool isLoggedIn = Application.Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(App.Current.Properties["IsLoggedIn"]) : false;

            if (isLoggedIn)
            {
                MainPage = new NavigationPage(new PagePrincipal());
            }else 
            {
                MainPage = new NavigationPage(new LoginPage());
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
