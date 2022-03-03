using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Models;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chonGio : ContentPage
    {
        public chonGio()
        {
            InitializeComponent();
            KhoiTao();
        }
        public async void KhoiTao()
        {
            HttpClient client = new HttpClient();
            var kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/GetChiTietLichKham?id_lich_kham=" + App.idlichKham);
            var dsChiTiet = JsonConvert.DeserializeObject<List<ChiTietLichKham>>(kq);
            lstChiTiet.ItemsSource = dsChiTiet;
        }

        private void lstChiTiet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ChiTietLichKham chiTietLich = (ChiTietLichKham)e.SelectedItem;
            App.idchiTietLichKham = chiTietLich.id;
            App.chiTietLichKham = chiTietLich;
            Navigation.PushAsync(new DatLichKham());
        }
    }
}