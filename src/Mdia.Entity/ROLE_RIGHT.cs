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
    
    public partial class ROLE_RIGHT
    {
        public int Role_Id { get; set; }
        public int Right_Id { get; set; }
        public string Description { get; set; }
    
        public virtual RIGHT RIGHT { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
