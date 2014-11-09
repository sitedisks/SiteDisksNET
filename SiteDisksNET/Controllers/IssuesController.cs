using SiteDisksNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiteDisksNET.Controllers
{
    public class IssuesController : ApiController
    {
        private IRepository<Task> TaskRep;
    }
}
