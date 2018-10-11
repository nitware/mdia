using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.FilePicker.Abstractions;
using Plugin.FilePicker;

namespace Mdia.Mobile.Pages.Upload
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        private MediaFile _mediaFile;

        public UploadPage()
        {
            InitializeComponent();

            aiBusy.IsRunning = false;
            lblBusy.IsVisible = false;

            pkContentType.SelectedIndex = 0;
        }

        async void btnPickFile_OnClicked(object sender, EventArgs e)
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();

                if (fileData != null)
                {
                    eFilePath.Text = fileData.FileName;
                    byte[] file = fileData.DataArray;


                    
                    
                }

                //if (!string.IsNullOrEmpty(myResult.FileName)) //Just the file name, it doesn't has the path
                //{
                //    foreach (byte b in myResult.DataArray) //Empty array
                //        b.ToString();
                //}




                //await CrossMedia.Current.Initialize();
                //if (!CrossMedia.Current.IsPickPhotoSupported)
                //{
                //    await DisplayAlert("PHOTO", "No Pick Photo Available", "Ok");
                //    return;
                //}

                //_mediaFile = await CrossMedia.Current.PickPhotoAsync();
                //if (_mediaFile == null)
                //{
                //    return;
                //}

                //eFilePath.Text = _mediaFile.Path;
                //image.Source = ImageSource.FromStream(() =>
                //{
                //    return _mediaFile.GetStream();
                //});



            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }

        async void btnUpload_OnClicked(object sender, EventArgs e)
        {
            aiBusy.IsRunning = true;
            lblBusy.IsVisible = true;
        }


    }





}