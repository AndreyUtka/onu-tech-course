﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject
{
    public abstract class PersonDAL
    {
        public string uSerial { get; set; }
        public string uNumber { get; set; }
        public string uLastName { get; set; }
        public string uName { get; set; }
        public string uPatr { get; set; }
    }
}