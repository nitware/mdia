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
    public partial class LatestContentPage : ContentPage
    {
        public LatestContentPage()
        {
            InitializeComponent();
            BindingContext = new LatestContentPageModel();
        }


    }
}