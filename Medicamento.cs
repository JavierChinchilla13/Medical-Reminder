using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoMedicamento.Models;
using System.Runtime.InteropServices;

namespace ProyectoMedicamento
{
    public partial class Medicamento : Form
    {
        ProyectoContext context = new ProyectoContext();
        Med user;
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
        public static String Name = " ";
        public static int hour, minute, second;
        DataSet ds = new DataSet();
        public Medicamento()
        {
            InitializeComponent();
        }
        int filaSeleccionada;
        private void Medicamento_Load(object sender, EventArgs e)
        {
            txtdate.Text = UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear;
            

            showMed();
        }
        private void showMed()
        {


            String querry = "SELECT NameM,Info,TypeM,DoseM FROM Med where DateM = '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'" +
                 "AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";

            SqlDataAdapter cmd = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void create_Click(object sender, EventArgs e)
        {
            registerUser();
            String querry = "SELECT NameM,Info,TypeM,DoseM FROM Med where DateM = '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'" +
                "AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";

            

            SqlDataAdapter cmd = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;




        }
        public void registerUser()
        {
            SqlCommand cm = new SqlCommand("Select * from Med WHERE CONVERT(VARCHAR, NameM)= '" + txtName.Text + "'" + "AND DateM= '" + UserControlDays.staticDay + "/" + Calendar1.staticMonth + "/" + Calendar1.staticYear + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                MessageBox.Show("Treatment " + txtName.Text + " already used in this day", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds.Clear();
            }
            else if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtType.Text) &&  !string.IsNullOrEmpty(txtDose.Text) && !string.IsNullOrEmpty(txtdate.Text))
            {
                conn.Open();
                
                String sql = "Insert INTO Med(NameM, TypeM, DoseM, DateM, Info, idLog)VALUES('"+txtName.Text+"', '"+txtType.Text+"',  '"+ Int32.Parse(txtDose.Text.ToString()) + "', '"+ txtdate.Text + "', '"+txtInfo.Text+"', (SELECT id FROM Log  WHERE CONVERT(VARCHAR, Users) = '" + Form1.USER + "'))";
                
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                

                cmd.ExecuteNonQuery();
                
                conn.Close();
                MessageBox.Show("The treatment has been registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                

            }
            else
            {
                MessageBox.Show("Please add information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            

            
        }
        private void medList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
            

            

        }

        private void update_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Schedule time = new Schedule();
            time.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        
    }
}
