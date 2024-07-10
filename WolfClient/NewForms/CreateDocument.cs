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

namespace WolfClient.NewForms
{
    public partial class CreateDocument : Form
    {
        private readonly IDataService _dataService;
        private readonly IFileUploader _fileUploader;
        public CreateDocument(IDataService dataService, IFileUploader fileUploader)
        {
            _dataService = dataService;
            _fileUploader = fileUploader;
            InitializeComponent();
        }

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.Title = "Open PDF File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    folderPathTextBox.Text = "Selected Path: " + filePath;
                    await _fileUploader.UploadFileAsync(filePath);
                }
            }
        }
    }
}
