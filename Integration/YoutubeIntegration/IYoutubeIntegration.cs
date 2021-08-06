using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.YoutubeIntegration
{
    public interface IYoutubeIntegration
    {
        string CreateLiveBroadcastEvent(string eventTitle, DateTime eventStartDate);
    }
}
