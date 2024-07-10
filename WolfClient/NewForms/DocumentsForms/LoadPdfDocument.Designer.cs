namespace WolfClient.NewForms.DocumentsForms
{
    partial class LoadPdfDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            pdfToolStripMain1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pdfViewer1
            // 
            pdfViewer1.BackColor = SystemColors.ControlDark;
            pdfViewer1.CurrentIndex = -1;
            pdfViewer1.CurrentPageHighlightColor = Color.FromArgb(170, 70, 130, 180);
            pdfViewer1.Dock = DockStyle.Fill;
            pdfViewer1.Document = null;
            pdfViewer1.FormHighlightColor = Color.Transparent;
            pdfViewer1.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            pdfViewer1.LoadingIconText = "Loading...";
            pdfViewer1.Location = new Point(0, 0);
            pdfViewer1.Margin = new Padding(4, 5, 4, 5);
            pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.OptimizedLoadThreshold = 1000;
            pdfViewer1.Padding = new Padding(13, 15, 13, 15);
            pdfViewer1.PageAlign = ContentAlignment.MiddleCenter;
            pdfViewer1.PageAutoDispose = true;
            pdfViewer1.PageBackColor = Color.White;
            pdfViewer1.PageBorderColor = Color.Black;
            pdfViewer1.PageMargin = new Padding(10);
            pdfViewer1.PageSeparatorColor = Color.Gray;
            pdfViewer1.RenderFlags = Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH;
            pdfViewer1.ShowCurrentPageHighlight = true;
            pdfViewer1.ShowLoadingIcon = true;
            pdfViewer1.ShowPageSeparator = true;
            pdfViewer1.Size = new Size(800, 383);
            pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            pdfViewer1.TabIndex = 0;
            pdfViewer1.TextSelectColor = Color.FromArgb(70, 70, 130, 180);
            pdfViewer1.TilesCount = 2;
            pdfViewer1.UseProgressiveRender = true;
            pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            pdfViewer1.Zoom = 1F;
            // 
            // pdfToolStripMain1
            // 
            pdfToolStripMain1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pdfToolStripMain1.Dock = DockStyle.None;
            pdfToolStripMain1.ImageScalingSize = new Size(20, 20);
            pdfToolStripMain1.Location = new Point(0, 0);
            pdfToolStripMain1.Name = "pdfToolStripMain1";
            pdfToolStripMain1.PdfViewer = pdfViewer1;
            pdfToolStripMain1.Size = new Size(133, 63);
            pdfToolStripMain1.TabIndex = 1;
            pdfToolStripMain1.Text = "pdfToolStripMain1";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pdfViewer1);
            panel1.Location = new Point(0, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 383);
            panel1.TabIndex = 2;
            // 
            // LoadPdfDocument
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(pdfToolStripMain1);
            Name = "LoadPdfDocument";
            Text = "LoadPdfDocument";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain pdfToolStripMain1;
        private Panel panel1;
    }
}