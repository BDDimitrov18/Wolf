namespace WolfClient.UserControls
{
    partial class IdealPartNumber
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numberTextBox = new TextBox();
            SuspendLayout();
            // 
            // numberTextBox
            // 
            numberTextBox.Location = new Point(0, 1);
            numberTextBox.Name = "numberTextBox";
            numberTextBox.Size = new Size(183, 27);
            numberTextBox.TabIndex = 0;
            // 
            // IdealPartNumber
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(numberTextBox);
            Name = "IdealPartNumber";
            Size = new Size(183, 28);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numberTextBox;
    }
}
