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
    
    public partial class Task
    {
        public Task()
        {
            this.Issues = new HashSet<Issue>();
        }
    
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
