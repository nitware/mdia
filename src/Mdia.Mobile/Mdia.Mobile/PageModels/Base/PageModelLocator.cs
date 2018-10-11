using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Xamarin.Forms;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using Mdia.Mobile.Interfaces;
using Mdia.Mobile.Services;
using Mdia.Mobile.PageModels.Contents;
using Mdia.Mobile.Adapters;
using Mdia.Mobile.PageModels.Media;

namespace Mdia.Mobile.PageModels.Base
{
    public static class PageModelLocator
    {
        private static IUnityContainer _container;
        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached("AutoWirePageModel", typeof(bool), typeof(PageModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(PageModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(PageModelLocator.AutoWireViewModelProperty, value);
        }

        public static void RegisterDependencies()
        {
            _container = new UnityContainer();

            _container.RegisterType<HomePageModel>();
            _container.RegisterType<LoginPageModel>();
            _container.RegisterType<AudioContentPageModel>();
            _container.RegisterType<ContentListPageModel>();
            _container.RegisterType<LatestContentPageModel>();
            _container.RegisterType<TextContentPageModel>();
            _container.RegisterType<VideoContentPageModel>();
            _container.RegisterType<PDFViewerPageModel>();

            _container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IMediaManagerAdapter, MediaManagerAdapter>();

           UnityServiceLocator serviceLocator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var page = bindable as Element;
            if (page == null)
            {
                return;
            }

            var pageType = page.GetType();
            var pageName = pageType.FullName.Replace(".Pages.", ".PageModels.");
            var pageAssemblyName = pageType.GetTypeInfo().Assembly.FullName;
            var pageModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", pageName, pageAssemblyName);

            var pageModelType = Type.GetType(pageModelName);
            if (pageModelType == null)
            {
                return;
            }

            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
        }




    }


}
