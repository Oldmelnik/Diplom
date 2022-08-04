using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Diplom_one
{
    public partial class registration : Form
    {


        public registration()
        {
            InitializeComponent();
        }

    //    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
      //  DataSet ds;

      

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "")
            {
                //   SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");
                /*
                  string query = "insert into User(Name,SecondName,Otchestvo, Birthday, Manager, Telegramid) values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "' ,'" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text+"')";
                  SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                  DataTable dtbl = new DataTable();
                  sda.Fill(dtbl);
                */

                string sqlcon = @"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True";


                using (SqlConnection sqlconnect = new SqlConnection(sqlcon))
                {
                    sqlconnect.Open();
                    SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlconnect);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@SecondName", textBox2.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Otchestvo", textBox3.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Birthday", textBox4.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Manager", checkBox1.Checked);
                    sqlcmd.Parameters.AddWithValue("@Telegramid", textBox5.Text.Trim());

                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Now enter login and password");

                }

                string name;
                string secondname;
                int id = 0;
                using (SqlConnection sqlconnect = new SqlConnection(sqlcon))
                {
                    string query = "Select * FROM Users WHERE Name = '" + textBox1.Text + "' and SecondName = '" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlconnect);
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    sqlconnect.Open();
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {

                        if (read.Read())
                        {
                            name = Convert.ToString(read["Name"]);
                            secondname = Convert.ToString(read["SecondName"]);
                            id = Convert.ToInt32(read["id"]);
                        }


                    }
                    sqlconnect.Close();

                    this.Hide();
                    Form4 form4 = new Form4(id);
                    form4.Closed += (s, args) => this.Close();
                    form4.Show();



                }

            }
            else
            {
                MessageBox.Show("Some fields are empty");
            }

      
            /*
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
            }
            Console.Read();
            */
        }

        private void registration_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet1.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.mixTaskDataSet1.Users);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
