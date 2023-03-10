using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;
using Xamarin_Hybrid_Prototype.Views;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    [QueryProperty(nameof(PartyId), nameof(PartyId))]
    public class PartyDetailViewModel : BaseViewModel
    {
        public PartyDetailViewModel()
        {
            Title = "Party Details";
            Tapped = new Command(OnTapped);
            InvFriendsTap = new Command(OnInvFriends);
        }

        public Command Tapped { get; }
        public Command InvFriendsTap { get; }
        private int partyId;
        private string name;
        private string description;
        private string date;
        private List<User> users = new List<User>();
        public int Id { get; set; }
        public Party party;

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
            Console.WriteLine("Show List Tap");
            Console.WriteLine(Users.Count);
            Console.WriteLine(Users[0].Name);
            if (Users == null) 
            {
                return;
            }
            Console.WriteLine("Going To " + Id);
            await Shell.Current.GoToAsync($"{nameof(UsersListPage)}?{nameof(UsersListViewModel.PartyId)}={party.Id}");
            
        }

        public async void OnInvFriends()
        {
            Console.WriteLine("Inv Friends Tap");
            
            try
            {
                var contact = await Contacts.PickContactAsync();

                if (contact == null)
                    return;

                var name = contact.GivenName;
                var phone = contact.Phones.FirstOrDefault().ToString();
                var surname = contact.FamilyName;
                Console.WriteLine(name + " - " + surname + " - " + phone);
                User newUser = new User() { Name = name, Surname = surname, PhoneNumber = phone };
                Console.WriteLine(newUser.Name + newUser.Surname + newUser.PhoneNumber);
                party.Users.Add(newUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        


        public async void LoadPartyId(int partyId)
        {
            try
            {
                party = await DataStore.GetPartyAsync(partyId);
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
