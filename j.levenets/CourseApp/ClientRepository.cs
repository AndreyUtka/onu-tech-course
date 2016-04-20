using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace CourseApp
{
    
    public class ClientRepository : BaseRepository
    {
        public ClientRepository(string connectionString)
            : base(connectionString)
        {
        }

        public List<Client> GetAll()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Client");
            DataTable clientsDt = SqlCaller.GetTable(connectionString, command);

            List<Client> result = new List<Client>();
            foreach (DataRow dr in clientsDt.Rows)
            {
                result.Add(GetClient(dr));
            }

            return result;
        }

        public Client GetById(int id)
        {
            string sql = "SELECT * FROM Client WHERE id_cl = @id_cl";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_cl", NpgsqlDbType.Integer);
            command.Parameters["@id_cl"].Value = id;

            DataTable clientsDt = SqlCaller.GetTable(connectionString, command);

            return GetClient(clientsDt.Rows[0]);
        }

        private Client GetClient(DataRow dataRow)
        {
            return new Client
            {
                Id = (int)dataRow["id_cl"],
                SecondName = (string)dataRow["SecondName"],
                FirstName = (string)dataRow["FirstName"],
                Patronymic = (string)dataRow["Patronymic"],
                Birthday = (DateTime)dataRow["Birthday"],
                GNum = (int)dataRow["GNum"]
            };
        }

    }

}