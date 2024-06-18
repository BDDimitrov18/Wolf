using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.NewForms;

namespace WolfClient.UserControls
{
    public partial class MenuClientsUserControl : UserControl
    {
        public MenuClientsUserControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClientForm addClientFrom = new AddClientForm();
            addClientFrom.Show();
        }
    }
}
