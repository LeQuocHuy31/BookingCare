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
    public partial class ResetPassword : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        public ResetPassword()
        {
            InitializeComponent();
        }

        private async void cmdSend_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng nhập địa chỉ email.", "Ok");
                return;
            }
            bool isSend = await userRepository.Reset(email.Text);
            if (isSend)
            {
                await DisplayAlert("Reset mật khẩu", "Vui lòng kiểm tra email.", "Ok");
            }
            else
                await DisplayAlert("Reset mật khẩu", "Email không được gửi thành công.", "Ok");
        }
    }
}