using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteDisksNET.Models;
using SiteDisksNET.Controllers;
using Moq;
using System.Collections.Generic;

namespace SiteDisksNET.Test
{
    [TestClass]
    public class UnitTest1
    {   // kakimotonline.com/2011/02/13/tdd-in-asp-net-mvc-applications-with-moq-framework/
        
        [TestMethod]
        public void TestWebAPI()
        {
            Mock<IRepository<Contact>> _contactRepository = new Mock<IRepository<Contact>>();
            var contacts = new List<Contact>();
            contacts.Add(new Contact() { Id = 1, Name = "alpha", Email = "alpha@test.com", Subject = "Alpha Test", Message = "Alpha Message" });
            contacts.Add(new Contact() { Id = 2, Name = "beta", Email = "beta@test.com", Subject = "Beta Test", Message = "Beta Message" });
            contacts.Add(new Contact() { Id = 3, Name = "omega", Email = "omega@test.com", Subject = "Omega Test", Message = "Omega Message" });
            _contactRepository.Setup(x => x.GetAll()).Returns(contacts);

            var theController = new ContactsController(_contactRepository.Object);

            var result = theController.GetContacts() as List<Contact>;
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("beta", result[1].Name);
            
        }
    }
}
