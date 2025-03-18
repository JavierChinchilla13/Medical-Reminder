using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;

namespace ProyectoMedicamento
{
    public partial class Menu : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
        public Menu()
        {
            InitializeComponent();
        }
        public static int hour, minute, second, day, month, year;
        

        private void btnCalendar_Click_1(object sender, EventArgs e)
        {
            PanelSubmenu.Visible = true;
            AbrirCalendar(new Calendar1());
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            PanelSubmenu.Visible = true;
            AbrirHistory(new History());
        }
        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            PanelSubmenu.Visible = false;
            AbrirSearch(new Buscador());
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            PanelSubmenu.Visible = false;
            AbrirHelp(new Help());
        }

        private void AbrirHelp(object form5)
        {
            if (this.panelContenedor1.Controls.Count > 0)
                this.panelContenedor1.Controls.RemoveAt(0);
            Help about = form5 as Help;
            about.TopLevel = false;
            about.Dock = DockStyle.Fill;
            this.panelContenedor1.Controls.Add(about);
            this.panelContenedor1.Tag = about;
            about.Show();
        }
        private void AbrirHistory(object form4)
        {
            if (this.panelContenedor1.Controls.Count > 0)
                this.panelContenedor1.Controls.RemoveAt(0);
            History lista = form4 as History;
            lista.TopLevel = false;
            lista.Dock = DockStyle.Fill;
            this.panelContenedor1.Controls.Add(lista);
            this.panelContenedor1.Tag = lista;
            lista.Show();
        }
        
        private void AbrirCalendar(object form1)
        {
            if (this.panelContenedor1.Controls.Count > 0)
                this.panelContenedor1.Controls.RemoveAt(0);

            Calendar1 calendar = form1 as Calendar1;
            calendar.TopLevel = false;

            calendar.Dock = DockStyle.Fill;
            this.panelContenedor1.Controls.Add(calendar);
            this.panelContenedor1.Tag = calendar;
            calendar.Show();

        }
        private void AbrirSearch(object form3)
        {
            if (this.panelContenedor1.Controls.Count > 0)
                this.panelContenedor1.Controls.RemoveAt(0);

            Buscador search = form3 as Buscador;
            search.TopLevel = false;

            search.Dock = DockStyle.Fill;
            this.panelContenedor1.Controls.Add(search);
            this.panelContenedor1.Tag = search;
            search.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void btnSalir1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax1.Visible = false;
            btnRestaurar1.Visible = true;
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestaurar1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar1.Visible = false;
            btnMax1.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            second = DateTime.Now.Second;
            minute = DateTime.Now.Minute;
            hour = DateTime.Now.Hour;
            day = DateTime.Now.Day;
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;   
            lblTime.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
            lblDate.Text = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            Alarm();
        }

        private void Alarm()
        {
            
            String sql = "SELECT * FROM Schedule INNER JOIN Med ON Schedule.idMed = Med.id where Schedule = '" + hour.ToString() + ":" + minute.ToString() + ":" + second.ToString() + "'" + "AND DateM='" + day.ToString() + "/" + month.ToString() + "/" + year.ToString() + "'";
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "It's time for";
                popup.ContentText = reader["NameM"].ToString();
                
                popup.Popup();

                Time add = new Time();
                add.Show();

            }
           
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        private void User()
        {
            conn.Open();
            String sql = "select * from Log WHERE id = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtUser.Text = reader["Users"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            timer1.Start();

            User();


            
        }
    }
}
