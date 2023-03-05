using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    public class NewPartyViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private DateTime date;

        public NewPartyViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                   && !String.IsNullOrWhiteSpace(description);
        }

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

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Party newParty = new Party()
            {
                Id = Int32.Parse(Guid.NewGuid().ToString()),
                Name = Name,
                Description = Description,
                Date = Date,
                Organiser = new User()
                {
                    Id = 100,
                    Name = "John",
                    Surname = "Smith",
                    PhoneNumber = 0123456789
                }

            };

            await DataStore.AddPartyAsync(newParty);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
