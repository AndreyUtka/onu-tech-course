using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.DomainObjects
{
    public class StudentBLL:PersonBLL
    {
        public int sKurs { get; set; }
        public string sFacult { get; set; }
        public string sSpec { get; set; }
        public int sGroup { get; set; }
        public int room { get; set; }
    }
}
