using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Utility.Interfaces;
using System.Web;
using System.Configuration;
using System.IO;

namespace Mdia.Utility
{
    public class FileManager : IFileManager
    {
        //private const string JUNK_FOLDER_PATH = "Junk";


        private const string LOG_FOLDER_PATH = "Log";
        private const string ROOT_FOLDER_PATH = "/Contents";
        private const string DESTINATION_FOLDER_PATH = "Contents";
        private string appRoot = ConfigurationManager.AppSettings["AppRoot"];
        public const string DEFAULT_AVATAR = "/Content/Images/default_avatar.png";
        public static string TILDA = "~";

        private readonly string _basePath;

        public FileManager(string basePath)
        {
            _basePath = basePath;
        }

        //public string JunkFolderPath { get { return JUNK_FOLDER_PATH; } }

        public string RootFolderPath { get { return ROOT_FOLDER_PATH; } }
        public string DestinationFolderPath { get { return DESTINATION_FOLDER_PATH; } }
        public string LogFolderPath { get { return LOG_FOLDER_PATH; } }
        public string BasePath { get { return _basePath; } }

        public Dictionary<string, dynamic> Upload(HttpFileCollection files, string fileName)
        {
            string path = null;
            string fileUrl = null;
            string message = "File upload failed";
            int fileSize = 0;
            string fileExtension = null;
            bool isUploaded = false;

            try
            {
                if (files != null && files.Count > 0)
                {
                    foreach (string file in files)
                    {
                        HttpPostedFile postedFile = files[file];
                        FileInfo fileInfo = new FileInfo(postedFile.FileName);

                        fileExtension = fileInfo.Extension;
                        fileSize = postedFile.ContentLength;
                        string invalidFileMessage = InvalidFile(fileSize, fileExtension);
                        if (!string.IsNullOrEmpty(invalidFileMessage))
                        {
                            return CreateFileUploadResponse(false, invalidFileMessage, null, fileSize, fileExtension);
                        }

                        string folderPath = System.Web.Hosting.HostingEnvironment.MapPath(TILDA + RootFolderPath);
                        if (this.CreateFolderIfNeeded(folderPath))
                        {
                            //DeleteFileIfExist(folderPath, id.ToString());
                            postedFile.SaveAs(Path.Combine(folderPath, fileName));

                            isUploaded = true;
                            message = "File uploaded successfully!";

                            path = Path.Combine(folderPath, fileName);
                            if (path != null)
                            {
                                fileUrl = RootFolderPath + "/" + fileName;
                            }
                        }
                        else
                        {
                            return CreateFileUploadResponse(false, "Error occurred during folder creation process!", null, fileSize, fileExtension);
                        }
                    }
                }
                else
                {
                    return CreateFileUploadResponse(false, "No file uploaded or uploaded file content lenght is zero! Please upload a file", null, fileSize, fileExtension);
                }
            }
            catch (Exception ex)
            {
                fileUrl = null;
                isUploaded = false;
                message = string.Format("File upload failed with: {0}", ex.Message);
            }

            return CreateFileUploadResponse(isUploaded, message, fileUrl, fileSize, fileExtension);
        }

        public Dictionary<string, dynamic> Upload(HttpFileCollection files, Guid id)
        {
            string path = null;
            string fileUrl = null;
            string message = "File upload failed";
            int fileSize = 0;
            string fileExtension = null; 
            bool isUploaded = false;

            try
            {
                if (files != null && files.Count > 0)
                {
                    foreach (string file in files)
                    {
                        HttpPostedFile postedFile = files[file];
                        FileInfo fileInfo = new FileInfo(postedFile.FileName);
                        string fileName = id + "__" + DateTime.Now.ToString("yyyyMMddHHmmss") + fileInfo.Extension;

                        fileExtension = fileInfo.Extension;
                        fileSize = postedFile.ContentLength;

                        string invalidFileMessage = InvalidFile(fileSize, fileExtension);
                        if (!string.IsNullOrEmpty(invalidFileMessage))
                        {
                            return CreateFileUploadResponse(false, invalidFileMessage, null, fileSize, fileExtension);
                        }
                        
                        string folderPath = System.Web.Hosting.HostingEnvironment.MapPath(TILDA + RootFolderPath);
                        if (this.CreateFolderIfNeeded(folderPath))
                        {
                            DeleteFileIfExist(folderPath, id.ToString());
                            postedFile.SaveAs(Path.Combine(folderPath, fileName));
                            
                            isUploaded = true;
                            message = "File uploaded successfully!";

                            path = Path.Combine(folderPath, fileName);
                            if (path != null)
                            {
                                fileUrl = RootFolderPath + "/" + fileName;
                            }
                        }
                        else
                        {
                            return CreateFileUploadResponse(false, "Error occurred during folder creation process!", null, fileSize, fileExtension);
                        }
                    }
                }
                else
                {
                    return CreateFileUploadResponse(false, "No file uploaded or uploaded file content lenght is zero! Please upload a file", null, fileSize, fileExtension);
                }
            }
            catch (Exception ex)
            {
                fileUrl = null;
                isUploaded = false;
                message = string.Format("File upload failed with: {0}", ex.Message);
            }

            return CreateFileUploadResponse(isUploaded, message, fileUrl, fileSize, fileExtension);
        }

