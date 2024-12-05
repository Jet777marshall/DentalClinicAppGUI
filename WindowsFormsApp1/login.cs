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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public login()
        {
            InitializeComponent();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {

            if (txtuser.Text != "" && txtpass.Text != "" && comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem?.ToString() == "Doctor")
                {
                    if (txtpass.Text != "" && txtuser.Text != "")
                    {

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM dentaldb.doctortb WHERE username = @Username AND Password = @Password", con);
                        cmd.Parameters.AddWithValue("@Username", txtuser.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpass.Text);

                        con.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dentist dentist = new dentist();
                            dentist.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Username and password do not match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }

                    else
                    {
                        MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                if (comboBox1.SelectedItem?.ToString() == "Recepsionist")
                {
                    if (txtpass.Text != "" && txtuser.Text != "")
                    {

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM dentaldb.accreccep WHERE Username = @Username AND Password = @Password", con);
                        cmd.Parameters.AddWithValue("@Username", txtuser.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpass.Text);

                        con.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            patience patience = new patience();
                            patience.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Username and password do not match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("Fill out all the information needed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


              

        }

        private void gunaTransfarantPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
