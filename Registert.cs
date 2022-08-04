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
    public partial class Registert : Form
    {
        public Registert()
        {
            InitializeComponent();
        }

        private void Registert_Load(object sender, EventArgs e)
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

            registerBindingSource.EndEdit();
            registerTableAdapter.Update(mixTaskDataSet1);
            //TO DOOOOO exception!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registerBindingSource.AddNew();
        }

        private void registerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
