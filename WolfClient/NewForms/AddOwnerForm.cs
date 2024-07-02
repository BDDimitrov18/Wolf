using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.UserControls;

namespace WolfClient.NewForms
{
    public partial class AddOwnerForm : Form
    {
        public AddOwnerForm()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IdealPartsComboBox.Text == "дроб") {
                IdealPartDrob drob = new IdealPartDrob();
                LoadUserControl(drob);
            }
            if (IdealPartsComboBox.Text == "плаваща запетая")
            {
                IdealPartNumber number = new IdealPartNumber();
                LoadUserControl(number);
            }
        }
        private void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            IdealPartsPanel.Controls.Clear();

            // Set the Dock property to Fill to make it responsive
            userControl.Dock = DockStyle.Fill;

            // Add the new UserControl
            IdealPartsPanel.Controls.Add(userControl);
        }
    }
}
