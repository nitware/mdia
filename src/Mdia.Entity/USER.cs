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
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.CONTENT = new HashSet<CONTENT>();
            this.CONTENT1 = new HashSet<CONTENT>();
            this.PAYMENT = new HashSet<PAYMENT>();
        }
    
        public System.Guid User_Id { get; set; }
        public string First_Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Password_Salt { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int Role_Id { get; set; }
        public bool Is_Locked { get; set; }
        public System.DateTime Date_Created { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTENT> CONTENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTENT> CONTENT1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT> PAYMENT { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
