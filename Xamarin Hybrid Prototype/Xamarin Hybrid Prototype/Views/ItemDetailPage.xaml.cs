using System.ComponentModel;
using Xamarin.Forms;
using Xamarin_Hybrid_Prototype.ViewModels;

namespace Xamarin_Hybrid_Prototype.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}