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
    public class VideoContentPageModel : BaseContentPageModel
    {
        public VideoContentPageModel()
        {
            UpdatePageState(false);

            Content = new Content();
            Content.Title = "Video Content";

            //ContentWrapper.DataLoadOperationCompleted += Cw2_DataLoadOperationCompleted;
            //ContentFilter = x => x.Type.Id == 3;
            
            MessagingCenter.Subscribe<LatestContentPageModel, ObservableCollection<Content>>(this, MessageKeys.ContentsLoaded, OnContentLoadCompleted);
            
            //LoadContent();
        }

        private void OnContentLoadCompleted(LatestContentPageModel sender, ObservableCollection<Content> contentsArgs)
        {
            try
            {
                IsBusy = true;
                //MessagingCenter.Unsubscribe<LatestContentPageViewModel, ObservableCollection<Content>>(this, MessageKeys.ContentsLoaded);

                if (contentsArgs != null && contentsArgs.Count > 0)
                {
                    List<Models.Content> texts = contentsArgs.Where(x => x.Type.Id == 3).ToList();
                    if (texts != null)
                    {
                        Contents = new ObservableCollection<Models.Content>(texts);
                    }
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }


        //private void Cw2_DataLoadOperationCompleted(object sender, EventArgs e)
        //{

        //    IsBusy = false;
        //    ContentWrapper.DataLoadOperationCompleted -= Cw2_DataLoadOperationCompleted;

        //    ObservableCollection<Models.Content> contents = (ObservableCollection<Content>)sender;
        //    List<Models.Content> videos = contents.Where(x => x.Type.Id == 3).ToList();
        //    if (videos != null)
        //    {
        //        Contents = new ObservableCollection<Models.Content>(videos);
        //    }

        //}



    }


}
