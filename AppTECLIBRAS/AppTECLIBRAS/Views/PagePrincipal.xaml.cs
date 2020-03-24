using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTECLIBRAS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagePrincipal : MasterDetailPage
	{
		public PagePrincipal ()
		{
            SetValue(NavigationPage.HasNavigationBarProperty, false);  /*ESCONDE A NAVEBAR DO LOGIN DESCONFIGURA ESSA PAGE*/
			InitializeComponent ();
            BtHome_Clicked(new Object(), new EventArgs());
        }

        private void BtHome_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageHome());
            IsPresented = false;             /*esconde o Menu*/
        }

        private void BtCalibrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCalibrarLuva());
            IsPresented = false;
        }

        private void BtAlfabetizar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageAlfabetizar());
            IsPresented = false;
        }

        private void BtExercicio_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageExercicios());
            IsPresented = false;
        }

        private void BtSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageSobre());
            IsPresented = false;
        }

        async void BtSair_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

       
    }
}