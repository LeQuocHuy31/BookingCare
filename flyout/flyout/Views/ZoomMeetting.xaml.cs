using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.ViewModels;
namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZoomMeetting : ContentPage
    {
        public ZoomMeetting()
        {
            InitializeComponent();
             BindingContext = new ZoomMeettingViewModel();
        }
    }
}