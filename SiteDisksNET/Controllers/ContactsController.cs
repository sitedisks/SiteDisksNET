using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SiteDisksNET.Models;
using System.Web.Http.Cors;

namespace SiteDisksNET.Controllers
{
    [EnableCors(origins:"http://www.sitedisks.com.au", headers: "*", methods:"*")]
    public class ContactsController : ApiController
    {
        private IRepository<Contact> ContactRep;
        public ContactsController()
        {
            var dbcontext = new lowataEntities();
            ContactRep = new Repository<Contact>(dbcontext);
            
        }

        public ContactsController(IRepository<Contact> contactRep)
        {
            this.ContactRep = contactRep;
        }

        // GET api/Contacts - GetAll()
        public IEnumerable<Contact> GetContacts()
        {
            return ContactRep.GetAll();
        }

        // GET api/Contacts/5 - Get()
        public Contact GetContact(int id)
        {
            Contact contact = ContactRep.Get(x => x.Id == id);
            if (contact == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return contact;
        }

        // PUT api/Contacts/5 -- Update()
        public HttpResponseMessage PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != contact.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                ContactRep.Update(contact);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Contacts - Add()
        public HttpResponseMessage PostContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ContactRep.Add(contact);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contact);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contact.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Contacts/5 - Delete()
        public HttpResponseMessage DeleteContact(int id)
        {
            Contact contact = ContactRep.Get(c => c.Id == id);
            if (contact == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }


            try
            {
                ContactRep.Delete(contact);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contact);
        }

        protected override void Dispose(bool disposing)
        {
            ContactRep.Dispose();
            base.Dispose(disposing);
        }
    }
}