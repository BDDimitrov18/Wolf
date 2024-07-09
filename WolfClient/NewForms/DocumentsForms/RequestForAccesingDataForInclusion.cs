using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using PdfiumViewer;

namespace WolfClient.NewForms.DocumentsForms
{
    public partial class RequestForAccesingDataForInclusion : Form
    {
        public RequestForAccesingDataForInclusion()
        {
            InitializeComponent();
        }



        private void LoadPdf(string pdfPath)
        {
            using (var document = PdfiumViewer.PdfDocument.Load(pdfPath))
            {
                // Render the first page of the PDF to a bitmap
                var page = document.Render(0, pdfPictureBox.Width, pdfPictureBox.Height, 96, 96, PdfRenderFlags.Annotations);

                // Set the rendered image to the PictureBox
                pdfPictureBox.Image = page;
            }
        }

        private object GetDataSource1()
        {
            // Fetch data from database or other source
            return new[] { "Option 1", "Option 2", "Option 3" };
        }

        private object GetDataSource2()
        {
            // Fetch data from database or other source
            return new[] { "Choice A", "Choice B", "Choice C" };
        }

        private void RequestForAccesingDataForInclusion_Load(object sender, EventArgs e)
        {
            LoadPdf(@"..\..\..\PdfDocuments\ВиКЗаявление_за_предоставяне_на_изходни_данни_за_присъединяване-ВИК.pdf");
        }
    }
}
