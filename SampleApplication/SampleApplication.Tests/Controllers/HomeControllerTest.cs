using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApplication;
using SampleApplication.Controllers;
using Moq;
using Moq.Matchers;
using SampleApplicationServiceModel;

namespace SampleApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        //}

        public void Index()
        {
            
            var mockService = new Moq.Mock<ISampleService>();

            
            //mockService.SetupProperty(client => client., "chat.mail.com").SetupProperty(client => client.Port, "1212");


            mockService.Setup(client => client.fetchPets(It.IsAny<string>()));
                //.Returns();

            ISampleService sampleService = new SampleService() {};

            ////Use the mock object of MailClient instead of actual object
            //var result = sampleService.fetchPets(string s);

            ////Verify that it return true
           // Assert.IsTrue(result);

            ////Verify that the MailClient's SendMail methods gets called exactly once when string is passed as parameters
            mockService.Verify(client => client.fetchPets(It.IsAny<string>()), Times.Once);
        }

   
    }
}
