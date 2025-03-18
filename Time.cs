using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMedicamento
{
    public partial class Time : Form
    {
        public Time()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");

        SoundPlayer player = new SoundPlayer();
        private void Time_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "SELECT * FROM Schedule INNER JOIN Med ON Schedule.idMed = Med.id where Schedule = '" + Menu.hour + ":" + Menu.minute + ":" + Menu.second + "'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblTreatment.Text = reader["NameM"].ToString();
                lblInfo.Text = reader["Info"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();

            
            player.SoundLocation = @"D:\alarm.wav";

            player.PlayLooping(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            player.Stop();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TittleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
