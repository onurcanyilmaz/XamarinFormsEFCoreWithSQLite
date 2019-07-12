using EFCoreDatabase;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EFCoreWithSQLite
{
    public partial class App : Application
    {
        public App(IProductRepository productRepository)
        {
            InitializeComponent();

            MainPage = new ProductPage()
            {
                BindingContext = new ProductViewModel(productRepository)
            };
        }



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
    }
}
