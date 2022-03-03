using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flyout.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using flyout.Services;
using System.Net.Http;
using Newtonsoft.Json;
using flyout.Models;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chonPhong : ContentPage
    {
        public chonPhong()
        {
            InitializeComponent();
            KhoiTao();
        }

        HttpClient httpClient = new HttpClient();
        private async void KhoiTao()
        {
            
            var kq = await httpClient.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/GetLichKhamTheoNgayChuyenKhoaLoaiHinh?ngay=" + App.ngay + "&chuyen_khoa=" + App.chuyenkhoa + "&loai_hinh="+App.loai_hinh);
           
            var dsLichKham = JsonConvert.DeserializeObject<List<LichKham>>(kq);
            lstdsPhongKham.ItemsSource = dsLichKham;
        }


        private void lstdsPhongKham_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LichKham lich = (LichKham)e.SelectedItem;
            App.idlichKham = lich.id;
            App.lichKham = lich;
            Navigation.PushAsync(new chonGio());
        }
    }
}