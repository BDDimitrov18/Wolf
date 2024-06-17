﻿namespace Wolf
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeesTableLabel = new System.Windows.Forms.Label();
            this.EmployeesAddButton = new System.Windows.Forms.Button();
            this.EmployeesTitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.FirstName,
            this.SecondName,
            this.LastName,
            this.Phone,
            this.Email});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(69, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(802, 511);
            this.dataGridView1.TabIndex = 0;
            // 
            // EmployeeId
            // 
            this.EmployeeId.HeaderText = "Номер";
            this.EmployeeId.MinimumWidth = 6;
            this.EmployeeId.Name = "EmployeeId";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Име";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            // 
            // SecondName
            // 
            this.SecondName.HeaderText = "Презиме";
            this.SecondName.MinimumWidth = 6;
            this.SecondName.Name = "SecondName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Фамилия";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Телефон";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // EmployeesTableLabel
            // 
            this.EmployeesTableLabel.AutoSize = true;
            this.EmployeesTableLabel.Location = new System.Drawing.Point(66, 135);
            this.EmployeesTableLabel.Name = "EmployeesTableLabel";
            this.EmployeesTableLabel.Size = new System.Drawing.Size(80, 16);
            this.EmployeesTableLabel.TabIndex = 1;
            this.EmployeesTableLabel.Text = "Служители";
            // 
            // EmployeesAddButton
            // 
            this.EmployeesAddButton.Location = new System.Drawing.Point(152, 132);
            this.EmployeesAddButton.Name = "EmployeesAddButton";
            this.EmployeesAddButton.Size = new System.Drawing.Size(22, 23);
            this.EmployeesAddButton.TabIndex = 2;
            this.EmployeesAddButton.Text = "+";
            this.EmployeesAddButton.UseVisualStyleBackColor = true;
            this.EmployeesAddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmployeesTitleLabel
            // 
            this.EmployeesTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EmployeesTitleLabel.AutoSize = true;
            this.EmployeesTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeesTitleLabel.Location = new System.Drawing.Point(604, 34);
            this.EmployeesTitleLabel.Name = "EmployeesTitleLabel";
            this.EmployeesTitleLabel.Size = new System.Drawing.Size(212, 42);
            this.EmployeesTitleLabel.TabIndex = 3;
            this.EmployeesTitleLabel.Text = "Служители";
            // 
            // MenuEmployeesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.EmployeesTitleLabel);
            this.Controls.Add(this.EmployeesAddButton);
            this.Controls.Add(this.EmployeesTableLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MenuEmployeesUserControl";
            this.Size = new System.Drawing.Size(1350, 785);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
