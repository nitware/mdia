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
    public class TextContentPageModel : BaseContentPageModel
    {
        //private bool isBusy;
        //private Content content;
        //private ObservableCollection<Content> contents;

        public TextContentPageModel()
        {
            Content = new Content();
            Content.Title = "Text Content";

            //ContentWrapper.DataLoadOperationCompleted += Cw3_DataLoadOperationCompleted;

            UpdatePageState(false);
            //ContentFilter = x => x.Type.Id == 1;

            //MessagingCenter.Unsubscribe<LatestContentPageViewModel, ObservableCollection<Content>>(this, MessageKeys.ContentsLoaded);
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
                    List<Models.Content> texts = contentsArgs.Where(x => x.Type.Id == 1).ToList();
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
        //                List<Models.Content> texts = args.Where(x => x.Type.Id == 1).ToList();
        //                if (texts != null)
        //                {
        //                    Contents = new ObservableCollection<Models.Content>(texts);
        //                }

        //                IsBusy = false;
        //            }
        //        }
        //    );
        //    }
        //    catch(Exception ex)
        //    {
        //        IsBusy = false;
        //    }
        //}

        //private void Cw3_DataLoadOperationCompleted(object sender, EventArgs e)
        //{

        //    IsBusy = false;
        //    ContentWrapper.DataLoadOperationCompleted -= Cw3_DataLoadOperationCompleted;

        //    ObservableCollection<Models.Content> contents = (ObservableCollection<Content>)sender;
        //    List<Models.Content> texts = contents.Where(x => x.Type.Id == 1).ToList();
        //    if (texts != null)
        //    {
        //        Contents = new ObservableCollection<Models.Content>(texts);
        //    }

        //}



        //public ObservableCollection<Content> Contents
        //{
        //    private set { SetProperty(ref contents, value); }
        //    get { return contents; }
        //}
        //public Content Content
        //{
        //    set { SetProperty(ref content, value); }
        //    get { return content; }
        //}
        //public bool IsBusy
        //{
        //    set { SetProperty(ref isBusy, value); }
        //    get { return isBusy; }
        //}

        //private async void LoadContent()
        //{
        //    await Task.Run(() =>
        //    {
        //        Contents = new ObservableCollection<Models.Content>();
        //        Contents.Add(new Content() { Type = new Models.ContentType() { Id = 1 }, Size = "20.9 KB", Title = "Financial Education", Description = "Financial education education" });
        //        Contents.Add(new Content() { Type = new Models.ContentType() { Id = 1 }, Size = "240.7 KB", Title = "The Power of Your Mind", Description = "Book written by Pastor Chris Oyakhilome, Walk in divine excellence and transform your world through the power of a renewed mind" });
        //        Contents.Add(new Content() { Type = new Models.ContentType() { Id = 1 }, Size = "20.6 MB", Title = "Who Are My", Description = "A book from Napoleon Mill on destiny" });
        //        Contents.Add(new Content() { Type = new Models.ContentType() { Id = 1 }, Size = "66 KB", Title = "The Study of Palmistry", Description = "The study of palmistry description" });
        //    });
        //}


    }
}
