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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mixTaskDataSet1.Task". При необходимости она может быть перемещена или удалена.
            this.taskTableAdapter.Fill(this.mixTaskDataSet1.Task);

        }

        private void taskBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taskBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mixTaskDataSet1);
            Program.f1.UpdateFlow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taskBindingSource.EndEdit();
            taskTableAdapter.Update(mixTaskDataSet1);
            Program.f1.UpdateFlow();
        }
    }
}
