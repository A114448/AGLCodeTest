using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SampleApplicationDataModel
{
    
    public class ViewModel
    {
        
        public List<animalModel> ListMale { get; set; }
        public List<animalModel> ListFemale { get; set; }
        
    }
}
