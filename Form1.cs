
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using ProyectoMedicamento.Models;

namespace ProyectoMedicamento
{
    public partial class Form1 : Form
    {

        
        public static String idLog = " ";
        public static String idLOG = " ";
        public static String USER = " ";
        public Form1()
        {
            InitializeComponent();
            
        }
       

        public void button1_Click_1(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
            String querry = "SELECT * FROM Log WHERE CONVERT(VARCHAR, Users) = '" + txtUser.Text.Trim() + "' AND Pass = '" + txtPass.Text.Trim() + "';";
            conn.Open();
            
            USER= txtUser.Text.Trim();  


        SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Clear();
                txtPass.Clear();

                txtUser.Focus();
            }

        }


 
        private void button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint ="ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void TittleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TittleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}