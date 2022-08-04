using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diplom_one
{
    public partial class Form4 : Form
    {
        public Form4(int id)
        {

            InitializeComponent();
            textBox1.Text = id.ToString();
          //  textBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            //  SqlDataAdapter da;

            SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");
            sqlcon.Open();

            cmd = new SqlCommand($"INSERT INTO Register (Login, Password, User_id) Values (@Login, @Password, @User_id)", sqlcon);

            cmd.Parameters.AddWithValue("Login", Logintext.Text);
            cmd.Parameters.AddWithValue("Password", Passtext.Text);
            cmd.Parameters.AddWithValue("User_id", Convert.ToInt32(textBox1.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("Registration successful!");
            this.Hide();
            Login log = new Login();
            log.Closed += (s, args) => this.Close();
            log.Show();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Logintext_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
