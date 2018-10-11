using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mdia.Mobile.PageModels;

namespace Mdia.Mobile.Pages.Media
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFViewerPage : ContentPage
    {
        //private bool _on;
        //private const string _file1 = "Display_Local_PDF_File_in_a_WebView.pdf";
        //private const string _file2 = "compressed.tracemonkey-pldi-09.pdf";

        //private PDFViewerPageModel _viewModel;

        public PDFViewerPage()
        {
            InitializeComponent();

            //_viewModel = new PDFViewerPageModel(this);
            //BindingContext = _viewModel;
        }

        async void OnMediaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Media.MediaPlayerPage());
        }

        async void OnSelectFileCommand(object sender, EventArgs e)
        {
            try
            {
                PCLStorage.IFolder folder = PCLStorage.FileSystem.Current.LocalStorage;
                string rootFolder = folder.Path;
                //txtSelectedFile.Text = rootFolder;

                Plugin.FilePicker.Abstractions.FileData fileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile();

                //string fileName = null;
                if (fileData != null)
                {
                    
                    string filePath = fileData.FilePath;
                    string fileName = fileData.FileName;

                    //string filePath = "/storage/sdcard0/MyFavorite/Photo Card-1.pdf";
                    string encodedFilePath = GetTruePath(filePath);

                    //_viewModel.Uri = string.Format("file:///{0}", encodedFilePath);

                    PCLStorage.IFolder folder2 = await folder.CreateFolderAsync("root", PCLStorage.CreationCollisionOption.ReplaceExisting);
                    await SaveImage(fileData.DataArray, fileName, folder2);

                  
                    txtSelectedFile.Text = folder2.Path + "/" + fileName;
                   // _viewModel.Uri = string.Format("file:///{0}", GetTruePath(txtSelectedFile.Text));
                }
                else
                {
                    txtSelectedFile.Text = null;
                }

                //txtSelectedFile.Text = _viewModel.Uri;
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }
        private string GetTruePath(string path)
        {
            string[] filePathArray = path.Split('/');

            string fileName = filePathArray[filePathArray.Length - 1];
            filePathArray[filePathArray.Length - 1] = System.Net.WebUtility.UrlEncode(filePathArray[filePathArray.Length - 1]);

            string encodedFilePath = string.Join("/", filePathArray);

            string firstCharacter = encodedFilePath.Substring(0, 1);
            if (firstCharacter == "/")
            {
                encodedFilePath = encodedFilePath.Substring(1, encodedFilePath.Length - 1);
            }

            return encodedFilePath;
        }
        private void OnLoadPDFCommand(object sender, EventArgs e)
        {
            //if (_on)
            //{
            //    _viewModel.Uri = string.Format("file:///android_asset/Content/{0}", System.Net.WebUtility.UrlEncode(_file2));
            //}
            //else
            //{
            //    _viewModel.Uri = string.Format("file:///android_asset/Content/{0}", System.Net.WebUtility.UrlEncode(_file1));
            //}
            
            //_on = !_on;
            //txtSelectedFile.Text = _viewModel.Uri;
        }

        async Task SaveImage(byte[] image, String fileName, PCLStorage.IFolder rootFolder = null)
        {
            // get hold of the file system  
            PCLStorage.IFolder folder = rootFolder ?? PCLStorage.FileSystem.Current.LocalStorage;

            // create a file, overwriting any existing file  
            PCLStorage.IFile file = await folder.CreateFileAsync(fileName, PCLStorage.CreationCollisionOption.ReplaceExisting);

            // populate the file with image data  
            using (System.IO.Stream stream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                stream.Write(image, 0, image.Length);
            }
        }



    }
}