using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XacNhanThongTinDatKham : ContentPage
    {
        public XacNhanThongTinDatKham()
        {
            InitializeComponent();
            Title = "Xác nhận";
            txtBacSi.Text = App.lichKham.bac_si;
            txtChuyenKhoa.Text = App.lichKham.chuyen_khoa;
            txtGio.Text = App.chiTietLichKham.gio;
            txtNgay.Text = App.lichKham.ngay + " - " + App.lichKham.thoi_gian;
            txtPhongKham.Text = "Phòng " + App.lichKham.phong_kham;
            txtBHYT.Text = App.isBHYT;
            txtTongien.Text = App.lichKham.gia.ToString();
            txtTongienkhambenh.Text = "Tổng tiền khám: " + App.lichKham.gia.ToString();
        }

        private void cmdTiepTuc_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Thanh_toan());
        }
    }
}