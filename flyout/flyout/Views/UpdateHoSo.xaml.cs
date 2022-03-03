using flyout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Services;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateHoSo : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        Database db = new Database();
        public UpdateHoSo()
        {
            InitializeComponent();
            KhoiTao();
        }
        BenhNhan bn = new BenhNhan();
        NguoiThan nt = new NguoiThan();
        async void KhoiTao()
        {
            string email = Preferences.Get("userEmail", "");
            string password = Preferences.Get("userPassword", "");
            EmailUser user = await userRepository.GetUser(email, password);
            //Lấy thông tin bệnh nhân
            bn = db.GetBenhNhanByEmail(user.Email).ElementAt(0);
            txtHoTenBn.Text = bn.hoTen;
            txtNgaySinhBn.Text = bn.ngaySinh;
            txtGtBn.Text = bn.gioiTinh;
            txtCMND.Text = bn.CMND;
            txtEmail.Text = bn.email;
            txtQG.Text = bn.quocGia;
            txtDT.Text = bn.danToc;
            txtSdt.Text = bn.sdt;
            txtNghe.Text = bn.nghe;
            txtTinh.Text = bn.tinh;
            //Xuất thông tin người thân
            nt = db.GetNguoiThan(bn.IdBenhNhan).ElementAt(0);
            txtHotenNt.Text = nt.Hoten;
            txtQuanHe.Text = nt.QuanHe;
            txtSdtNt.Text = nt.Sdt;
            txtEmailNt.Text = nt.Email;
        }

        private void cmdUpdateBN_Clicked(object sender, EventArgs e)
        {
            bn.hoTen = txtHoTenBn.Text;
            bn.ngaySinh = txtNgaySinhBn.Text;
            bn.gioiTinh = txtGtBn.Text;
            bn.email = txtEmail.Text;
            bn.quocGia = txtQG.Text;
            bn.danToc = txtDT.Text;
            bn.sdt = txtSdt.Text;
            bn.nghe = txtNghe.Text;
            bn.tinh = txtTinh.Text;
            bn.CMND = txtCMND.Text;
           
           if (db.UpdateHoSo(bn))
            {
                DisplayAlert("Thông báo", "Cập nhật thông tin bệnh nhân thành công", "OK");
            }
            else
            {
                DisplayAlert("Thông báo", "Cập nhật thông tin bệnh nhân thất bại", "OK");
            }

        }

        private void cmdUpdateNT_Clicked(object sender, EventArgs e)
        {
            
            nt.Hoten = txtHotenNt.Text;
            nt.QuanHe = txtQuanHe.Text;
            nt.Email = txtEmailNt.Text;
            nt.Sdt = txtSdtNt.Text;
            if (db.UpdateThongTinNguoiThan(nt))
            {
                DisplayAlert("Thông báo", "Cập nhật thông tin người thân thành công", "OK");
            }
            else
            {
                DisplayAlert("Thông báo", "Cập nhật thông tin người thân thành công", "OK");
            }

        }
    }
}