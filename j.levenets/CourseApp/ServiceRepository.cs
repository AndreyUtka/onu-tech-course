using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace CourseApp
{
    public class ServiceRepository : BaseRepository
    {
        public ServiceRepository(string connectionString)
            : base(connectionString)
        {
        }

        public List<Service> GetAll()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Service");
            DataTable servicesDt = SqlCaller.GetTable(connectionString, command);

            List<Service> result = new List<Service>();
            foreach (DataRow dr in servicesDt.Rows)
            {
                result.Add(GetService(dr));
            }

            return result;
        }

        public Service GetById(int id)
        {
            string sql = "SELECT * FROM Service WHERE id = @id";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id", NpgsqlDbType.Integer);
            command.Parameters["@id"].Value = id;

            DataTable servicesDt = SqlCaller.GetTable(connectionString, command);

            return GetService(servicesDt.Rows[0]);
        }

        //TODO: must return List<Service>
        public Service GetByClientId(int id)
        {
            //TODO: remove this line when method is finished
            throw new NotImplementedException();

            string sql = "SELECT * FROM Service WHERE id_cl = @id_cl";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_cl", NpgsqlDbType.Integer);
            command.Parameters["@id_cl"].Value = id;

            DataTable servicesDt = SqlCaller.GetTable(connectionString, command);

            return GetService(servicesDt.Rows[0]);
        }

        //TODO: must return List<Service>
        public Service GetByPlaceId(int id)
        {
            //TODO: remove this line when method is finished
            throw new NotImplementedException();

            string sql = "SELECT * FROM Service WHERE id_pl = @id_pl";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_pl", NpgsqlDbType.Integer);
            command.Parameters["@id_pl"].Value = id;

            DataTable servicesDt = SqlCaller.GetTable(connectionString, command);

            return GetService(servicesDt.Rows[0]);
        }

        //TODO: must return List<Service>
        public Service GetByPersonalId(int id)
        {
            //TODO: remove this line when method is finished
            throw new NotImplementedException();

            string sql = "SELECT * FROM Service WHERE id_per = @id_per";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_per", NpgsqlDbType.Integer);
            command.Parameters["@id_per"].Value = id;

            DataTable servicesDt = SqlCaller.GetTable(connectionString, command);

            return GetService(servicesDt.Rows[0]);
        }

        private Service GetService(DataRow dataRow)
        {
            return new Service
            {
                Id = (int)dataRow["id"],
                ClientId = (int)dataRow["id_cl"],
                PlaceId = (int)dataRow["id_pl"],
                PersonalId = (int)dataRow["id_per"],
                Rate = (int)dataRow["Rate"],
                Result = (bool)dataRow["Result"],
                TimeOfStart = (string)dataRow["TimeOfStart"],
                TimeOfEnd = (string)dataRow["TimeOfEnd"]
            };
        }
    }
}
