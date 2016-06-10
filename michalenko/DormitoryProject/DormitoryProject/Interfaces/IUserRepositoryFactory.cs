using DormitoryProject.PGServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.Interfaces
{
    public interface IUserRepositoryFactory
    {
        PGUserRepository getUserRepository();
    }
}
