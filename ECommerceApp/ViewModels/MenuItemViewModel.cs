using System;
using System.Windows.Input;
using ECommerceApp.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceApp.ViewModels
{
    public class MenuItemViewModel
    {
        #region Attributes
        private NavigationService navigationService; 
        #endregion

        #region Properties
        public string Icon
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string PageName
        {
            get;
            set;
        }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }

        private async void Navigate()
        {
            await navigationService.Navigate(PageName);
        }
        #endregion

        #region Constructors
        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        } 
        #endregion
    }
}
