using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mdia.Mobile.PageModels.Contents;

namespace Mdia.Mobile.Pages.Contents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextContentPage : ContentPage
    {
        public TextContentPage()
        {
            InitializeComponent();
            BindingContext = new TextContentPageModel();

            //slMain.IsVisible = true;
            //svContainer.IsVisible = false;
            
        }

        void btnDetail_OnClicked(object sender, EventArgs e)
        {
            ////bool show = true;
            //slMain.IsVisible = false;
            //Container.IsVisible = true;
            
            //svContainer.Content = new DetailsView(svContainer, slMain);
        }



    }
}