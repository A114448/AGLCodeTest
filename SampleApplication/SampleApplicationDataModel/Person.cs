﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplicationDataModel
{
    public class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public List<animal> pets {get; set;}
    }
}
