using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.DomainObjects
{
    public class StudentTicketBLL:TicketBLL
    {
        public int kurs { get; set; }
        public string facult { get; set; }
        public string speciality { get; set; }
        public int group { get; set; }
        public int roomNumber { get; set; }
    }
}
