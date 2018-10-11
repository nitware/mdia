//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdia.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAYMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYMENT()
        {
            this.DOWNLOAD = new HashSet<DOWNLOAD>();
        }
    
        public System.Guid Payment_Id { get; set; }
        public int Payment_Mode_Id { get; set; }
        public int Payment_Channel_Id { get; set; }
        public System.Guid User_Id { get; set; }
        public Nullable<long> Serial_Number { get; set; }
        public string Invoice_Number { get; set; }
        public bool Paid { get; set; }
        public Nullable<System.DateTime> Date_Paid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOWNLOAD> DOWNLOAD { get; set; }
        public virtual PAYMENT_INTERSWITCH PAYMENT_INTERSWITCH { get; set; }
        public virtual PAYMENT_CHANNEL PAYMENT_CHANNEL { get; set; }
        public virtual PAYMENT_MODE PAYMENT_MODE { get; set; }
        public virtual USER USER { get; set; }
    }
}