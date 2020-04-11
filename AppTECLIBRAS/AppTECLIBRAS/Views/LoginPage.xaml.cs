using AppTECLIBRAS.Clients;
using AppTECLIBRAS.Tables;
using AppTECLIBRAS.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTECLIBRAS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            /* loginButton.Clicked += LoginButton_Clicked; */ /*VERIFICAÇÃO DOS CAMPOS*/
        }

        async void LoginButton_Clicked(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(emailEntry.Text))
            {
                await DisplayAlert("Erro!", "Digite um email Válido", "Aceitar");
                emailEntry.Focus();
                return;
            }

            if (String.IsNullOrEmpty(senhaEntry.Text))
            {
                await DisplayAlert("Erro!", "Digite uma senha Válida", "Aceitar");
                senhaEntry.Focus();
                return;        /*FIM DA VERIFICAÇÃO DOS CAMPOS*/
            }

            UserLogin userLogin = new UserLogin() { 
                 Email = emailEntry.Text,
                 Password = senhaEntry.Text
            };
            AuthClient authClient = new AuthClient();

            var token = await authClient.Login(userLogin);
            var IsLoggedIn = true;
            if (string.IsNullOrWhiteSpace(token))
                IsLoggedIn = false;

            SetProperties("IsLoggedIn", IsLoggedIn);


            if (IsLoggedIn)
            {
                App.Current.MainPage = new NavigationPage(new PagePrincipal());
                
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Erro!", "Nome de Usuário ou Senha não encontrado", "Sim", "Cancelar");
                    if (result)
                    {
                        await Navigation.PushAsync(new LoginPage());
                       
                    }
                    else
                    {
                        await Navigation.PushAsync(new LoginPage());
                        
                    }

                });

            }
        }

        public async static void SetProperties(string property, object value)
        {
            var app = (App)Application.Current;
            app.Properties[property] = value;
            await app.SavePropertiesAsync();
        }

        async void Cad_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarPage());
        }
    }
}
