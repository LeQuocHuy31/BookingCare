using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using flyout.Droid.Flatform;
using flyout.Interface;
using US.Zoom.Sdk;
using Xamarin.Forms;
[assembly: Dependency(typeof(ZoomService))]
namespace flyout.Droid.Flatform
{
    public class ZoomService : Java.Lang.Object, IZoomService, IZoomSDKInitializeListener
    {
        ZoomSDK zoomSDK;

        public ZoomService() { }
        public void InitZoomLib(string appKey, string appSecret)
        {
            zoomSDK = ZoomSDK.Instance;
            var zoomInitParmas = new ZoomSDKInitParams
            {
                AppKey = appKey,
                AppSecret = appSecret,
            };
            zoomSDK.Initialize(Android.App.Application.Context, this, zoomInitParmas);
        }
        public bool IsInitialized() => zoomSDK?.IsInitialized ?? false;

        public void JoinMeeting(string meetingID, string displayName)
        {
            if (IsInitialized())
            {
                var meetingService = zoomSDK.MeetingService;
                meetingService.JoinMeetingWithParams(Android.App.Application.Context, new JoinMeetingParams
                {
                    MeetingNo = meetingID,
                    DisplayName = displayName,
                }); ;
            }
        }
        public void OnZoomAuthIdentityExpired()
        {

        }

        public void OnZoomIdentityExpired()
        {

        }

        public void OnZoomSDKInitializeResult(int p0, int p1)
        {

        }
    }
}