using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp27;
using System.Data.SqlClient;
using System.Timers;
using System.Threading;

namespace Diplom_one
{

    public partial class Form1 : Form
    {
        public Form1(string data)
        {
            Program.f1 = this;
            InitializeComponent();
            UpdateFlow();

            textBox2.Text = data;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");

            string query = "Select * FROM Users WHERE id = " + Convert.ToInt32(data);

            SqlCommand cmd = new SqlCommand(query, sqlcon);

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            //  DataTable dtbl = new DataTable();
            //  sda.Fill(dtbl);

            sqlcon.Open();
            using (SqlDataReader read = cmd.ExecuteReader())
            {

                if (read.Read())
                {
                    string secname = Convert.ToString(read["SecondName"]);
                    bool manager = Convert.ToBoolean(read["Manager"]);
                    string name = Convert.ToString(read["Name"]);



                    if (manager == false)
                    {
                        //   textBox1.Hide();
                        label1.Hide();
                        button1.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                    }
                    textBox1.Text = name + " " + secname;
                    textBox2.Text = data;
                }
                sqlcon.Close();

                /*
                //?  
            //    SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");

             //   string query = "Select * FROM Users WHERE id = " + Convert.ToInt32(data);

               // SqlCommand cmd = new SqlCommand(query, sqlcon);

        //        SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                //  DataTable dtbl = new DataTable();
                //  sda.Fill(dtbl);

                sqlcon.Open();
                bool manager = false;
      //          using (SqlDataReader read = cmd.ExecuteReader())
        //        {

                    if (read.Read())
                    {
                        manager = Convert.ToBoolean(read["Manager"]);
                        if (manager == false)
                        {
                            textBox1.Hide();
                        }

                //    }
                }
                sqlcon.Close();
            }
                */
            }
            UserControl1 user1 = new UserControl1();
           if( user1.button1.DialogResult == DialogResult.OK)
            {
                UpdateFlow();
            }
        }



        void MyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  UpdateFlow();
        }
        public void UpdateFlow()
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");

            string query = "Select * from Task  where Executor = '"+  textBox2.Text +"'";

            SqlCommand cmd = new SqlCommand(query, sqlcon);

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            sqlcon.Open();

            foreach (Control control in flowLayoutPanel1.Controls) //Delete all tasks in collumn 1,2,3
            {
                flowLayoutPanel1.Controls.Clear();
                control.Dispose();
            }

            foreach (Control control in flowLayoutPanel2.Controls) //Delete all tasks in collumn 1,2,3
            {
                flowLayoutPanel2.Controls.Clear();
                control.Dispose();
            }

            foreach (Control control in flowLayoutPanel3.Controls) //Delete all tasks in collumn 1,2,3
            {
                flowLayoutPanel3.Controls.Clear();
                control.Dispose();
            }
            ///////////////////////////////////////////////////

            int posit;

            using (SqlDataReader read = cmd.ExecuteReader())
            {

                for (int i = 1; i <= dtbl.Rows.Count; i++)
                {
                    UserControl1 x = new UserControl1();

                    if (read.Read())
                    {
                        x.mylabel.Text = read.GetString(1).ToString();
                        x.mybutton.Text = read.GetString(2).ToString();
                        posit = Convert.ToInt32(read["Position"]);
                        x.mylabelid.Text = Convert.ToString(read["id"]);

                        if (posit == 2)
                        {
                            flowLayoutPanel1.Controls.Add(x);

                            x.mybuttonprog.Visible = false;
                        }

                        if (posit == 1)
                        {
                            flowLayoutPanel2.Controls.Add(x);
                            x.mybuttontodo.Visible = false;
                        }

                        if (posit == 3)
                        {
                            flowLayoutPanel3.Controls.Add(x);
                            x.mybuttondone.Visible = false;
                        }

                    }

                }
            }



            // flowLayoutPanel2.Controls.Add(xx);
            // flowLayoutPanel3.Controls.Add(xxx);
            //   }


            if (dtbl.Rows.Count == 1)
            {
                //  Form1 formmain = new Form1();
                //  this.Hide();
                //  formmain.Show();
            }
            else
            {
                //       MessageBox.Show("Incorrect login or password!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet1.Task". При необходимости она может быть перемещена или удалена.
            this.taskTableAdapter.Fill(this.mixTaskDataSet1.Task);
            //UpdateFlow();
            foreach (Control control in Controls)
            {
                //    control.Enter += ControlReceivedFocus;
            }

        }

         public void buttoncheck(bool buttonclick)
        {
            if(buttonclick == true)
            {
                UpdateFlow();
            }
        }

        void ControlReceivedFocus(object sender, EventArgs e)
        {
            UpdateFlow();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string data = textBox2.Text;

              SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");

               string query = "Select * FROM Users WHERE id = " + Convert.ToInt32(data);

             SqlCommand cmd = new SqlCommand(query, sqlcon);

                   SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);


            sqlcon.Open();
            bool manager = false;

           using (SqlDataReader read = cmd.ExecuteReader())
           {

             if (read.Read())
              {
                manager = Convert.ToBoolean(read["Manager"]);
                if (manager == false)
                {
                    label1.Hide();
                }

              }
            }
            sqlcon.Close();

            Form3 form3 = new Form3(manager, data);

            form3.Show();
            UpdateFlow();


        }                                                   
        


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            registration form2 = new registration();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Closed += (s, args) => this.Close();
            log.Show();

            //Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            data_test datat = new data_test();

            datat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registert regt = new Registert();

            regt.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserControl1 x = new UserControl1();
            UserControl1 xx = new UserControl1();
            UserControl1 xxx = new UserControl1();

           // x.mybutton.Text = "VICTORY";    

            flowLayoutPanel1.Controls.Add(x);
            flowLayoutPanel2.Controls.Add(xx);
            flowLayoutPanel3.Controls.Add(xxx);
        }

        public void button7_Click(object sender, EventArgs e)
        {
            UpdateFlow();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }
    }
}
