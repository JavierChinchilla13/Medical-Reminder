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

namespace ProyectoMedicamento
{
    public partial class Buscador : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
        public Buscador()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            String querry = "SELECT id,NameM,Info,DateM,DoseM,TypeM  FROM Med WHERE CONVERT(VARCHAR, NameM) = '" + txtSearch.Text + "' AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "') " +
                "OR DateM = '" + txtDate.Text + "' AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";

            SqlDataAdapter cmd = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtNameB.Text) && !string.IsNullOrEmpty(cmbTypeB.Text) && !string.IsNullOrEmpty(txtDoseB.Text))
            {
                int cant = 0;
                String querry = "Update Med set NameM='" + txtNameB.Text + "',TypeM='" + cmbTypeB.Text + "',DoseM='" + Int32.Parse(txtDoseB.Text.ToString()) + "',Info='"+ txtInfo.Text +"' Where id='" + Int32.Parse(txtId.Text.ToString()) + "'AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "')";
                SqlCommand sda = new SqlCommand(querry, conn);
                conn.Open();
                cant = sda.ExecuteNonQuery();
                
                if(cant == 1)
                {
                    MessageBox.Show("Successfully updated");
                }
                else
                {
                    MessageBox.Show("There is no treatment with that Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNameB.Clear();
                    
                    txtId.Clear();
                    
                    
                }
                
            }
            else
            {
                MessageBox.Show("Please add information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                


            }
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                
                int cant = 0;
                String querry = "Delete Med Where id='" + Int32.Parse(txtId.Text.ToString()) + "'AND EXISTS (SELECT id FROM Log  WHERE idLog = id AND CONVERT(VARCHAR, Users)  = '" + Form1.USER + "') ";
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
                    txtNameB.Clear();
                    txtId.Clear();
                    

                }

            }
            else
            {
                MessageBox.Show("Please enter id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            conn.Close();
        }

        private void txtNameB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscador_Load(object sender, EventArgs e)
        {
           

        }


        
    }
}
