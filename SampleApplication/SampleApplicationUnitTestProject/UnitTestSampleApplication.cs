using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApplicationServiceModel;
using SampleApplicationDataModel;
using SampleApplication;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SampleApplicationUnitTestProject
{
    [TestClass]
    public class SampleApplicationUnitTest
    {        
        [TestMethod]
        public void TestMethod_CheckPet()
        {
            SampleService obj = new SampleService();
            string data = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";

            List<animalModel> resultforMaleOwner = obj.GetPets(data, "Male");
            List<animalModel> animalsM = new List<animalModel>()
                    {
                        new animalModel {name = "Garfield", type = "Cat"},
                        new animalModel {name = "Jim", type = "Cat"},
                        new animalModel {name = "Max", type = "Cat"},
                        new animalModel {name = "Tom", type = "Cat"}
                    };
            Assert.AreEqual(animalsM.Count, resultforMaleOwner.Count);

            List<animalModel> resultforFemaleOwner = obj.GetPets(data, "Female");
            List<animalModel> animalsF = new List<animalModel>()
            {
                        new animalModel {name = "Garfield", type = "Cat"},
                        new animalModel {name = "Simba", type = "Cat"},
                        new animalModel {name = "Tabby", type = "Cat"}
            };
            Assert.AreEqual(animalsF.Count, resultforFemaleOwner.Count);
        }
    }
}
