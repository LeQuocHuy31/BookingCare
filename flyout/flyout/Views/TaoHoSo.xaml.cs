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
    public partial class TaoHoSo : ContentPage
    {
        public TaoHoSo()
        {
            InitializeComponent();
            KhoiTao();
        }

        void KhoiTao()

        {
            string[] Ngay = new string[] {
            "01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16",
            "18","19","20","21","22","23","24","25","26","27","28","29","30","31"
            };
            pkNgay.ItemsSource = Ngay;
            string[] Thang = new string[] {
           "01","02","03","04","05","06","07","08","09","10","11","12"
            };
            pkThang.ItemsSource = Thang;
            string[] Nam = new string[] {
            "1970","1971","1972","1973","1974","1975","1976","1977","1978","1979","1980","1981","1982","1983","1984","1985","1986",
            "1988","1989","1990","1991","1992","1993","1994","1995","1996","1997","1998","1999","2000","2001","2011","2012","2013",
            "2014","2015","2016","2017","2018","2019","2020","2021"
            };
            
            pkNam.ItemsSource = Nam;

            string[] gioiTinh = new string[]
            {
                "Nam","Nu"
            };
            pkGioiTinh.ItemsSource = gioiTinh;

        }

        private void cmdTiepTheo_Clicked(object sender, EventArgs e)
        {

            BenhNhan bn = new BenhNhan();
            bn.hoTen = txtHoten.Text;
            bn.ngaySinh = pkNgay.SelectedItem + "/" + pkThang.SelectedItem + "/" + pkNam.SelectedItem;
            bn.gioiTinh = pkGioiTinh.SelectedItem.ToString();
            bn.CMND = txtCMND.Text;
            bn.quocGia = txtQG.Text;
            bn.danToc = txtDanToc.Text;
            bn.nghe = txtNghe.Text;
            bn.sdt = txtSdt.Text;
            bn.email = txtEmail.Text;
            bn.tinh = txtTinh.Text;
            Database db = new Database();
            db.ThemHoSo(bn);
            Navigation.PushAsync(new Thong_tin_nguoi_nha(bn));
        }
    }
}