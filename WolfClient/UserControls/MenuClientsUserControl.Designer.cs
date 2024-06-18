using System.Xml.Linq;
using WolfClient.NewForms;

namespace WolfClient.UserControls
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
            ClientsDataGridView = new DataGridView();
            ClientId = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            SecondName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ClientLegalType = new DataGridViewTextBoxColumn();
            ClientsTableLabel = new Label();
            ClientsAddButton = new Button();
            ClientsTitleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ClientsDataGridView
            // 
            ClientsDataGridView.AllowUserToResizeColumns = false;
            ClientsDataGridView.AllowUserToResizeRows = false;
            ClientsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ClientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ClientsDataGridView.BackgroundColor = Color.Moccasin;
            ClientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ClientId, FirstName, SecondName, LastName, Phone, Email, Address, ClientLegalType });
            ClientsDataGridView.Location = new Point(46, 142);
            ClientsDataGridView.Name = "ClientsDataGridView";
            ClientsDataGridView.RowHeadersWidth = 51;
            ClientsDataGridView.RowTemplate.Height = 24;
            ClientsDataGridView.Size = new Size(1053, 582);
            ClientsDataGridView.TabIndex = 0;
            // 
            // ClientId
            // 
            ClientId.HeaderText = "Номер";
            ClientId.MinimumWidth = 6;
            ClientId.Name = "ClientId";
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
            Phone.HeaderText = "телефон";
            Phone.MinimumWidth = 6;
            Phone.Name = "Phone";
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // Address
            // 
            Address.HeaderText = "Адрес";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            // 
            // ClientLegalType
            // 
            ClientLegalType.HeaderText = "Лице";
            ClientLegalType.MinimumWidth = 6;
            ClientLegalType.Name = "ClientLegalType";
            // 
            // ClientsTableLabel
            // 
            ClientsTableLabel.AutoSize = true;
            ClientsTableLabel.Location = new Point(45, 107);
            ClientsTableLabel.Name = "ClientsTableLabel";
            ClientsTableLabel.Size = new Size(67, 20);
            ClientsTableLabel.TabIndex = 1;
            ClientsTableLabel.Text = "Клиенти";
            ClientsTableLabel.Click += label1_Click;
            // 
            // ClientsAddButton
            // 
            ClientsAddButton.Location = new Point(118, 102);
            ClientsAddButton.Name = "ClientsAddButton";
            ClientsAddButton.Size = new Size(27, 31);
            ClientsAddButton.TabIndex = 2;
            ClientsAddButton.Text = "+";
            ClientsAddButton.UseVisualStyleBackColor = true;
            ClientsAddButton.Click += button1_Click;
            // 
            // ClientsTitleLabel
            // 
            ClientsTitleLabel.Anchor = AnchorStyles.Top;
            ClientsTitleLabel.AutoSize = true;
            ClientsTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            ClientsTitleLabel.Location = new Point(604, 34);
            ClientsTitleLabel.Name = "ClientsTitleLabel";
            ClientsTitleLabel.Size = new Size(165, 42);
            ClientsTitleLabel.TabIndex = 3;
            ClientsTitleLabel.Text = "Клиенти";
            // 
            // MenuClientsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(ClientsTitleLabel);
            Controls.Add(ClientsAddButton);
            Controls.Add(ClientsTableLabel);
            Controls.Add(ClientsDataGridView);
            Name = "MenuClientsUserControl";
            Size = new Size(1350, 785);
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView ClientsDataGridView;
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
