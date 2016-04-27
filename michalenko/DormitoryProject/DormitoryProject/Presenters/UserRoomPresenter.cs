using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.InterfacesBLL;
using DormitoryProject.PGServer;
using DormitoryProject.DomainObjects;

namespace DormitoryProject.Presenters
{
    public class UserRoomPresenter
    {
        UserRoomForm form;
        private readonly string connectionString = string.Empty;
        private readonly string login = string.Empty;
        private readonly string userType = string.Empty;
        private readonly IServiceFactory serviceFactory;
        private readonly IService service;

        public UserRoomPresenter(UserRoomForm form,string login,string connection)
        {
            this.form = form;
            this.login = login;
            userType = login.Substring(0, 1);
            connectionString = connection;
            if(userType.Equals("С"))
            {
                serviceFactory = new StudentServiceFactory(new PGStudentRepositoryFactory(connectionString));
                service = serviceFactory.getStudentService();
            }
            else if(userType.Equals("Р"))
            {
                //serviceFactory = new WorkerServiceFactory(new PGWorkerRepositoryFactory(connectionString));
            }
            loadInfo();

        }

        public void loadInfo()
        {
            if(userType.Equals("С"))
            {
                StudentBLL st = (service as IStudentService).findBySerial(login.Substring(1, 2), login.Substring(3, login.Length - 3));
                StringBuilder sb = new StringBuilder();
                sb.Append("Логин: "+login+
                          "\nНомер студ. билета: " + login.Substring(1,login.Length-1) +
                          "\nФамилия:" + st.uLastName +
                          "\nИмя: " + st.uName +
                          "\nОтчество: " + st.uPatr +
                          "\nКурс: " + st.sKurs +
                          "\nФакультет: " + st.sFacult +
                          "\nГруппа: " + st.sGroup +
                          "\nСпециальность: " + st.sSpec+
                          "\nКомната:"+st.room
                    );
                form.setInfo(sb.ToString());
            }
            
        }
    }
}
