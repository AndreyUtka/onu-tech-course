using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace CourseApp
{
    public class CashboxRepository : BaseRepository
    {
        public CashboxRepository(string connectionString)
            : base(connectionString)
        {
        }

        public List<Cashbox> GetAll()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Cashbox");
            DataTable cashboxesDt = SqlCaller.GetTable(connectionString, command);

            List<Cashbox> result = new List<Cashbox>();
            foreach (DataRow dr in cashboxesDt.Rows)
            {
                result.Add(GetCashBox(dr));
            }

            return result;
        }

        public Cashbox GetById(int id)
        {
            string sql = "SELECT * FROM Cashbox WHERE id_time = @id_time";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_time", NpgsqlDbType.Integer);
            command.Parameters["@id_time"].Value = id;

            DataTable cashboxesDt = SqlCaller.GetTable(connectionString, command);

            return GetCashBox(cashboxesDt.Rows[0]);
        }

        private Cashbox GetCashBox(DataRow dataRow)
        {
            return new Cashbox
            {
                TimeId = (int)dataRow["id_time"],
                //TODO: verify this conversion
                Value = (int[][])dataRow["Value"],
                MNum = (int)dataRow["MNum"]
            };
        }
    }
}
