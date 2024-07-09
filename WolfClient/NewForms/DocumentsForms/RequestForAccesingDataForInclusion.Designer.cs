namespace WolfClient.NewForms.DocumentsForms
{
    partial class RequestForAccesingDataForInclusion
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
            pdfPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pdfPictureBox).BeginInit();
            SuspendLayout();
            // 
            // pdfPictureBox
            // 
            pdfPictureBox.Location = new Point(0, 0);
            pdfPictureBox.Name = "pdfPictureBox";
            pdfPictureBox.Size = new Size(800, 600);
            pdfPictureBox.TabIndex = 0;
            pdfPictureBox.TabStop = false;
            // 
            // RequestForAccesingDataForInclusion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 599);
            Controls.Add(pdfPictureBox);
            Name = "RequestForAccesingDataForInclusion";
            Text = "RequestForAccesingDataForInclusion";
            Load += RequestForAccesingDataForInclusion_Load;
            ((System.ComponentModel.ISupportInitialize)pdfPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pdfPictureBox;
    }
}