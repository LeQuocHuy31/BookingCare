using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;
using Newtonsoft.Json;
using flyout.Models;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DanhSachPhieuKhamBenh : ContentPage
    {
        public DanhSachPhieuKhamBenh()
        {
            InitializeComponent();
            KhoiTao();
        }

        async void KhoiTao()
        {
            HttpClient client = new HttpClient();
            App.loai_hinh = "Trực tiếp";
            var kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/GetPhieuKhamBenh?email_user=" + App.email_user+ "&loai_hinh="+ App.loai_hinh);
            var dsphieukham = JsonConvert.DeserializeObject<List<ChiTietPhieuKham>>(kq);
            lstDsKhamBenh.ItemsSource = dsphieukham;
        }

        private void lstDsKhamBenh_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App.chiTietPhieuKham = (ChiTietPhieuKham)e.SelectedItem;
            Navigation.PushAsync(new PhieuKhamBenh());
        }
    }
}