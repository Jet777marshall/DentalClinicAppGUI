using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class viewpat : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public viewpat()
        {
            InitializeComponent();
            DisplayData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtpatientid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtfirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            date.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtnumber.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtemercon.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtmedhistory.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("select * from dentaldb.receptionistdb", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtpatientid.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtgender.Text = "";
            txtaddress.Text = "";
            txtnumber.Text = "";
            txtemail.Text = "";
            txtaddress.Text = "";
            txtemercon.Text = "";
            txtmedhistory.Text = "";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
