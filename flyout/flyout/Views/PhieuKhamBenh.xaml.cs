using flyout.Models;
using flyout.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhieuKhamBenh : ContentPage
    {
        public PhieuKhamBenh()
        {
            InitializeComponent();
            Title = "Chi tiết";
            txtBHYT.Text = App.chiTietPhieuKham.bhyt;
            txtChuyenKhoa.Text = App.chiTietPhieuKham.chuyen_khoa;
            txtGioKham.Text = App.chiTietPhieuKham.gio;
            txtMaPhieu.Text = "Mã " + App.chiTietPhieuKham.ma_phieu;
            txtNgayKham.Text = App.chiTietPhieuKham.ngay;
            txtPhongKham.Text = "Phòng " + App.chiTietPhieuKham.phong_kham;
            txtSTT.Text = App.chiTietPhieuKham.stt.ToString();
            txtTienKham.Text = App.chiTietPhieuKham.gia.ToString();
            Database db = new Database();
            BenhNhan bn = db.GetBenhNhanByEmail(App.email_user).ElementAt(0);
            txtHoten.Text = bn.hoTen;
            txtTinh.Text = bn.tinh;
            txtNgaySinh.Text = bn.ngaySinh;
            txtGT.Text = bn.gioiTinh;
        }

        private async void cmdHuyPhieu_Clicked(object sender, EventArgs e)
        {
            var hoi = await DisplayAlert("Xác nhận", "Bạn có muốn hủy phiêu khám này không?", "Yes", "No");
            if (hoi)
            {
                HttpClient httpClient = new HttpClient();
                var subjectList = await httpClient.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/DeletePhieuKham?ma_phieu=" + App.chiTietPhieuKham.ma_phieu);
                var CancleChiTietKhamBenh = await httpClient.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/UpdateHuyChiTietLichKham?id_chi_tiet_lich_kham=" + App.chiTietPhieuKham.id_chi_tiet_lich_kham);
                await DisplayAlert("Thông báo", "Xóa lịch khám thành công.", "Ok");
                await Navigation.PushAsync(new DanhSachPhieuKhamBenh());

                // Shell.Current.GoToAsync("//main");
            }
        }
    }
}