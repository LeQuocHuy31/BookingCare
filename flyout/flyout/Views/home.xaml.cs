using Firebase.Auth;
using flyout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using flyout.Services;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        public home()
        {
            InitializeComponent();
            KhoiTao();
        }
        string mail="";
        async void KhoiTao()
        {
            List<Image> images = new List<Image>();
            images.Add(new Image { url = "slide_hai.jpg" });
            images.Add(new Image { url = "slide_ba.jpg" });
            images.Add(new Image { url = "slide_bon.jpg" });
            SliderImage.ItemsSource = images;

            string email = Preferences.Get("userEmail", "");
            string password = Preferences.Get("userPassword", "");
            EmailUser user = await userRepository.GetUser(email, password);

            //await DisplayAlert("Thông báo", "Xin chào " + user.Email, "Ok");
            mail = user.Email;

        }

        private void cmdDatLich_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Tao_ho_so());
            popupDatLich.Opacity = 0;
            popupDatLich.IsVisible = true;
            popupDatLich.FadeTo(1, 400);
            trangChu.Opacity = 0.3;
            AnimationCloseButton(closebtn, true);

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            AnimationCloseButton(closebtn, false);
            await popupDatLich.FadeTo(0, 400);
            trangChu.Opacity = 1;
            popupDatLich.IsVisible = false;
        }

        private void AnimationCloseButton(VisualElement element, bool entering)
        {
            var startTransaction = entering ? 100 : 0;
            var endTransaction = entering ? 0 : 100;
            var transactionEasing = entering ? Easing.SinInOut : Easing.SinIn;

            var startOpacity = entering ? 0 : 1;
            var endOpacity = entering ? 1 : 0;

            var startRotation = entering ? -90 : 0;
            var endRotation = entering ? 0 : 180;
            element.TranslationY = startTransaction;
            element.Opacity = startOpacity;
            element.Rotation = startRotation;

            element.FadeTo(endOpacity, 400);
            element.RotateTo(endRotation, 700, Easing.SinInOut);
            element.TranslateTo(0, endTransaction, 600, transactionEasing);
        }

        Database db = new Database();
        private void btnDatLichKham_Clicked(object sender, EventArgs e)
        {
            App.loai_hinh = "Trực tiếp";
            if (db.GetBenhNhanByEmail(mail).Count > 0)
            {
                BenhNhan bn = db.GetBenhNhanByEmail(mail).ElementAt(0);
                Navigation.PushAsync(new HoSo(bn));
            }
            else
            {
                Navigation.PushAsync(new Tao_ho_so());
            }
            trangChu.Opacity = 1;
            popupDatLich.IsVisible = false;
        }


        private void btnDatLichKhamOnline_Clicked(object sender, EventArgs e)
        {
            App.loai_hinh = "Video Call";
            if (db.GetBenhNhanByEmail(mail).Count > 0)
            {
                BenhNhan bn = db.GetBenhNhanByEmail(mail).ElementAt(0);
                Navigation.PushAsync(new HoSo(bn));
            }
            else
            {
                Navigation.PushAsync(new Tao_ho_so());
            }
            trangChu.Opacity = 1;
            popupDatLich.IsVisible = false;
        }

        private void cmdZoomMeeting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ZoomMeetting());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DanhSachPhieuKhamBenh());
        }

       
    }
}