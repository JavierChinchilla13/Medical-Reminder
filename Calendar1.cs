using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMedicamento
{
    public partial class Calendar1 : Form
    {
        int month, year;

        public static int staticMonth, staticYear;
        public Calendar1()
        {
            InitializeComponent();
        }
        private void displaDays()
        {

            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            
            

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            staticMonth = month;
            staticYear = year;


            DateTime startofthemonth = new DateTime(year, now.Month, 1);
            int days = DateTime.DaysInMonth(year, now.Month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 2; i <= dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.day(i);
                daycontainer.Controls.Add(ucdays);
            }
        }
        private void btnnext_Click(object sender, EventArgs e)
        {
           

        }

        private void btnnext_Click_1(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            if (month != 12)
            {
                month++;
            }
            else
            {
                month = 1;
                year++;
            }
            staticMonth = month;
            staticYear = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);

            LBDATE.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);



            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 2; i <= dayoftheweek; i += 1)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.day(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void btnprevious_Click_1(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();

            if (month != 1)
            {
                month--;
            }
            else
            {
                month = 12;
                year--;
            }


            staticMonth = month;
            staticYear = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);

            LBDATE.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);



            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 2; i <= dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.day(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
          
        }

        private void Calendar1_Load(object sender, EventArgs e)
        {
            displaDays();
        }
    }
}
