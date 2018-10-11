using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Business.Interfaces;
using Mdia.Model.Model;
using System.Web;
using Mdia.Utility.Interfaces;
using System.Transactions;

namespace Mdia.Business
{
    public class ContentProvider : IContentProvider
    {
        private readonly IRepository _da;
        private readonly IFileManager _fileManager;

        public ContentProvider(IRepository da, IFileManager fileManager)
        {
            if (da == null)
            {
                throw new ArgumentNullException("da");
            }
            if (fileManager == null)
            {
                throw new ArgumentNullException("fileManager");
            }

            _da = da;
            _fileManager = fileManager;
        }

        public async Task<Content> AddAsync(Content content, HttpFileCollection files)
        {
            try
            {
                Dictionary<string, dynamic> postedFileMetadata = _fileManager.GetFileMetadata(files[0]);
                if (postedFileMetadata == null)
                {
                    throw new Exception("Posted file is empty! Please re-upload");
                }

                Guid id = Guid.NewGuid();
                DateTime dateUploaded = DateTime.Now;
                string fileName = id + "__" + dateUploaded.ToString("yyyyMMddHHmmss") + postedFileMetadata["fileExtension"];
                string folderPath = _fileManager.RootFolderPath + "/" + fileName;

                content.Id = id;
                content.URL = folderPath;
                content.Size = _fileManager.GetCalculatedFileSize(postedFileMetadata["fileSize"]);
                content.Type = GetContentTypeBy(postedFileMetadata["fileExtension"]);
                content.DateUploaded = dateUploaded;
                content.Approved = false;

                using (TransactionScope transaction = new TransactionScope())
                {
                    Content newContent = await _da.CreateAsync<Content>(content);
                    if (newContent == null)
                    {
                        throw new Exception("Content Add operation failed! Please try again.");
                    }

                    Dictionary<string, dynamic> uploadedFileResponse = _fileManager.Upload(files, fileName);
                    if (uploadedFileResponse == null || uploadedFileResponse["isUploaded"] == false)
                    {
                        throw new Exception(string.Format("File upload failed with {0}! Please try again.", uploadedFileResponse["message"]));
                    }

                    transaction.Complete();
                }

                return content;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private ContentType GetContentTypeBy(string fileExtension)
        {
            try
            {
                ContentType contentType = null;
                switch(fileExtension.ToLower())
                {
                    case ".pdf":
                        {
                            contentType = new ContentType() { Id = 1 };
                            break;
                        }
                    case ".mp3":
                        {
                            contentType = new ContentType() { Id = 2 };
                            break;
                        }
                    case ".mp4":
                        {
                            contentType = new ContentType() { Id = 3 };
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException(string.Format("File type {0} not supported!", fileExtension));
                        }
                }

                return contentType;
            }
            catch(Exception)
            {
                throw;
            }
        }



    }


}
