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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-GF63-THIN;Initial Catalog=Proyecto;Integrated Security=True");
        private void History_Load(object sender, EventArgs e)
        {
            Form1 med = new Form1();

            String querry = "SELECT NameM,Info,DateM,DoseM,TypeM,id FROM Med  WHERE EXISTS(SELECT id FROM Log WHERE idLog = id AND CONVERT(VARCHAR, Users) = '" + Form1.USER +"')";


            SqlDataAdapter cmd = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
