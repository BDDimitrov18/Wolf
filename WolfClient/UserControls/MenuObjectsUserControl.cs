﻿using System;
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
    public partial class MenuObjectsUserControl : UserControl
    {
        public MenuObjectsUserControl()
        {
            InitializeComponent();
        }

        private void MenuObjectsUserControl_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPlotToObject addPlotToObjectForm = new AddPlotToObject();
            addPlotToObjectForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm();
            addActivityTaskForm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddWorkObjectForm addWorkObjectsForm = new AddWorkObjectForm();
            addWorkObjectsForm.Show();
        }
    }
}