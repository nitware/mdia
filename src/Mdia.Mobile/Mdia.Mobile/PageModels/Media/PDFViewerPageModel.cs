using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.PageModels.Base;
using Xamarin.Forms;
using System.Windows.Input;

namespace Mdia.Mobile.PageModels.Media
{
    public class PDFViewerPageModel : BasePageModel
    {
        private string _uri;
        private string _selectedFile;

        private bool _on;
        private const string _file1 = "Display_Local_PDF_File_in_a_WebView.pdf";
        private const string _file2 = "compressed.tracemonkey-pldi-09.pdf";

        public PDFViewerPageModel()
        {
            //Uri = "Display_Local_PDF_File_in_a_WebView.pdf";
        }

        public ICommand SelectFileCommand => new Command(OnSelectFileCommand);
        public ICommand OnLoadPDFCommand => new Command(OnOnLoadPDFCommand);

        public string Uri
        {
            set { SetProperty(ref _uri, value); }
            get { return _uri; }
        }
        public string SelectedFile
        {
            set { SetProperty(ref _selectedFile, value); }
            get { return _selectedFile; }
        }

        private void OnOnLoadPDFCommand()
        {
            if (_on)
            {
                Uri = string.Format("file:///android_asset/Content/{0}", System.Net.WebUtility.UrlEncode(_file2));
            }
            else
            {
                Uri = string.Format("file:///android_asset/Content/{0}", System.Net.WebUtility.UrlEncode(_file1));
            }

            _on = !_on;
        }

        private async void OnSelectFileCommand()
        {
            try
            {
                Plugin.FilePicker.Abstractions.FileData fileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile();

                if (fileData != null)
                {
                    SelectedFile = fileData.FileName;
                    //Uri = System.Net.WebUtility.UrlEncode(filePath);
                    //byte[] file = fileData.DataArray;
                }
                else
                {
                    SelectedFile = null;
                }
            }
            catch (Exception ex)
            {
                //await _page.DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }


    }


}
