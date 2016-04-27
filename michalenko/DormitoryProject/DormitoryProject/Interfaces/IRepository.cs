using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.Interfaces
{
    public interface IRepository:IDisposable
    {
        Object findBySerial(string seria, string number);
        bool removeBySerial(string seria, string number);
        bool addUser(Object person);
        bool updateInfo(Object person);
        bool checkUser(string userType, string serial, string number, string password);
        
        IEnumerable<Object> getAll();
        IEnumerable<Object> searchBy(Object person);
    }
}
