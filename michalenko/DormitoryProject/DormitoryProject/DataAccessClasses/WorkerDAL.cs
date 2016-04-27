using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.DataAccessClasses
{
    public class WorkerDAL:PersonDAL
    {
        public string wSpec { get; set; }
        public string wPhone { get; set; }
    }
}
