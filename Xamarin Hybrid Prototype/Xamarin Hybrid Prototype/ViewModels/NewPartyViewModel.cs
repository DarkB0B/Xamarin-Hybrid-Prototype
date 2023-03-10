using Android.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Provider;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.ViewModels
{
    public class NewPartyViewModel : BaseViewModel
    {
        //Activity activity = new Activity();
        Random rnd = new Random();
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
            int id = rnd.Next(100, 100000);
            Party newParty = new Party()
            {
                
                Id = id,
                Name = Name,
                Description = Description,
                Date = Date,
                Users = new List<User>()

            };
            await DataStore.AddPartyAsync(newParty);

            //Comment this for app to work 
            /*
            ContentValues eventValues = new ContentValues();
            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, 1);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
                Name);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
                Description);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
                Date.Millisecond);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
                (Date.Millisecond + 10));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
                "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
                "UTC");
            var uri = activity.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
          
            
            //Comment this for app to work

            
           // var uri = Android.Net.Uri.Parse("content://com.android.calendar/events");
            ContentValues eventValues = new ContentValues();
            eventValues.Put("calendar_id", 1); // id, We need to choose from
                                                // our mobile for primary
                                               // its 1
            eventValues.Put("title", Name);
            eventValues.Put("description", Description);
            eventValues.Put("eventLocation", "My Location");
            eventValues.Put("dtstart", Date.Millisecond);
            eventValues.Put("dtend", Date.Millisecond + 10);
            eventValues.Put("allDay", 0); // 0 for false, 1 for true
            eventValues.Put("eventStatus", 1);
            eventValues.Put("visibility", 0);

            eventValues.Put("hasAlarm", 1); // 0 for false, 1 for true

             var uri = activity.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
            /*/
           




            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        
    }
}