        private Dictionary<string, dynamic> CreateFileUploadResponse(bool isUploaded, string message, string fileUrl, int fileSize, string fileExtension)
        {
            try
            {
                Dictionary<string, dynamic> fileUploadResponse = new Dictionary<string, dynamic>();
                fileUploadResponse.Add("isUploaded", isUploaded);
                fileUploadResponse.Add("message", message);
                fileUploadResponse.Add("fileUrl", fileUrl);
                fileUploadResponse.Add("fileSize", fileSize);
                fileUploadResponse.Add("fileExtension", fileExtension);

                return fileUploadResponse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Dictionary<string, dynamic> GetFileMetadata(HttpPostedFile postedFile)
        {
            try
            {
                Dictionary<string, dynamic> fileMetadata = null;

                if (postedFile == null)
                {
                    return fileMetadata;
                }

                FileInfo fileInfo = new FileInfo(postedFile.FileName);
                string extension = fileInfo.Extension;
                int fileSize = postedFile.ContentLength;

                fileMetadata = new Dictionary<string, dynamic>();
                fileMetadata.Add("fileExtension", extension);
                fileMetadata.Add("fileSize", fileSize);

                return fileMetadata;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string InvalidFile(decimal uploadedFileSize, string fileExtension)
        {
            try
            {
                string message = null;
                decimal oneKiloByte = 1024;
                decimal maximumFileSize = 40000 * oneKiloByte;

                //decimal maximumFileSize = 20 * oneKiloByte;

                decimal actualFileSizeToUpload = Math.Round(uploadedFileSize / oneKiloByte, 1);
                if (InvalidFileType(fileExtension))
                {
                    message = "File type '" + fileExtension + "' is invalid! File type must be any of the following: .pdf, .mp3, .mp4";
                    //message = "File type '" + fileExtension + "' is invalid! File type must be any of the following: .jpg, .jpeg, .png or .jif ";
                }
                else if (actualFileSizeToUpload > (maximumFileSize / oneKiloByte))
                {
                    message = "Your file size of " + actualFileSizeToUpload.ToString("0.#") + " Kb is too large, maximum allowed size is " + (maximumFileSize / oneKiloByte) + " Kb";
                }

                return message;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InvalidFileType(string extension)
        {
            try
            {
                extension = extension.ToLower();
                switch (extension)
                {
                    case ".pdf":
                    case ".mp3":
                    case ".mp4":
                        return false;

                    default:
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFileIfExist(string folderPath, string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(fileName))
                {
                    throw new Exception("Folder path or file search string cannot be null! Please contact your system administrator.");
                }

                string wildCard = fileName + "*.*";
                IEnumerable<string> files = Directory.EnumerateFiles(folderPath, wildCard, SearchOption.TopDirectoryOnly);

                if (files != null && files.Count() > 0)
                {
                    foreach (string file in files)
                    {
                        System.IO.File.Delete(file);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }

        //public string GetDestinationFilePath(string junkFilePath, string junkFolderPath, string destinationFolderPath)
        //{
        //    try
        //    {
        //        return junkFilePath.Replace(junkFolderPath, destinationFolderPath);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Move(string junkFileUrl, string destinationFileUrl, string junkFileSearchString)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(destinationFileUrl))
        //        {
        //            throw new Exception("Destination file path cannot be empty! Please try again. Contact your administrator after three unsuccessful trials.");
        //        }

        //        string junkFilePath = _basePath + junkFileUrl.Replace("/", @"\");
        //        string destinationFilePath = _basePath + destinationFileUrl.Replace("/", @"\");
        //        string folderPath = Path.GetDirectoryName(destinationFilePath);

        //        if (!CreateFolderIfNeeded(folderPath))
        //        {
        //            throw new Exception("Destination file path failed during creation! Please try again!");
        //        }

        //        DeleteFileIfExist(folderPath, junkFileSearchString);
        //        if (System.IO.File.Exists(junkFilePath) && !string.IsNullOrWhiteSpace(destinationFilePath))
        //        {
        //            System.IO.File.Move(junkFilePath, destinationFilePath);
        //        }
        //        else if (!string.IsNullOrWhiteSpace(destinationFilePath))
        //        {
        //            System.IO.File.Create(destinationFilePath);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public string ChangeFileName(FileInfo file, string newFileNameStartString)
        {
            try
            {
                string fileName = file.Name;
                string directory = Path.GetDirectoryName(file.FullName);
                string newFileName = newFileNameStartString + DateTime.Now.ToString("yyyyMMddHHmmss") + file.Extension;
                
                //string newFileName = newFileNameStartString + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") + file.Extension;

                return directory + @"\" + newFileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetRelativeFilePathFrom(string absolutefilePath, string startAt)
        {
            try
            {
                int stringLenght = absolutefilePath.Length;
                int startIndex = absolutefilePath.IndexOf(startAt);
                int endIndex = stringLenght - startIndex;

                string relativePath = absolutefilePath.Substring(startIndex, endIndex);
                if (!string.IsNullOrWhiteSpace(relativePath))
                {
                    relativePath = relativePath.Replace("\\", "/");
                }

                return relativePath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exist(string fileUrl)
        {
            try
            {
                //string filePath = System.Web.Hosting.HostingEnvironment.MapPath(TILDA + fileUrl);

                string filePath = _basePath + fileUrl.Replace("/", @"\");
                return System.IO.File.Exists(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public string GetFileDestinationRelativePath(string junkFileUrl, string junkFileSearchString, string junkFolderPath, string destinationFolderPath)
        //{
        //    try
        //    {
        //        string startAt = @"\Content";
        //        string destinationFileUrl = GetDestinationFilePath(junkFileUrl, junkFolderPath, destinationFolderPath);

        //        string destinationFolder = _basePath + startAt + @"\" + destinationFolderPath;
        //        if (!CreateFolderIfNeeded(destinationFolder))
        //        {
        //            throw new Exception("Destination folder does not exist or cannot be created!");
        //        }

        //        //System.IO.FileInfo file = new System.IO.FileInfo(System.Web.Hosting.HostingEnvironment.MapPath(TILDA + destinationFileUrl));

        //        string fileUrl = _basePath + destinationFileUrl.Replace("/", @"\");
        //        FileInfo file = new FileInfo(fileUrl);
        //        string newAbsoluteFilePath = ChangeFileName(file, junkFileSearchString);

        //        return GetRelativeFilePathFrom(newAbsoluteFilePath, startAt);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public void CreateLog(string filePath, string content)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(content);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string GetCalculatedFileSize(long rawFileSize)
        {
            const decimal ONE_KILO_BYTE = 1024;
            const decimal ONE_MEGA_BYTE = 1048576;
            const decimal ONE_GIGA_BYTE = 1073741824;
            const decimal ONE_TERA_BYTE = 1099511627776;
            const decimal ONE_PETA_BYTE = 1125899906842624;
            const decimal ONE_EXA_BYTE = 1152921504606846976;
            //const decimal ONE_ZETTA_BYTE = 1180591620717411303424;
            //const decimal ONE_YOTTA_BYTE = 1208925819614629174706176;

            try
            {
                string fileSize = null;
                decimal calculatedFileSize = 0;

                if (rawFileSize >= ONE_EXA_BYTE)
                {
                    calculatedFileSize = Math.Round(rawFileSize / ONE_EXA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " EB";
                }
                else if (rawFileSize >= ONE_PETA_BYTE)
                {
                    calculatedFileSize = Math.Round(rawFileSize / ONE_PETA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " PB";
                }
                else if (rawFileSize >= ONE_TERA_BYTE)
                {
                    calculatedFileSize = Math.Round(rawFileSize / ONE_TERA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " TB";
                }
                else if (rawFileSize >= ONE_GIGA_BYTE)
                {
                    calculatedFileSize = Math.Round(rawFileSize / ONE_GIGA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " GB";
                }
                else if (rawFileSize >= ONE_MEGA_BYTE)
                {
                    calculatedFileSize = Math.Round(rawFileSize / ONE_MEGA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " MB";
                }
                else if (rawFileSize >= ONE_KILO_BYTE)
                {
                    calculatedFileSize = Math.Round(rawFileSize / ONE_KILO_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " KB";
                }
                else
                {
                    calculatedFileSize = Math.Round(calculatedFileSize, 2);
                    fileSize = calculatedFileSize > 1 ? calculatedFileSize.ToString() + " Bytes" : calculatedFileSize.ToString() + " Byte";
                }

                return fileSize;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
