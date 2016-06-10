using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject
{
    public class StudentTicketDAL:TicketDAL
    {
        public int kurs { get; set; }
        public string facult { get; set; }
        public string speciality { get; set; }
        public int group { get; set; }
        public int roomNumber { get; set; }
    }
}
