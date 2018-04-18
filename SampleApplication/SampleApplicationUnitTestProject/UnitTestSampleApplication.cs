using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApplicationDataModel;
using SampleApplicationServiceModel;

namespace SampleApplicationUnitTestProject
{
    [TestClass]
    public class SampleApplicationUnitTest
    {
        SampleService obj = new SampleService();
        
        [TestMethod]
        public void TestGetPet()
        {            
            ViewModel objResult = obj.GetPets();
            List<AnimalModel> animalsM = new List<AnimalModel>()
                    {
                        new AnimalModel {Name = "Garfield", Type = "Cat"},
                        new AnimalModel {Name = "Jim", Type = "Cat"},
                        new AnimalModel {Name = "Max", Type = "Cat"},
                        new AnimalModel {Name = "Tom", Type = "Cat"}
                    };
            List<AnimalModel> animalsF = new List<AnimalModel>()
            {
                        new AnimalModel {Name = "Garfield", Type = "Cat"},
                        new AnimalModel {Name = "Simba", Type = "Cat"},
                        new AnimalModel {Name = "Tabby", Type = "Cat"}
            };
            Assert.AreEqual(animalsM.Count, objResult.ListMale.Count);
            Assert.AreEqual(animalsM[2].Name.ToString(), objResult.ListMale[2].Name.ToString());

            Assert.AreEqual(animalsF.Count, objResult.ListFemale.Count);
            Assert.AreEqual(animalsF[1].Name.ToString(), objResult.ListFemale[1].Name.ToString());
        }

    }
}
