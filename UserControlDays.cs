using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoMedicamento
{
    public partial class UserControlDays : UserControl 
    {
        public static String staticDay;
        
        

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            
        }
        public void day(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            staticDay = lbdays.Text;
            Medicamento add = new Medicamento();
            add.Show();
        }
        private void display()
        {
            

        }

        private void lblAdd_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void lbdays_Click(object sender, EventArgs e)
        {

        }
    }
}
