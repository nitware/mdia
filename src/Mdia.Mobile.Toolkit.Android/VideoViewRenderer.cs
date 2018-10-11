using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Plugin.MediaManager;
using Xamarin.Forms.Platform.Android;
using Mdia.Mobile.Toolkit.Android;
using Mdia.Mobile.Toolkit;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace Mdia.Mobile.Toolkit.Android
{
    public class VideoViewRenderer : ViewRenderer<VideoView, VideoSurface>
    {
        private VideoSurface _videoSurface;

        public static async void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                _videoSurface = new VideoSurface(Context);
                SetNativeControl(_videoSurface);
                CrossMediaManager.Current.VideoPlayer.RenderSurface = _videoSurface;
            }
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    if (Control == null)
        //    {
        //        _videoSurface = new VideoSurface(Context);
        //        SetNativeControl(_videoSurface);
        //        CrossMediaManager.Current.VideoPlayer.RenderSurface = _videoSurface;
        //    }
        //}

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var p = _videoSurface.LayoutParameters;
            p.Height = heightMeasureSpec;
            p.Width = widthMeasureSpec;
            _videoSurface.LayoutParameters = p;
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }


    }
}
