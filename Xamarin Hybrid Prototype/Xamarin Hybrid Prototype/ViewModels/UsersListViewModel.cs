using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;
using Xamarin_Hybrid_Prototype.Views;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    [QueryProperty(nameof(Users), nameof(Users))]
    public class UsersListViewModel : BaseViewModel
    {
       
       

        
        public Command LoadUsersCommand { get; }
        public List<User> Users;

        public UsersListViewModel()
        {
            Title = "People invited to this party";
            Users = new List<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());
        }

        async Task ExecuteLoadUsersCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var users = await UserStore.GetUsersAsync(true);
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            
        }

        
    }
}
