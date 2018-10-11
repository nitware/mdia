using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using Mdia.Business.Interfaces;
using Mdia.Utility.Interfaces;
using Mdia.Model.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mdia.WebAPI.Controllers
{
    public class ContentsController : ApiController
    {
        private readonly IRepository _da;
        private readonly IContentProvider _contentProvider;

        public ContentsController(IRepository da, IContentProvider contentProvider)
        {
            if (da == null)
            {
                throw new ArgumentNullException("da");
            }
            if (contentProvider == null)
            {
                throw new ArgumentNullException("contentProvider");
            }

            _da = da;
            _contentProvider = contentProvider;
        }

        //public HttpResponseMessage Post(MultipartDataMediaFormatter.Infrastructure.FormData formData)
        //{
        //    HttpResponseMessage response = null;

        //    try
        //    {
        //        string jsonContent = formData.Fields[0].Value;
        //        Content content = JsonConvert.DeserializeObject<Content>(jsonContent);
        //        //Content addedContent = await _contentProvider.AddAsync(content, HttpContext.Current.Request.Files);

        //        response = Request.CreateResponse(HttpStatusCode.OK, "addedContent");
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
        //    }

        //    return response;
        //}

        public async Task<HttpResponseMessage> Post(MultipartDataMediaFormatter.Infrastructure.FormData formData)
        {
            HttpResponseMessage response = null;

            try
            {
                string jsonContent = formData.Fields[0].Value;
                Content content = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Content>(jsonContent));
                Content addedContent = await _contentProvider.AddAsync(content, HttpContext.Current.Request.Files);

                response = Request.CreateResponse(HttpStatusCode.OK, addedContent);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }

            return response;
        }



        //public HttpResponseMessage Post()
        //{
        //    HttpResponseMessage response = null;

        //    try
        //    {
        //        HttpRequest httpRequest = HttpContext.Current.Request;
        //        Dictionary<string, dynamic> fileUploadResponse = _fileManager.Upload(httpRequest.Files, "testing-upload.mp3");
        //        //Dictionary<string, dynamic> fileUploadResponse = _fileManager.Upload(httpRequest.Files, Guid.NewGuid());

        //        response = Request.CreateResponse(HttpStatusCode.OK, fileUploadResponse);
        //    }
        //    catch(Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.Forbidden, ex);
        //    }

        //    return response;
        //}






    }
}
