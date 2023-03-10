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
    [QueryProperty(nameof(PartyId), nameof(PartyId))]
    public class UsersListViewModel : BaseViewModel
    {



        private int partyId;
        private Party _party;
        public Command LoadUsersCommand { get; }
        public ObservableCollection<User> UsersCollection { get; }

        public UsersListViewModel()
        {
            UsersCollection = new ObservableCollection<User>();
            Title = "People invited to this party";
            Console.WriteLine("Constructor");
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());
        }

        public int PartyId
        {
            get
            {
                return partyId;
            }
            set
            {
                partyId = value;
                LoadPartyId(value);
            }
        }
        public async void LoadPartyId(int partyId)
        {
            Console.WriteLine("Loading PartyId");
            try
            {
                _party = await DataStore.GetPartyAsync(partyId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        async Task ExecuteLoadUsersCommand()
        {
            IsBusy = true;

            try
            {
                UsersCollection.Clear();
                if (_party.Users != null && _party.Users.Count > 0)
                {
                    foreach (var user in _party.Users)
                    {
                        UsersCollection.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                Console.WriteLine("Finished loading users");
                Console.WriteLine(UsersCollection.Count);
                Console.WriteLine(UsersCollection[0].Name);
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            
        }

        
    }
}
