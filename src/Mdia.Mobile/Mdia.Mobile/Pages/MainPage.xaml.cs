using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.Media;
using Plugin.FilePicker;
using Plugin.Media.Abstractions;
using Plugin.FilePicker.Abstractions;
using Mdia.Mobile.MdiaService;

namespace Mdia.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        private MediaFile _mediaFile;
        private MdiaService.ServiceClient _client;
        
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnTestService_Onclicked(object sender, EventArgs e)
        {
            try
            {
                filePath.Text = "";
                InitializeHelloWorldServiceClient();
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }
        async void btnTestRESTService_Onclicked(object sender, EventArgs e)
        {
            try
            {
                filePath.Text = "";
                aiBusy.IsRunning = true;

                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                filePath.Text = await client.GetStringAsync("http://content.nitware.com.ng/api/values");
                
                aiBusy.IsRunning = false;
            }
            catch (Exception ex)
            {
                aiBusy.IsRunning = false;
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }
        void btnTempConverter_Onclicked(object sender, EventArgs e)
        {
            try
            {
                filePath.Text = "";

                aiBusy.IsRunning = true;

                TempConverterService.TempConvertSoapClient client = new TempConverterService.TempConvertSoapClient(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress("https://www.w3schools.com/xml/TempConvert.asmx"));
                client.CelsiusToFahrenheitCompleted += Client_CelsiusToFahrenheitCompleted;
                client.CelsiusToFahrenheitAsync(txtInput.Text);
            }
            catch (Exception ex)
            {
                aiBusy.IsRunning = false;
                filePath.Text = ex.ToString();
                //await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }

        private void Client_CelsiusToFahrenheitCompleted(object sender, TempConverterService.CelsiusToFahrenheitCompletedEventArgs e)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                string error = null;
                aiBusy.IsRunning = false;

                if (e.Error != null)
                {
                    error = e.Error.ToString();
                }
                else if (e.Cancelled)
                {
                    error = "Cancelled";
                }

                if (!string.IsNullOrEmpty(error))
                {
                    filePath.Text = error;
                    //await DisplayAlert("Error", error, "Ok", "Cancel");
                }
                else
                {
                    filePath.Text = e.Result;
                }
            });
        }

        private void InitializeHelloWorldServiceClient()
        {
            try
            {
                int value = int.Parse(txtInput.Text);

                aiBusy.IsRunning = true;

                _client = new MdiaService.ServiceClient(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress("http://mdia.nitware.com.ng/service.svc"));
                _client.GetDataCompleted += OnGetDataCompleted;
                _client.GetDataAsync(value);
            }
            catch(Exception ex)
            {
                aiBusy.IsRunning = false;
                filePath.Text = ex.ToString();
            }
        }

        private void OnGetDataCompleted(object sender, MdiaService.GetDataCompletedEventArgs e)
        {
            //Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                aiBusy.IsRunning = false;

                string error = null;

                if (e.Error != null)
                {
                    error = e.Error.ToString();
                }
                else if (e.Cancelled)
                {
                    error = "Cancelled";
                }
                
                if (!string.IsNullOrEmpty(error))
                {
                    filePath.Text = error;
                    //await DisplayAlert("Error", error, "Ok", "Cancel");
                }
                else
                {
                    filePath.Text = e.Result;
                }
            });
        }
        
        private static System.ServiceModel.BasicHttpBinding CreateBasicHttp()
        {
            System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding
            {
                Name = "basicHttpBinding",

                //Name = "customBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;

            return binding;
        }

        async void btnPickPhoto_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("PHOTO", "No Pick Photo Available", "Ok");
                    return;
                }

                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null)
                {
                    return;
                }

                filePath.Text = _mediaFile.Path;

                image.Source = ImageSource.FromStream(() =>
                {
                    return _mediaFile.GetStream();
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }

        async void btnTakePhoto_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { Directory = "Sample", Name = "test.jpg" });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");
                //System.IO.FileStream fs 
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
            catch(Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }

        async void btnPickFile_Onclicked(object sender, EventArgs e)
        {
            try
            {

                FileData fileData = await CrossFilePicker.Current.PickFile();

                if (fileData != null)
                {
                    string filePath = fileData.FilePath;
                    //filePath.Text = fileData.FileName;
                    byte[] file = fileData.DataArray;

                    //await SaveImage(fileData.DataArray, fileData.FileName, PCLStorage.FileSystem.Current.LocalStorage);
                }

                //if (!string.IsNullOrEmpty(myResult.FileName)) //Just the file name, it doesn't has the path
                //{
                //    foreach (byte b in myResult.DataArray) //Empty array
                //        b.ToString();
                //}
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Ok");
            }
        }

        //public async static Task SaveImage(this byte[] image, String fileName, PCLStorage.IFolder rootFolder = null)
        //{
        //    // get hold of the file system  
        //    PCLStorage.IFolder folder = rootFolder ?? PCLStorage.FileSystem.Current.LocalStorage;

        //    // create a file, overwriting any existing file  
        //    PCLStorage.IFile file = await folder.CreateFileAsync(fileName, PCLStorage.CreationCollisionOption.ReplaceExisting);

        //    // populate the file with image data  
        //    using (System.IO.Stream stream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
        //    {
        //        stream.Write(image, 0, image.Length);
        //    }
        //}





    }

}
