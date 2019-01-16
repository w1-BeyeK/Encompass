using Encompass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace Encompass.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BalancePage : ContentPage
	{
        public Balance SelectedBalance { get; set; }

		public BalancePage (Balance balance)
		{
			InitializeComponent ();
            
            BindingContext = balance;

		}
        
        public void NFCtest()
        {
            
        }
	}
}