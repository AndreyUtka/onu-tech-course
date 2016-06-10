using DormitoryProject.DataAccessClasses;
using DormitoryProject.DomainObjects;
using DormitoryProject.Interfaces;
using DormitoryProject.InterfacesBLL;
using DormitoryProject.PGServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.ServicesBLL
{
    public class UserService : IUserService<StudentTicketBLL>, IUserService<WorkerTicketBLL>
    {
        private readonly PGUserRepositoryFactory repositoryFactory;

        public UserService(PGUserRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public void addUser(StudentTicketBLL student)
        {
            StudentTicketDAL studDAL = new StudentTicketDAL()
            {
                lastName = student.lastName,
                name = student.name,
                patronimic = student.patronimic,
                number = student.number,
                serial = student.serial,
                facult = student.facult,
                kurs = student.kurs,
                group = student.group,
                speciality = student.speciality,
                roomNumber = student.roomNumber
            };
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                repository.addUser(studDAL);
            }
        }

        public void addUser(WorkerTicketBLL worker)
        {
            WorkerTicketDAL wDAL = new WorkerTicketDAL
            {
                lastName = worker.lastName,
                name = worker.name,
                patronimic = worker.patronimic,
                number = worker.number,
                serial = worker.serial,
                phoneNumber = worker.phoneNumber,
                spec = worker.speciality
            };
            if (worker.workDays != null)
            {
                wDAL.workDays = worker.workDays;
            }
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                repository.addUser(wDAL);
            }
        }

        public bool Authentication(string userType, string serial, string number, string password)
        {
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                return repository.checkUser(userType, serial, number, password);
            }
        }

        public void deleteUser(StudentTicketBLL student)
        {
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                StudentTicketDAL studentDAL = new StudentTicketDAL
                {
                    serial=student.serial,
                    number=student.number,
                    lastName=student.lastName,
                    name=student.name,
                    patronimic=student.patronimic,
                    kurs=student.kurs,
                    speciality=student.speciality,
                    facult=student.facult,
                    group=student.group,
                    roomNumber=student.roomNumber
                };
                repository.removeBySerial(studentDAL);
            }
        }

        public void deleteUser(WorkerTicketBLL worker)
        {
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                WorkerTicketDAL workerDAL = new WorkerTicketDAL
                {
                    serial = worker.serial,
                    number = worker.number,
                    lastName = worker.lastName,
                    name = worker.name,
                    patronimic = worker.patronimic,
                    phoneNumber = worker.phoneNumber,
                    spec = worker.speciality,
                    workDays = worker.workDays
                };
                repository.removeBySerial(workerDAL);
            }
        }

        public IEnumerable<StudentTicketBLL> getAllStudents()
        {
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                IEnumerable<StudentTicketDAL> list = (repository.getAllStudents() as List<StudentTicketDAL>);
                return list.Select(s => new StudentTicketBLL
                {
                    lastName = s.lastName,
                    name = s.name,
                    patronimic = s.patronimic,
                    number = s.number,
                    serial = s.serial,
                    kurs = s.kurs,
                    facult = s.facult,
                    group = s.group,
                    speciality = s.speciality,
                    roomNumber = s.roomNumber
                }).AsEnumerable();
            }
        }

        public IEnumerable<WorkerTicketBLL> getAllWorkers()
        {
            using(PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                IEnumerable<WorkerTicketDAL> list = (repository.getAllWorkers() as List<WorkerTicketDAL>);
                return list.Select(w => new WorkerTicketBLL
                {
                    lastName = w.lastName,
                    name = w.name,
                    patronimic = w.patronimic,
                    number = w.number,
                    serial = w.serial,
                    phoneNumber = w.phoneNumber,
                    speciality = w.spec,
                    workDays = w.workDays
                }).AsEnumerable();
            }
        }

        public void resettleStudent(StudentTicketBLL student)
        {

            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                StudentTicketDAL studentDAL = new StudentTicketDAL
                {
                    serial = student.serial,
                    number = student.number,
                    lastName = student.lastName,
                    name = student.name,
                    patronimic = student.patronimic,
                    kurs = student.kurs,
                    speciality = student.speciality,
                    facult = student.facult,
                    group = student.group,
                    roomNumber = student.roomNumber
                };
                repository.resettleStudent(studentDAL);
            }
        }

        public IEnumerable<StudentTicketBLL> searchBy(StudentTicketBLL student)
        {
            IEnumerable<StudentTicketDAL> listDal = new List<StudentTicketDAL>();
            StudentTicketDAL searchPattern = new StudentTicketDAL
            {
                lastName = student.lastName,
                name = student.name,
                patronimic = student.patronimic,
                number = student.number,
                serial = student.serial,
                facult = student.facult,
                kurs = student.kurs,
                group = student.group,
                speciality = student.speciality,
                roomNumber = student.roomNumber
            };
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                listDal = (repository.searchBy(searchPattern) as IEnumerable<StudentTicketDAL>);
            }
            return listDal.Select(s => new StudentTicketBLL
            {
                lastName = s.lastName,
                name = s.name,
                number = s.number,
                patronimic = s.patronimic,
                serial = s.serial,
                facult = s.facult,
                group = s.group,
                kurs = s.kurs,
                speciality = s.speciality,
                roomNumber = s.roomNumber
            }).AsEnumerable();
        }

        public IEnumerable<WorkerTicketBLL> searchBy(WorkerTicketBLL worker)
        {
            IEnumerable<WorkerTicketDAL> listDAL = new List<WorkerTicketDAL>();
            WorkerTicketDAL searchPattern = new WorkerTicketDAL
            {
                lastName = worker.lastName,
                name = worker.name,
                patronimic = worker.patronimic,
                number = worker.number,
                serial = worker.serial,
                phoneNumber = worker.phoneNumber,
                spec = worker.speciality,
                workDays = worker.workDays
            };
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                listDAL = (repository.searchBy(searchPattern) as IEnumerable<WorkerTicketDAL>);
            }
            return listDAL.Select(w => new WorkerTicketBLL
            {
                lastName = w.lastName,
                name = w.name,
                number = w.number,
                patronimic = w.patronimic,
                serial = w.serial,
                phoneNumber = w.phoneNumber,
                speciality = w.spec
            }).AsEnumerable();
        }

        public void updateData(StudentTicketBLL updatedStudent)
        {
            StudentTicketDAL sDal = new StudentTicketDAL
            {
                name = updatedStudent.name,
                lastName = updatedStudent.lastName,
                patronimic = updatedStudent.patronimic,
                number = updatedStudent.number,
                serial = updatedStudent.serial,
                kurs = updatedStudent.kurs,
                facult = updatedStudent.facult,
                group = updatedStudent.group,
                speciality = updatedStudent.speciality
            };
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                repository.updateInfo(sDal);
            }
        }

        public void updateData(WorkerTicketBLL updatedWorker)
        {
            WorkerTicketDAL wDal = new WorkerTicketDAL
            {
                name = updatedWorker.name,
                lastName = updatedWorker.lastName,
                patronimic = updatedWorker.patronimic,
                number = updatedWorker.number,
                serial = updatedWorker.serial,
                phoneNumber = updatedWorker.phoneNumber,
                spec = updatedWorker.speciality
            };
            using (PGUserRepository repository = repositoryFactory.getUserRepository())
            {
                repository.updateInfo(wDal);
            }
        }

    }
}
