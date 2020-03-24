using AppTECLIBRAS.Tables;
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
		public RegistrarPage ()
		{
			InitializeComponent ();
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
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = NomeEntry.Text,
                Email = emailEntry.Text,
                Senha = senhaEntry.Text,
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Parabéns", "Usuário Registrado com Sucesso", "OK",".");
                if (result)
                {
                    await Navigation.PushAsync(new LoginPage());
                }

            });
        }
    }
}