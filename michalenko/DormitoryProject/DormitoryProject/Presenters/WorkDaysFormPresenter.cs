using DormitoryProject.DataAccessClasses;
using DormitoryProject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryProject.Presenters
{
    public class WorkDaysFormPresenter
    {
        private WorkDaysForm form;
        private List<WorkDayBLL> week;
        private WorkerTicketBLL worker;
        public WorkDaysFormPresenter(WorkDaysForm form,WorkerTicketBLL worker)
        {
            this.form = form;
            this.worker = worker;
            initWeek();
            disableDays();
        }

        private void initWeek()
        {
            week = new List<WorkDayBLL>();
            List<CheckBox> days = form.getDaysCheckBoxes();
            List<CheckBox> breaks = form.getBreakesCheckBoxes();

            List<ComboBox> start = form.getStartTimeComboBoxes();
            List<ComboBox> end = form.getEndTimeComboBoxes();
            List<ComboBox> restStart = form.getRestStartComboBoxes();
            List<ComboBox> restEnd = form.getRestEndComboBoxes();

            for (int i=0;i<7;i++)
            {
                week.Add(new WorkDayBLL(days[i], breaks[i], start[i], end[i], restStart[i], restEnd[i]));
            }
        }

        public void disableDays()
        {
            foreach(WorkDayBLL day in week)
            {
                day.disableDay();
            }
        }
        public void enableDays()
        {
            foreach(WorkDayBLL day in week)
            {
                day.enableDay();
            }
        }

        public void setWorkDaysToWorker()
        {
            worker.workDays = new List<WorkDayDAL>();
            foreach(WorkDayBLL day in week)
            {
                WorkDayDAL wdDAL = new WorkDayDAL();
                if(day.day.Checked)
                {
                    day.getWorkingTimeForWorkDayDAL(ref wdDAL);
                    if(day.rest.Checked)
                    {
                        day.getRestTimeForWorkDAL(ref wdDAL);
                    }
                    worker.workDays.Add(wdDAL);
                }
            }
        }

        public void dayCheckChanged(CheckBox box)
        {
            bool state = box.Checked;
            foreach(WorkDayBLL day in week)
            {
                if(day.day.Equals(box))
                {
                    if(state)
                    {
                        day.enableWorkTime();
                    }
                    else
                    {
                        day.disableDay();
                    }
                }
            }
        }

        public void restCheckChanged(CheckBox box)
        {
            bool state = box.Checked;
            foreach (WorkDayBLL day in week)
            {
                if (day.rest.Equals(box))
                {
                    if (state)
                    {
                        day.enableRestTime();
                    }
                    else
                    {
                        day.disableRestTime();
                    }
                }
            }
        }

    }
}
