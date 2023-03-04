using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    public class PartiesViewModel : BaseViewModel
    {
        private Party _selectedParty;

        public ObservableCollection<Party> Parties { get; }
        public Command LoadPartiesCommand { get; }
        public Command AddPartyCommand { get; }
        public Command<Party> PartyTapped { get; }

        public PartiesViewModel()
        {
            Title = "Browwse Parties";
            Parties = new ObservableCollection<Party>();
            LoadPartiesCommand = new Command(async () => await ExecuteLoadPartiesCommand());

            PartyTapped = new Command<Party>(OnPartySelected);

            AddPartyCommand = new Command(OnAddParty);
        }

        async Task ExecuteLoadPartiesCommand()
        {
            IsBusy = true;

            try
            {
                Parties.Clear();
                var parties = await DataStore.GetPartiesAsync(true);
                foreach (var party in parties)
                {
                    Parties.Add(party);
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
            SelectedParty = null;
        }

        public Party SelectedParty
        {
            get => _selectedParty;
            set
            {
                SetProperty(ref _selectedParty, value);
                OnPartySelected(value);
            }
        }

        private async void OnAddParty(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPartyPage));
        }

        async void OnPartySelected(Party party)
        {
            if (party == null)
            {
                return;
            }

            await Shell.Current.GoToAsync(
                $"{nameof(PartyDetailPage)}?{nameof(PartyDetailViewModel.Party.Id)}={party.Id}");
        }
    }
}
