using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
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
    public partial class recepsionistinfo : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public recepsionistinfo()
        {

            InitializeComponent();
            DisplayData();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "" &&
               txtlastname.Text != "" &&
               txtaddress.Text != "" &&
               cbgender.Text != "" &&
               txtpassword.Text != "" )
             
            {
                cmd = new MySqlCommand("update dentaldb.accreccep set Firstname=@Firstname,Lastname=@Lastname," +
                                       "gender=@gender,DateOfBirth=@DateOfBirth,Address=@Address," +
                                       "Username=@Username,Password=@Password where ReceptionistID=@ReceptionistID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ReceptionistID", txtrecepsionist.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@gender", cbgender.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dbdateofbirth.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
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
            adapt = new MySqlDataAdapter("select * from dentaldb.accreccep", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtrecepsionist.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            cbgender.Text = "";
            txtaddress.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtrecepsionist.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtfirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbgender.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dbdateofbirth.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtusername.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtpassword.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
