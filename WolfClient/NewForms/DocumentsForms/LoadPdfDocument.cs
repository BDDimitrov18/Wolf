using Patagames.Pdf.Net;
using Patagames.Pdf.Net.AcroForms;
using Patagames.Pdf.Net.Controls.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WolfClient.NewForms.DocumentsForms
{
    public partial class LoadPdfDocument : Form
    {
        private Timer timer;
        private Dictionary<string, string> formFieldValues;
        private PdfDocument pdfDocument;
        private PdfForms forms;
        public LoadPdfDocument()
        {
            InitializeComponent();
            InitializePdfViewer();
            forms = new PdfForms();
            LoadPdf(@"..\..\..\PdfDocuments\ВиКЗаявление_за_предоставяне_на_изходни_данни_за_присъединяване-ВИК_edit.pdf");

            // Initialize the timer to check for changes
            timer = new Timer();
            timer.Interval = 300; // Check every 500ms
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        

        private void InitializePdfViewer()
        {
            // Additional PdfViewer initialization if needed
        }

        private void LoadPdf(string pdfPath)
        {
            if (!File.Exists(pdfPath))
            {
                MessageBox.Show($"The file '{pdfPath}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load PDF document with interactive forms enabled
            pdfDocument = PdfDocument.Load(pdfPath, forms);
            pdfViewer1.Document = pdfDocument;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var fromsNow = pdfViewer1.FillForms;
            foreach (var field in fromsNow.InterForm.Fields)
            {
                if (field is PdfPushButtonField)
                {
                    var pushbutton = field as PdfPushButtonField;
                    //...
                }
                else if (field is PdfCheckBoxField)
                {
                    var checkbox = field as PdfCheckBoxField;
                    //...
                }
                else if (field is PdfRadioButtonField)
                {
                    var radiobutton = field as PdfRadioButtonField;
                    //...
                }
                else if (field is PdfTextBoxField)
                {
                    var textbox = field as PdfTextBoxField;
                    //...
                }
                else if (field is PdfComboBoxField)
                {
                    var combobox = field as PdfComboBoxField;
                    //...
                }
                else if (field is PdfListBoxField)
                {
                    var listbox = field as PdfListBoxField;
                    //...
                }
            }
        }

        private void OnFormFieldValueChanged(string fieldName, string newValue)
        {
            // Handle the form field value change event
            MessageBox.Show($"Field '{fieldName}' changed to '{newValue}'", "Field Value Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

