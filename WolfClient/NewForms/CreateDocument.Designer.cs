namespace WolfClient.NewForms
{
    partial class CreateDocument
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
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label3 = new Label();
            openFileDialog1 = new OpenFileDialog();
            UploadButton = new Button();
            folderPathTextBox = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            OpenFileReaderButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(90, 9);
            label1.Name = "label1";
            label1.Size = new Size(441, 50);
            label1.TabIndex = 0;
            label1.Text = "Създаване на Заявление";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 12);
            label2.Name = "label2";
            label2.Size = new Size(230, 35);
            label2.TabIndex = 1;
            label2.Text = "Избери Заявление";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(15, 50);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(265, 28);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(15, 156);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(265, 28);
            comboBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(15, 118);
            label3.Name = "label3";
            label3.Size = new Size(205, 35);
            label3.TabIndex = 3;
            label3.Text = "Избери Дейност";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // UploadButton
            // 
            UploadButton.Location = new Point(50, 76);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(196, 29);
            UploadButton.TabIndex = 5;
            UploadButton.Text = "Добави Ново Заявление";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // folderPathTextBox
            // 
            folderPathTextBox.Location = new Point(3, 31);
            folderPathTextBox.Name = "folderPathTextBox";
            folderPathTextBox.Size = new Size(291, 27);
            folderPathTextBox.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox2);
            panel1.Location = new Point(12, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 212);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(folderPathTextBox);
            panel2.Controls.Add(UploadButton);
            panel2.Location = new Point(323, 87);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 115);
            panel2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 8);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 7;
            label4.Text = "Път Към Заявлението";
            // 
            // OpenFileReaderButton
            // 
            OpenFileReaderButton.Location = new Point(392, 250);
            OpenFileReaderButton.Name = "OpenFileReaderButton";
            OpenFileReaderButton.Size = new Size(179, 49);
            OpenFileReaderButton.TabIndex = 9;
            OpenFileReaderButton.Text = "Преглеждане на заявление";
            OpenFileReaderButton.UseVisualStyleBackColor = true;
            // 
            // CreateDocument
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(631, 323);
            Controls.Add(OpenFileReaderButton);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "CreateDocument";
            Text = "CreateDocument";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private Button UploadButton;
        private TextBox folderPathTextBox;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Button OpenFileReaderButton;
    }
}