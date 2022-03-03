using flyout.Services;
using flyout.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Plugin.LocalNotification;

namespace flyout
{
    public partial class App : Application
    {
     
        public static string tenbenhnhan { get; set; }
        public static string ngay { get; set; }
        public static string chuyenkhoa { get; set; }
        public static string isBHYT { get; set; }
        public static string email_user { get; set; }
        public static string ma_phieu { get; set; }
        public static string ten { get; set; }
        //lấy loại hình khám bệnh
        public static string loai_hinh { get; set; }
        public static int idlichKham { get; set; }
        public static int idchiTietLichKham { get; set; }
        public static LichKham lichKham { get; set; }
        public static ChiTietLichKham chiTietLichKham { get; set; }
        public static PhieuKham phieuKhamBenh { get; set; }
        public static ChiTietPhieuKham chiTietPhieuKham { get; set; }
        public App()
        {
            InitializeComponent();
            Database db = new Database();
            db.CreateDatabase();
            MainPage = new MainPage();
            ThongBao();

        }
        public async void ThongBao()
        {
            HttpClient client = new HttpClient();
            var kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/GetPhieuKhamBenh?email_user=" + App.email_user + "&loai_hinh=" + App.loai_hinh);
            var dsphieukham = JsonConvert.DeserializeObject<List<ChiTietPhieuKham>>(kq);
            foreach (ChiTietPhieuKham chiTiet in dsphieukham)
            {
                if (DateTime.Parse(chiTiet.ngay_dat_lich).Date == DateTime.Now.Date)
                {
                    var notification = new NotificationRequest
                    {
                        BadgeNumber = 1,
                        Description = "Bạn có lịch khám vào lúc " + chiTiet.gio + " ngày " + chiTiet.ngay + "tại phòng khám "+ chiTiet.phong_kham,
                        Title = "Thông báo lịch khám",
                        ReturningData = "Dummy Data",
                        NotificationId = 1337,
                        Schedule =
                        {
                            NotifyTime = DateTime.Now.AddSeconds(10)
                        }
                    };
                    await NotificationCenter.Current.Show(notification);
                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
