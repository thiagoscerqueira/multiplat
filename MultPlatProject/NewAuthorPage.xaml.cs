using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultPlatProject
{	
	public partial class NewAuthorPage : ContentPage
    {
        async void Handle_Back(object sender, EventArgs e)
        {
            await DisplayAlert("Sucesso", "Autor cadastrado com sucesso. Ele pode não ser mostrado na pesquisa pois a mesma está limitada a 10 registros", "ok");
            await Navigation.PopAsync();
        }

        void Handle_RequestFailed(object sender, MultPlatProject.ErrorResponse e)
        {
            DisplayAlert("Erro", e.Message, "ok");
        }

        public NewAuthorPage()
		{
            InitializeComponent();
        }
	}
}