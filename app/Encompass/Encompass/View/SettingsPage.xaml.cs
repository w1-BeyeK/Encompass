using System;
using Encompass.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace Encompass.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

        public async void ShowAlert(object sender, EventArgs args)
        {
            
           if(PinSwitch.On == false)
            {
                PromptResult result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                {
                    MaxLength = 5,
                    InputType = InputType.NumericPassword,
                    Title = "Insert Pincode",
                    IsCancellable = true
                });

                if (result.Ok && result.Text.Length == 5)
                {
                    Service service = new Service();
                    int userId = (int)Application.Current.Properties["UserID"];
                    service.UpdateUserCode(userId, result.Text);
                }

                else
                {

                }

            }
           else
            {
               await  DisplayAlert("baba", "true", "ok");

            }
        }

        public async void ExportCardData(object sender, EventArgs args)
        {
            int userId = (int)Application.Current.Properties["UserID"];

            if (FileHandler.ExportCardTxt(userId))
            {
                await DisplayAlert("Exported succesful", "Your cards have been succesfully exported", "OK");
            }
            else
            {
                await DisplayAlert("Exported unsuccesful", "We were unsuccesful in the exporting of the cards", "OK");
            }
          
        }
	}
}