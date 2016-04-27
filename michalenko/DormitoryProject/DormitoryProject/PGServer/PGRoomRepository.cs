using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.DataAccessClasses;
using DormitoryProject.Interfaces;
using Npgsql;
using System.Windows.Forms;

namespace DormitoryProject.PGServer
{
    public class PGRoomRepository:IRoomRepository
    {
        private readonly string connectionString;
        public PGRoomRepository(string connection)
        {
            connectionString = connection;
        }

        public IEnumerable<RoomDAL> findByCapacity(int number)
        {
            List<RoomDAL> list = new List<RoomDAL>();
            string searchQuery = "SELECT room_num,room_stage,room_block,room_capacity,room_state "+
                                "FROM room WHERE room_num IN("+
                                "SELECT room_num FROM("+
                                "SELECT room_num, count(*) FROM accomodation"+
                                "GROUP BY room_num) AS T1"+
                                "WHERE T1.count < @number)";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(searchQuery, conn);
                cmd.Parameters.AddWithValue("@number", number);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(fromReaderToRoom(reader));
                    }
                }
            }
            return list.AsEnumerable();
        }

        private static RoomDAL fromReaderToRoom(NpgsqlDataReader reader)
        {
            var room = new RoomDAL
            {
                roomNum = Convert.ToInt32(reader["room_num"]),
                roomBlock=Convert.ToInt32(reader["room_block"]),
                roomStage=Convert.ToInt32(reader["room_stage"]),
                roomCapacity=Convert.ToInt32(reader["room_capacity"]),
                roomState=Convert.ToString(reader["room_state"])
            };
            return room;
        }

        public RoomDAL findByNum(int number)
        {
            string searchQuery = "SELECT room_num,room_stage,room_block,room_capacity,room_state FROM room " +
                                 "WHERE room_num=@room_num";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(searchQuery, conn);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    return fromReaderToRoom(reader);
                }
            }
        }

        public IEnumerable<RoomDAL> findByState(string state)
        {
            List<RoomDAL> list = new List<RoomDAL>();
            string searchQuery = "SELECT room_num,room_stage,room_block,room_capacity,room_state " +
                                "FROM room WHERE room_state=@state";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(searchQuery, conn);
                cmd.Parameters.AddWithValue("@state", state);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(fromReaderToRoom(reader));
                    }
                }
            }
            return list.AsEnumerable();
        }

        
        public RoomDAL findStudent(StudentDAL student)
        {
            string searchQuery = "SELECT room_num,room_stage,room_block,room_capacity,room_state FROM room"+
                                 "WHERE room_num=(SELECT room_num FROM accomodation "+
                                 "WHERE u_serial=@serial AND u_number=@number)";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(searchQuery, conn);
                cmd.Parameters.AddWithValue("@serial", student.uSerial);
                cmd.Parameters.AddWithValue("@number", student.uNumber);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    return fromReaderToRoom(reader);
                }
            }
        }

        public IEnumerable<RoomDAL> getAllRooms()
        {
            List<RoomDAL> list = new List<RoomDAL>();
            string searchQuery = "SELECT room_num,room_stage,room_block,room_capacity,room_state FROM room";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(searchQuery, conn);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(fromReaderToRoom(reader));
                    }
                }
            }
            return list.AsEnumerable();
        }

        public bool updateState(RoomDAL updatedRoom)
        {
            string query = "UPDATE room "+
                           "room_state=@state "+
                           "WHERE room_num=@num";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@state", updatedRoom.roomState);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка обновления записи в БД! Сообщение:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
        }
    }
}
