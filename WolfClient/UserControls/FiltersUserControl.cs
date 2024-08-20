using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class FiltersUserControl : UserControl
    {
        private readonly IDataService _dataService;
        public FiltersUserControl(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        private void FiltersUserControl_Load(object sender, EventArgs e)
        {
                
        }
    }
}
