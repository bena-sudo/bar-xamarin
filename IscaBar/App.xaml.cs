using iscaBar.Views;
using IscaBar.DAO.Servidor;
using IscaBar.Services;
using IscaBar.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IscaBar
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new OrdersListView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
