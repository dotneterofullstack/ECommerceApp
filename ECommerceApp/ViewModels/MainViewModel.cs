using System;
using System.Collections.ObjectModel;
using ECommerceApp.Pages;

namespace ECommerceApp.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get;
            set;
        }

        public LoginViewModel NewLogin
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            NewLogin = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel{
                Icon = "ic_action_product.png",
                PageName = nameof(ProductsPage),
                Title = "Productos"    
            });

			Menu.Add(new MenuItemViewModel
			{
				Icon = "ic_action_customer.png",
				PageName = nameof(CustomersPage),
				Title = "Clientes"
			});

			Menu.Add(new MenuItemViewModel
			{
				Icon = "ic_action_order.png",
				PageName = nameof(OrdersPage),
				Title = "Pedidos"
			});

			Menu.Add(new MenuItemViewModel
			{
				Icon = "ic_action_delivery.png",
				PageName = nameof(DeliveriesPage),
				Title = "Entregas"
			});

			Menu.Add(new MenuItemViewModel
			{
				Icon = "ic_action_sync.png",
				PageName = nameof(SyncPage),
				Title = "Sincronizar"
			});

			Menu.Add(new MenuItemViewModel
			{
				Icon = "ic_action_setup.png",
				PageName = nameof(SetupPage),
				Title = "Configuración"
			});

			Menu.Add(new MenuItemViewModel
			{
				Icon = "ic_action_logout.png",
                PageName = "LogoutPage",
				Title = "Cerrar Sesión"
			});
        }
		#endregion
    }
}
