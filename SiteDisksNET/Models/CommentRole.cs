//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteDisksNET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CommentRole
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int RoleId { get; set; }
    
        public virtual Comment Comment { get; set; }
        public virtual Role Role { get; set; }
    }
}
