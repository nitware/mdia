using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.Models;
using System.Collections.ObjectModel;
using Mdia.Mobile.PageModels.Base;
using Xamarin.Forms;

namespace Mdia.Mobile.PageModels.Contents
{
    public class LatestContentPageModel : BaseContentPageModel
    {
        public LatestContentPageModel()
        {
            Content = new Content();
            Content.Title = "Latest Content";

            UpdatePageState(false);

            LoadContentAsync();
        }
        
        private async void LoadContentAsync()
        {
            try
            {
                IsBusy = true;

                ObservableCollection<Content> contents = await base.LoadRemoteContentsAsync();
                Contents = new ObservableCollection<Content>(contents);

                IsBusy = false;
                MessagingCenter.Send(this, MessageKeys.ContentsLoaded, contents);
            }
            catch(Exception ex)
            {
                IsBusy = false;
            }
        }


        //private void Cw1_DataLoadOperationCompleted(object sender, EventArgs e)
        //{
        //    IsBusy = false;
        //    ContentWrapper.DataLoadOperationCompleted -= Cw1_DataLoadOperationCompleted;
        //    ObservableCollection<Models.Content> contents = (ObservableCollection<Content>)sender;
        //    if (contents != null)
        //    {
        //        Contents = new ObservableCollection<Models.Content>(contents);
        //    }
        //}




    }



}
