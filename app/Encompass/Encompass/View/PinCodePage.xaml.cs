using Encompass.Data;
using Encompass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encompass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinCodePage : ContentPage
    {
        public PinCodePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnConfirm(object sender, EventArgs args)
        {
            string pinCode = pin.Text;
            int maxLength = pin.MaxLength;

            if (pinCode.Length != maxLength)
            {
                await DisplayAlert("Alert", $"Pin should have {maxLength} digits", "OK");
                return;
            }

            Service service = new Service();
            User user = service.LoginWithPinCode(pinCode);

            if (user != null)
            {
                var mDP = new MasterMenu();
                NavigationPage.SetHasNavigationBar(mDP, false);
                Application.Current.MainPage = new MasterMenu();
                await Navigation.PushAsync(mDP);
            }
            else
            {
                await DisplayAlert("Alert", "Pin code was invalid", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            pin.Focus();
        }
    }
}