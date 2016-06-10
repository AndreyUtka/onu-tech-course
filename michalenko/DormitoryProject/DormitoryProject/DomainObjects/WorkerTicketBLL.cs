using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.DataAccessClasses;
namespace DormitoryProject.DomainObjects
{
    public class WorkerTicketBLL:TicketBLL
    {
        public string speciality { get; set; }
        public string phoneNumber { get; set; }
        public List<WorkDayDAL> workDays { get; set; }
    }
}
