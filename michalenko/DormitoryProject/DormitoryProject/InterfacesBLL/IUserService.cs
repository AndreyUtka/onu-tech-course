using DormitoryProject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.InterfacesBLL
{
    public interface IUserService<TicketType> where TicketType:TicketBLL
    {
        IEnumerable<TicketType> searchBy(TicketType search);
        IEnumerable<StudentTicketBLL> getAllStudents();
        IEnumerable<WorkerTicketBLL> getAllWorkers();
        void addUser(TicketType user);
        void updateData(TicketType user);
        void deleteUser(TicketType user);
        void resettleStudent(StudentTicketBLL student);
        bool Authentication(string userType, string serial, string number, string password);
    }
}
