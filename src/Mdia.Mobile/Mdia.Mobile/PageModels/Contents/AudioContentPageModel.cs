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
    public class AudioContentPageModel : BaseContentPageModel
    {
        public AudioContentPageModel()
        {
            Content = new Content();
            Content.Title = "Audio Content";
                        
            UpdatePageState(false);
            //ContentFilter = x => x.Type.Id == 2;
            
            MessagingCenter.Subscribe<LatestContentPageModel, ObservableCollection<Content>>(this, MessageKeys.ContentsLoaded, OnContentLoadCompleted);
            
            //ContentWrapper.DataLoadOperationCompleted += Cw4_DataLoadOperationCompleted;
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
                    List<Models.Content> texts = contentsArgs.Where(x => x.Type.Id == 2).ToList();
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


        //private void LoadContent()
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        MessagingCenter.Subscribe<LatestContentPageViewModel, ObservableCollection<Content>>(this, MessageKeys.ContentsLoaded, (o, args) =>
        //        {
        //            if (args != null && args.Count > 0)
        //            {
        //                List<Models.Content> audios = args.Where(x => x.Type.Id == 2).ToList();
        //                if (audios != null)
        //                {
        //                    Contents = new ObservableCollection<Models.Content>(audios);
        //                }

        //                IsBusy = false;
        //            }
        //        }
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        IsBusy = false;
        //    }
        //}



        //private void Cw4_DataLoadOperationCompleted(object sender, EventArgs e)
        //{

        //    IsBusy = false;
        //    ContentWrapper.DataLoadOperationCompleted -= Cw4_DataLoadOperationCompleted;

        //    ObservableCollection<Models.Content> contents = (ObservableCollection<Content>)sender;
        //    List<Models.Content> audios = contents.Where(x => x.Type.Id == 2).ToList();
        //    if (audios != null)
        //    {
        //        Contents = new ObservableCollection<Models.Content>(audios);
        //    }

        //}


    }



}
