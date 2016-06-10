using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.InterfacesBLL;
using DormitoryProject.PGServer;
using DormitoryProject.DomainObjects;
using DormitoryProject.ServicesBLL;

namespace DormitoryProject.Presenters
{
    public class UserRoomPresenter
    {
        UserRoomForm form;
        private readonly string currentRole = string.Empty;
        private readonly string login = string.Empty;
        private readonly string userType = string.Empty;
        private readonly IServiceFactory serviceFactory;
        private readonly UserService service;
        
        public UserRoomPresenter(UserRoomForm form, string login, string role)
        {
            this.form = form;
            this.login = login;
            userType = login.Substring(0, 1);
            currentRole = role;
            serviceFactory = new UserServiceFactory(new PGUserRepositoryFactory(currentRole));
            service = serviceFactory.getUserService();
            loadInfo();
        }

        public void loadInfo()
        {
            if (userType.Equals("С"))
            {
                IEnumerable<TicketBLL> res = service.searchBy(new StudentTicketBLL { roomNumber = 0, kurs = 0, group = 0, serial = login.Substring(1, 2), number = login.Substring(3, login.Length - 3) });
                StringBuilder sb = new StringBuilder();
                List<StudentTicketBLL> st = res.Cast<StudentTicketBLL>().ToList();
                sb.Append("Логин: " + login +
                          "\nНомер студ. билета: " + login.Substring(1, login.Length - 1) +
                          "\nФамилия:" + st[0].lastName +
                          "\nИмя: " + st[0].name +
                          "\nОтчество: " + st[0].patronimic +
                          "\nКурс: " + st[0].kurs +
                          "\nФакультет: " + st[0].facult +
                          "\nГруппа: " + st[0].group +
                          "\nСпециальность: " + st[0].speciality +
                          "\nКомната:" + st[0].roomNumber
                    );
                form.setInfo(sb.ToString());
            }
            else if (userType.Equals("Р") || userType.Equals("К"))
            {
                IEnumerable<TicketBLL> res = service.searchBy(new WorkerTicketBLL { serial=login.Substring(1, 2), number=login.Substring(3, login.Length - 3) });
                StringBuilder sb = new StringBuilder();
                List<WorkerTicketBLL> w = res.Cast<WorkerTicketBLL>().ToList();
                sb.Append("Логин: " + login +
                          "\nНомер удостоверения: " + login.Substring(1, login.Length - 1) +
                          "\nФамилия:" + w[0].lastName +
                          "\nИмя: " + w[0].name +
                          "\nОтчество: " + w[0].patronimic +
                          "\nСпециализация: " + w[0].speciality+
                          "\nНомер тел.: " + w[0].phoneNumber
                    );
                form.setInfo(sb.ToString());
            }

        }

        public string getCurrentRole()
        {
            return currentRole;
        }
    }
}
