using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Hybrid_Prototype.Models;
using Xamarin_Hybrid_Prototype.ViewModels;

namespace Xamarin_Hybrid_Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class PartyDetailPage : ContentPage
    {
        public PartyDetailPage()
        {
            
            InitializeComponent();
            BindingContext =  new PartyDetailViewModel();
        }

       
        private  void ShowList(object sender, EventArgs e)
        {
            

        }
        

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var contact = await Contacts.PickContactAsync();

                if (contact == null)
                    return;

               var info = new StringBuilder();
               info.AppendLine(contact.Id);
               info.AppendLine(contact.DisplayName);
               info.AppendLine(contact.GivenName);
               info.AppendLine(contact.FamilyName);
               info.AppendLine(contact.Phones.FirstOrDefault()?.PhoneNumber??string.Empty);
               LabelInfo.Text = info.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}