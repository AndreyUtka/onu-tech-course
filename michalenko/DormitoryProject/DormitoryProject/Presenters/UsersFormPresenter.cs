using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryProject.InterfacesBLL;
using DormitoryProject.ServicesBLL;
using DormitoryProject.PGServer;
using System.Data;
using DormitoryProject.DomainObjects;
using System.Windows.Forms;
using DormitoryProject.DataAccessClasses;

namespace DormitoryProject.Presenters
{
    
    public class UsersFormPresenter
    {
        private readonly string roleToSend=string.Empty;
        private UserForm form;
        private IEnumerable<TicketBLL> userList;
        private UserService service;
        private IServiceFactory serviceFactory;
        #region Общее
        private string colHeaderLastName = "Фамилия";
        private string colHeaderName = "Имя";
        private string colHeaderPatr = "Отчество";
        private string colHeaderSerial = "Серия";
        private string colHeaderNumber = "Номер";
        #endregion
        #region Студент
        private string colHeaderCurs = "Курс";
        private string colHeaderFacult = "Факультет";
        private string colHeaderGroup = "Группа";
        private string colHeaderSpec = "Специальность";
        private string colHeaderRoom = "Комната";
        #endregion
        #region Рабочий
        private string colHeaderWorkSpec = "Специализация";
        private string colHeaderPhone = "Телефон";
        #endregion
        private DataTable tableForValues = new DataTable();

        public UsersFormPresenter(UserForm form,string role)
        {
            this.form = form;
            roleToSend = role;
            buildStudTable();
            getUserService();
            getListOfStudents();
            fillStudentTable(userList);
            sendToGrid(tableForValues);
        }

        public void getUserService()
        {
            serviceFactory = new UserServiceFactory(new PGUserRepositoryFactory(roleToSend));
            service = serviceFactory.getUserService();
            getListOfStudents();
        }
        public void getListOfWorkers()
        {
            userList = service.getAllWorkers();   
        }

        public void getListOfStudents()
        {
            userList = service.getAllStudents();
        }

        public StudentTicketBLL getStudentFromTextBoxes()
        {
            List<string> list = new List<string>();
            this.form.getTextBoxValues().ForEach(o=>list.Add(o.Text.ToString()));
            
            if (string.IsNullOrWhiteSpace(list[0]))
            {
                list[0]= "0";
            }
            if(string.IsNullOrWhiteSpace(list[4]))
            {
                list[4]= "0";
            }
            if (string.IsNullOrWhiteSpace(list[6]))
            {
                list[6]= "0";
            }
            StudentTicketBLL student= new StudentTicketBLL
            {   
                roomNumber = Convert.ToInt32(list[0]),
                lastName = list[1].ToString(),
                name = list[2].ToString(),
                patronimic = list[3].ToString(),
                kurs = Convert.ToInt32(list[4]),
                facult = list[5].ToString(),
                group= Convert.ToInt32(list[6]),
                speciality= list[7].ToString(),
                serial=list[8].ToString(),
                number=list[9].ToString()
            };
            return student;
        }
        public WorkerTicketBLL getWorkerFromTextBoxes()
        {
            List<string> list = new List<string>();
            this.form.getTextBoxValues().ForEach(o => list.Add(o.Text.ToString()));

            WorkerTicketBLL worker = new WorkerTicketBLL
            {
                lastName = list[0].ToString(),
                name = list[1].ToString(),
                patronimic = list[2].ToString(),
                speciality= list[3].ToString(),
                phoneNumber= list[4].ToString(),
                serial = list[5].ToString(),
                number = list[6].ToString()
            };
            if(!form.getDayValue().Equals("не указано"))
            {
                WorkDayDAL wd = new WorkDayDAL
                {
                    day = form.getDayValue()
                };
                worker.workDays = new List<WorkDayDAL>();
                worker.workDays.Add(wd);
            }
            return worker;
        }

        public void searchWorker()
        {
            fillWorkerTable(service.searchBy(getWorkerFromTextBoxes()));
            sendToGrid(tableForValues);
        }
        public void searchStudent()
        {
            fillStudentTable(service.searchBy(getStudentFromTextBoxes()));
            sendToGrid(tableForValues);
        }

