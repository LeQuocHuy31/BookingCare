using System;
using System.Collections.Generic;
using System.Text;

namespace flyout.Interface
{
    public interface IZoomService
    {
        bool IsInitialized();
        void InitZoomLib(string appKey, string appSecret);
        void JoinMeeting(string meetingID, string displayName);
    }
}
