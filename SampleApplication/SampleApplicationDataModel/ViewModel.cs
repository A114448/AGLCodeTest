﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SampleApplicationDataModel
{
    
    public class ViewModel
    {
        
        public List<animal> ListMale { get; set; }
        public List<animal> ListFemale { get; set; }
        
    }
}
