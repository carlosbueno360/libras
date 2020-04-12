using AppTECLIBRAS.Clients;
using AppTECLIBRAS.Tables;
using AppTECLIBRAS.ViewModels;
using Refit;
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
    public partial class RegistrarPage : ContentPage
    {
       

        public RegistrarPage()
        {
            
            InitializeComponent();
        }

        async void RegButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(NomeEntry.Text))
            {
                await DisplayAlert("Erro!", "Digite um Nome Válido", "Aceitar");
                NomeEntry.Focus();
                return;
            }
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


            var userRegistration = new UserRegistration()
            {
                Username = NomeEntry.Text,
                Email = emailEntry.Text,
                Password = senhaEntry.Text,
                PasswordConfirm = senhaEntry.Text
            };

            AuthClient authClient = new AuthClient();

            var token = await authClient.RegisterUser(userRegistration);

            if (token.Success)
                return;

            SetProperties("IsLoggedIn", token.Success);
            SetProperties("UserName", NomeEntry.Text);
            SetProperties("UserId", token.UserId);
            SetProperties("Email", token.Email);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Parabéns", "Usuário Registrado com Sucesso", "OK",".");
                if (result)
                {
                    await Navigation.PushAsync(new PagePrincipal());
                }
            });
        }

        public async static void SetProperties(string property, object value)
        {
            var app = (App)Application.Current;
            app.Properties[property] = value;
            await app.SavePropertiesAsync();
        }
    }


   

    public class RestEndPoints
    {
        public static string BaseUrl => "https://192.168.1.79:45455/";
    }
}