using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.Interfaces;

namespace DormitoryProject.PGServer
{
    public class PGRoomRepositoryFactory:IRoomRepositoryFactory
    {
        private readonly string connectionString;

        public PGRoomRepositoryFactory(string connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(connection);
            }
            connectionString = connection;
        }
        public IRoomRepository getRoomRepository()
        {
            return new PGRoomRepository(connectionString);
        }
    }
}
