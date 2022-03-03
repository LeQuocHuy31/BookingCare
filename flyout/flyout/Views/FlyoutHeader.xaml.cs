using flyout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeader : Grid
    {
        UserRepository userRepository = new UserRepository();
        public FlyoutHeader()
        {
            InitializeComponent();
            KhoiTao();
        }
        async void KhoiTao()
        {
            string email = Preferences.Get("userEmail", "");
            string password = Preferences.Get("userPassword", "");
            EmailUser user = await userRepository.GetUser(email, password);
            txtEmailUser.Text = user.Email;
        }
    }
}