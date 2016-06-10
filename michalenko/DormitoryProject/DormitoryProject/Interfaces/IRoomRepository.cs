using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.DataAccessClasses;

namespace DormitoryProject.Interfaces
{
    public interface IRoomRepository
    {
        RoomDAL findByNum(int number);
        IEnumerable<RoomDAL> findByCapacity(int number);
        IEnumerable<RoomDAL> findByState(string state);
        RoomDAL findStudent(StudentTicketDAL student);
        IEnumerable<RoomDAL> getAllRooms();
        bool updateState(RoomDAL updatedRoom);
    }
}
