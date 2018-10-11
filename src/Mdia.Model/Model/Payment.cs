using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Model.Model
{
    public class Payment
    {
        public Guid Id { get; set; }
        public PaymentMode Mode { get; set; }
        public PaymentChannel Channel { get; set; }
        public User User { get; set; }
        public long? SerialNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? DatePaid { get; set; }
        public bool Paid { get; set; }

    }



}