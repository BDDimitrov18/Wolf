namespace WolfClient.UserControls
{
    partial class MenuEmployeesUserControl
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
            EmployeesDataGridView = new DataGridView();
            EmployeeId = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            SecondName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            EmployeesTableLabel = new Label();
            EmployeesAddButton = new Button();
            EmployeesTitleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)EmployeesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // EmployeesDataGridView
            // 
            EmployeesDataGridView.AllowUserToResizeColumns = false;
            EmployeesDataGridView.AllowUserToResizeRows = false;
            EmployeesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EmployeesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EmployeesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            EmployeesDataGridView.BackgroundColor = Color.Moccasin;
            EmployeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmployeesDataGridView.Columns.AddRange(new DataGridViewColumn[] { EmployeeId, FirstName, SecondName, LastName, Phone, Email });
            EmployeesDataGridView.ImeMode = ImeMode.NoControl;
            EmployeesDataGridView.Location = new Point(69, 204);
            EmployeesDataGridView.Margin = new Padding(3, 4, 3, 4);
            EmployeesDataGridView.Name = "EmployeesDataGridView";
            EmployeesDataGridView.RowHeadersWidth = 51;
            EmployeesDataGridView.RowTemplate.Height = 24;
            EmployeesDataGridView.Size = new Size(802, 639);
            EmployeesDataGridView.TabIndex = 0;
            // 
            // EmployeeId
            // 
            EmployeeId.HeaderText = "Номер";
            EmployeeId.MinimumWidth = 6;
            EmployeeId.Name = "EmployeeId";
            // 
            // FirstName
            // 
            FirstName.HeaderText = "Име";
            FirstName.MinimumWidth = 6;
            FirstName.Name = "FirstName";
            // 
            // SecondName
            // 
            SecondName.HeaderText = "Презиме";
            SecondName.MinimumWidth = 6;
            SecondName.Name = "SecondName";
            // 
            // LastName
            // 
            LastName.HeaderText = "Фамилия";
            LastName.MinimumWidth = 6;
            LastName.Name = "LastName";
            // 
            // Phone
            // 
            Phone.HeaderText = "Телефон";
            Phone.MinimumWidth = 6;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // EmployeesTableLabel
            // 
            EmployeesTableLabel.AutoSize = true;
            EmployeesTableLabel.Location = new Point(66, 169);
            EmployeesTableLabel.Name = "EmployeesTableLabel";
            EmployeesTableLabel.Size = new Size(84, 20);
            EmployeesTableLabel.TabIndex = 1;
            EmployeesTableLabel.Text = "Служители";
            // 
            // EmployeesAddButton
            // 
            EmployeesAddButton.Location = new Point(152, 165);
            EmployeesAddButton.Margin = new Padding(3, 4, 3, 4);
            EmployeesAddButton.Name = "EmployeesAddButton";
            EmployeesAddButton.Size = new Size(22, 29);
            EmployeesAddButton.TabIndex = 2;
            EmployeesAddButton.Text = "+";
            EmployeesAddButton.UseVisualStyleBackColor = true;
            EmployeesAddButton.Click += button1_Click;
            // 
            // EmployeesTitleLabel
            // 
            EmployeesTitleLabel.Anchor = AnchorStyles.Top;
            EmployeesTitleLabel.AutoSize = true;
            EmployeesTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeesTitleLabel.Location = new Point(604, 42);
            EmployeesTitleLabel.Name = "EmployeesTitleLabel";
            EmployeesTitleLabel.Size = new Size(212, 42);
            EmployeesTitleLabel.TabIndex = 3;
            EmployeesTitleLabel.Text = "Служители";
            // 
            // MenuEmployeesUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(EmployeesTitleLabel);
            Controls.Add(EmployeesAddButton);
            Controls.Add(EmployeesTableLabel);
            Controls.Add(EmployeesDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuEmployeesUserControl";
            Size = new Size(1350, 981);
            Load += MenuEmployeesUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)EmployeesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView EmployeesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Label EmployeesTableLabel;
        private System.Windows.Forms.Label EmployeesTitleLabel;
        private System.Windows.Forms.Button EmployeesAddButton;
    }
}
