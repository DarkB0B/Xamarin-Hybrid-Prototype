using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersListPage : ContentPage
    {
        public List<User> Users { get; set; }

        public UsersListPage(List<User> users)
        {
            InitializeComponent();

            Users = users;

            MyListView.ItemsSource = Users;
        }

        
    }
}
