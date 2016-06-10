using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.DomainObjects
{
    public abstract class TicketBLL
    {
        public string serial { get; set; }
        public string number { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string patronimic { get; set; }
    }
}
