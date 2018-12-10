using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MultPlatProject
{
    public partial class AuthorsPage : ContentPage
    {
        async void Handle_NewAuthor(
           object sender,
           EventArgs e
       )
        {
            await Navigation.PushAsync(
                new NewAuthorPage()
            );
        }

        public AuthorsPage()
        {
            InitializeComponent();
        }

        // Executado toda vez que a tela for exibida.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Pega o view model pelo cast do BindingContext e executa o GetCommand.
            // Isso deve popular a lista de autores inicialmente.
            (BindingContext as AuthorsViewModel).GetCommand.Execute(null);
        }

        // Executado quando a requisição de consulta dos autores falha.
        void Handle_RequestFailed(object sender, MultPlatProject.ErrorResponse e)
        {
            // Mostra alerta.
            DisplayAlert("Erro", e.Message, "ok");
        }
    }
}
