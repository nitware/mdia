using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mdia.Mobile.Pages.UserCntrols
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentListView : ContentView
    {
        public ContentListView()
        {
            InitializeComponent();

            //Plugin.MediaManager.CrossMediaManager.Current.VideoPlayer.RenderSurface
        }

        async void OnPlayButtonClicked(object sender, EventArgs e)
        {

            //if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            //{
            //    await DisplayAlert("");
            //}

             
            
            await Plugin.MediaManager.CrossMediaManager.Current.Play("http://www.montemagno.com/sample.mp3", Plugin.MediaManager.Abstractions.Enums.MediaFileType.Audio);
            


        }
                
        void OnBuyButtonClicked(object sender, EventArgs e)
        {
            //Plugin.MediaManager.Abstractions.IMediaFile video = new Plugin.Media.Abstractions.MediaFile();
            //Plugin.MediaManager.CrossMediaManager.Current.VideoPlayer.Play()


           //await Plugin.MediaManager.CrossMediaManager.Current.Play("https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4", Plugin.MediaManager.Abstractions.Enums.MediaFileType.Video);
        }


    }
}