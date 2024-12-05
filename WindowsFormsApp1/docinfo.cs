using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class docinfo : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public docinfo()
        {
            InitializeComponent();
            DisplayData();
          
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != ""  && txtpassword.Text != "")
            {
                cmd = new MySqlCommand("update dentaldb.doctortb set username=@name, Password=@pass ", con);
                con.Open();
              
                cmd.Parameters.AddWithValue("@name", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Successfully Updated", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select the record you want to Update", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("select * from dentaldb.doctortb", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
        
         

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
