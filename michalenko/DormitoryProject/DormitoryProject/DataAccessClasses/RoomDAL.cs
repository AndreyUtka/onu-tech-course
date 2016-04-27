using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.DataAccessClasses
{
    public class RoomDAL
    {
        public int roomNum { get; set; }
        public int roomStage { get; set; }
        public int roomBlock { get; set; }
        public int roomCapacity { get; set; }
        public string roomState { get; set; }
    }
}
