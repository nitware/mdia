using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.Interfaces;

namespace Mdia.Mobile.PageModels.Base
{
    public class BasePageModel : BasePropertyChangeNotifier, INotifyPropertyChanged
    {
        //protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;
        
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public BasePageModel()
        {
            //DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = PageModelLocator.Resolve<INavigationService>();
            //GlobalSetting.Instance.BaseEndpoint = Settings.UrlBase;
        }
        
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


    }
}
