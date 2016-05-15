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

            foreach (DALBooksFromInfoAll book in books)
            {
                com = new NpgsqlCommand("SELECT id_a FROM authority WHERE id_b = @bid", dbconn);
                com.Parameters.AddWithValue("@bid", Convert.ToInt32(book.Id));
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DALAuthor author = new DALAuthor();
                    author.Id = reader.GetString(0);
                    book.Authors.Add(author);
                }
                reader.Close();
                foreach (DALAuthor author in book.Authors)
                {
                    com = new NpgsqlCommand("SELECT * FROM author WHERE id = @aid", dbconn);
                    com.Parameters.AddWithValue("@aid", Convert.ToInt32(author.Id));
                    reader = com.ExecuteReader();
                    reader.Read();
                    author.Surname = reader.GetString(1);
                    author.Name = reader.GetString(2);
                    author.Aftername = reader.GetString(3);
                    author.Year = reader.GetString(4);
                    reader.Close();
                }
            }
            //GridView1.DataSource = dtAll;
            //GridView1.DataBind();
            //reader.Close();
            dbconn.Close();

            return books;
        }

        public static List<DALBooksFromInfoAll> GetInfoForReaders()
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            NpgsqlDataReader reader;

            List<DALBooksFromInfoAll> books = new List<DALBooksFromInfoAll>();

            com = new NpgsqlCommand("SELECT * FROM booksinlibrary WHERE b_id NOT IN (SELECT id_b FROM givenbooks)", dbconn);
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                books.Add(new DALBooksFromInfoAll(newrow));
            }
            reader.Close();

            dbconn.Close();

            return books;
        }

        public static bool SubmitBook(object[] book, object[][] authors)
        {
            DALBooksFromInfoAll bookToSubmit = new DALBooksFromInfoAll(book, authors);
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            //NpgsqlDataReader reader;
            bool succeded = false;
            com = new NpgsqlCommand(
                String.Format("INSERT INTO book(name,year,janre,izd,numofpages,howmanytimes,number_s1) VALUES('{0}',{1},'{2}','{3}',{4},{5},{6});",
                bookToSubmit.Name, bookToSubmit.Year, bookToSubmit.Janre, bookToSubmit.Izd,
                bookToSubmit.Numofpages, bookToSubmit.Howmanytimes, bookToSubmit.Number_s1)
                , dbconn);
            int executed = Convert.ToInt32(com.ExecuteNonQuery());
            if (executed == 1)
            {
                com = new NpgsqlCommand("SELECT MAX(id) FROM book", dbconn);
                bookToSubmit.Id = Convert.ToInt32(com.ExecuteScalar()).ToString();
                foreach (DALAuthor a in bookToSubmit.Authors)
                {
                    com = new NpgsqlCommand(
                     String.Format("INSERT INTO author(surname, name, aftername, year) VALUES('{0}','{1}','{2}',{3});",
                                    a.Surname,a.Name, a.Aftername, a.Year)
                     , dbconn);
                    executed = Convert.ToInt32(com.ExecuteNonQuery());
                    if (executed == 1)
                    {
                        com = new NpgsqlCommand("SELECT MAX(id) FROM author", dbconn);
                        a.Id = Convert.ToInt32(com.ExecuteScalar()).ToString();
                    }
                    else
                    {
                        Console.WriteLine("SOMETHING BAD INSIDE SUBMITBOOK (DAL)");
                    }
                } 
            }
            if (executed == 1)
            {
                int authorsinauthority = 0;
                foreach (DALAuthor a in bookToSubmit.Authors)
                {
                    com = new NpgsqlCommand(
                     String.Format("INSERT INTO authority VALUES({0},{1});",
                    bookToSubmit.Id, a.Id)
                     , dbconn);
                    executed = Convert.ToInt32(com.ExecuteNonQuery());
                    if (executed == 1)
                        authorsinauthority++;
                }
                if (authorsinauthority == bookToSubmit.Authors.Count)
                    succeded = true;
            }
            dbconn.Close();
            return succeded;
        }

        public static bool RemoveBookWithId(int bid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;


            com = new NpgsqlCommand("SELECT * FROM authority WHERE id_b=@bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);

            //// Проверить если это последняя книга Автора в библиотеке - то удалить его
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            List<int> aIds = new List<int>();
            while (reader.Read())
            {
                aIds.Add(reader.GetInt32(1));
            }

            reader.Close();

            com = new NpgsqlCommand("DELETE FROM authority WHERE id_b=@bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            int succeded = com.ExecuteNonQuery();
            int numofbooks = 0;
            foreach (int aId in aIds)
            {
                com = new NpgsqlCommand("SELECT COUNT(*) FROM authority WHERE id_a=@aid", dbconn);
                com.Parameters.AddWithValue("@aid", aId);
                numofbooks = Convert.ToInt32(com.ExecuteScalar());

                if (numofbooks == 0)
                {
                    com = new NpgsqlCommand("DELETE FROM author WHERE id=@aid", dbconn);
                    com.Parameters.AddWithValue("@aid", aId);
                    succeded = com.ExecuteNonQuery();
                }
            }

            // Удалить книгу
            com = new NpgsqlCommand("DELETE FROM book WHERE id=@bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            succeded = com.ExecuteNonQuery();
            dbconn.Close();
            if (succeded == 1)
                return true;
            else
                return false;
        }

        public static List<DALReader> GetAllReaders()
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;


            com = new NpgsqlCommand("SELECT * FROM reader", dbconn);
            NpgsqlDataReader reader = com.ExecuteReader();
            List<DALReader> readers = new List<DALReader>();

            while (reader.Read())
            {
                object[] newrow = new object[4];
                newrow[0] = reader.GetString(0);
                newrow[1] = reader.GetString(1);
                newrow[2] = reader.GetString(2);
                if (reader.GetValue(3) != DBNull.Value)
                    newrow[3] = reader.GetString(3);
                else
                    newrow[3] = "";
                readers.Add(new DALReader(newrow));
            }
            reader.Close();
            dbconn.Close();
            return readers;
        }

        public static bool GiveBookToReader(int bid, int rid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("INSERT INTO givenbooks VALUES (@bid, @rid)", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            com.Parameters.AddWithValue("@rid", rid);
            
            int succeded = com.ExecuteNonQuery();

            com = new NpgsqlCommand("UPDATE book SET howmanytimes = howmanytimes + 1 WHERE id = @bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            com.ExecuteNonQuery();

            dbconn.Close();
            return Convert.ToBoolean(succeded);
        }

        public static bool HasBookOnHands(int rid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("SELECT id_b FROM givenbooks WHERE id_r = @rid", dbconn);
            com.Parameters.AddWithValue("@rid", rid);
            object bid = com.ExecuteScalar();

            if (bid == null)
                return false;
            else
                return true;
        }

        public static DALBooksFromInfoAll GetBookBookOnHandsForReader(int rid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            NpgsqlDataReader reader;

            DALBooksFromInfoAll book = null;
            com = new NpgsqlCommand("SELECT * FROM booksinlibrary WHERE b_id IN (SELECT id_b FROM givenbooks WHERE id_r = @rid)", dbconn);
            com.Parameters.AddWithValue("@rid", rid);
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                book = new DALBooksFromInfoAll(newrow);
            }
            reader.Close();

            dbconn.Close();

            return book;
        }

        public static bool TakeBookFromReader(int bid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("DELETE FROM givenbooks WHERE id_b = @bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);

            int succeded = com.ExecuteNonQuery();
            return Convert.ToBoolean(succeded);
        }

        public static bool RemoveReader(int rid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("DELETE FROM reader WHERE id = @rid", dbconn);
            com.Parameters.AddWithValue("@rid", rid);

            int succeded = com.ExecuteNonQuery();

            return Convert.ToBoolean(succeded);
        }

        public static bool AddReader(object[] newReader)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("INSERT INTO reader(surname,name,aftername) VALUES (@surname, @name, @aftername)", dbconn);
            com.Parameters.AddWithValue("@surname", newReader[0]);
            com.Parameters.AddWithValue("@name", newReader[1]);
            if (newReader[2] == null)
                com.Parameters.AddWithValue("@aftername", DBNull.Value);
            else
                com.Parameters.AddWithValue("@aftername", newReader[2]);
            int succeded = com.ExecuteNonQuery();

            return Convert.ToBoolean(succeded);
        }
    }
}
