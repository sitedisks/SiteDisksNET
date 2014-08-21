using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteDisksNET;
using SiteDisksNET.Controllers;

namespace SiteDisksNET.Tests.Controllers
{
    // NUnit & Moq
    // http://stackoverflow.com/questions/6646244/mvc-3-how-to-learn-how-to-test-with-nunit-ninject-and-moq
    // A testable application is an application that is loosely coupled enough to allow its independent parts to be tested in isolation. 
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Services()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Services() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
