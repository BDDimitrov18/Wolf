namespace Wolf
{
    partial class MenuClientsUserControl
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
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientLegalType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientsTableLabel = new System.Windows.Forms.Label();
            this.ClientsAddButton = new System.Windows.Forms.Button();
            this.ClientsTitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientId,
            this.FirstName,
            this.SecondName,
            this.LastName,
            this.Phone,
            this.Email,
            this.Address,
            this.ClientLegalType});
            this.dataGridView1.Location = new System.Drawing.Point(46, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 582);
            this.dataGridView1.TabIndex = 0;
            // 
            // ClientId
            // 
            this.ClientId.HeaderText = "Номер";
            this.ClientId.MinimumWidth = 6;
            this.ClientId.Name = "ClientId";
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
            this.Phone.HeaderText = "телефон";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            // 
            // ClientLegalType
            // 
            this.ClientLegalType.HeaderText = "Лице";
            this.ClientLegalType.MinimumWidth = 6;
            this.ClientLegalType.Name = "ClientLegalType";
            // 
            // ClientsTableLabel
            // 
            this.ClientsTableLabel.AutoSize = true;
            this.ClientsTableLabel.Location = new System.Drawing.Point(43, 116);
            this.ClientsTableLabel.Name = "ClientsTableLabel";
            this.ClientsTableLabel.Size = new System.Drawing.Size(62, 16);
            this.ClientsTableLabel.TabIndex = 1;
            this.ClientsTableLabel.Text = "Клиенти";
            this.ClientsTableLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ClientsAddButton
            // 
            this.ClientsAddButton.Location = new System.Drawing.Point(111, 113);
            this.ClientsAddButton.Name = "ClientsAddButton";
            this.ClientsAddButton.Size = new System.Drawing.Size(24, 23);
            this.ClientsAddButton.TabIndex = 2;
            this.ClientsAddButton.Text = "+";
            this.ClientsAddButton.UseVisualStyleBackColor = true;
            this.ClientsAddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClientsTitleLabel
            // 
            this.ClientsTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ClientsTitleLabel.AutoSize = true;
            this.ClientsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientsTitleLabel.Location = new System.Drawing.Point(604, 34);
            this.ClientsTitleLabel.Name = "ClientsTitleLabel";
            this.ClientsTitleLabel.Size = new System.Drawing.Size(165, 42);
            this.ClientsTitleLabel.TabIndex = 3;
            this.ClientsTitleLabel.Text = "Клиенти";
            // 
            // MenuClientsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ClientsTitleLabel);
            this.Controls.Add(this.ClientsAddButton);
            this.Controls.Add(this.ClientsTableLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MenuClientsUserControl";
            this.Size = new System.Drawing.Size(1350, 785);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientLegalType;
        private System.Windows.Forms.Label ClientsTableLabel;
        private System.Windows.Forms.Button ClientsAddButton;
        private System.Windows.Forms.Label ClientsTitleLabel;
    }
}
