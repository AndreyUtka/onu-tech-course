using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.Interfaces;

namespace DormitoryProject.PGServer
{
    public class PGStudentRepositoryFactory:IRepositoryFactory
    {
        private readonly string connectionString;

        public PGStudentRepositoryFactory(string connection)
        {
            if(connection==null)
            {
                throw new ArgumentNullException(connection);
            }
            connectionString = connection;
        }

        public IRepository getRepository()
        {
            return new PGStudentRepository(connectionString);
        }
    }
}
