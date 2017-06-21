using System;
using System.Threading.Tasks;
using ECommerceApp.Pages;

namespace ECommerceApp.Services
{
    public class NavigationService
    {
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
                default:
                    break;
            }
        }

        public NavigationService()
        {
        }
    }
}
