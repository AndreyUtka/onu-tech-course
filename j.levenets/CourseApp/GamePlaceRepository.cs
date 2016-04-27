using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace CourseApp
{
    class GamePlaceRepository : BaseRepository
    {
        public GamePlaceRepository(string connectionString)
            : base(connectionString)
        {
        }

        public List<GamePlace> GetAll()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM GamePlace");
            DataTable gameplacesDt = SqlCaller.GetTable(connectionString, command);

            List<GamePlace> result = new List<GamePlace>();
            foreach (DataRow dr in gameplacesDt.Rows)
            {
                result.Add(GetGamePlace(dr));
            }

            return result;
        }

        public GamePlace GetById(int id)
        {
            string sql = "SELECT * FROM GamePlace WHERE id_pl = @id_pl";
            NpgsqlCommand command = new NpgsqlCommand(sql);
            command.Parameters.Add("@id_pl", NpgsqlDbType.Integer);
            command.Parameters["@id_pl"].Value = id;

            DataTable gameplacesDt = SqlCaller.GetTable(connectionString, command);

            return GetGamePlace(gameplacesDt.Rows[0]);
        }

        private static GamePlace GetGamePlace(DataRow dataRow)
        {
            return new GamePlace
            {
                Id = (int)dataRow["id_pl"],
                Name = (string)dataRow["Name"],
                Type = (string)dataRow["Type"],
                Capacity = (int)dataRow["Capacity"]
            };
        }
    }
}
