using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Encompass
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // user is logged in
            if (Current.Properties.ContainsKey("UserID"))
            {
                if (Current.Properties.ContainsKey("HasPin"))
                {
                    MainPage = new NavigationPage(new PinCodePage());
                    return;
                }
            }

            MainPage = new NavigationPage(new LoginPage());
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
