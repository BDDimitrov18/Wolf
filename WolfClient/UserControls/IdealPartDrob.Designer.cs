namespace WolfClient.UserControls
{
    partial class IdealPartDrob
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
            FirstNumberTextBox = new TextBox();
            SecondNumberTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // FirstNumberTextBox
            // 
            FirstNumberTextBox.Location = new Point(0, 0);
            FirstNumberTextBox.Name = "FirstNumberTextBox";
            FirstNumberTextBox.Size = new Size(78, 27);
            FirstNumberTextBox.TabIndex = 0;
            // 
            // SecondNumberTextBox
            // 
            SecondNumberTextBox.Location = new Point(105, 0);
            SecondNumberTextBox.Name = "SecondNumberTextBox";
            SecondNumberTextBox.Size = new Size(78, 27);
            SecondNumberTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(81, -2);
            label1.Name = "label1";
            label1.Size = new Size(21, 28);
            label1.TabIndex = 2;
            label1.Text = "/";
            // 
            // IdealPartDrob
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(SecondNumberTextBox);
            Controls.Add(FirstNumberTextBox);
            Name = "IdealPartDrob";
            Size = new Size(183, 27);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstNumberTextBox;
        private TextBox SecondNumberTextBox;
        private Label label1;
    }
}
