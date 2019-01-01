using Encompass.Data;
using Encompass.Models;
using Encompass.View;
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
    public partial class CardsPage : ContentPage
    {
        public CardsPage()
        {
            InitializeComponent();
            CardListView.ItemSelected += CardListView_ItemSelected;

            Service service = new Service();
            List<Balance> cards = service.GetUserCards(1);

            CardListView.ItemsSource = cards;
        }

        private async void CardListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Balance balance = e.SelectedItem as Balance;

            if (balance == null)
            {
                return;
            }

            var balancePage = new BalancePage(balance);
            await Navigation.PushAsync(balancePage);
        }
    }
}