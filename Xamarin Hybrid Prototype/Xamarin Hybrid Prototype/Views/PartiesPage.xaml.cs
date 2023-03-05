using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Hybrid_Prototype.ViewModels;

namespace Xamarin_Hybrid_Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartiesPage : ContentPage
    {
        PartiesViewModel _viewModel;

        public PartiesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PartiesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        
        }
    }
}
