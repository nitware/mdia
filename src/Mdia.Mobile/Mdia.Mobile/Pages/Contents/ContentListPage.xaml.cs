using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mdia.Mobile.Pages.Upload;


namespace Mdia.Mobile.Pages.Contents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentListPage : TabbedPage
    {
        public ContentListPage()
        {
            InitializeComponent();

            //t = new
            //{
            //    new LatestContentPage()
            //};


            //this.Children.Add(new LatestContentPage());
            //this.Children.Add(new LatestContentPage());
            //this.Children.Add(new LatestContentPage());
            //this.Children.Add(new LatestContentPage());
        }

        async void OnFindIconClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        async void OnUploadIconClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UploadPage());
        }


    }

}