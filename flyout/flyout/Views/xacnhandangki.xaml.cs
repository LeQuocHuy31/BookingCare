using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Models;
using flyout.Services;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class xacnhandangki : ContentPage
    {
        public xacnhandangki()
        {
            InitializeComponent();
        }

        BenhNhan benhNhan = new BenhNhan();
        public xacnhandangki( BenhNhan bn)
        {
            InitializeComponent();
            txtHoten.Text = bn.hoTen;
            txtNgaySinh.Text = bn.ngaySinh;
            txtGT.Text = bn.gioiTinh;
            txtEmail.Text = bn.email;
            txtQG.Text = bn.quocGia;
            txtCMND.Text = bn.CMND;
            txtDt.Text = bn.danToc;
            txtNgheNghiep.Text = bn.nghe;
            txtSdt.Text = bn.sdt;
            txtTinh.Text = bn.tinh;
            benhNhan = bn;
        }

        private void cmdXacNhan_Clicked(object sender, EventArgs e)
        {
            if (txtHoten.Text == "" || txtEmail.Text == "" || txtSdt.Text == "" || txtCMND.Text == "")
            {
                DisplayAlert("Thông báo", "Bạn cần điền đầy đủ các trường thông tin ", "OK");
            }
            else
            {
                benhNhan.hoTen = txtHoten.Text;
                benhNhan.ngaySinh = txtNgaySinh.Text;
                benhNhan.gioiTinh = txtGT.Text;
                benhNhan.email = txtEmail.Text;
                benhNhan.quocGia = txtQG.Text;
                benhNhan.danToc = txtDt.Text;
                benhNhan.sdt = txtSdt.Text;
                benhNhan.nghe = txtNgheNghiep.Text;
                benhNhan.tinh = txtTinh.Text;
                benhNhan.CMND = txtCMND.Text;
                Database db = new Database();
                db.UpdateHoSo(benhNhan);
                Navigation.PushAsync(new HoSo(benhNhan));
            }
        }
    }
}