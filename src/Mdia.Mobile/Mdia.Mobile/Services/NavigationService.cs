using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.Interfaces;
using Mdia.Mobile.PageModels.Base;
using Xamarin.Forms;
using Mdia.Mobile.Pages;
using System.Reflection;
using System.Globalization;
using Mdia.Mobile.PageModels;

namespace Mdia.Mobile.Services
{
    public class NavigationService : INavigationService
    {
        public BasePageModel PreviousPageModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as MainNavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BasePageModel;
            }
        }

        public Task InitializeAsync()
        {
            var mainPage = Application.Current.MainPage as MainNavigationPage;
            if (mainPage == null)
            {
                Application.Current.MainPage = new MainNavigationPage(new HomePage());
            }
           
            return NavigateToAsync<HomePageModel>();




            //if (string.IsNullOrEmpty(Settings.AuthAccessToken))
            //{
            //    return NavigateToAsync<LoginPageModel>();
            //}
            //else
            //{
            //    return NavigateToAsync<HomePageModel>();
            //}
        }

        public Task NavigateToAsync<TPageModel>() where TPageModel : BasePageModel
        {
            return InternalNavigateToAsync(typeof(TPageModel), null);
        }

        public Task NavigateToAsync<TPageModel>(object parameter) where TPageModel : BasePageModel
        {
            return InternalNavigateToAsync(typeof(TPageModel), parameter);
        }

        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as MainNavigationPage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as MainNavigationPage;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        private async Task InternalNavigateToAsync(Type pageModelType, object parameter)
        {
            Page page = CreatePage(pageModelType, parameter);

            var navigationPage = Application.Current.MainPage as MainNavigationPage;
            if (navigationPage != null)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                Application.Current.MainPage = new MainNavigationPage(page);
            }



            //if (page is LoginPage)
            //{
            //    Application.Current.MainPage = new MainNavigationPage(page);
            //}
            //else
            //{
            //    var navigationPage = Application.Current.MainPage as MainNavigationPage;
            //    if (navigationPage != null)
            //    {
            //        await navigationPage.PushAsync(page);
            //    }
            //    else
            //    {
            //        Application.Current.MainPage = new MainNavigationPage(page);
            //    }
            //}

            await (page.BindingContext as BasePageModel).InitializeAsync(parameter);
        }

        private Type GetPageTypeForPageModel(Type pageModelType)
        {
            var pageName = pageModelType.FullName.Replace("Model", string.Empty);
            var pageModelAssemblyName = pageModelType.GetTypeInfo().Assembly.FullName;
            var pageAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", pageName, pageModelAssemblyName);
            var pageType = Type.GetType(pageAssemblyName);
            return pageType;
        }

        private Page CreatePage(Type pageModelType, object parameter)
        {
            try
            {
                Type pageType = GetPageTypeForPageModel(pageModelType);
                if (pageType == null)
                {
                    throw new Exception($"Cannot locate page type for {pageModelType}");
                }

                Page page = Activator.CreateInstance(pageType) as Page;
                return page;
            }
            catch(Exception ex)
            {
                throw;
            }
        }




    }


}
