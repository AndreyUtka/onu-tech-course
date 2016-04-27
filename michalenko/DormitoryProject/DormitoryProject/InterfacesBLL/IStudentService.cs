using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.DomainObjects;

namespace DormitoryProject.InterfacesBLL
{
    public interface IStudentService:IService
    {
        StudentBLL findBySerial(string serial,string number);
        IEnumerable<StudentBLL> getStudents();//long offset, int count);
        
        bool createNewStudent(StudentBLL student);
        bool updateStudentData(StudentBLL updatedData);
        bool removeStudent(StudentBLL student);
        bool checkPassword(string userType, string serial, string number, string password);
    }
}
