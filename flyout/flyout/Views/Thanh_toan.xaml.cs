using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flyout.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Thanh_toan : ContentPage
    {
        public Thanh_toan()
        {
            InitializeComponent();
            lblTongTien.Text = App.lichKham.gia.ToString() + "đ";
            lblTongTienKham.Text = App.lichKham.gia.ToString() + "đ";
            KhoiTao();
        }
        List<payment> dsThanhToan = new List<payment>();
        void KhoiTao()
        {
            dsThanhToan.Add(new payment {id=1, tenPT = "Thanh toán bằng thẻ quốc tế", imgPT = "visa.png" });
            dsThanhToan.Add(new payment {id=2, tenPT = "Thanh toán bằng thẻ ATM", imgPT = "ATM.jpg" });
            dsThanhToan.Add(new payment {id=3, tenPT = "Thanh toán bằng Momo", imgPT = "momo.png" });
            lstphuongthuc.ItemsSource = dsThanhToan;
        }
        private void cmdThanhToan_Clicked(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new StripePayMent());
        }

        private void lstphuongthuc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            payment selectedPayment = (payment)e.SelectedItem;
            if (selectedPayment.id == 1)
            {
                //Thanh toán bằng thẻ visa
                Navigation.PushAsync(new StripePayMent());
            }
            else if(selectedPayment.id ==2)
            {
                //
            }
            else if (selectedPayment.id == 3)
            {

            }
        }
    }
}