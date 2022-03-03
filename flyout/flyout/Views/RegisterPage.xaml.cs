using flyout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void cmdSignIn_Clicked(object sender, EventArgs e)
        {
            if (cfpassword.Text != password.Text)
            {
                await DisplayAlert("Thông báo", "Mật khẩu không trùng khớp", "OK");
            }
            try
            {
                bool isSave = await userRepository.Register(email.Text, password.Text, name.Text);
                if (isSave)
                {
                    await DisplayAlert("Thông báo", "Vui lòng kiểm tra email để xác thực tài khoản", "OK");
                    await Shell.Current.GoToAsync("//loginpage");
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Thông báo", "Email đã được đăng kí. Vui lòng đăng kí email khác.", "OK");
                }
            }
        }
    }
}