using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flyout.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using flyout.Models;
using System.Net.Http;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chuyenkhoa : ContentPage
    {
       
        public chuyenkhoa()
        {
            InitializeComponent();
            KhoiTao();
        }
        HttpClient client = new HttpClient();
        async void KhoiTao()
        {
            //var dslstKhoa = await firebaseHelper.GetAllKhoa();
            var kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/GetChuyenKhoa");
            var dsChuyenKhoa = JsonConvert.DeserializeObject<List<ChuyenKhoa>>(kq);
            dsKhoa.ItemsSource = dsChuyenKhoa;
        }


        private void dsKhoa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ChuyenKhoa selectedKhoa = (ChuyenKhoa)e.SelectedItem;
            App.chuyenkhoa = selectedKhoa.ten_chuyen_khoa;
            Navigation.PushAsync(new DatLichKham());
        }
    }
}