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
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class CreateDocument : Form
    {
        private readonly IDataService _dataService;
        private readonly IFileUploader _fileUploader;
        private List<GetFileDTO> _allFiles;

        string lastFile = "";
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
                openFileDialog.Title = "Open File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lastFile = openFileDialog.FileName;
                    string filePath = openFileDialog.FileName;
                    folderPathTextBox.Text = "Selected Path: " + filePath;
                    await _fileUploader.UploadFileAsync(filePath);
                }
            }
        }
        public byte[] ReadFileToByteArray()
        {
            // Ensure the file exists
            if (!File.Exists(lastFile))
            {
                throw new FileNotFoundException("The specified file does not exist.", lastFile);
            }

            // Read the file into a byte array
            byte[] fileBytes = File.ReadAllBytes(lastFile);

            return fileBytes;
        }


        private async void OpenFileReaderButton_Click(object sender, EventArgs e)
        {
            if (newDocumentRadioButton.Checked)
            {
                DocumentEditor documentEditor = new DocumentEditor(_dataService, ReadFileToByteArray(), ActivityComboBox.SelectedItem as GetActivityDTO);
                documentEditor.Show();
            }
            if (OldDocumentRadioButton.Checked)
            {
                var selectedItem = FileComboBox.SelectedItem as GetFileDTO;
                var response = await _fileUploader.DownloadFileContentAsync(selectedItem);

                if (response.IsSuccess)
                {
                    var downloadedFile = response.ResponseObj;
                    DocumentEditor documentEditor = new DocumentEditor(_dataService, downloadedFile, ActivityComboBox.SelectedItem as GetActivityDTO);
                    documentEditor.Show();
                }

            }
        }

        private void newDocumentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            OldDocumentRadioButton.Checked = false;
        }

        private void OldDocumentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            newDocumentRadioButton.Checked = false;
        }

        private async void CreateDocument_Load(object sender, EventArgs e)
        {
            _allFiles = await _fileUploader.GetAllFilesAsync();
            FileComboBox.DataSource = _allFiles;
            FileComboBox.DisplayMember = "FileName";
            FileComboBox.ValueMember = "FileId";

            ActivityComboBox.DataSource = _dataService.GetSelectedActivities();
            ActivityComboBox.DisplayMember = "ActivityTypeName";
            ActivityComboBox.ValueMember = "ActivityId";
            ActivityComboBox.SelectedIndex = 0;
        }
    }
}
