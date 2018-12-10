using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultPlatProject
{
    public abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<ErrorResponse> RequestFailed;

        IEnumerable<T> mData;
        public IEnumerable<T> Data
        {
            get => mData;
            set => SetProperty(ref mData, value, "Data");            
        }

        Boolean mIsLoading;
        public Boolean IsLoading
        {
            get => mIsLoading;
            set => SetProperty(ref mIsLoading, value, "IsLoading");          
        }

        protected void SetProperty<U>(ref U propRef, U propNewValue, string propName)
        {
            if (!Equals(propRef, propNewValue))
            {
                propRef = propNewValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public ICommand GetCommand { get; private set; }

        public BaseViewModel()
        {
            GetCommand = new Command<string>((text) => Request("GET", text));
        }

        protected async void Request(string method, string param, Object obj = null, EventHandler eventOnSucess = null)
        {
            IsLoading = true;
            try
            {
                Url url = Constants.BaseServiceUrl.AppendPathSegment(typeof(T).Name);
                url = customizeUrl(url, param);

                if (method.Equals("GET")) {
                    Data = await url.GetJsonAsync<List<T>>();
                } else {
                    string response = await url.PostJsonAsync(obj).ReceiveString();
                    Console.WriteLine(response);
                }
                
                IsLoading = false;

                eventOnSucess?.Invoke(this, null);                
             }
             catch (FlurlHttpException ex) { 
                
                    IsLoading = false;
                    var error = await ex.GetResponseJsonAsync<ErrorResponse>();

                    RequestFailed?.Invoke(this, error);
             }            
        }

        protected virtual Url customizeUrl(Url urlBase, string text)
        {
            return urlBase;
        }
    }

  
}
