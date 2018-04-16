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
using SampleApplicationDataModel;
using System.Configuration;

namespace SampleApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //Another Unit test method is written in SampleApplicationUnitTest.cs 
        [TestMethod]
        public void IndexTestMaleOwnerPet()
        {

            var mockService = new Mock<ISampleService>();

            List<animalModel> animalsM = new List<animalModel>()
                    {
                        new animalModel {name = "Garfield", type = "Cat"},
                        new animalModel {name = "Jim", type = "Cat"},
                        new animalModel {name = "Max", type = "Cat"},
                        new animalModel {name = "Tom", type = "Cat"}
                    };

            string genderMale = "Male";

            mockService.Setup(x => x.fetchPets(genderMale)).Returns(new List<animalModel>());

            HomeController controller = new HomeController(mockService.Object);

            var result = (controller.Index() as ViewResult).Model;

            Assert.IsNotNull(result);
            
         }
    }
}
