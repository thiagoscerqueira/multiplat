using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultPlatProject
{
    class NewAuthorViewModel : BaseViewModel<Author>
    {
        public event EventHandler AuthorAdded;

        public ICommand PostCommand { get; private set; }

        public NewAuthorViewModel() {            
            PostCommand = new Command<string>((text) => Request("POST", text, new Author { Name = text }, AuthorAdded));
        }
    }
}
