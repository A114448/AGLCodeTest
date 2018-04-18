using System.Collections.Generic;

namespace SampleApplicationDataModel
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public List<AnimalModel> Pets { get; set; }
    }
}
