using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_one
{
    public partial class data_test : Form
    {
        public data_test()
        {
            InitializeComponent();
        }

        private void data_test_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet11.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.mixTaskDataSet11.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet11.Task". При необходимости она может быть перемещена или удалена.
//            this.taskTableAdapter.Fill(this.mixTaskDataSet11.Task);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet11.Register". При необходимости она может быть перемещена или удалена.
   //         this.registerTableAdapter.Fill(this.mixTaskDataSet11.Register);

        }

        private void registerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mixTaskDataSet11);

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            usersBindingSource.EndEdit();
            usersTableAdapter.Update(mixTaskDataSet11);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            usersBindingSource.AddNew();
        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
