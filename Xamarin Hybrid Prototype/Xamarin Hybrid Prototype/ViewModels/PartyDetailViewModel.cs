using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;
using Xamarin_Hybrid_Prototype.Views;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    [QueryProperty(nameof(PartyId), nameof(PartyId))]
    public class PartyDetailViewModel : BaseViewModel
    {
        public PartyDetailViewModel(){
            Title = "Party Details";
            Tapped = new Command(OnTapped);
        }   
        public Command Tapped { get; }
        private int partyId;
        private string name;
        private string description;
        private string date;
        private List<User> users = new List<User>();
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public List<User> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
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

        public async void OnTapped()
        {
            Console.WriteLine("Users: " + Users);
            if (Users == null)
            {
                return;
            }
            
            await Shell.Current.GoToAsync($"{nameof(UsersListPage)}?{nameof(UsersListViewModel.Users)}={Users}");
        }
        
        


        public async void LoadPartyId(int partyId)
        {
            try
            {
                var party = await DataStore.GetPartyAsync(partyId);
                Id = party.Id;
                Name = party.Name;
                Description = party.Description;
                Date = party.Date.ToString("MM/dd/yyyy");
                Users = party.Users;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
