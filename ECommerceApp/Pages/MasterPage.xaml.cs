using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ECommerceApp.Pages
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			App.Master = this;
            App.Navigator = Navigator;
        }
    }
}