        public void addStudent()
        {
            service.addUser(getStudentFromTextBoxes());
            reloadStudGrid();
        }
        public void addWorker()
        {
            WorkerTicketBLL worker = getWorkerFromTextBoxes();
            if(openWorkDaysForm(ref worker))
            {
                service.addUser(worker);
                getListOfWorkers();
                reloadWorkerGrid();
            }
            else
            {
                MessageBox.Show("Рабочие дни не были указаны", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void deleteStudent()
        {
            service.deleteUser(getStudentFromTextBoxes());
            reloadStudGrid();
        }
        public void deleteWorker()
        {
            service.deleteUser(getWorkerFromTextBoxes());
            reloadWorkerGrid();
        }

        public void resettleStudent()
        {
            service.resettleStudent(getStudentFromTextBoxes());
            reloadStudGrid();
        }

        public void reloadStudGrid()
        {
            fillStudentTable(service.getAllStudents());
            sendToGrid(tableForValues);
        }
        public void reloadWorkerGrid()
        {
            fillWorkerTable(service.getAllWorkers());
            sendToGrid(tableForValues);
        }

        public void buildStudTable()
        {
            tableForValues = new DataTable();
            DataColumn 
                serialCol = new DataColumn(colHeaderSerial, typeof(string)),
                numberCol=new DataColumn(colHeaderNumber, typeof(string)),
                lastNameCol=new DataColumn(colHeaderLastName, typeof(string)),
                nameCol=new DataColumn(colHeaderName, typeof(string)),
                patrCol=new DataColumn(colHeaderPatr, typeof(string)),
                kursCol=new DataColumn(colHeaderCurs, typeof(Int32)),
                facultCol=new DataColumn(colHeaderFacult,typeof(string)),
                groupCol=new DataColumn(colHeaderGroup, typeof(Int32)),
                specCol=new DataColumn(colHeaderSpec, typeof(string)),
                roomCol=new DataColumn(colHeaderRoom, typeof(Int32));

            patrCol.AllowDBNull = true;

            tableForValues.Columns.Add(roomCol);
            tableForValues.Columns.Add(lastNameCol);
            tableForValues.Columns.Add(nameCol);
            tableForValues.Columns.Add(patrCol);
            tableForValues.Columns.Add(kursCol);
            tableForValues.Columns.Add(facultCol);
            tableForValues.Columns.Add(groupCol);
            tableForValues.Columns.Add(specCol);
            tableForValues.Columns.Add(serialCol);
            tableForValues.Columns.Add(numberCol);

        }
        public void buildWorkTable()
        {
            tableForValues = new DataTable();
            DataColumn
                serialCol = new DataColumn(colHeaderSerial, typeof(string)),
                numberCol = new DataColumn(colHeaderNumber, typeof(string)),
                lastNameCol = new DataColumn(colHeaderLastName, typeof(string)),
                nameCol = new DataColumn(colHeaderName, typeof(string)),
                patrCol = new DataColumn(colHeaderPatr, typeof(string)),
                specCol = new DataColumn(colHeaderWorkSpec, typeof(string)),
                phoneCol = new DataColumn(colHeaderPhone, typeof(string));
            patrCol.AllowDBNull = true;

            tableForValues.Columns.Add(lastNameCol);
            tableForValues.Columns.Add(nameCol);
            tableForValues.Columns.Add(patrCol);
            tableForValues.Columns.Add(specCol);
            tableForValues.Columns.Add(phoneCol);
            tableForValues.Columns.Add(serialCol);
            tableForValues.Columns.Add(numberCol);
        }

        public WorkerTicketBLL findWorkerInUserListBySerial(string serial,string number)
        {
            WorkerTicketBLL worker = new WorkerTicketBLL();
            foreach(WorkerTicketBLL w in userList)
            {
                if(w.serial==serial && w.number==number)
                {
                    worker = (w as WorkerTicketBLL);
                    break;
                }
            }
            return worker;
        }
        
        public void fillWorkerTable(IEnumerable<TicketBLL> list)
        {
            buildWorkTable();
            DataRow row;
            StringBuilder sb = new StringBuilder();
            foreach (WorkerTicketBLL w in list)
            { 
                sb.Clear();
                row = tableForValues.NewRow();
                row[colHeaderLastName] = w.lastName;
                row[colHeaderName] = w.name;
                row[colHeaderPatr] = w.patronimic;
                row[colHeaderWorkSpec] = w.speciality;
                row[colHeaderPhone] = w.phoneNumber;
                row[colHeaderSerial] = w.serial;
                row[colHeaderNumber] = w.number;
                tableForValues.Rows.Add(row);
            }
            tableForValues.AcceptChanges();
        }
        public void fillStudentTable(IEnumerable<TicketBLL> list)
        {
            buildStudTable();
            DataRow row;
            foreach(StudentTicketBLL s in list)
            {
                row = tableForValues.NewRow();
                row["Комната"] = s.roomNumber;
                row["Фамилия"] = s.lastName;
                row["Имя"] = s.name;
                row["Отчество"] = s.patronimic;
                row["Курс"] = s.kurs;
                row["Факультет"] = s.facult;
                row["Группа"] = s.group;
                row["Специальность"] = s.speciality;
                row["Серия"] = s.serial;
                row["Номер"] = s.number;
                tableForValues.Rows.Add(row);
            }
            tableForValues.AcceptChanges();
        }
        public void sendToGrid(DataTable table)
        {
            form.loadTable(table);
        }

        public bool openWorkDaysForm(ref WorkerTicketBLL worker)
        {
            WorkDaysForm wdForm = new WorkDaysForm(ref worker);
            wdForm.ShowDialog();
            bool result = false;
            if(wdForm.DialogResult==DialogResult.OK)
            {
                result = true;
            }
            return result;
        }
    }
}
