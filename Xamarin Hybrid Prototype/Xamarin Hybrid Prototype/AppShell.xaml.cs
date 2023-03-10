using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.ViewModels;
using Xamarin_Hybrid_Prototype.Views;

namespace Xamarin_Hybrid_Prototype
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PartyDetailPage), typeof(PartyDetailPage));
            Routing.RegisterRoute(nameof(NewPartyPage), typeof(NewPartyPage));
            Routing.RegisterRoute(nameof(UsersListPage), typeof(UsersListPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
