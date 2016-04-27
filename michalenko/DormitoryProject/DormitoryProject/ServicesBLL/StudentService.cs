using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.DomainObjects;
using DormitoryProject.Interfaces;
using DormitoryProject.InterfacesBLL;

namespace DormitoryProject.ServicesBLL
{
    public class StudentService:IStudentService
    {
        private readonly IRepositoryFactory repositoryFactory;
        public StudentService(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public bool createNewStudent(StudentBLL student)
        {
            StudentDAL sDal = new StudentDAL()
            {
                uLastName = student.uLastName,
                uName = student.uName,
                uPatr = student.uPatr,
                uNumber = student.uNumber,
                uSerial = student.uSerial,
                sFacult = student.sFacult,
                sKurs = student.sKurs,
                sGroup = student.sGroup,
                sSpec = student.sSpec,
                room = student.room
            };
            using (IRepository repository = repositoryFactory.getRepository())
            {
                return repository.addUser(sDal);
            }
        }

        public StudentBLL findBySerial(string serial,string number)
        {
            #region Проверки
            if(serial.Length>2)
            {
                throw new ArgumentException("Длина превышает допустимое значение" + serial + " неверно");
            }
            else if(serial==null)
            {
                throw new ArgumentNullException("Значение серийного номера не введено");
            }
            else if((serial[0]<'А' || serial[0]>'Я') || (serial[1]<'А' || serial[1]>'Я'))
            {
                throw new ArgumentException("Введено недопустимое значение серийного номера");
            }
            if (number.Contains("[[aA-Zz]]"))
            {
                throw new ArgumentException("Номер должен содержать только цифры");
            }
            #endregion
            using (IRepository repository = repositoryFactory.getRepository())
            {
                StudentDAL stdDAL=(repository.findBySerial(serial, number) as StudentDAL);
                return new StudentBLL
                {
                    uName = stdDAL.uName,
                    uLastName = stdDAL.uLastName,
                    uPatr = stdDAL.uPatr,
                    uNumber = stdDAL.uNumber,
                    uSerial = stdDAL.uSerial,
                    sKurs = stdDAL.sKurs,
                    sFacult = stdDAL.sFacult,
                    sGroup = stdDAL.sGroup,
                    sSpec = stdDAL.sSpec,
                    room = stdDAL.room
                };
            }

        }

        public IEnumerable<Object> searchBy(Object search)
        {
            StudentBLL student = (search as StudentBLL);
            IEnumerable<StudentDAL> lDal = new List<StudentDAL>();
            StudentDAL searchPattern = new StudentDAL
            {
                uLastName = student.uLastName,
                uName = student.uName,
                uPatr = student.uPatr,
                uNumber = student.uNumber,
                uSerial = student.uSerial,
                sFacult = student.sFacult,
                sKurs = student.sKurs,
                sGroup = student.sGroup,
                sSpec = student.sSpec,
                room=student.room
            };
            using (IRepository repository = repositoryFactory.getRepository())
            {
                lDal=(repository.searchBy(searchPattern) as IEnumerable<StudentDAL>);
            }
            return lDal.Select(s => new StudentBLL
            {
                uLastName=s.uLastName,
                uName=s.uName,
                uNumber=s.uNumber,
                uPatr=s.uPatr,
                uSerial=s.uSerial,
                sFacult=s.sFacult,
                sGroup=s.sGroup,
                sKurs=s.sKurs,
                sSpec=s.sSpec,
                room=s.room
            }).AsEnumerable();
        }

        public IEnumerable<StudentBLL> getStudents()//long offset, int count)
        {
            using (IRepository repository = repositoryFactory.getRepository())
            {
                IEnumerable<StudentDAL> list = (repository.getAll() as List<StudentDAL>);
                return list.Select(s => new StudentBLL
                {
                    uLastName=s.uLastName,
                    uName=s.uName,
                    uPatr=s.uPatr,
                    uNumber=s.uNumber,
                    uSerial=s.uSerial,
                    sKurs=s.sKurs,
                    sFacult=s.sFacult,
                    sGroup=s.sGroup,
                    sSpec=s.sSpec,
                    room=s.room
                }).AsEnumerable();
            }
        }

        public bool removeStudent(StudentBLL student)
        {
            #region Проверки
            if(student==null)
            {
                throw new ArgumentNullException("Недопустимое значение аргумента");
            }
            else if((student.uSerial==null)||(student.uNumber==null))
            {
                throw new ArgumentNullException("Поле серийного номера не может быть пустым");
            }
            #endregion
            using (IRepository repository = repositoryFactory.getRepository())
            {
                return repository.removeBySerial(student.uSerial, student.uNumber);
            }
               
        }

        public bool updateStudentData(StudentBLL updatedData)
        { 
            StudentDAL sDal = new StudentDAL
            {
                uName = updatedData.uName,
                uLastName = updatedData.uLastName,
                uPatr = updatedData.uPatr,
                uNumber = updatedData.uNumber,
                uSerial = updatedData.uSerial,
                sKurs = updatedData.sKurs,
                sFacult = updatedData.sFacult,
                sGroup = updatedData.sGroup,
                sSpec = updatedData.sSpec
            };
            using (IRepository repository = repositoryFactory.getRepository())
            {
                return repository.updateInfo(sDal);
            }
        }
        public bool checkPassword(string userType, string serial, string number, string password)
        { 
            using (IRepository repository = repositoryFactory.getRepository())
            {
                return repository.checkUser(userType, serial, number, password);
            }
            
        }
    }
}
