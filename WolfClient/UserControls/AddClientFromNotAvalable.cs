using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfClient.UserControls
{
    public partial class AddClientFromNotAvalable : UserControl
    {
        public CreateClientDTO _clientObject;
        private Panel _parent;
        public AddClientFromNotAvalable(CreateClientDTO clientObject, Panel parent)
        {
            InitializeComponent();
            _clientObject = clientObject;
            _parent = parent;
        }

        private void AddClientFromNotAvalable_Load(object sender, EventArgs e)
        {
            DisplayNameLabel.Text = _clientObject.FirstName + " " + _clientObject.MiddleName + " " + _clientObject.LastName;
        }

        private void DeleteUserControlButton_Click(object sender, EventArgs e)
        {
            _parent.Dispose();
        }
    }
}
