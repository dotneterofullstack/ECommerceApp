using System;
using System.ComponentModel;
using System.Windows.Input;
using ECommerceApp.Models;
using ECommerceApp.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private NavigationService navigationService;
        private DialogService dialogService;
        private ApiService apiService;
        private DataService dataService;
        private bool isRunning;
        #endregion

        #region Properties
        public string User
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set 
            {
                if (isRunning != value) 
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(
                        nameof(IsRunning)));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await dialogService.ShowMessage("Error", "Debes ingresar un usuario");
                return;
            }

            if (string.IsNullOrEmpty(Password))
			{
				await dialogService.ShowMessage("Error", "Debes ingresar una contraseña");
				return;
			}

            IsRunning = true;
            var response = await apiService.Login(User, Password);
            IsRunning = false;

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            var user = response.Result as User;
            user.IsRemembered = IsRemembered;
            user.Password = Password;

            dataService.InsertUser(user);
            User = string.Empty;
            Password = string.Empty;
            navigationService.SetMainPage(user);
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            apiService = new ApiService();
            dataService = new DataService();

            IsRemembered = true;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
