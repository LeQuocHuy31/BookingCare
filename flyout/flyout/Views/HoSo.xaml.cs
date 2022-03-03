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
    public partial class HoSo : ContentPage
    {
        public HoSo()
        {
            InitializeComponent();
        }

        Database db = new Database();
        
        public HoSo(BenhNhan bn)
        {
            InitializeComponent();

            //Xuất thông tin bệnh nhân
            lblHoTenBn.Text = bn.hoTen;
            lblNgaySinhBn.Text = bn.ngaySinh;
            lblGtBn.Text = bn.gioiTinh;
            lblCMND.Text = bn.CMND;
            lblEmail.Text = bn.email;
            lblQG.Text = bn.quocGia;
            lblDT.Text = bn.danToc;
            lblSdt.Text = bn.sdt;
            lblNghe.Text = bn.nghe;
            lblTinh.Text = bn.tinh;
            //Xuất thông tin người thân
            NguoiThan ng = db.GetNguoiThan(bn.IdBenhNhan).ElementAt(0);
            txtHoten.Text = ng.Hoten;
            txtQuanHe.Text = ng.QuanHe;
            txtSdt.Text = ng.Sdt;
            txtEmail.Text = ng.Email;

            //Lấy tên bệnh nhân
            App.tenbenhnhan = bn.hoTen;
        }

        private void cmdDatLich_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DatLichKham( ));
        }
    }
}