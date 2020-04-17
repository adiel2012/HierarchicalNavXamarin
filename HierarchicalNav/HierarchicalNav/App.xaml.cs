using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchicalNav
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(Utils.Functions.GetTree(), 1));
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
