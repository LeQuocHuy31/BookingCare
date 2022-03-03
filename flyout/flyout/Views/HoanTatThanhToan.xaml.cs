using flyout.Services;
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
    public partial class HoanTatThanhToan : ContentPage
    {
        public HoanTatThanhToan()
        {
            InitializeComponent();
            txtBHYT.Text = App.isBHYT;
            txtChuyenKhoa.Text = App.lichKham.chuyen_khoa;
            txtGioKham.Text = App.chiTietLichKham.gio;
            txtMaPhieu.Text = "Mã " + App.ma_phieu;
            txtNgayKham.Text = App.lichKham.ngay;
            txtPhongKham.Text = "Phòng " + App.lichKham.phong_kham;
            txtSTT.Text = App.phieuKhamBenh.stt.ToString();
            txtTienKham.Text = App.lichKham.gia.ToString();
            Database db = new Database();
            BenhNhan bn = db.GetBenhNhanByEmail(App.email_user).ElementAt(0);
            txtHoten.Text = bn.hoTen;
            txtTinh.Text = bn.tinh;
            txtNgaySinh.Text = bn.ngaySinh;
            txtGt.Text = bn.gioiTinh;
        }
        private void cmdBackHome_Clicked(object sender, EventArgs e)
        {
            App.chuyenkhoa = null;
            App.ngay = null;
            App.loai_hinh = null;
            App.ma_phieu = null;
            App.chiTietLichKham = null;
            App.lichKham = null;
            App.phieuKhamBenh = null;
            App.chiTietPhieuKham = null;
            App.isBHYT = null;
            Shell.Current.GoToAsync("//main");
        }
    }
}