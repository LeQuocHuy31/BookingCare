using flyout.Models;
using flyout.ViewModels;
using flyout.Views;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace flyout
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        UserRepository userRepository = new UserRepository();
        public AppShell()
        {
            InitializeComponent();
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Schedule = {
                 NotifyTime = DateTime.Now.AddSeconds(10)
                }

            };

            NotificationCenter.Current.Show(notification);
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void cmdLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
