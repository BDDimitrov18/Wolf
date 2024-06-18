using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfClient.NewForms
{
    public partial class AddRequestForm : Form
    {
        public AddRequestForm()
        {
            InitializeComponent();
        }

        private void AddNonExistingClientButton_Click(object sender, EventArgs e)
        {
            AddClientForm addClientFrom = new AddClientForm();
            addClientFrom.Show();
        }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
