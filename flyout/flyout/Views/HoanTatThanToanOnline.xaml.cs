using flyout.Models;
using flyout.Services;
using Newtonsoft.Json;
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
    public partial class HoanTatThanToanOnline : ContentPage
    {
        public HoanTatThanToanOnline()
        {
            InitializeComponent();
           
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
            txtNgaySinh.Text = bn.ngaySinh;
            txtGT.Text = bn.gioiTinh;
            KhoiTao();
        }
        async void KhoiTao()
        {
            HttpClient client = new HttpClient();
            var kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/GetBacSiTheoTen?bac_si="+ App.lichKham.bac_si);
            var dsbacsi = JsonConvert.DeserializeObject<List<BacSi>>(kq);
            if (dsbacsi.Count > 0)
            {
                txtID.Text = dsbacsi.ElementAt(0).id_zoom;
                txtMatKhau.Text = dsbacsi.ElementAt(0).pass_zoom;
            }
           
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