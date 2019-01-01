using Encompass.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encompass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuMaster : ContentPage
    {
        public ListView ListView;

        public MasterMenuMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterMenuItem> MenuItems { get; set; }
            
            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem { Id = 1, Title = "Cards", Icon = "card.png", TargetType = typeof(CardsPage) },
                    new MasterMenuItem { Id = 2, Title = "My Account", Icon = "settings.png", TargetType = typeof(SettingsPage)},
                    new MasterMenuItem { Id = 3, Title = "Information", Icon = "info.png", TargetType = typeof(InformationPage) },
                    new MasterMenuItem { Id = 4, Title = "Logout", Icon = "info.png", TargetType = typeof(LoginPage) }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}