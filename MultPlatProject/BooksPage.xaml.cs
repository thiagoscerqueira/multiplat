using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MultPlatProject
{
    public partial class BooksPage : ContentPage
    {
        public BooksPage()
        {
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();            
            (BindingContext as BooksViewModel).GetCommand.Execute(null);
        }
        
        void Handle_RequestFailed(object sender, MultPlatProject.ErrorResponse e)
        {            
            DisplayAlert("Erro", e.Message, "ok");
        }
    }
}
