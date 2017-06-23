using ECommerceApp.Models;
using ECommerceApp.Pages;
using ECommerceApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ECommerceApp
{
    public partial class App : Application
    {
        #region Attributes
        private DataService dataService;
        private NavigationService navigationService;
        #endregion

        #region Properties
        public static NavigationPage Navigator { get; set; }

        public static MasterPage Master { get; set; }

        public static User CurrentUser { get; set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();
            dataService = new DataService();
            navigationService = new NavigationService();

            var user = dataService.GetUser();

            if (user != null && user.IsRemembered)
            {
                //App.CurrentUser = user;
                //MainPage = new MasterPage();
                navigationService.SetMainPage(user);
            }
            else
            {
                MainPage = new LoginPage();
            }
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
