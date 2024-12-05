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
    public partial class sampling : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;

        public sampling()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Checks if Username Exists
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM sampling.gaming WHERE mouse = @mouse", con);
            cmd1.Parameters.AddWithValue("@mouse", txtmouse.Text);
            con.Open();
            bool userExists = false;
            using (var dr1 = cmd1.ExecuteReader())
                if (userExists = dr1.HasRows)
                    MessageBox.Show("Username not available!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            con.Close();
           
                // Adds a User in the Database
                if (!(userExists))
                {
                    cmd = new MySqlCommand("insert into sampling.gaming(mouse,keyboard,headset,monitor) " +
                        "values(@mouse,@keyboard,@headset,@monitor)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@mouse", txtmouse.Text);
                    cmd.Parameters.AddWithValue("@keyboard", txtkeyboard.Text);
                    cmd.Parameters.AddWithValue("@headset", txtheadset.Text);
                    cmd.Parameters.AddWithValue("@monitor", txtmonitor.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Successfully Added", "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Fill out all the information needed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }
    }
}
