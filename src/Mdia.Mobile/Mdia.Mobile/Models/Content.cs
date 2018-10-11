using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Mobile.Models
{
    public class Content
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateUploaded { get; set; }
        public User Uploader { get; set; }
        public ContentType Type { get; set; }
        public decimal Price { get; set; }
        public User Approver { get; set; }
        public bool Approved { get; set; }
        public string URL { get; set; }
        public string Size { get; set; }
    }



}
