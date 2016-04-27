using System.Data;
using Npgsql;


namespace CourseApp
{
    public static class SqlCaller
    {
        public static DataTable GetTable(string connectionString, NpgsqlCommand command)
        {
            using (NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter())
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            {
                command.Connection = sqlConnection;
                sqlConnection.Open();

                sqlDataAdapter.SelectCommand = command;

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                sqlConnection.Close();

                return dataSet.Tables[0];
            }
        }
    }
}