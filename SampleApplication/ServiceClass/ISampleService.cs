using System;
using System.Collections.Generic;
namespace SampleApplicationServiceModel
{
    public interface ISampleService
    {
        List<SampleApplicationDataModel.animal> fetchPets(string gender);
    }
}
