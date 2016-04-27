using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryProject.InterfacesBLL
{
    public interface IServiceFactory
    {
        IStudentService getStudentService();
        IRoomService getRoomService();

    }
}
