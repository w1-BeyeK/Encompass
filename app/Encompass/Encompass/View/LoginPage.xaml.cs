using Encompass.Data;
using Encompass.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encompass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            pinCodeLink.GestureRecognizers.Add(tapGestureRecognizer);
        }
        
        async void OnLogin(object sender, EventArgs args)
        {
            string usernameText = username.Text;
            string passwordText = password.Text;

            if (string.IsNullOrEmpty(usernameText) || string.IsNullOrEmpty(passwordText))
            {
                await DisplayAlert("Alert", "Both a username and password are required to login", "OK");
            }
            else
            {
                try
                {
                    // for testing purposes
                    usernameText = "kbeye1999@hotmail.com";
                    passwordText = "asdf123";

                    Service service = new Service();
                    User user = service.Login(usernameText, passwordText);

                    if (user != null)
                    {
                        Application.Current.Properties["UserID"] = user.ID;
                        Application.Current.Properties["UserName"] = user.Name;

                        if (user.Code != null)
                        {
                            Application.Current.Properties["HasPin"] = true;
                        }

                        var mDP = new MasterMenu();
                        NavigationPage.SetHasNavigationBar(mDP, false);
                        Application.Current.MainPage = new MasterMenu();
                        await Navigation.PushAsync(mDP);
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Username or password was invalid", "OK");
                    }
                }
                catch (Exception e)
                {
                    string message = e.InnerException.ToString();
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var pinCodePage = new PinCodePage();
            await Navigation.PushAsync(pinCodePage);
        }
    }
}
