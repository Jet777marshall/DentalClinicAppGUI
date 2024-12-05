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
using Mysqlx.Prepare;

namespace WindowsFormsApp1
{
    public partial class patience : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public patience()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            // Checks if Username Exists
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM dentaldb.receptionistdb WHERE PatienceID = @PatienceID", con);
            cmd1.Parameters.AddWithValue("@PatienceID", txtpatientid.Text);
            con.Open();
            bool userExists = false;
            using (var dr1 = cmd1.ExecuteReader())
                if (userExists = dr1.HasRows)
                    MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            con.Close();

            // Adds a User in the Database
            if (!(userExists))
            {

                if(txtfirstname.Text != "" &&
                   txtlastname.Text != "" &&
                   txtgender.Text != "" &&
                   txtnumber.Text != "" &&
                   txtemail.Text != "" &&
                   txtaddress.Text != "" &&
                   txtemercon.Text != "" &&
                   txtmedhistory.Text != "")
                {
                    cmd = new MySqlCommand("insert into dentaldb.receptionistdb(PatienceID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Email, Address, EmergencyContact, MedicalHistory) " +
                                           "values(@PatienceID, @FirstName, @LastName, @DateOfBirth, @Gender, @PhoneNumber, @Email, @Address, @EmergencyContact, @MedicalHistory)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@PatienceID", txtpatientid.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", date.Text);
                    cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtnumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@EmergencyContact", txtemercon.Text);
                    cmd.Parameters.AddWithValue("@MedicalHistory", txtmedhistory.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Successfully Added", "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();
                    ClearData();


                }
            else
                {
                    MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "" &&
                txtlastname.Text != "" &&
                txtgender.Text != "" &&
                txtnumber.Text != "" &&
                txtemail.Text != "" &&
                txtaddress.Text != "" &&
                txtemercon.Text != "" &&
                txtmedhistory.Text != "")
            {
                cmd = new MySqlCommand("update dentaldb.receptionistdb set FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, " +
                               "Gender = @Gender, PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address, " +
                               "EmergencyContact = @EmergencyContact, MedicalHistory = @MedicalHistory " +
                               "where PatienceID = @PatienceID", con);
                con.Open();

                cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", date.Text);
                cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtnumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@EmergencyContact", txtemercon.Text);
                cmd.Parameters.AddWithValue("@MedicalHistory", txtmedhistory.Text);
                cmd.Parameters.AddWithValue("@PatienceID", txtpatientid.Text);
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "" &&
                txtlastname.Text != "" &&
                txtgender.Text != "" &&
                txtnumber.Text != "" &&
                txtemail.Text != "" &&
                txtaddress.Text != "" &&
                txtemercon.Text != "" &&
                txtmedhistory.Text != "")
            {
                cmd = new MySqlCommand("delete from  dentaldb.receptionistdb where PatienceID=@PatienceID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@PatienceID", txtpatientid.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Successfully Deleted", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select the record you want to Delete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim();

           
            string connection = "datasource=localhost;port=3306;username=root;password=;database=dentaldb";

           
            string query = "SELECT * FROM receptionistdb WHERE PatienceID LIKE @SearchText OR LastName LIKE @SearchText OR PhoneNumber LIKE @SearchText";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    try
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (MySqlException mysqlEx)
                    {
                        MessageBox.Show("Database error: " + mysqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }
    }
    }

  
    

