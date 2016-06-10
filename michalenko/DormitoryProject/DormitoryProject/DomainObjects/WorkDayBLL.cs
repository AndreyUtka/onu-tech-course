using DormitoryProject.DataAccessClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryProject.DomainObjects
{
    public class WorkDayBLL
    {
        public CheckBox day { get; set; }
        public CheckBox rest { get; set; }
        public ComboBox startTime { get; set; }
        public ComboBox endTime { get; set; }
        public ComboBox restStart { get; set; }
        public ComboBox restEnd { get; set; }

        public WorkDayBLL(CheckBox day,CheckBox rest,ComboBox startTime,ComboBox endTime,ComboBox restStart,ComboBox restEnd)
        {
            this.day = day;
            this.rest = rest;
            this.startTime = startTime;
            this.endTime = endTime;
            this.restStart = restStart;
            this.restEnd = restEnd;
        }
        public void setWorkDayBLLFromDAL(WorkDayDAL workDay)
        {
            if(!string.IsNullOrWhiteSpace(workDay.startTime))
            {
                this.startTime.Text = workDay.startTime;
            }
            if (!string.IsNullOrWhiteSpace(workDay.day))
            {
                this.day.Text = workDay.day;
            }
            if (!string.IsNullOrWhiteSpace(workDay.endTime))
            {
                this.endTime.Text = workDay.endTime;
            }
            if (workDay.restStart==null)
            {
                this.restStart.Text = "----";
            }
            else
            {
                this.restStart.Text = workDay.restStart;
            }
            if(workDay.restEnd==null)
            {
                this.restEnd.Text = "----";
            }
            else
            {
                this.restEnd.Text = workDay.restEnd;
            }
        }

        public void getWorkingTimeForWorkDayDAL(ref WorkDayDAL day)
        {
            day.day = this.day.Text;
            day.startTime = this.startTime.Text;
            day.endTime = this.endTime.Text;
        }
        public void getRestTimeForWorkDAL(ref WorkDayDAL day)
        {
            day.restStart = this.restStart.Text;
            day.restEnd = this.restEnd.Text;
        }

        public void enableWorkTime()
        {
            
            this.startTime.Enabled = true;
            this.endTime.Enabled = true;
            this.rest.Enabled = true;

        }
        public void disableWorkTime()
        {
            this.day.Checked = false;
            this.startTime.Enabled = false;
            this.startTime.Text = "---:---";
            this.endTime.Enabled = false;
            this.endTime.Text = "---:---";
            this.rest.Enabled = false;
            this.rest.Checked = false;
        }

        public void enableDay()
        {
            enableWorkTime();
            enableRestTime();
        }
        public void disableDay()
        {
            disableWorkTime();
            disableRestTime();
        }

        public void enableRestTime()
        {
            this.restStart.Enabled = true;
            this.restEnd.Enabled = true;
        }
        public void disableRestTime()
        {
            this.restStart.Enabled = false;
            this.restStart.Text = "---:---";
            this.restEnd.Enabled = false;
            this.restEnd.Text = "---:---";
        }
    }
}
