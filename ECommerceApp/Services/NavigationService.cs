using System;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Pages;
using ECommerceApp.ViewModels;

namespace ECommerceApp.Services
{
    public class NavigationService
    {
        private DataService dataService;

        public async Task Navigate(string pageName) 
        {
            App.Master.IsPresented = false;
            switch (pageName) 
            {
                case nameof(CustomersPage):
                    await App.Navigator.PushAsync(new CustomersPage());
                    break;
				case nameof(DeliveriesPage):
					await App.Navigator.PushAsync(new DeliveriesPage());
					break;
                case nameof(OrdersPage):
					await App.Navigator.PushAsync(new OrdersPage());
					break;
				case nameof(ProductsPage):
					await App.Navigator.PushAsync(new ProductsPage());
					break;
                case nameof(SetupPage):
					await App.Navigator.PushAsync(new SetupPage());
					break;
                case nameof(SyncPage):
					await App.Navigator.PushAsync(new SyncPage());
					break;
                case "LogoutPage":
                    Logout();
                    break;
            }
        }

        private void Logout()
        {
            App.CurrentUser.IsRemembered = false;
            dataService.UpdateUser(App.CurrentUser);
            App.Current.MainPage = new LoginPage();
        }

        internal void SetMainPage(User user)
        {
            App.CurrentUser = user;
            MainViewModel.GetInstance().LoadUser(user);
            App.Current.MainPage = new MasterPage();
        }

        public NavigationService()
        {
            dataService = new DataService();
        }
    }
}
