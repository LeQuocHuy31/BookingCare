using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Models;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatLichKham : ContentPage
    {
        public DatLichKham()
        {
            InitializeComponent();
            lblTenBn.Text = App.tenbenhnhan;
            if (App.ngay != null)
            {
                string[] ngay = App.ngay.Split('/');
                string ngayconverted = ngay.ElementAt(1) + "/" + ngay.ElementAt(0) + "/" + ngay.ElementAt(2);
                prkNgay.Date = DateTime.Parse(ngayconverted);
            }
            App.ngay = prkNgay.Date.ToString("dd/MM/yyyy");
            if (App.chuyenkhoa != null)
            {
                txtKhoa.Text = App.chuyenkhoa;
            }
            if (App.chiTietLichKham != null)
            {
                txtBacSi.Text = App.lichKham.bac_si;
                txtphong.Text = "Phòng " + App.lichKham.phong_kham + " - " + App.chiTietLichKham.gio;
            }
        }
        private void cmdDk_Clicked(object sender, EventArgs e)
        {
            if (App.chiTietLichKham == null || App.lichKham == null)
            {
                DisplayAlert("Thông báo", "Vui lòng chọn thông tin lịch khám", "Ok");
            }
            else
                Navigation.PushAsync(new XacNhanThongTinDatKham());
        }

  

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.ngay = prkNgay.Date.ToString("dd/MM/yyyy");
            Navigation.PushAsync(new chuyenkhoa());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            App.ngay = prkNgay.Date.ToString("dd/MM/yyyy");
            Navigation.PushAsync(new chonPhong());
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            App.isBHYT = "Có";
        }

        private void RadioButton_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            App.isBHYT = "Không";
        }
    }
}