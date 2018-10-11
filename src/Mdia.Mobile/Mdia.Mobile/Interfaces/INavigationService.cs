using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.PageModels.Base;

namespace Mdia.Mobile.Interfaces
{
    public interface INavigationService
    {
        BasePageModel PreviousPageModel { get; }

        Task InitializeAsync();
        Task NavigateToAsync<TPageModel>() where TPageModel : BasePageModel;
        Task NavigateToAsync<TPageModel>(object parameter) where TPageModel : BasePageModel;
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();

    }



}
