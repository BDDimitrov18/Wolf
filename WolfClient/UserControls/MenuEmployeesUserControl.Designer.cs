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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuEmployeesUserControl));
            EmployeesDataGridView = new DataGridView();
            EmployeeId = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            SecondName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            EmployeesTableLabel = new Label();
            EmployeesAddButton = new Button();
            Refresh = new Button();
            FirstRowButton = new Button();
            PreviousRowButton = new Button();
            NextRowButton = new Button();
            LastRowButton = new Button();
            DeleteEmployeeButton = new Button();
            EditEmployeeButton = new Button();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)EmployeesDataGridView).BeginInit();
            panel1.SuspendLayout();
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
            EmployeesDataGridView.Location = new Point(0, 132);
            EmployeesDataGridView.Margin = new Padding(3, 4, 3, 4);
            EmployeesDataGridView.Name = "EmployeesDataGridView";
            EmployeesDataGridView.RowHeadersWidth = 51;
            EmployeesDataGridView.RowTemplate.Height = 24;
            EmployeesDataGridView.Size = new Size(1350, 849);
            EmployeesDataGridView.TabIndex = 0;
            EmployeesDataGridView.CellContentClick += EmployeesDataGridView_CellContentClick;
            // 
            // EmployeeId
            // 
            EmployeeId.DataPropertyName = "EmployeeId";
            EmployeeId.HeaderText = "Номер";
            EmployeeId.MinimumWidth = 6;
            EmployeeId.Name = "EmployeeId";
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "Име";
            FirstName.MinimumWidth = 6;
            FirstName.Name = "FirstName";
            // 
            // SecondName
            // 
            SecondName.DataPropertyName = "SecondName";
            SecondName.HeaderText = "Презиме";
            SecondName.MinimumWidth = 6;
            SecondName.Name = "SecondName";
            // 
            // LastName
            // 
            LastName.DataPropertyName = "LastName";
            LastName.HeaderText = "Фамилия";
            LastName.MinimumWidth = 6;
            LastName.Name = "LastName";
            // 
            // Phone
            // 
            Phone.DataPropertyName = "Phone";
            Phone.HeaderText = "Телефон";
            Phone.MinimumWidth = 6;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // EmployeesTableLabel
            // 
            EmployeesTableLabel.AutoSize = true;
            EmployeesTableLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeesTableLabel.Location = new Point(14, 44);
            EmployeesTableLabel.Name = "EmployeesTableLabel";
            EmployeesTableLabel.Size = new Size(113, 28);
            EmployeesTableLabel.TabIndex = 1;
            EmployeesTableLabel.Text = "Служители";
            // 
            // EmployeesAddButton
            // 
            EmployeesAddButton.BackgroundImage = (Image)resources.GetObject("EmployeesAddButton.BackgroundImage");
            EmployeesAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            EmployeesAddButton.Location = new Point(218, 79);
            EmployeesAddButton.Margin = new Padding(3, 4, 3, 4);
            EmployeesAddButton.Name = "EmployeesAddButton";
            EmployeesAddButton.Size = new Size(45, 45);
            EmployeesAddButton.TabIndex = 2;
            EmployeesAddButton.Text = "+";
            EmployeesAddButton.UseVisualStyleBackColor = true;
            EmployeesAddButton.Click += button1_Click;
            // 
            // Refresh
            // 
            Refresh.BackgroundImage = (Image)resources.GetObject("Refresh.BackgroundImage");
            Refresh.BackgroundImageLayout = ImageLayout.Stretch;
            Refresh.Location = new Point(371, 79);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(45, 45);
            Refresh.TabIndex = 4;
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // FirstRowButton
            // 
            FirstRowButton.BackgroundImage = (Image)resources.GetObject("FirstRowButton.BackgroundImage");
            FirstRowButton.BackgroundImageLayout = ImageLayout.Stretch;
            FirstRowButton.Location = new Point(14, 80);
            FirstRowButton.Name = "FirstRowButton";
            FirstRowButton.Size = new Size(45, 45);
            FirstRowButton.TabIndex = 5;
            FirstRowButton.UseVisualStyleBackColor = true;
            // 
            // PreviousRowButton
            // 
            PreviousRowButton.BackgroundImage = (Image)resources.GetObject("PreviousRowButton.BackgroundImage");
            PreviousRowButton.BackgroundImageLayout = ImageLayout.Stretch;
            PreviousRowButton.Location = new Point(65, 80);
            PreviousRowButton.Name = "PreviousRowButton";
            PreviousRowButton.Size = new Size(45, 45);
            PreviousRowButton.TabIndex = 6;
            PreviousRowButton.UseVisualStyleBackColor = true;
            // 
            // NextRowButton
            // 
            NextRowButton.BackgroundImage = (Image)resources.GetObject("NextRowButton.BackgroundImage");
            NextRowButton.BackgroundImageLayout = ImageLayout.Stretch;
            NextRowButton.Location = new Point(116, 80);
            NextRowButton.Name = "NextRowButton";
            NextRowButton.Size = new Size(45, 45);
            NextRowButton.TabIndex = 7;
            NextRowButton.UseVisualStyleBackColor = true;
            // 
            // LastRowButton
            // 
            LastRowButton.BackgroundImage = (Image)resources.GetObject("LastRowButton.BackgroundImage");
            LastRowButton.BackgroundImageLayout = ImageLayout.Stretch;
            LastRowButton.Location = new Point(167, 80);
            LastRowButton.Name = "LastRowButton";
            LastRowButton.Size = new Size(45, 45);
            LastRowButton.TabIndex = 8;
            LastRowButton.UseVisualStyleBackColor = true;
            // 
            // DeleteEmployeeButton
            // 
            DeleteEmployeeButton.BackgroundImage = (Image)resources.GetObject("DeleteEmployeeButton.BackgroundImage");
            DeleteEmployeeButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteEmployeeButton.Location = new Point(320, 79);
            DeleteEmployeeButton.Name = "DeleteEmployeeButton";
            DeleteEmployeeButton.Size = new Size(45, 45);
            DeleteEmployeeButton.TabIndex = 9;
            DeleteEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // EditEmployeeButton
            // 
            EditEmployeeButton.BackgroundImage = (Image)resources.GetObject("EditEmployeeButton.BackgroundImage");
            EditEmployeeButton.BackgroundImageLayout = ImageLayout.Stretch;
            EditEmployeeButton.Location = new Point(269, 79);
            EditEmployeeButton.Name = "EditEmployeeButton";
            EditEmployeeButton.Size = new Size(45, 45);
            EditEmployeeButton.TabIndex = 10;
            EditEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(434, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 106);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "филтри";
            // 
            // MenuEmployeesUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(panel1);
            Controls.Add(EditEmployeeButton);
            Controls.Add(DeleteEmployeeButton);
            Controls.Add(LastRowButton);
            Controls.Add(NextRowButton);
            Controls.Add(PreviousRowButton);
            Controls.Add(FirstRowButton);
            Controls.Add(Refresh);
            Controls.Add(EmployeesAddButton);
            Controls.Add(EmployeesTableLabel);
            Controls.Add(EmployeesDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuEmployeesUserControl";
            Size = new Size(1350, 981);
            Load += MenuEmployeesUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)EmployeesDataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView EmployeesDataGridView;
        private System.Windows.Forms.Label EmployeesTableLabel;
        private System.Windows.Forms.Button EmployeesAddButton;
        private DataGridViewTextBoxColumn EmployeeId;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn SecondName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private Button Refresh;
        private Button FirstRowButton;
        private Button PreviousRowButton;
        private Button NextRowButton;
        private Button LastRowButton;
        private Button DeleteEmployeeButton;
        private Button EditEmployeeButton;
        private Panel panel1;
        private Label label1;
    }
}
