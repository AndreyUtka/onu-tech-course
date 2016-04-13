using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Configuration;

namespace LibraryDAL
{
    public class InfoAll
    {
        public static DALBooksFromInfoAll[] GetInfo()
        {
            // NpgsqlConnection dbconn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["HomeLibrary"].ConnectionString);
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com; // = new NpgsqlCommand("SELECT * FROM booksinlibrarycolumns", dbconn);
            NpgsqlDataReader reader;
            // reader = com.ExecuteReader();
            //DataTable dtAll = new DataTable();
            //while (reader.Read())
            //{
            //    dtAll.Columns.Add(reader.GetString(0));
            //}
            //reader.Close();

            //            string first = reader.GetString(0);
            com = new NpgsqlCommand("SELECT Count(*) FROM booksinlibrary", dbconn);
            int iteratormax = Convert.ToInt32(com.ExecuteScalar());
            
            com = new NpgsqlCommand("SELECT * FROM booksinlibrary", dbconn);
            DALBooksFromInfoAll[] books = new DALBooksFromInfoAll[iteratormax];
            reader = com.ExecuteReader();
            int iterator = 0;
            while (iterator < iteratormax)
            {
                reader.Read();
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                books[iterator] = new DALBooksFromInfoAll(newrow);
                //dtAll.Rows.Add(newrow);
                iterator++;
            }
            reader.Close();

            //GridView1.DataSource = dtAll;
            //GridView1.DataBind();
            //reader.Close();
            dbconn.Close();

            return books;
        }
    }
}
