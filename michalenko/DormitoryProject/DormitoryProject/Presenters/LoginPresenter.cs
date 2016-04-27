using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.InterfacesBLL;
using DormitoryProject.PGServer;
using DormitoryProject.ServicesBLL;
using System.Windows.Forms;
using Npgsql;


namespace DormitoryProject.Presenters
{
    public class LoginPresenter
    {
        private string con=string.Empty;
        private LoginForm form;
        private readonly IServiceFactory serviceFactory;
        private readonly IStudentService service;

        private string login;
        private string password;
        private string userType;
        private string serial;
        private string number;

        private readonly string STUD_ROLE = "student";
        private readonly string WORKER_ROLE = "worker";
        private readonly string KOMENDANT_ROLE = "komendant";
        private readonly string POSTGRES_ROLE = "postgres";
        public LoginPresenter(LoginForm logform)
        {
            form = logform;
            con = buildConnectionString(POSTGRES_ROLE);
            serviceFactory = new StudentServiceFactory(new PGStudentRepositoryFactory(con));
            service = serviceFactory.getStudentService();
            
        }

        public void checkLogin()
        {
            #region Проверки
            if(string.IsNullOrWhiteSpace(form.getLogin()))
            {
                throw new ArgumentException("Логин не может быть пустым");
            }
            else
            {
                login = form.getLogin();
            }
            if (string.IsNullOrWhiteSpace(form.getPassword()))
            {
                throw new ArgumentException("Пароль не может быть пустым");
            }
            else
            {
                password = form.getPassword();
            }
            #endregion
            userType = login.Substring(0, 1);
            serial = login.Substring(1, 2);
            number = login.Substring(3, login.Length-3);

            bool res;
            res = service.checkPassword(userType, serial, number, password);
                
            if(res)
            {
                MessageBox.Show("Вы успешно вошли в систему под именем " + login, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (userType.Equals("С"))
                {
                    con = buildConnectionString(STUD_ROLE);
                }
                else if(userType.Equals("Р"))
                {
                    con = buildConnectionString(WORKER_ROLE);
                }
                else if(userType.Equals("К"))
                {
                    con = buildConnectionString(KOMENDANT_ROLE);
                }
                UserRoomForm ur = new UserRoomForm(form,login,con);
                form.Hide();
                ur.Show();
            }

        }
        public string buildConnectionString(string role)
        {
            return string.Format("Server = 127.0.0.1; Port=5432;User Id = {0}; Password=0000;Database=dormitory;",role);
        }
    }
}
