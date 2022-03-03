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
    public partial class Thong_tin_nguoi_nha : ContentPage
    {
        public Thong_tin_nguoi_nha()
        {
            InitializeComponent();
        }

        BenhNhan benhNhan = new BenhNhan();
        public Thong_tin_nguoi_nha(BenhNhan bn)
        {
            InitializeComponent();
            benhNhan = bn;
        }

        private void cmdtiepTuc_Clicked(object sender, EventArgs e)
        {
            NguoiThan newNguoiThan = new NguoiThan();
            newNguoiThan.Hoten = txtTen.Text;
            newNguoiThan.QuanHe = txtQuanHe.Text;
            newNguoiThan.Email = txtEmail.Text;
            newNguoiThan.Sdt = txtSdt.Text;
            newNguoiThan.IDbenhNhan = benhNhan.IdBenhNhan;
            Database db = new Database();
            db.AddNguoiThan(newNguoiThan);
            Navigation.PushAsync(new xacnhandangki(benhNhan));
        }
    }
}