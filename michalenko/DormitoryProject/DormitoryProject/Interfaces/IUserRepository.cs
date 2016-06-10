using DormitoryProject.DataAccessClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.Interfaces
{
    public interface IUserRepository<TicketType>:IDisposable where TicketType:TicketDAL
    {
        TicketType findBySerial(TicketType ticket);
        void removeBySerial(TicketType ticket);
        void addUser(TicketType user);
        void updateInfo(TicketType user);
        bool checkUser(string userType, string serial, string number, string password);
        void resettleStudent(StudentTicketDAL student);
        IEnumerable<StudentTicketDAL> getAllStudents();
        IEnumerable<WorkerTicketDAL> getAllWorkers();
        IEnumerable<TicketType> searchBy(TicketType person);
    }
}
