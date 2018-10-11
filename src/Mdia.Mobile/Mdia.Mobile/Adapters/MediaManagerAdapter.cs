using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Mdia.Mobile.Interfaces;

namespace Mdia.Mobile.Adapters
{
    public class MediaManagerAdapter : IMediaManagerAdapter
    {
        public IMediaManager MediaManager => CrossMediaManager.Current;
        public IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
    }




}
