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
    public partial class DetailsView : ContentView
    {
        private ScrollView _child;
        private StackLayout _parent;

        public DetailsView(ScrollView child, StackLayout parent)
        {
            InitializeComponent();

            _child = child;
            _parent = parent;
        }
        
        async void btnContentList_OnClicked(object sender, EventArgs e)
        {
            //bool show = true;

            _child.IsVisible = false;
            _parent.IsVisible = true;

            //this.IsVisible = false;
            //await Navigation.PushAsync(new TextContentPage());
        }

       


    }




}