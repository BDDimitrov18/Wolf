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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDocument));
            label2 = new Label();
            FileComboBox = new ComboBox();
            ActivityComboBox = new ComboBox();
            label3 = new Label();
            openFileDialog1 = new OpenFileDialog();
            UploadButton = new Button();
            folderPathTextBox = new TextBox();
            panel1 = new Panel();
            OldDocumentRadioButton = new RadioButton();
            label5 = new Label();
            panel2 = new Panel();
            newDocumentRadioButton = new RadioButton();
            label6 = new Label();
            label4 = new Label();
            OpenFileReaderButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
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
            // FileComboBox
            // 
            FileComboBox.FormattingEnabled = true;
            FileComboBox.Location = new Point(15, 50);
            FileComboBox.Name = "FileComboBox";
            FileComboBox.Size = new Size(265, 28);
            FileComboBox.TabIndex = 2;
            // 
            // ActivityComboBox
            // 
            ActivityComboBox.FormattingEnabled = true;
            ActivityComboBox.Location = new Point(15, 156);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(265, 28);
            ActivityComboBox.TabIndex = 4;
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
            UploadButton.Location = new Point(50, 80);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(196, 29);
            UploadButton.TabIndex = 5;
            UploadButton.Text = "Добави Ново Заявление";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // folderPathTextBox
            // 
            folderPathTextBox.Location = new Point(3, 47);
            folderPathTextBox.Name = "folderPathTextBox";
            folderPathTextBox.Size = new Size(291, 27);
            folderPathTextBox.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(OldDocumentRadioButton);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(FileComboBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(ActivityComboBox);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 212);
            panel1.TabIndex = 7;
            // 
            // OldDocumentRadioButton
            // 
            OldDocumentRadioButton.AutoSize = true;
            OldDocumentRadioButton.CheckAlign = ContentAlignment.MiddleRight;
            OldDocumentRadioButton.Location = new Point(192, -2);
            OldDocumentRadioButton.Name = "OldDocumentRadioButton";
            OldDocumentRadioButton.Size = new Size(106, 24);
            OldDocumentRadioButton.TabIndex = 10;
            OldDocumentRadioButton.TabStop = true;
            OldDocumentRadioButton.Text = "Използвай";
            OldDocumentRadioButton.UseVisualStyleBackColor = true;
            OldDocumentRadioButton.CheckedChanged += OldDocumentRadioButton_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 5;
            label5.Text = "Налични документи";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(newDocumentRadioButton);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(folderPathTextBox);
            panel2.Controls.Add(UploadButton);
            panel2.Location = new Point(323, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 119);
            panel2.TabIndex = 8;
            // 
            // newDocumentRadioButton
            // 
            newDocumentRadioButton.AutoSize = true;
            newDocumentRadioButton.CheckAlign = ContentAlignment.MiddleRight;
            newDocumentRadioButton.Location = new Point(188, -2);
            newDocumentRadioButton.Name = "newDocumentRadioButton";
            newDocumentRadioButton.Size = new Size(106, 24);
            newDocumentRadioButton.TabIndex = 9;
            newDocumentRadioButton.TabStop = true;
            newDocumentRadioButton.Text = "Използвай";
            newDocumentRadioButton.UseVisualStyleBackColor = true;
            newDocumentRadioButton.CheckedChanged += newDocumentRadioButton_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 8;
            label6.Text = "Нови Документи";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 24);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 7;
            label4.Text = "Път Към Заявлението";
            // 
            // OpenFileReaderButton
            // 
            OpenFileReaderButton.Location = new Point(392, 175);
            OpenFileReaderButton.Name = "OpenFileReaderButton";
            OpenFileReaderButton.Size = new Size(179, 49);
            OpenFileReaderButton.TabIndex = 9;
            OpenFileReaderButton.Text = "Преглеждане на заявление";
            OpenFileReaderButton.UseVisualStyleBackColor = true;
            OpenFileReaderButton.Click += OpenFileReaderButton_Click;
            // 
            // CreateDocument
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(631, 237);
            Controls.Add(OpenFileReaderButton);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateDocument";
            Text = "Wolf: Създаване на заявление";
            Load += CreateDocument_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private ComboBox FileComboBox;
        private ComboBox ActivityComboBox;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private Button UploadButton;
        private TextBox folderPathTextBox;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Button OpenFileReaderButton;
        private RadioButton OldDocumentRadioButton;
        private Label label5;
        private RadioButton newDocumentRadioButton;
        private Label label6;
    }
}