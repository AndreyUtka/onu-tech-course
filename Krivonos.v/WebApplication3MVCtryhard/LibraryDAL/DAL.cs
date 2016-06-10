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
    public class DAL
    {
        public DALBook[] GetAllBooks()
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            
            NpgsqlCommand com = new NpgsqlCommand("SELECT Count(*) FROM book", dbconn);
            int iteratormax = Convert.ToInt32(com.ExecuteScalar());
            
            com = new NpgsqlCommand("SELECT * FROM book", dbconn);

            DALBook[] books = new DALBook[iteratormax];
            NpgsqlDataReader reader = com.ExecuteReader();
            int iterator = 0;
            while (iterator < iteratormax)
            {
                reader.Read();
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                books[iterator] = new DALBook(newrow);
                //dtAll.Rows.Add(newrow);
                iterator++;
            }
            reader.Close();

            foreach (DALBook book in books)
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
                    author.Patronymic = reader.GetString(3);
                    author.Year = reader.GetString(4);
                    reader.Close();
                }

                com = new NpgsqlCommand("SELECT janrename FROM janre WHERE id_b = @bid", dbconn);
                com.Parameters.AddWithValue("@bid", Convert.ToInt32(book.Id));
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    book.Janres.Add(reader.GetString(0));
                }
                reader.Close();
            }
            //GridView1.DataSource = dtAll;
            //GridView1.DataBind();
            //reader.Close();
            dbconn.Close();

            return books;
        }

        public List<DALBook> GetBooksForReaders()
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            NpgsqlDataReader reader;

            List<DALBook> books = new List<DALBook>();

            com = new NpgsqlCommand("SELECT * FROM book WHERE id NOT IN (SELECT id_b FROM givenbooks)", dbconn);
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                books.Add(new DALBook(newrow));
            }
            reader.Close();

            foreach (DALBook book in books)
            {
                com = new NpgsqlCommand("SELECT janrename FROM janre WHERE id_b = @bid", dbconn);
                com.Parameters.AddWithValue("@bid", Convert.ToInt32(book.Id));
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    book.Janres.Add(reader.GetString(0));
                }
                reader.Close();
            }

            dbconn.Close();

            return books;
        }

        public bool SubmitBook(object[] book, object[][] authors, object[] janres)
        {
            DALBook bookToSubmit = new DALBook(book, authors, janres);
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            //NpgsqlDataReader reader;
            bool succeded = false;
            com = new NpgsqlCommand(
                String.Format("INSERT INTO book(name,year,izd,numofpages,howmanytimes,number_s1) VALUES('{0}',{1},'{2}','{3}',{4},{5});",
                bookToSubmit.Name, bookToSubmit.Year, bookToSubmit.Izd,
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
                     String.Format("INSERT INTO author(surname, name, patronymic, year) VALUES('{0}','{1}','{2}',{3});",
                                    a.Surname,a.Name, a.Patronymic, a.Year)
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

                foreach (string j in bookToSubmit.Janres)
                {
                    com = new NpgsqlCommand(
                     String.Format("INSERT INTO janre(janrename, id_b) VALUES('{0}', {1});",
                                    j, bookToSubmit.Id)
                     , dbconn);
                    executed = Convert.ToInt32(com.ExecuteNonQuery());
                }
                if (executed == 1)
                {
                    Console.WriteLine("Janres Added");
                }
                else
                {
                    Console.WriteLine("SOMETHING BAD INSIDE SUBMITBOOK (DAL)");
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

        public int RemoveBookWithId(int bid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            // Проверить выдана ли эта книга в данный момент
            com = new NpgsqlCommand("SELECT COUNT(*) FROM givenbooks WHERE id_b = @bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            int succeded = Convert.ToInt32(com.ExecuteScalar());
            if (succeded != 0)
            {
                com = new NpgsqlCommand("SELECT id_r FROM givenbooks WHERE id_b = @bid", dbconn);
                com.Parameters.AddWithValue("@bid", bid);
                succeded = Convert.ToInt32(com.ExecuteScalar());
                return succeded;
            }

            com = new NpgsqlCommand("SELECT * FROM authority WHERE id_b=@bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);

            // Проверить если это последняя книга Автора в библиотеке - то удалить его
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            List<int> aIds = new List<int>();
            while (reader.Read())
            {
                aIds.Add(reader.GetInt32(1));
            }

            reader.Close();
            // Удалить запись об авторстве
            com = new NpgsqlCommand("DELETE FROM authority WHERE id_b=@bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            succeded = com.ExecuteNonQuery();
            int numofbooks = 0;
            // Проверить если это последняя книга Автора в библиотеке - то удалить его
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

            // Удалить все записи об этой книге из таблицы жанров
            com = new NpgsqlCommand("DELETE FROM janre WHERE id_b = @bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            succeded = com.ExecuteNonQuery();

            // Удалить книгу
            com = new NpgsqlCommand("DELETE FROM book WHERE id=@bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);
            succeded = com.ExecuteNonQuery();
            dbconn.Close();
            return succeded;
        }

        public List<DALReader> GetAllReaders()
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

        public bool GiveBookToReader(int bid, int rid)
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

        public bool HasBookOnHands(int rid)
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

        public DALBook GetBookBookOnHandsForReader(int rid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            NpgsqlDataReader reader;

            DALBook book = null;
            com = new NpgsqlCommand("SELECT * FROM book WHERE id IN (SELECT id_b FROM givenbooks WHERE id_r = @rid)", dbconn);
            com.Parameters.AddWithValue("@rid", rid);
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                book = new DALBook(newrow);
            }
            reader.Close();


            com = new NpgsqlCommand("SELECT janrename FROM janre WHERE id_b = @bid", dbconn);
            com.Parameters.AddWithValue("@bid", Convert.ToInt32(book.Id));
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                book.Janres.Add(reader.GetString(0));
            }
            reader.Close();


            dbconn.Close();

            return book;
        }

        public bool TakeBookFromReader(int bid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("DELETE FROM givenbooks WHERE id_b = @bid", dbconn);
            com.Parameters.AddWithValue("@bid", bid);

            int succeded = com.ExecuteNonQuery();
            return Convert.ToBoolean(succeded);
        }

        public bool RemoveReader(int rid)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(*) FROM givenbooks WHERE id_r = @rid", dbconn);
            com.Parameters.AddWithValue("@rid", rid);
            int succeded = Convert.ToInt32(com.ExecuteScalar());
            if (succeded != 0)
                return false;


            com = new NpgsqlCommand("DELETE FROM reader WHERE id = @rid", dbconn);
            com.Parameters.AddWithValue("@rid", rid);

            succeded = com.ExecuteNonQuery();

            return Convert.ToBoolean(succeded);
        }

        public bool AddReader(object[] newReader)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com = new NpgsqlCommand("INSERT INTO reader(surname,name,patronymic) VALUES (@surname, @name, @patronymic)", dbconn);
            com.Parameters.AddWithValue("@surname", newReader[0]);
            com.Parameters.AddWithValue("@name", newReader[1]);
            if (newReader[2] == null)
                com.Parameters.AddWithValue("@patronymic", DBNull.Value);
            else
                com.Parameters.AddWithValue("@patronymic", newReader[2]);
            int succeded = com.ExecuteNonQuery();

            return Convert.ToBoolean(succeded);
        }

        public List<DALBook> SearchForBookWithParams(object[] book, object[] janres)
        {
            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();

            DALBook b = new DALBook(book, null, janres);
            string where = "";
            if (!string.IsNullOrEmpty(b.Id))
            {
                where += " AND id = " + b.Id;
            }
            if (!string.IsNullOrEmpty(b.Name))
            {
                where += " AND name LIKE '%" + b.Name + "%'";
            }
            if (!string.IsNullOrEmpty(b.Year))
            {
                where += " AND year = " + b.Year;
            }
            if (!string.IsNullOrEmpty(b.Izd))
            {
                where += " AND izd LIKE '%" + b.Izd + "%'";
            }
            if (!string.IsNullOrEmpty(b.Numofpages))
            {
                where += " AND numofpages = " + b.Numofpages;
            }
            if (!string.IsNullOrEmpty(b.Howmanytimes))
            {
                where += " AND howmanytimes = " + b.Howmanytimes;
            }
            if (!string.IsNullOrEmpty(b.Number_s1))
            {
                where += " AND number_s1 = " + b.Number_s1;
            }
            
            // ДОДЕЛАТЬ ЭТУ ЧАСТЬ!!! и переделать вьюхи что-бы они отображали список жанров тоже)

            if (b.Janres.Count != 0)
            {
                where += " AND (";
                foreach (string j in b.Janres)
                {
                    where += "janrename LIKE '%" + j + "%' OR ";
                }
                where = where.Substring(0, where.Length - 3) + ')';
            }

            if (!string.IsNullOrEmpty(where))
            {
                where = "WHERE" + where.Substring(4);
            }
            List<DALBook> foundBooks = new List<DALBook>();
            NpgsqlCommand com = new NpgsqlCommand("SELECT b.* FROM book b JOIN janre j on b.id = j.id_b " + where, dbconn);
            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                object[] newrow = new object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    newrow[i] = reader.GetString(i);
                foundBooks.Add(new DALBook(newrow));
            }
            reader.Close();
            foreach (DALBook foundbook in foundBooks)
            {
                com = new NpgsqlCommand("SELECT id_a FROM authority WHERE id_b = @bid", dbconn);
                com.Parameters.AddWithValue("@bid", Convert.ToInt32(foundbook.Id));
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DALAuthor author = new DALAuthor();
                    author.Id = reader.GetString(0);
                    foundbook.Authors.Add(author);
                }
                reader.Close();
                foreach (DALAuthor author in foundbook.Authors)
                {
                    com = new NpgsqlCommand("SELECT * FROM author WHERE id = @aid", dbconn);
                    com.Parameters.AddWithValue("@aid", Convert.ToInt32(author.Id));
                    reader = com.ExecuteReader();
                    reader.Read();
                    author.Surname = reader.GetString(1);
                    author.Name = reader.GetString(2);
                    author.Patronymic = reader.GetString(3);
                    author.Year = reader.GetString(4);
                    reader.Close();
                }


                com = new NpgsqlCommand("SELECT janrename FROM janre WHERE id_b = @bid", dbconn);
                com.Parameters.AddWithValue("@bid", Convert.ToInt32(foundbook.Id));
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    foundbook.Janres.Add(reader.GetString(0));
                }
                reader.Close();
                
            }
            //reader.Close();
            dbconn.Close();

            
            return foundBooks;
        }

        public bool SaveBook(object[] book, object[] janres, object[][] authors)
        {
            DALBook bookToSave = new DALBook(book, authors, janres);

            NpgsqlConnection dbconn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Port=5433;Database=Home Library;");
            dbconn.Open();
            NpgsqlCommand com;
            //NpgsqlDataReader reader;
            com = new NpgsqlCommand(
                String.Format("UPDATE book SET name = '{0}', year = {1}, izd = '{2}',numofpages = {3}, howmanytimes = {4}, number_s1 = {5} WHERE id = {6}",
                bookToSave.Name, bookToSave.Year, bookToSave.Izd,
                bookToSave.Numofpages, bookToSave.Howmanytimes, bookToSave.Number_s1, bookToSave.Id)
                , dbconn);

            int executed = Convert.ToInt32(com.ExecuteNonQuery());

            if (executed == 1)
            {
                com = new NpgsqlCommand("DELETE FROM janre WHERE id_b = " + bookToSave.Id, dbconn);
                executed = Convert.ToInt32(com.ExecuteNonQuery());


                foreach (string j in bookToSave.Janres)
                {
                    com = new NpgsqlCommand(
                     String.Format("INSERT INTO janre(janrename, id_b) VALUES('{0}', {1});",
                                    j, bookToSave.Id)
                     , dbconn);
                    executed = Convert.ToInt32(com.ExecuteNonQuery());
                }
                if (executed == 1)
                {
                    Console.WriteLine("Janres Saved");
                }
                else
                {
                    Console.WriteLine("SOMETHING BAD after janres save in SAVEBOOK (DAL)");
                }
                foreach (DALAuthor a in bookToSave.Authors)
                {
                    com = new NpgsqlCommand("UPDATE author SET surname = @surname, name = @name, patronymic = @patronymic, year = @year WHERE id = @id", dbconn);
                    com.Parameters.AddWithValue("@surname", a.Surname);
                    com.Parameters.AddWithValue("@name", a.Name);
                    com.Parameters.AddWithValue("@patronymic", a.Patronymic);
                    com.Parameters.AddWithValue("@year", Convert.ToInt32(a.Year));
                    com.Parameters.AddWithValue("@id", Convert.ToInt32(a.Id));
                    executed = Convert.ToInt32(com.ExecuteNonQuery());
                }
            }
            return executed == 1 ? true : false;
        }
    }
}
