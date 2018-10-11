using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Mdia.Mobile.Toolkit.Android;
using Mdia.Mobile.Toolkit;
using Xamarin.Forms.Platform.Android;
using System.Net;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(PDFReader), typeof(PDFReaderRenderer))]
namespace Mdia.Mobile.Toolkit.Android
{
    public class PDFReaderRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                LoadPDF();

                //MessagingCenter.Send(this, "n", e.NewElement);
                //MessagingCenter.Subscribe<PDFReaderRenderer, WebView>(this, "n", (o, args) => { int a = 6; });
                //MessagingCenter.Subscribe<PDFReaderRenderer, WebView>(this, "n", MessageHandler);

                //var pdfReader = Element as PDFReader;
                //Control.Settings.AllowUniversalAccessFromFileURLs = true;
                //Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", pdfReader.Uri));

                //string filePath = WebUtility.UrlEncode("https://www.asp.net/media/4071077/aspnet-web-api-poster.pdf");
                //string filePath = string.Format("https://www.asp.net/media/4071077/{0}", WebUtility.UrlEncode("aspnet-web-api-poster.pdf"));
                //Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", filePath));
                //string url = string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(pdfReader.Uri));
                //Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(pdfReader.Uri))));
            }
        }

        //private void MessageHandler(PDFReaderRenderer sender, WebView e)
        //{

        //}


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Uri")
            {
                LoadPDF();
            }
        }

        private void LoadPDF()
        {
            var pdfReader = Element as PDFReader;
            Control.Settings.AllowUniversalAccessFromFileURLs = true;
            Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", pdfReader.Uri));
        }




    }
}