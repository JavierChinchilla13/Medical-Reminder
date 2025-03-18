using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using ProyectoMedicamento.Models;
using System.Data.SqlClient;

namespace ProyectoMedicamento
{
    public partial class Signup : Form
    {
       
       
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        public Signup()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registerUser();
            
        }

        public void registerUser()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            if (Regex.IsMatch(txtEmail.Text, pattern) == false)
            {
                txtEmail.Focus();
                errorProvider1.SetError(this.txtEmail, "Enter a valid Email address");
                MessageBox.Show("Invalid email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
            else if(!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                SqlCommand cmd2 = new SqlCommand("Select * from Log WHERE CONVERT(VARCHAR, Mail)= '" + txtEmail.Text + "'", conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds2);
                int j = ds2.Tables[0].Rows.Count;

                SqlCommand cmd = new SqlCommand("Select * from Log WHERE CONVERT(VARCHAR, Users)= '" + txtUsername.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;    
                if (i > 0)
                {
                    MessageBox.Show("Username " + txtUsername.Text + " already exists");
                    ds.Clear();
                }
                else if (j > 0)
                {
                    MessageBox.Show("Mail adress " + txtEmail.Text + " already in use");
                    ds2.Clear();
                }
                

                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Insert into Log (Users,Mail,Pass,Edad)values('" + txtUsername.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + Int32.Parse(txtAge.Text.ToString()) + "')", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    MessageBox.Show("The user has been registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider1.Clear();
                }
                
                
               
            }     
            
            else
            {
                MessageBox.Show("Please add information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                
                
            }

         
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TittleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
