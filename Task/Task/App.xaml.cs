using System;
using Task.Services;
using Task.Services.Interfaces;
using Task.ViewModels;
using Task.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Task
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
          

            
        }

        protected override void OnStart()
        {
            MainPage = new MainPage();
            MainPage.BindingContext = Bootstrapper.Bootstrapper.RootVisual;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
