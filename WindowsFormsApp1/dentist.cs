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

    public partial class dentist : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public dentist()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {

            // Checks if Username Exists
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM dentaldb.patiencetb WHERE ProcedureID = @ProcedureID", con);
            cmd1.Parameters.AddWithValue("@ProcedureID", txtprocedureid.Text);
            con.Open();
            bool userExists = false;
            using (var dr1 = cmd1.ExecuteReader())
                if (userExists = dr1.HasRows)
                    MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            con.Close();

            // Adds a User in the Database
            if (!(userExists))

            {

                if (txtfirstname.Text != "" &&
                   txtlastname.Text != "" &&
                   txtprocedurename.Text != "" &&
                   txtprocedurecost.Text != "" &&
                   txtexcutetime.Text != "")
                {
                    cmd = new MySqlCommand("insert into dentaldb.patiencetb(ProcedureID,Firstname,Lastname,Procedurename,Procedurecost,Executedate,Executetime) " +
                                           "values(@ProcedureID,@Firstname,@Lastname,@Procedurename,@Procedurecost,@Executedate,@Executetime)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ProcedureID", txtprocedureid.Text);
                    cmd.Parameters.AddWithValue("@Firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@Lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@Procedurename", txtprocedurename.Text);
                    cmd.Parameters.AddWithValue("@Procedurecost", txtprocedurecost.Text);
                    cmd.Parameters.AddWithValue("@Executedate", dbexecute.Text);
                    cmd.Parameters.AddWithValue("@Executetime", txtexcutetime.Text);
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
            adapt = new MySqlDataAdapter("select * from dentaldb.patiencetb", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtprocedureid.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtprocedurename.Text = "";
            txtprocedurecost.Text = "";
            txtexcutetime.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtprocedureid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtfirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtprocedurename.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtprocedurecost.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dbexecute.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtexcutetime.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "" &&
                txtlastname.Text != "" &&
                txtprocedurename.Text != "" &&
                txtprocedurecost.Text != "" &&
                txtexcutetime.Text != "")
            {
                cmd = new MySqlCommand("update dentaldb.patiencetb set Firstname=@Firstname,Lastname=@Lastname," +
                                       "Procedurename=@Procedurename,Procedurecost=@Procedurecost,Executedate=@Executedate," +
                                       "Executetime=@Executetime where ProcedureID=@ProcedureID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ProcedureID", txtprocedureid.Text);
                cmd.Parameters.AddWithValue("@Firstname", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@Lastname", txtlastname.Text);
                cmd.Parameters.AddWithValue("@Procedurename", txtprocedurename.Text);
                cmd.Parameters.AddWithValue("@Procedurecost", txtprocedurecost.Text);
                cmd.Parameters.AddWithValue("@Executedate", dbexecute.Text);
                cmd.Parameters.AddWithValue("@Executetime", txtexcutetime.Text);
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

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (txtfirstname.Text != "" &&
                txtlastname.Text != "" &&
                txtprocedurename.Text != "" &&
                txtprocedurecost.Text != "" &&
                txtexcutetime.Text != "")
            {
                cmd = new MySqlCommand("delete from dentaldb.patiencetb where ProcedureID=@ProcedureID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ProcedureID", txtprocedureid.Text);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            docinfo docinfo = new docinfo();
            docinfo.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createaccrecep createaccrecep = new createaccrecep();
            createaccrecep.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewpat viewpat = new viewpat();
            viewpat.Show();
            

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {


            string searchText = txtsearch.Text.Trim();


            string connection = "datasource=localhost;port=3306;username=root;password=;database=dentaldb";

            string query = "SELECT * FROM patiencetb WHERE ProcedureID  LIKE @SearchText OR ProcedureID LIKE @SearchText OR Lastname LIKE @SearchText";

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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void recepview_btn_Click(object sender, EventArgs e)
        {

            recepsionistinfo recepsionistinfo = new recepsionistinfo();
            recepsionistinfo.Show();

        }
    }
}
