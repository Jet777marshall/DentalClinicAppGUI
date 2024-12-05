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
    public partial class createaccrecep : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public createaccrecep()
        {
            InitializeComponent();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "" &&
               txtlastname.Text != "" &&
               txtaddress.Text != "" &&
               txtusername.Text != "" &&
               txtpass1.Text != "" &&
               txtpass2.Text != "")
            {
                if (txtpass1.Text == txtpass2.Text)
                {
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO dentaldb.accreccep (ReceptionistID, FirstName, LastName, gender, DateOfBirth, Address, Username, Password) " +
                                                "VALUES (@ReceptionistID, @FirstName, @LastName, @gender, @DateOfBirth, @Address, @Username, @Password)", con);

                        con.Open();
                        cmd.Parameters.AddWithValue("@ReceptionistID", txtrecepsionistid.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                        cmd.Parameters.AddWithValue("@gender", cbgender.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dtbirth.Text);
                        cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpass2.Text); 

                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Record Successfully Added", "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException ex)
                    {
                        
                        if (ex.Number == 1062)
                        {
                            MessageBox.Show("A record with the same Receptionist ID or Username already exists. Please use a different ID or Username.", "Duplicate Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                          
                            MessageBox.Show("An error occurred while trying to insert the record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match. Please enter the same password.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txt_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
