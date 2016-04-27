using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.InterfacesBLL;
using DormitoryProject.Interfaces;
using DormitoryProject.ServicesBLL;
namespace DormitoryProject
{
    class StudentServiceFactory : IServiceFactory
    {
        private readonly IRepositoryFactory repositoryFactory;
        public StudentServiceFactory(IRepositoryFactory repositoryFactory)
        {
            if(repositoryFactory==null)
            {
                throw new ArgumentNullException("repositoryFactory");
            }
            this.repositoryFactory = repositoryFactory;
        }
        public IRoomService getRoomService()
        {
            throw new NotImplementedException();
        }

        public IStudentService getStudentService()
        {
            return new StudentService(repositoryFactory);
        }
    }
}
