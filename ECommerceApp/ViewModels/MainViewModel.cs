using System;
using System.Collections.ObjectModel;
using ECommerceApp.Models;
using ECommerceApp.Pages;
using ECommerceApp.Services;

namespace ECommerceApp.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private DataService dataService;
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }
        #endregion

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

        public UserViewModel UserLogged
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;

            Menu = new ObservableCollection<MenuItemViewModel>();
            NewLogin = new LoginViewModel();
            UserLogged = new UserViewModel();
            dataService = new DataService();

            LoadMenu();
        }
		#endregion

		#region Methods
        public void LoadUser(User user)
		{
			UserLogged.FullName = user.FullName;
			UserLogged.Photo = user.PhotoFullPath;
		}

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
