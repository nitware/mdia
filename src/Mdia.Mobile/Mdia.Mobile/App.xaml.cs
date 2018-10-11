using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Mdia.Mobile.PageModels.Base;
using Mdia.Mobile.Interfaces;
using System.Threading.Tasks;

namespace Mdia.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            PageModelLocator.RegisterDependencies();

            InitNavigation();

            
            //NavigationPage mainNav = new NavigationPage(new Views.Media.PDFViewer());
            //mainNav.BarBackgroundColor = Color.Purple;
            //MainPage = mainNav;

            
            //NavigationPage mainNav = new NavigationPage(new Pages.HomePage());
            //mainNav.BarBackgroundColor = Color.Purple;
            //MainPage = mainNav;

        }

        private Task InitNavigation()
        {
            var navigationService = PageModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
