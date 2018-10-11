using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Mdia.Utility.Interfaces
{
    public interface IFileManager
    {
        //string JunkFolderPath { get; }

        string RootFolderPath { get; }
        string DestinationFolderPath { get; }
        string LogFolderPath { get; }
        string BasePath { get; }


        //string GetDestinationFilePath(string junkFilePath, string junkFolderPath, string destinationFolderPath);
        //string GetFileDestinationRelativePath(string junkFileUrl, string junkFileSearchString, string junkFolderPath, string destinationFolderPath);
        //void Move(string junkFileUrl, string destinationFileUrl, string junkFileSearchString);


        Dictionary<string, dynamic> Upload(HttpFileCollection files, Guid id);
        Dictionary<string, dynamic> Upload(HttpFileCollection files, string fileName);
        string GetRelativeFilePathFrom(string absolutefilePath, string startAt);
        string ChangeFileName(FileInfo file, string newFileNameStartString);
        void DeleteFileIfExist(string folderPath, string fileName);
        void CreateLog(string filePath, string content);
        bool CreateFolderIfNeeded(string path);
        bool Exist(string fileUrl);

        string GetCalculatedFileSize(long rawFileSize);
        Dictionary<string, dynamic> GetFileMetadata(HttpPostedFile postedFile);
    }




}
