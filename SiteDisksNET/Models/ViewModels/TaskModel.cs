using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDisksNET.Models.ViewModels
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public ICollection<IssueModel> Issues { get; set; }
        public bool IsActive { get; set; }
        public bool IsDone { get; set; }
    }
}