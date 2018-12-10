using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Flurl;
using Flurl.Http;
using Xamarin.Forms;

namespace MultPlatProject
{
    public class BooksViewModel : BaseViewModel<Book>
    {
        protected override Url customizeUrl(Url url, string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                return url.SetQueryParam("where", "title like '%" + text + "%'");
            }

            return url;
        }
    }
}
