using flyout.Models;
using flyout.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }
        UserRepository userRepository = new UserRepository();
        public LoginPage()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            //CheckUserLoggedIn();
            InitializeComponent();

        }

        private async void cmdLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                string token = await userRepository.SignIn(email.Text, password.Text);
                if (!string.IsNullOrEmpty(token))
                {
                    Preferences.Set("token", token);
                    Preferences.Set("userEmail", email.Text);
                    Preferences.Set("userPassword", password.Text);
                    App.email_user = email.Text;
                    App.Current.MainPage = new AppShell();
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Thông báo", "Password sai", "OK");
                }
                if (exception.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("Thông báo", "Email sai", "OK");
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//registerpage");
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//resetpassword");
        }

        private void cmdLoginWithGoogle_Clicked(object sender, EventArgs e)
        {
            _googleManager.Login(OnLoginComplete);
        }
        private void CheckUserLoggedIn()
        {
            _googleManager.Login(OnLoginComplete);
        }
        private async void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                Preferences.Set("GoogleUser", googleUser.Name);
                Preferences.Set("GoogleEmail", googleUser.Email);
                //await Navigation.PushAsync(new home());
                await DisplayAlert("Đăng nhập", "Xin chào " + GoogleUser.Name, "OK");
                //txtName.Text = GoogleUser.Name;
                //txtEmail.Text = GoogleUser.Email;s
                //imgProfile.Source = GoogleUser.Picture;
                IsLogedIn = true;
            }
            else
            {
                await DisplayAlert("Message", message, "Ok");
            }
        }
        private void GoogleLogout()
        {
            _googleManager.Logout();
            IsLogedIn = false;
        }
    }
}