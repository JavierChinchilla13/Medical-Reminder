using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMedicamento
{
    public partial class Schedule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public Schedule()
        {
            InitializeComponent();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbTreat.Text))
            {
                conn.Open();
                String sq = "Insert INTO Schedule(Schedule,idMed)VALUES('" + txtSchedule.Text + "', (SELECT id FROM Med WHERE CONVERT(VARCHAR, NameM) = '" + cbTreat.Text + "'AND DateM='" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'))";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sq;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("The treatment has been registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Please select a treatment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

            String querry = "SELECT Schedule, NameM FROM Schedule INNER JOIN Med ON Schedule.idMed = Med.id " +
                "where Med.DateM = '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'" + "AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";


            SqlDataAdapter cm = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            cm.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Med()
        {
            conn.Open();

            String sql = "select * from Med where DateM = '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'" +
                "AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";
            cmd = new SqlCommand(sql, conn);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                cbTreat.Items.Add(dr["NameM"]);
            }

            conn.Close();
        }
        private void createMed()
        {


            String querry = "SELECT Schedule, NameM FROM Schedule INNER JOIN Med ON Schedule.idMed = Med.id " +
                "where Med.DateM = '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'" + "AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";


            SqlDataAdapter cmd = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Schedule_Load(object sender, EventArgs e)
        {

            createMed();
            Med();

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSchedule.Text))
            {

                int cant = 0;

                String querry = "Delete Schedule Where Schedule='" + txtSchedule.Text + "'" + "AND CONVERT(VARCHAR, NameM) = '" + cbTreat + "' AND DateM='" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "')";


                SqlCommand sda = new SqlCommand(querry, conn);
                conn.Open();
                cant = sda.ExecuteNonQuery();

                
                    
                if (cant == 1)
                {
                    MessageBox.Show("Successfully deleted");
                }
                else
                {
                    MessageBox.Show("There is no treatment with that Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }



            }
            else
            {
                MessageBox.Show("Please select a treatment and correct time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            conn.Close();

            String query = "SELECT Schedule, NameM FROM Schedule INNER JOIN Med ON Schedule.idMed = Med.id " +
               "where Med.DateM = '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";


            SqlDataAdapter cm = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            cm.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
