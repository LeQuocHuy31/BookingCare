using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using flyout.Models;

using Xamarin.Forms.Xaml;




namespace flyout.Views
{
     [XamlCompilation(XamlCompilationOptions.Compile)]

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StripePayMent : ContentPage
    {
        public StripePayMent()
        {
            InitializeComponent();
            lblTongTien.Text = App.lichKham.gia.ToString() + "đ";
            lblTongTienKham.Text = App.lichKham.gia.ToString() + "đ";
        }

        public async void PayViaStripe()
        {
            StripeConfiguration.ApiKey = "sk_test_51JFE0aJ8gEDJ91qwzdvDPcf5UabuygY9qNW7X6r3uQNEgLwUWKPJgRjtpsrREe8MRb4QuWvXKrmyOLJKRJuqJ2LF003FMN5JdQ";

            string cardno = cardNo.Text;
            string expMonth = expireMonth.Text;
            string expYear = expireYear.Text;
            string cardCvv = cvv.Text;

            // Step 1: create card option


            var options = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = cardno,
                    ExpYear = Convert.ToInt64(expYear),
                    ExpMonth = Convert.ToInt64(expMonth),
                    Cvc = cardCvv,
                },
            };
            var service = new TokenService();
            Token newToken = service.Create(options);

            // step 3: assign the token to the source
            var option = new SourceCreateOptions
            {
                Type = SourceType.Card,
                Currency = "inr",
                Token = newToken.Id
            };

            var sourceService = new SourceService();
            Source source = sourceService.Create(option);

            // step 4: create customer
            CustomerCreateOptions customer = new CustomerCreateOptions
            {
                Name = "SP Tutorial",
                Email = "spaltutorials@gmail.com",
                Description = "Paying 10 Rs",
                Address = new AddressOptions { City = "Kolkata", Country = "India", Line1 = "Sample Address", Line2 = "Sample Address 2", PostalCode = "700030", State = "WB" }
            };

            var customerService = new CustomerService();
            var cust = customerService.Create(customer);

            // step 5: charge option
            var chargeoption = new ChargeCreateOptions
            {
                Amount = 45000,
                Currency = "INR",
                ReceiptEmail = "spaltutorials@gmail.com",
                Customer = cust.Id,
                Source = source.Id
            };

            // step 6: charge the customer
            var chargeService = new ChargeService();
            Charge charge = chargeService.Create(chargeoption);
            if (charge.Status == "succeeded")
            {
               await DisplayAlert("Thông báo", "Thanh toán thành công", "OK");
                
                //Email gửi về
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("bookingcareit@gmail.com");
                mail.To.Add(App.email_user);
                mail.Subject = "PHIẾU KHÁM BỆNH ĐẠI HỌC Y DƯỢC";
                mail.IsBodyHtml = true;
                string body = "<h2 style='text-align:center;'>Bệnh viện Đại học Y dược TP.HCM</h2>"
                            + "<h1 style='text-align:center;'>PHIẾU KHÁM BỆNH</h1>"
                            + "<h2 style='text-align:center;'>Phòng khám:" + App.lichKham.phong_kham + "</h2>"
                            + "<h2 style='text-align:center;'>Chuyên khoa: " + App.lichKham.chuyen_khoa + "</h2>"
                            + "<p>Ngày khám:<b>" + App.lichKham.ngay + "</b></p>"
                            + "<p>Giờ khám:<b>" + App.chiTietLichKham.gio + "</b></p>"
                            + "<p>Họ tên:<b>Lê Quốc Huy</b></p>"
                            + "<p>Giới tính:<b> Nam</b></p>"
                            + "<p>Mã hồ sơ:<b> BN201213</b></p>"
                            + "<h2 style='text-align:center;'>Chi tiết đơn hàng</h2>"
                            + "<table cellspacing='0' cellpadding='2' border='1' style='margin-left: auto; margin-right: auto;' width='90%'><tr><th width='10%'>STT</th><th width='30%'>Tên dịch vụ</th><th width='15%'>Đơn giá</th><th width='15%'>Số lượng</th><th width='20%'>Thành tiền</th></tr>"
                            + "<tr><td>1</td><td>" + App.lichKham.chuyen_khoa + "</td><td>" + App.lichKham.gia + "</td><td>1</td><td>" + App.lichKham.gia + "</td></tr></table>"
                            + "<h2 style='text-align:right;'>Tổng cộng: " + App.lichKham.gia + "</h2>";
                mail.Body = body;
                smtpServer.Port = 587;
                smtpServer.Host = "smtp.gmail.com";
                smtpServer.EnableSsl = true;
                smtpServer.UseDefaultCredentials = false;
                smtpServer.Credentials = new System.Net.NetworkCredential("bookingcareit@gmail.com", "booking123^^");
                ServicePointManager.ServerCertificateValidationCallback = delegate (object senders, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicy)
                {
                    return true;
                };
                smtpServer.Send(mail);
                //Cập nhập chi tiết vé
                HttpClient client = new HttpClient();
                var kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/UpdateChiTietLichKham?id=" + App.chiTietLichKham.id_lich_kham + "&gio=" + App.chiTietLichKham.gio);
                //Insert phiếu khám
                App.ma_phieu = MaXacNhan();
                Random random = new Random();
                int stt = random.Next(1, 11);
                kq = await client.GetStringAsync("http://192.168.1.64/webbookingcare/api/DataController/InsertPhieuKhamBenh?email_user=" + App.email_user + "&id_chi_tiet_lich_kham=" + App.chiTietLichKham.id + "&ma_phieu=" + App.ma_phieu + "&stt=" + stt + "&ngay_dat_lich=" + DateTime.Now.ToString() + "&bhyt=" + App.isBHYT +"&loai_hinh=" + App.loai_hinh);
                var phieuKham = JsonConvert.DeserializeObject<List<PhieuKham>>(kq);
                App.phieuKhamBenh = phieuKham.ElementAt(0);
                if(App.loai_hinh== "Trực tiếp")
                {
                    await Navigation.PushAsync(new HoanTatThanhToan());
                }
                else
                {
                    await Navigation.PushAsync(new HoanTatThanToanOnline());
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Thanh toán thất bại. Vui lòng chọn phương thức thanh toán khác", "OK");
                await Navigation.PushAsync(new Thanh_toan());
            }
        }

        private String chuoi = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

        private String MaXacNhan()
        {
            String ma = "";
            for (int i = 0; i < 9; i++)
            {
                Random random = new Random();
                int x = random.Next(1, 36);
                ma = ma + chuoi[x];
            }
            return ma;
        }

        private void cmdThanhToan_Clicked(object sender, EventArgs e)
        {
            if( cardNo.Text =="" || expireYear.Text == "" || expireMonth.Text  == ""|| cvv.Text == "" )
            {
                DisplayAlert("Thông báo", "Vui lòng cung cấp đầy đủ thông tin", "OK");
            }
            else
            {
                PayViaStripe();
            }
           
        }
    }
}