using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Model.Model
{
    public class Download
    {
        public Guid Id { get; set; }
        public Content Content { get; set; }
        public Payment Payment { get; set; }
        public DateTime Date { get; set; }

    }

   
}
