using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Windows.Input;
using Mdia.Mobile.Interfaces;
using Mdia.Mobile.PageModels.Base;

namespace Mdia.Mobile.PageModels.Media
{
    public class MediaPlayerPageModel : BasePageModel
    {
        private double _progress;
        private string _duration;
        private string _mediaSource;
        private string _mediaTitle;
        private readonly IMediaManagerAdapter _adapter;

        public MediaPlayerPageModel(IMediaManagerAdapter adapter)
        {
            _adapter = adapter;
            //MediaSource = "LegOver.mp4";
            MediaSource = "file:///LegOver.mp4";
            //MediaSource = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
            MediaTitle = "Big Buck Bunny (BBB)";

            //_adapter.MediaManager.PlayingChanged += (sender, e) =>
            //{
            //    Progress = e.Progress;
            //    Duration = "" + e.Duration.TotalSeconds + " seconds";
            //};

            _adapter.MediaManager.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Progress = e.Progress;
                    Duration = "" + e.Duration.TotalSeconds + " seconds";
                });
            };
        }

        public ICommand PlayCommand => new Command(OnPlayCommand);
        public ICommand PauseCommand => new Command(OnPauseCommand);
        public ICommand StopCommand => new Command(OnStopCommand);
        public ICommand StepForwardCommand => new Command(OnStepForwardCommand);
               
        public double Progress
        {
            set { SetProperty(ref _progress, value); }
            get { return _progress; }
        }
        public string Duration
        {
            set { SetProperty(ref _duration, value); }
            get { return _duration; }
        }
        public string MediaSource
        {
            set { SetProperty(ref _mediaSource, value); }
            get { return _mediaSource; }
        }
        public string MediaTitle
        {
            set { SetProperty(ref _mediaTitle, value); }
            get { return _mediaTitle; }
        }

        private void OnPlayCommand()
        {
            _adapter.PlaybackController.Play();
        }
        private void OnPauseCommand()
        {
            _adapter.PlaybackController.Pause();
        }
        private void OnStopCommand()
        {
            _adapter.PlaybackController.Stop();
        }
        private void OnStepForwardCommand()
        {
            _adapter.PlaybackController.StepForward();
        }




    }


}
