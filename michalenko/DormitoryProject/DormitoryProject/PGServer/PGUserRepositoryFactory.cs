using DormitoryProject.DataAccessClasses;
using DormitoryProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.PGServer
{
    public class PGUserRepositoryFactory:IUserRepositoryFactory
    {
        private readonly string role = string.Empty;
        public PGUserRepositoryFactory(string role)
        {
            if(role==null)
            {
                throw new ArgumentNullException(role);
            }
            this.role = role;
        }

        public PGUserRepository getUserRepository()
        {
            return new PGUserRepository(role);
        }
    }
}
