using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.PageModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Mdia.Mobile.PageModels.Contents;
using Mdia.Mobile.PageModels.Media;

namespace Mdia.Mobile.PageModels
{
    public class HomePageModel : BasePageModel
    {
        public ICommand SignupCommand => new Command(OnSignUp);
        public ICommand ListContentCommand => new Command(OnListContent);
        public ICommand ViewMediaCommand => new Command(OnViewMedia);
        public ICommand LoginCommand => new Command(OnLogin);

        
        private void OnSignUp()
        {
            NavigationService.NavigateToAsync<SignUpPageModel>();
        }
        private void OnListContent()
        {
            NavigationService.NavigateToAsync<ContentListPageModel>();
        }
        private void OnLogin()
        {
            NavigationService.NavigateToAsync<LoginPageModel>();
        }
        private void OnViewMedia()
        {
            NavigationService.NavigateToAsync<PDFViewerPageModel>();
        }



    }
}
