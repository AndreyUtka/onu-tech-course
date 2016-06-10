using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.DataAccessClasses
{
    public class WorkerTicketDAL:TicketDAL
    {
        public string spec { get; set; }
        public string phoneNumber { get; set; }
        public List<WorkDayDAL> workDays { get; set; }
    }
}
