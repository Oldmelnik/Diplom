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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet1.Register". При необходимости она может быть перемещена или удалена.
            this.registerTableAdapter.Fill(this.mixTaskDataSet1.Register);

        }

        private void registerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mixTaskDataSet1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginf.Text != "" & passf.Text != "")
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=ULTRA-PC\SQLEXPRESS;Initial Catalog=MixTask;Integrated Security=True");

                string query = "Select * from Register where login = '" + loginf.Text.Trim() + "' and Password ='" + passf.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

                SqlCommand cmd = new SqlCommand(query, sqlcon);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)

                {
                    sqlcon.Open();

                    string data;
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        query = "Select User_id from Register where login = " + loginf.Text.Trim();
                        cmd = new SqlCommand(query, sqlcon);

                        if (read.Read())
                        {

                            data = Convert.ToString(read["User_id"]);

                            Form1 formmain = new Form1(data);
                            this.Hide();

                            formmain.Show();

                            Program.f1.UpdateFlow();
                        }





                    }
                    sqlcon.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect login or password!");
                }
            } else
            {
                MessageBox.Show("Some fields are empty");
            }
        }
                
        public string login
        {
         
            get { return loginf.Text; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            registration regis = new registration();
            this.Hide();
            regis.Show();
        }

        private void passf_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
