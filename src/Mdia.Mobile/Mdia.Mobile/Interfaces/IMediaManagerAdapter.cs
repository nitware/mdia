using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.MediaManager.Abstractions;

namespace Mdia.Mobile.Interfaces
{
    public interface IMediaManagerAdapter
    {
        IMediaManager MediaManager { get; }
        IPlaybackController PlaybackController { get; }

        //IPlaybackController PlaybackController { get; }

    }
}
