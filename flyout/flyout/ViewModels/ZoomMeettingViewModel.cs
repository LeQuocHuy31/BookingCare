using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using flyout.Interface;
using System.Windows.Input;

namespace flyout.ViewModels
{
    class ZoomMeettingViewModel
    {
        public ICommand JoinMeetingCommand { get; set; }
        public string MeetingID { get; set; }
        IZoomService zoomService;
        public ZoomMeettingViewModel()
        {
            zoomService = DependencyService.Get<IZoomService>();
            zoomService.InitZoomLib("tkPRbTnqmW1mJbSEbpUYcPPgQj4jOh9fqVsC", "4l1M7PQ22WnI4rr2JuIhZaoCpoMhlXvGCsrE");
            JoinMeetingCommand = new Command(JoinMeeting);
        }
        private void JoinMeeting()
        {
            if (!zoomService.IsInitialized())
            {
                return;
            }
            zoomService.JoinMeeting(MeetingID, "Video Call");
        }
    }
}
