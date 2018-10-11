using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mdia.Mobile.PageModels.Base
{
    public abstract class BaseContentPageModel : BasePageModel
    {
        private bool _isBusy;
        private Content _content;
        private bool _showMasterPage;
        private bool _showDetailsPage;
        private ObservableCollection<Content> _contents;

        private string _previewButtonText;

        public BaseContentPageModel()
        {
            BackCommand = new Command(OnBackCommand);
            PreviewCommand = new Command(OnPreviewCommand);
            BuyCommand = new Command(OnBuyCommand);
        }

        public ICommand BackCommand { get; set; }
        public ICommand PreviewCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        //protected Func<Content, bool> ContentFilter { get; set; }

        public ObservableCollection<Content> Contents
        {
            set { SetProperty(ref _contents, value); }
            get { return _contents; }
        }
        public Content Content
        {
            get { return _content; }
            set
            {
                SetProperty(ref _content, value);
                if (_content != null && _content.Type != null)
                {
                    switch (_content.Type.Id)
                    {
                        case 1:
                            {
                                PreviewButtonText = "Preview";
                                break;
                            }
                        case 2:
                        case 3:
                            {
                                PreviewButtonText = "Play";
                                break;
                            }
                    }
                                         
                    UpdatePageState(true);
                }
            }
        }
        public bool IsBusy
        {
            set { SetProperty(ref _isBusy, value); }
            get { return _isBusy; }
        }
        public bool ShowDetailsPage
        {
            set { SetProperty(ref _showDetailsPage, value); }
            get { return _showDetailsPage; }
        }
        public bool ShowMasterPage
        {
            set { SetProperty(ref _showMasterPage, value); }
            get { return _showMasterPage; }
        }
        public string PreviewButtonText
        {
            set { SetProperty(ref _previewButtonText, value); }
            get { return _previewButtonText; }
        }
        
        protected void UpdatePageState(bool state)
        {
            ShowMasterPage = !state;
            ShowDetailsPage = state;
        }
        private void OnBackCommand()
        {
            UpdatePageState(false);
        }
        private void OnPreviewCommand()
        {
            
        }
        private void OnBuyCommand()
        {
            
        }

        public async Task<ObservableCollection<Models.Content>> LoadRemoteContentsAsync()
        {
            ObservableCollection<Models.Content> latestContent = await Task.Run<ObservableCollection<Models.Content>>(() =>
            {
                ObservableCollection<Models.Content> contents = new ObservableCollection<Models.Content>();
                contents.Add(new Content() { Price = 1050, Type = new Models.ContentType() { Id = 2, Name = "Audio" }, Size = "33.4 KB", Title = "The Lord is Good", Description = "The lord is good description" });
                contents.Add(new Content() { Price = 150, Type = new Models.ContentType() { Id = 2, Name = "Audio" }, Size = "25.2 KB", Title = "The gods Are Wise", Description = "The gods are wise description" });
                contents.Add(new Content() { Price = 220, Type = new Models.ContentType() { Id = 3, Name = "Video" }, Size = "13.1 MB", Title = "Unlimited Abundance", Description = "Unlimited abundance description" });
                contents.Add(new Content() { Price = 170, Type = new Models.ContentType() { Id = 1, Name = "Text" }, Size = "20.9 KB", Title = "Financial Education", Description = "Financial education education" });
                contents.Add(new Content() { Price = 230, Type = new Models.ContentType() { Id = 3, Name = "Video" }, Size = "120.2 KB", Title = "Leg Over", Description = "Leg over is a music by ..." });
                contents.Add(new Content() { Price = 60, Type = new Models.ContentType() { Id = 1, Name = "Text" }, Size = "240.7 KB", Title = "The Power of Your Mind", Description = "Book written by Pastor Chris Oyakhilome, Walk in divine excellence and transform your world through the power of a renewed mind" });
                contents.Add(new Content() { Price = 500, Type = new Models.ContentType() { Id = 3, Name = "Video" }, Size = "201.8 KB", Title = "Infinity", Description = "A song by ..." });
                contents.Add(new Content() { Price = 1000, Type = new Models.ContentType() { Id = 2, Name = "Audio" }, Size = "60.33 KB", Title = "Sins Are Fogiven", Description = "Sins are forgiven description" });
                contents.Add(new Content() { Price = 1500, Type = new Models.ContentType() { Id = 1, Name = "Text" }, Size = "20.6 MB", Title = "Who Are My", Description = "A book from Napoleon Mill on destiny" });
                contents.Add(new Content() { Price = 1700, Type = new Models.ContentType() { Id = 1, Name = "Text" }, Size = "66 KB", Title = "The Study of Palmistry", Description = "The study of palmistry description" });

                return contents;
            });

            return latestContent;
        }
        //protected virtual void OnContentLoadCompleted(LatestContentPageViewModel sender, ObservableCollection<Content> contentsArgs)
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        MessagingCenter.Unsubscribe<LatestContentPageViewModel, ObservableCollection<Content>>(this, MessageKeys.ContentsLoaded);
        //        if (contentsArgs != null && contentsArgs.Count > 0 && ContentFilter != null)
        //        {
        //            List<Models.Content> texts = contentsArgs.Where(ContentFilter).ToList();
        //            if (texts != null)
        //            {
        //                Contents = new ObservableCollection<Models.Content>(texts);
        //            }
        //        }

        //        IsBusy = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        IsBusy = false;
        //    }
        //}




    }
}
