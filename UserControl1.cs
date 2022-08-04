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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public Button mybutton
        {
            get { return tasktext; }
        }

        public Button mybuttontodo
        {
            get { return button2; }
        }
   
        public Label mylabel
        {
            get { return label1;  }
        }

        public Button mybuttonprog
         {
            get { return button3; }
        }

        public Button mybuttondone
        {
           get { return button1;  }

       }

        public Label mylabelid
        {
            get { return taskid; }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        SqlCommand cmd;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");
            sqlcon.Open();

            string posit = taskid.Text;
            cmd = new SqlCommand($"Update  Task  SET position  = 3 WHERE id =  " + taskid.Text, sqlcon);

            cmd.Parameters.AddWithValue("position", 1);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
           // MessageBox.Show("Task edited");
            button1.DialogResult = DialogResult.OK;

            Program.f1.UpdateFlow();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");
            sqlcon.Open();

            string posit = taskid.Text;
            cmd = new SqlCommand($"Update  Task  SET position  = 1 WHERE id =  "+taskid.Text, sqlcon);

            cmd.Parameters.AddWithValue("position", 1);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
           // MessageBox.Show("Task edited");

            Program.f1.UpdateFlow();
        }

        private void tasktext_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");
            sqlcon.Open();

            string posit = taskid.Text;
            cmd = new SqlCommand($"Update  Task  SET position  = 2 WHERE id =  " + taskid.Text, sqlcon);

            cmd.Parameters.AddWithValue("position", 1);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
           // MessageBox.Show("Task edited");

            Program.f1.UpdateFlow();
        }

        private void taskid_Click(object sender, EventArgs e)
        {

        }
    }
}
