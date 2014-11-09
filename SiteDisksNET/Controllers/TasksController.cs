using SiteDisksNET.Models;
using SiteDisksNET.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SiteDisksNET.Controllers
{
    [EnableCors(origins: "http://www.sitedisks.com.au", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        private IRepository<Task> TaskRep;

        public TasksController()
        {
            var dbcontext = new lowataEntities();
            TaskRep = new Repository<Task>(dbcontext);
        }

        public TasksController(IRepository<Task> taskRep)
        {
            this.TaskRep = taskRep;
        }

        // GET: api/Tasks
        public IEnumerable<TaskModel> Get()
        {
            var allTasks = TaskRep.GetAll().Where(x => x.IsActive ?? true).Select(x => new TaskModel
            {
                Id = x.Id,
                TaskTitle = x.TaskTitle,
                CategoryId = x.CategoryId,
                Details = x.Details,
                Issues = x.Issues.Select(a => new IssueModel
                {
                    Id = a.Id,
                    IssueTitle = a.IssueTitle,
                    Description = a.Description,
                    IsActive = a.IsActive?? true
                }).ToList(),
                IsActive = x.IsActive ?? true,
                IsDone = x.IsDone ?? false
            });



            return allTasks;
        }

        // GET: api/Tasks/5
        public Task Get(int id)
        {
            Task task = TaskRep.Get(x => x.Id == id);
            if (task == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return task;
        }

        // POST: api/Tasks
        public HttpResponseMessage Post([FromBody]Task task)
        {
            if (ModelState.IsValid)
            {
                TaskRep.Add(task);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, task);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = task.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT: api/Tasks/5
        public HttpResponseMessage Put(int id, [FromBody]Task task)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != task.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                TaskRep.Update(task);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Tasks/5
        public HttpResponseMessage Delete(int id)
        {
            Task task = TaskRep.Get(c => c.Id == id);

            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }


            try
            {
                task.IsActive = false;
                TaskRep.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, task);
        }
        protected override void Dispose(bool disposing)
        {
            TaskRep.Dispose();
            base.Dispose(disposing);
        }
    }
}
