using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Nfc;
using Android.Nfc.Tech;
using Android.Content;
using System.Text;
using Acr.UserDialogs;

namespace Encompass.Droid
{
    [Activity(Label = "Encompass", Icon = "@mipmap/icon", Theme = "@style/Encompass", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
      
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Rg.Plugins.Popup.Popup.Init(this, bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);
       

            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();

          
        }
    }
}