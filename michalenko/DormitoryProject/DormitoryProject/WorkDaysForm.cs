using DormitoryProject.DomainObjects;
using DormitoryProject.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryProject
{
    public partial class WorkDaysForm : Form
    {
        private WorkDaysFormPresenter presenter;

        private List<ComboBox> startTimeList = new List<ComboBox>();
        private List<ComboBox> endTimeList = new List<ComboBox>();

        private List<ComboBox> restStartList = new List<ComboBox>();
        private List<ComboBox> restEndList = new List<ComboBox>();

        private List<CheckBox> weekDaysCheckBoxes = new List<CheckBox>();
        private List<CheckBox> breaksCheckBoxes = new List<CheckBox>();


        public WorkDaysForm(ref WorkerTicketBLL worker)
        {
            InitializeComponent();
            fillComboBoxes();
            getAllControls();
            this.presenter = new WorkDaysFormPresenter(this,worker);
            lbWS.Text = "Время\nначала:";
            lbWE.Text = "Время\nокончания:";
            lbRS.Text = "Время\nначала:";
            lbRE.Text = "Время\nокончания:";
            
        }

       
        private void fillComboBoxes()
        {
            foreach(Control ctrl in Controls)
            {
                if(ctrl is ComboBox)
                {
                    ComboBox c = (ctrl as ComboBox);
                    c.DropDownStyle = ComboBoxStyle.DropDownList;
                    
                    c.Items.Add("---:---");
                    c.Items.Add("08:00");
                    c.Items.Add("08:15");
                    c.Items.Add("08:30");
                    c.Items.Add("08:45");
                    c.Items.Add("09:00");
                    c.Items.Add("09:15");
                    c.Items.Add("09:30");
                    c.Items.Add("09:45");
                    c.Items.Add("10:00");
                    c.Items.Add("10:15");
                    c.Items.Add("10:30");
                    c.Items.Add("10:45");
                    c.Items.Add("11:00");
                    c.Items.Add("11:15");
                    c.Items.Add("11:30");
                    c.Items.Add("11:45");
                    c.Items.Add("12:00");
                    c.Items.Add("12:15");
                    c.Items.Add("12:30");
                    c.Items.Add("12:45");
                    c.Items.Add("13:00");
                    c.Items.Add("13:15");
                    c.Items.Add("13:30");
                    c.Items.Add("13:45");
                    c.Items.Add("14:00");
                    c.Items.Add("14:15");
                    c.Items.Add("14:30");
                    c.Items.Add("14:45");
                    c.Items.Add("15:00");
                    c.Items.Add("15:15");
                    c.Items.Add("15:30");
                    c.Items.Add("15:45");
                    c.Items.Add("16:00");
                    c.Items.Add("16:15");
                    c.Items.Add("16:30");
                    c.Items.Add("16:45");
                    c.Items.Add("17:00");
                    c.Items.Add("17:15");
                    c.Items.Add("17:30");
                    c.Items.Add("17:45");
                    c.Items.Add("18:00");
                    c.Text = "---:---";

                }
                
            }
        }

        private void getAllControls()
        {
            weekDaysCheckBoxes.Add(chbMon);
            weekDaysCheckBoxes.Add(chbTue);
            weekDaysCheckBoxes.Add(chbWed);
            weekDaysCheckBoxes.Add(chbThu);
            weekDaysCheckBoxes.Add(chbFri);
            weekDaysCheckBoxes.Add(chbSat);
            weekDaysCheckBoxes.Add(chbSun);

            breaksCheckBoxes.Add(chbRestMon);
            breaksCheckBoxes.Add(chbRestTue);
            breaksCheckBoxes.Add(chbRestWed);
            breaksCheckBoxes.Add(chbRestThu);
            breaksCheckBoxes.Add(chbRestFri);
            breaksCheckBoxes.Add(chbRestSat);
            breaksCheckBoxes.Add(chbRestSun);

            startTimeList.Add(cbMonStart);
            startTimeList.Add(cbTueStart);
            startTimeList.Add(cbWedStart);
            startTimeList.Add(cbThuStart);
            startTimeList.Add(cbFriStart);
            startTimeList.Add(cbSatStart);
            startTimeList.Add(cbSunStart);

            endTimeList.Add(cbMonEnd);
            endTimeList.Add(cbTueEnd);
            endTimeList.Add(cbWedEnd);
            endTimeList.Add(cbThuEnd);
            endTimeList.Add(cbFriEnd);
            endTimeList.Add(cbSatEnd);
            endTimeList.Add(cbSunEnd);

            restStartList.Add(cbRestMonStart);
            restStartList.Add(cbRestTueStart);
            restStartList.Add(cbRestWedStart);
            restStartList.Add(cbRestThuStart);
            restStartList.Add(cbRestFriStart);
            restStartList.Add(cbRestSatStart);
            restStartList.Add(cbRestSunStart);

            restEndList.Add(cbRestMonEnd);
            restEndList.Add(cbRestTueEnd);
            restEndList.Add(cbRestWedEnd);
            restEndList.Add(cbRestThuEnd);
            restEndList.Add(cbRestFriEnd);
            restEndList.Add(cbRestSatEnd);
            restEndList.Add(cbRestSunEnd);

        }

        public List<CheckBox> getDaysCheckBoxes()
        {
            return this.weekDaysCheckBoxes;
        }
        public List<CheckBox> getBreakesCheckBoxes()
        {
            return this.breaksCheckBoxes;
        }
        public List<ComboBox> getStartTimeComboBoxes()
        {
            return this.startTimeList;
        }
        public List<ComboBox> getEndTimeComboBoxes()
        {
            return this.endTimeList;
        }
        public List<ComboBox> getRestStartComboBoxes()
        {
            return this.restStartList;
        }
        public List<ComboBox> getRestEndComboBoxes()
        {
            return this.restEndList;
        }

        private void dayChecked(object sender, EventArgs e)
        {
            presenter.dayCheckChanged(sender as CheckBox);
        }

        private void restChecked(object sender, EventArgs e)
        {
            presenter.restCheckChanged(sender as CheckBox);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            presenter.setWorkDaysToWorker();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            presenter.disableDays();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
