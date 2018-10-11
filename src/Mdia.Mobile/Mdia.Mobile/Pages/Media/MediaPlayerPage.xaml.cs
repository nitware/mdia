using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Plugin.MediaManager;
//using Plugin.MediaManager.Abstractions;

namespace Mdia.Mobile.Pages.Media
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPlayerPage : ContentPage
    {
        //private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public MediaPlayerPage()
        {
            InitializeComponent();
            
            //Media.Source = new Uri("file:///LegOver.mp4");
             
            //this.Appearing += MediaPlayerPage_Appearing;

            //CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        pbProgressBar.Progress = e.Progress;
            //        Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
            //    });
            //};
        }

        private void MediaPlayerPage_Appearing(object sender, EventArgs e)
        {
            //PlayMedia();
        }

        void OnPlayButtonClicked(object sender, EventArgs e)
        {
            //PlayMedia();
        }

        //void PlayMedia()
        //{
        //    Media.Source = new Uri("file:///LegOver.mp4");
        //    if (Media.CurrentState != InTheHand.Forms.MediaElementState.Playing)
        //    {
        //        Media.Play();

        //        //Media.CurrentState = InTheHand.Forms.MediaElementState.
        //    }
        //}

        //async void OnPDFViewerButtonClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Media.PDFViewerPage());
        //}

        //void PlayClicked(object sender, System.EventArgs e)
        //{
        //    PlaybackController.Play();
        //}

        //void PauseClicked(object sender, System.EventArgs e)
        //{
        //    PlaybackController.Pause();
        //}

        //void StopClicked(object sender, System.EventArgs e)
        //{
        //    PlaybackController.Stop();
        //}




    }
}