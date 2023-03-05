using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    [QueryProperty(nameof(PartyId), nameof(PartyId))]
    public class PartyDetailViewModel : BaseViewModel
    {
        private int partyId;
        private string name;
        private string description;
        private string date;
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

        public async void LoadPartyId(int partyId)
        {
            try
            {
                var party = await DataStore.GetPartyAsync(partyId);
                Id = party.Id;
                Name = party.Name;
                Description = party.Description;
                Date = party.Date.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
