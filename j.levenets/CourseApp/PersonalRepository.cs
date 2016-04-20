using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace CourseApp
{
    public class PersonalRepository : BaseRepository
    {
        public PersonalRepository(string connectionString)
            : base(connectionString)
        {
        }

        public List<Personal> GetAll()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Personal");
            DataTable personalsDt = SqlCaller.GetTable(connectionString, command);

            List<Personal> result = new List<Personal>();
            foreach (DataRow dr in personalsDt.Rows)
            {
                result.Add(GetPersonal(dr));
            }

            return result;
        }

        public Personal GetById(int id)
        {
            string sql = "SELECT * FROM Personal WHERE id_per = @id_per";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_per", NpgsqlDbType.Integer);
            command.Parameters["@id_per"].Value = id;

            DataTable personalsDt = SqlCaller.GetTable(connectionString, command);

            return GetPersonal(personalsDt.Rows[0]);
        }

        private Personal GetPersonal(DataRow dataRow)
        {
            return new Personal
            {
                Id = (int)dataRow["id_per"],
                SecondName = (string)dataRow["SecondName"],
                FirstName = (string)dataRow["FirstName"],
                Patronymic = (string)dataRow["Patronymic"],
                Birthday = (DateTime)dataRow["Birthday"],
                Post = (string)dataRow["Post"],
                Salary = (int)dataRow["Salary"],
                TimeOfStart = (DateTime)dataRow["TimeOfStart"],
                TimeOfEnd = (DateTime)dataRow["TimeOfEnd"]
            };
        }
    }
}
