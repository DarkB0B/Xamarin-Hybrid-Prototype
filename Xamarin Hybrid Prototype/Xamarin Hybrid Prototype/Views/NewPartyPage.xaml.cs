using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Hybrid_Prototype.Models;
using Xamarin_Hybrid_Prototype.ViewModels;

namespace Xamarin_Hybrid_Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPartyPage : ContentPage
    {
        public Party Party { get; set; }

        public NewPartyPage()
        {
            InitializeComponent();
            BindingContext = new NewPartyViewModel();
        }
    }
}