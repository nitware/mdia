using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mdia.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


            
            //btnMd.Clicked += async (sender, e) =>
            //{
            //    await Navigation.PushAsync(new Media.PDFViewerPage());
            //};
            //btnList.Clicked += async (sender, e) =>
            //{
            //    await Navigation.PushAsync(new Content.ContentListPage());
            //};
            //btnSignUp.Clicked += async (sender, e) =>
            //{
            //    await Navigation.PushAsync(new SignUpPage());
            //};
            //btnLogin.Clicked += async (sender, e) =>
            //{
            //    await Navigation.PushAsync(new LoginPage());
            //};
        }

        //private void RemoveLastPageFromStack()
        //{
        //    var mainPage = Application.Current.MainPage as NavigationPage;
        //    if (mainPage != null)
        //    {
        //        mainPage.Navigation.RemovePage(mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
        //    }
        //}





    }
}