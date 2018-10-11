using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Model.Model
{
    public class Content
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ContentType Type { get; set; }
        public DateTime DateUploaded { get; set; }
        public User Uploader { get; set; }
        public User Approver { get; set; }
        public bool Approved { get; set; }
        public decimal Cost { get; set; }
        public string URL { get; set; }
        public string Size { get; set; }

    }




}
