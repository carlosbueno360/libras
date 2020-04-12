using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTECLIBRAS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {


            InitializeComponent();
            email.SetValue(Label.TextProperty, Convert.ToString(App.Current.Properties["Email"]));
            userName.SetValue(Label.TextProperty, Convert.ToString(App.Current.Properties["UserName"]));
        }
    }
}