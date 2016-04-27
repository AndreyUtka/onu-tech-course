using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.Interfaces;
using DormitoryProject.DataAccessClasses;
using Npgsql;
using System.Windows.Forms;

namespace DormitoryProject.PGServer
{
    public class PGStudentRepository:IRepository,IDisposable
    {
        private readonly string connectionString;
        public PGStudentRepository(string connection)
        {
            this.connectionString = connection;
        }

        public Object findBySerial(string serial,string number)
        {
            string searchQuery = "SELECT u_serial,u_number,u_last_name,u_name,u_patr, kurs,facult,spec,s_group,room_num FROM stud_view WHERE u_serial=@serial AND u_number=@number";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(searchQuery, conn);
                cmd.Parameters.AddWithValue("@serial", serial);
                cmd.Parameters.AddWithValue("@number", number);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    return fromReaderToStudent(reader);               
                }
               
            }

        }
        private static StudentDAL fromReaderToStudent(NpgsqlDataReader reader)
        {
            var stud = new StudentDAL() ;
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    stud = new StudentDAL
                    {
                        uLastName = Convert.ToString(reader["u_last_name"]),
                        uName = Convert.ToString(reader["u_name"]),
                        sKurs = Convert.ToInt32(reader["kurs"]),
                        sFacult = Convert.ToString(reader["facult"]),
                        sSpec = Convert.ToString(reader["spec"]),
                        sGroup = Convert.ToInt32(reader["s_group"]),
                        uNumber = Convert.ToString(reader["u_number"]),
                        uSerial = Convert.ToString(reader["u_serial"]),
                        room=Convert.ToInt32(reader["room_num"])
                    };
                    if (reader["u_patr"] != DBNull.Value)
                    {
                        stud.uPatr = Convert.ToString(reader["u_patr"]);
                    }
                }
                
            }
            
            return stud;
        }

        public bool removeBySerial(string seria,string number)
        {
            string delQuery = "DELETE FROM stud_view WHERE u_serial=@u_serial AND u_number=@u_number";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(delQuery, conn);
                cmd.Parameters.AddWithValue("@u_serial", seria);
                cmd.Parameters.AddWithValue("@u_number", number);
                bool success = false;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка удаления записи БД! Сообщение:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return success;
            }
        }

        public bool addUser(Object person)
        {
            StudentDAL student = (person as StudentDAL);
            string addQuery = "SELECT settle('С',@serial,@number,@last_name,@name,@patr,@kurs,@facult,@spec,@group,@room)";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(addQuery, conn);
                cmd.Parameters.AddWithValue("@serial", student.uSerial);
                cmd.Parameters.AddWithValue("@number", student.uNumber);
                cmd.Parameters.AddWithValue("@last_name", student.uLastName);
                cmd.Parameters.AddWithValue("@name", student.uName);
                cmd.Parameters.AddWithValue("@kurs", student.sKurs);
                cmd.Parameters.AddWithValue("@facult", student.sFacult);
                cmd.Parameters.AddWithValue("@spec", student.sSpec);
                cmd.Parameters.AddWithValue("@group", student.sGroup);
                cmd.Parameters.AddWithValue("@room", student.room);
                if (student.uPatr!= null)
                {
                    cmd.Parameters.AddWithValue("@patr", student.uPatr);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@patr", DBNull.Value);
                }
                bool success = false;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка добавления записи в БД! Сообщение:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return success;

            }
        }

        public bool updateInfo(Object person)
        {
            StudentDAL updateStudent = (person as StudentDAL);
            string updateQuery = "UPDATE stud_view " +
                               "SET u_last_name=@last_name,"+
                               "u_name=@name "+
                               "u_patr=@patr " +
                               "kurs=@kurs " +
                               "spec=@spec " +
                               "facult=@facult " +
                               "s_group=@group " +
                               "room_num=@room_num"+
                               "WHERE u_serial=@serial AND u_number=@number";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(updateQuery);
                cmd.Parameters.AddWithValue("@last_name", updateStudent.uLastName);
                cmd.Parameters.AddWithValue("@u_name", updateStudent.uName);
                cmd.Parameters.AddWithValue("@kurs", updateStudent.sKurs);
                cmd.Parameters.AddWithValue("@spec", updateStudent.sSpec);
                cmd.Parameters.AddWithValue("@facult", updateStudent.sFacult);
                cmd.Parameters.AddWithValue("@s_group", updateStudent.sGroup);
                cmd.Parameters.AddWithValue("@room_num", updateStudent.room);
                if (updateStudent.uPatr != null)
                {
                    cmd.Parameters.AddWithValue("@patr", updateStudent.uPatr);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@patr", DBNull.Value);
                }
                bool success = false;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка обновления записи в БД! Сообщение:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return success;
            }
        }
        public IEnumerable<Object> getAll()
        {
            List<StudentDAL> list = new List<StudentDAL>();
            string getQuery = "SELECT * FROM stud_view";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(getQuery, conn);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(fromReaderToStudent(reader));
                    }
                }
            }
            return list.AsEnumerable();
        }
        public IEnumerable<Object> searchBy(Object person)
        {
            StudentDAL student = (person as StudentDAL);
            List<StudentDAL> list = new List<StudentDAL>();
            string getQuery = "SELECT u_serial,u_number,u_last_name,u_name,u_patr, kurs,facult,spec,s_group,room_num FROM stud_view " +
                              "WHERE ";

            bool hasPrev = false;
            #region LastName
            if(student.uLastName!=string.Empty)
            {
                getQuery += " u_last_name='" + student.uLastName.ToString() + "' ";
                hasPrev = true;
            }
            #endregion
            #region Name
            if(student.uName!=string.Empty)
            {
                if(hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " u_name='" + student.uName.ToString() + "'";
                }
                else
                {
                    getQuery += " u_name='" + student.uName.ToString() + "'";
                }
                hasPrev = true;
            }
            #endregion
            #region Patr
            if(student.uPatr!=string.Empty)
            {
                if (hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " u_patr='" + student.uPatr.ToString() + "' ";
                }
                else
                {
                    getQuery += " u_patr='" + student.uPatr.ToString() + "' ";
                }
                hasPrev = true;
            }
            #endregion
            #region Faculty
            if(student.sFacult!=string.Empty)
            {
                if (hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " facult='" + student.sFacult.ToString() + "' ";
                }
                else
                {
                    getQuery += " facult='" + student.sFacult.ToString() + "' ";
                }
                hasPrev = true;
            }
            #endregion
            #region Kurs
            if(student.sKurs>0)
            {
                if (hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " kurs='" + student.sKurs + "' ";
                }
                else
                {
                    getQuery += " kurs='" + student.sKurs + "' ";
                }
                hasPrev = true;
            }
            #endregion
            #region Speciality
            if (student.sSpec!=string.Empty)
            {
                if (hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " spec='" + student.sSpec + "' ";
                }
                else
                {
                    getQuery += " spec='" + student.sSpec + "' ";
                }
                hasPrev = true;
            }
            #endregion
            #region Group
            if (student.sGroup>0)
            {
                if (hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " s_group='" + student.sGroup + "' ";
                }
                else
                {
                    getQuery += " s_group='" + student.sGroup + "' ";
                }
                hasPrev = true;
            }
            #endregion
            #region Room
            if (student.room> 0)
            {
                if (hasPrev)
                {
                    getQuery += " AND ";
                    getQuery += " room_num=" + student.room + " ";
                }
                else
                {
                    getQuery += " room_num=" + student.room+ " ";
                }
                hasPrev = true;
            }
            #endregion

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(getQuery, conn);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(fromReaderToStudent(reader));
                    }
                }
            }
            return list.AsEnumerable();
        }

        public bool checkUser(string userType, string serial, string number, string password)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT check_user(@u_type,@u_serial,@u_number,@password)";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u_type", userType);
                cmd.Parameters.AddWithValue("@u_serial", serial);
                cmd.Parameters.AddWithValue("@u_number", number);
                cmd.Parameters.AddWithValue("@password", password);
                bool success = false;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка входа! Текст ошибки: " + ex.Message,"Ошибка входа",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                conn.Close();
                return success;
            }
        }

        public void Dispose()
        { }

    }
}
