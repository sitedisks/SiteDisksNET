using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDisksNET.Models.ViewModels
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string IssueTitle { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
 
        public bool IsActive { get; set; }
    }
}