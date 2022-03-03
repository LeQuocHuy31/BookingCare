using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Services;
using flyout.Models;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tao_ho_so : ContentPage
    {
        public Tao_ho_so()
        {
            InitializeComponent();
        }

       
        private void cmdTaoHoSo_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new MH_TaoHoSo());
          
        }
    }
}