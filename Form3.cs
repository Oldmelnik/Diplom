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
    public partial class Form3 : Form
    {
        public Form3(bool manager,string data)
        {
            InitializeComponent();

            comboBox1.SelectedItem = data;
            executorTextBox1.Text = data;
            //datatxt.Text = data;
            if (manager == false)
            {

                comboBox1.Hide();
                label4.Hide();
                executorTextBox1.Hide();
            }
        }




        private void Form3_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet11.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.mixTaskDataSet11.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet11.Task". При необходимости она может быть перемещена или удалена.
            this.taskTableAdapter.Fill(this.mixTaskDataSet11.Task);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.f1.UpdateFlow();
            this.Hide();
        }

        private void taskBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taskBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mixTaskDataSet11);

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (titleTextBox.Text != "" & titleTextBox1.Text != "") {
             //   string datas = datatxt.Text;

                if (comboBox1.Visible)
                {
                    executorTextBox1.Text = comboBox1.SelectedValue.ToString();
                }
                /* THIS IS WORK
               // executorTextBox1.Text = comboBox1.Text;

                taskBindingSource.AddNew();
                taskBindingSource.EndEdit();
                taskTableAdapter.Update(mixTaskDataSet11);

                */

                SqlCommand cmd;
                //  SqlDataAdapter da;

                SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");
                sqlcon.Open();
                // string query = "INSERT INTO Task (Title, Description, Executor, Position) Values (@Name//++","+titleTextBox1.Text.Trim()+ "," + executorTextBox1.Text.Trim()+ "," + "1";

                cmd = new SqlCommand($"INSERT INTO Task (Title, Description, Executor, Position) Values (@title, @text, @executor, @position)", sqlcon);

                cmd.Parameters.AddWithValue("title", titleTextBox.Text);
                cmd.Parameters.AddWithValue("text", titleTextBox1.Text);
                cmd.Parameters.AddWithValue("executor", executorTextBox1.Text);

                cmd.Parameters.AddWithValue("position", 1);
                cmd.ExecuteNonQuery();
                //  SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                //    DataTable dtbl = new DataTable();
                //   sda.Fill(dtbl);
                MessageBox.Show("Task added");


                //  var form1 = new Form1();
                //    form1.UpdateFlow();


                //Program.mf.UpdateFlow();
                Program.f1.UpdateFlow();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Some Fileds are empty");
            }
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void executorTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void titleTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
