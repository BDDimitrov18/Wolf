namespace WolfClient.UserControls
{
    partial class AddEmployeeFilter
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
            EmployeesComboBox = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // EmployeesComboBox
            // 
            EmployeesComboBox.FormattingEnabled = true;
            EmployeesComboBox.Location = new Point(3, 0);
            EmployeesComboBox.Name = "EmployeesComboBox";
            EmployeesComboBox.Size = new Size(330, 28);
            EmployeesComboBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(364, 0);
            button1.Name = "button1";
            button1.Size = new Size(164, 29);
            button1.TabIndex = 1;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddEmployeeFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(button1);
            Controls.Add(EmployeesComboBox);
            Name = "AddEmployeeFilter";
            Size = new Size(535, 28);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox EmployeesComboBox;
        private Button button1;
    }
}
