using DormitoryProject.InterfacesBLL;
using DormitoryProject.PGServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.ServicesBLL
{
    public class UserServiceFactory : IServiceFactory
    {
        private readonly PGUserRepositoryFactory repositoryFactory;
        public UserServiceFactory(PGUserRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
        public IRoomService getRoomService()
        {
            throw new NotImplementedException();
        }

        public UserService getUserService()
        {
            return new UserService(repositoryFactory);
        }
    }
}
