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
    
    public partial class PAYMENT_CHANNEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYMENT_CHANNEL()
        {
            this.PAYMENT = new HashSet<PAYMENT>();
        }
    
        public int Payment_Channel_Id { get; set; }
        public string Payment_Channel_Name { get; set; }
        public string Payment_Channel_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT> PAYMENT { get; set; }
    }
}
