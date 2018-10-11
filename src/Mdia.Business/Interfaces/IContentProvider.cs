using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Model.Model;
using System.Web;

namespace Mdia.Business.Interfaces
{
    public interface IContentProvider
    {
        Task<Content> AddAsync(Content content, HttpFileCollection files);
    }



}
