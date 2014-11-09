using SiteDisksNET.Models;
using SiteDisksNET.Models.ViewModels;
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
        private IRepository<Issue> IssueRep;

        public IssuesController() {
            var dbcontext = new lowataEntities();
            IssueRep = new Repository<Issue>(dbcontext);
        }

        public IssuesController(IRepository<Issue> issueRep)
        {
            this.IssueRep = issueRep;
        }

        public HttpResponseMessage Post([FromBody]IssueModel issue)
        {
            if (ModelState.IsValid)
            {
                Issue theIssue = new Issue();
                if(issue.Id == 0){
                    // new issue
                    theIssue = new Issue
                    {
                        IssueTitle = issue.IssueTitle,
                        Description = issue.Description,
                        TaskId = issue.TaskId,
                        IsActive = true,
                        CreatedDate = DateTime.Now
                    };
                    IssueRep.Add(theIssue);
                }
                else{
                    // update issue
                    theIssue = IssueRep.Get(x => x.Id == issue.Id);
                    theIssue.IssueTitle = issue.IssueTitle;
                    theIssue.Description = issue.Description;
                    theIssue.UpdatedDate = DateTime.Now;

                    IssueRep.Update(theIssue);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, theIssue);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = theIssue.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
