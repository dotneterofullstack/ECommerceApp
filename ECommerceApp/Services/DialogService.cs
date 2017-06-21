using System;
using System.Threading.Tasks;

namespace ECommerceApp.Services
{
    public class DialogService
    {
        public async Task ShowMessage(string title, string message) 
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Aceptar");
        }

        public DialogService()
        {
        }
    }
}
