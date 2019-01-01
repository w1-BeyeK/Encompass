using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encompass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu : MasterDetailPage
    {
        public MasterMenu()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterMenuItem item = e.SelectedItem as MasterMenuItem;

            if (item == null)
            {
                return;
            }
            
            const int logoutItemId = 4;

            if (item.Id == logoutItemId)
            {
                Application.Current.Properties.Clear();
            }

            Page page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}