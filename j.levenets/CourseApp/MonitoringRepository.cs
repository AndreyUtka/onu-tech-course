using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace CourseApp
{
    public class MonitoringRepository : BaseRepository
    {
        public MonitoringRepository(string connectionString)
            : base(connectionString)
        {
        }

        public List<Monitoring> GetAll()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Monitoring");
            DataTable monitoringsDt = SqlCaller.GetTable(connectionString, command);

            List<Monitoring> result = new List<Monitoring>();
            foreach (DataRow dr in monitoringsDt.Rows)
            {
                result.Add(GetMonitoring(dr));
            }

            return result;
        }

        public Monitoring GetById(int id)
        {
            string sql = "SELECT * FROM Monitoring WHERE id = @id";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id", NpgsqlDbType.Integer);
            command.Parameters["@id"].Value = id;

            DataTable monitoringsDt = SqlCaller.GetTable(connectionString, command);

            return GetMonitoring(monitoringsDt.Rows[0]);
        }

        //TODO: must return List<Monitoring>
        public Monitoring GetByClientId(int id)
        {
            //TODO: remove this line when method is finished
            throw new NotImplementedException();

            string sql = "SELECT * FROM Monitoring WHERE id_cl = @id_cl";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_cl", NpgsqlDbType.Integer);
            command.Parameters["@id_cl"].Value = id;

            DataTable monitoringsDt = SqlCaller.GetTable(connectionString, command);

            return GetMonitoring(monitoringsDt.Rows[0]);
        }

        //TODO: must return List<Monitoring>
        public Monitoring GetByTimeId(int id)
        {
            //TODO: remove this line when method is finished
            throw new NotImplementedException();

            string sql = "SELECT * FROM Monitoring WHERE id_time = @id_time";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_time", NpgsqlDbType.Integer);
            command.Parameters["@id_time"].Value = id;

            DataTable monitoringsDt = SqlCaller.GetTable(connectionString, command);

            return GetMonitoring(monitoringsDt.Rows[0]);
        }

        private Monitoring GetMonitoring(DataRow dataRow)
        {
            return new Monitoring
            {
                Id = (int)dataRow["id"],
                ClientId = (int)dataRow["id_cl"],
                TimeId = (int)dataRow["id_time"],
                //TODO: verify this conversion
                Value = (int[][])dataRow["Value"],
                MNum = (int)dataRow["MNum"]
            };
        }
    }
}
