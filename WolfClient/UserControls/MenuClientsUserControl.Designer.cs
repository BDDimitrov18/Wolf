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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuClientsUserControl));
            ClientsDataGridView = new DataGridView();
            ClientId = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            MiddleName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ClientLegalType = new DataGridViewTextBoxColumn();
            ClientsAddButton = new Button();
            RefreshButton = new Button();
            label1 = new Label();
            panel7 = new Panel();
            btnLastClientsDataGridView = new Button();
            btnNextClientsDataGridView = new Button();
            btnPreviousClientsDataGridView = new Button();
            btnFirstClientsDataGridView = new Button();
            label2 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            phoneTextBox = new TextBox();
            label5 = new Label();
            emailTextBox = new TextBox();
            label4 = new Label();
            FullNameTextBox = new TextBox();
            label3 = new Label();
            numberTextBox = new TextBox();
            button1 = new Button();
            EditClientButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).BeginInit();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ClientsDataGridView
            // 
            ClientsDataGridView.AllowUserToResizeColumns = false;
            ClientsDataGridView.AllowUserToResizeRows = false;
            ClientsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ClientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ClientsDataGridView.BackgroundColor = Color.Moccasin;
            ClientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ClientId, FirstName, MiddleName, LastName, Phone, Email, Address, ClientLegalType });
            ClientsDataGridView.Location = new Point(3, 111);
            ClientsDataGridView.Name = "ClientsDataGridView";
            ClientsDataGridView.RowHeadersWidth = 51;
            ClientsDataGridView.RowTemplate.Height = 24;
            ClientsDataGridView.Size = new Size(1344, 671);
            ClientsDataGridView.TabIndex = 0;
            ClientsDataGridView.CellContentClick += ClientsDataGridView_CellContentClick;
            // 
            // ClientId
            // 
            ClientId.DataPropertyName = "ClientId";
            ClientId.HeaderText = "Номер";
            ClientId.MinimumWidth = 6;
            ClientId.Name = "ClientId";
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "Име";
            FirstName.MinimumWidth = 6;
            FirstName.Name = "FirstName";
            // 
            // MiddleName
            // 
            MiddleName.DataPropertyName = "MiddleName";
            MiddleName.HeaderText = "Презиме";
            MiddleName.MinimumWidth = 6;
            MiddleName.Name = "MiddleName";
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
            Phone.HeaderText = "телефон";
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
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Адрес";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            // 
            // ClientLegalType
            // 
            ClientLegalType.DataPropertyName = "ClientLegalType";
            ClientLegalType.HeaderText = "Лице";
            ClientLegalType.MinimumWidth = 6;
            ClientLegalType.Name = "ClientLegalType";
            // 
            // ClientsAddButton
            // 
            ClientsAddButton.BackColor = Color.Transparent;
            ClientsAddButton.BackgroundImage = (Image)resources.GetObject("ClientsAddButton.BackgroundImage");
            ClientsAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            ClientsAddButton.Location = new Point(103, 15);
            ClientsAddButton.Name = "ClientsAddButton";
            ClientsAddButton.Size = new Size(35, 35);
            ClientsAddButton.TabIndex = 2;
            ClientsAddButton.Text = "+";
            ClientsAddButton.UseVisualStyleBackColor = false;
            ClientsAddButton.Click += button1_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BackgroundImage = (Image)resources.GetObject("RefreshButton.BackgroundImage");
            RefreshButton.BackgroundImageLayout = ImageLayout.Stretch;
            RefreshButton.Location = new Point(144, 15);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(35, 35);
            RefreshButton.TabIndex = 4;
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 15);
            label1.Name = "label1";
            label1.Size = new Size(89, 28);
            label1.TabIndex = 5;
            label1.Text = "Клиенти";
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.Fixed3D;
            panel7.Controls.Add(btnLastClientsDataGridView);
            panel7.Controls.Add(btnNextClientsDataGridView);
            panel7.Controls.Add(btnPreviousClientsDataGridView);
            panel7.Controls.Add(btnFirstClientsDataGridView);
            panel7.Location = new Point(8, 56);
            panel7.Name = "panel7";
            panel7.Size = new Size(187, 50);
            panel7.TabIndex = 22;
            panel7.Paint += panel7_Paint;
            // 
            // btnLastClientsDataGridView
            // 
            btnLastClientsDataGridView.BackColor = Color.Transparent;
            btnLastClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastClientsDataGridView.BackgroundImage");
            btnLastClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastClientsDataGridView.Location = new Point(141, 3);
            btnLastClientsDataGridView.Name = "btnLastClientsDataGridView";
            btnLastClientsDataGridView.Size = new Size(40, 40);
            btnLastClientsDataGridView.TabIndex = 3;
            btnLastClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnNextClientsDataGridView
            // 
            btnNextClientsDataGridView.BackColor = Color.Transparent;
            btnNextClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextClientsDataGridView.BackgroundImage");
            btnNextClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextClientsDataGridView.Location = new Point(95, 3);
            btnNextClientsDataGridView.Name = "btnNextClientsDataGridView";
            btnNextClientsDataGridView.Size = new Size(40, 40);
            btnNextClientsDataGridView.TabIndex = 2;
            btnNextClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnPreviousClientsDataGridView
            // 
            btnPreviousClientsDataGridView.BackColor = Color.Transparent;
            btnPreviousClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousClientsDataGridView.BackgroundImage");
            btnPreviousClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousClientsDataGridView.Location = new Point(49, 3);
            btnPreviousClientsDataGridView.Name = "btnPreviousClientsDataGridView";
            btnPreviousClientsDataGridView.Size = new Size(40, 40);
            btnPreviousClientsDataGridView.TabIndex = 1;
            btnPreviousClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnFirstClientsDataGridView
            // 
            btnFirstClientsDataGridView.BackColor = Color.Transparent;
            btnFirstClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstClientsDataGridView.BackgroundImage");
            btnFirstClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstClientsDataGridView.Location = new Point(3, 3);
            btnFirstClientsDataGridView.Name = "btnFirstClientsDataGridView";
            btnFirstClientsDataGridView.Size = new Size(40, 40);
            btnFirstClientsDataGridView.TabIndex = 0;
            btnFirstClientsDataGridView.UseVisualStyleBackColor = false;
            btnFirstClientsDataGridView.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 24;
            label2.Text = "Номер : ";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(phoneTextBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(emailTextBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(FullNameTextBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numberTextBox);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(267, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 90);
            panel1.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(-2, 0);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 32;
            label6.Text = "филтри";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(364, 55);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(182, 27);
            phoneTextBox.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(313, 51);
            label5.Name = "label5";
            label5.Size = new Size(55, 28);
            label5.TabIndex = 30;
            label5.Text = "тел : ";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(87, 55);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(220, 27);
            emailTextBox.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 51);
            label4.Name = "label4";
            label4.Size = new Size(73, 28);
            label4.TabIndex = 28;
            label4.Text = "Email : ";
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Location = new Point(265, 15);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(281, 27);
            FullNameTextBox.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(177, 11);
            label3.Name = "label3";
            label3.Size = new Size(87, 28);
            label3.TabIndex = 26;
            label3.Text = "Имена : ";
            // 
            // numberTextBox
            // 
            numberTextBox.Location = new Point(86, 15);
            numberTextBox.Name = "numberTextBox";
            numberTextBox.Size = new Size(85, 27);
            numberTextBox.TabIndex = 25;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(185, 15);
            button1.Name = "button1";
            button1.Size = new Size(35, 35);
            button1.TabIndex = 23;
            button1.UseVisualStyleBackColor = false;
            // 
            // EditClientButton
            // 
            EditClientButton.BackColor = Color.Transparent;
            EditClientButton.BackgroundImage = (Image)resources.GetObject("EditClientButton.BackgroundImage");
            EditClientButton.BackgroundImageLayout = ImageLayout.Stretch;
            EditClientButton.Location = new Point(226, 15);
            EditClientButton.Name = "EditClientButton";
            EditClientButton.Size = new Size(35, 35);
            EditClientButton.TabIndex = 26;
            EditClientButton.UseVisualStyleBackColor = false;
            EditClientButton.Click += EditClientButton_Click;
            // 
            // MenuClientsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(EditClientButton);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(panel7);
            Controls.Add(label1);
            Controls.Add(RefreshButton);
            Controls.Add(ClientsAddButton);
            Controls.Add(ClientsDataGridView);
            Name = "MenuClientsUserControl";
            Size = new Size(1350, 785);
            Load += MenuClientsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).EndInit();
            panel7.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView ClientsDataGridView;
        private System.Windows.Forms.Button ClientsAddButton;
        private Button RefreshButton;
        private DataGridViewTextBoxColumn ClientId;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn MiddleName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ClientLegalType;
        private Label label1;
        private Panel panel7;
        private Button btnLastClientsDataGridView;
        private Button btnNextClientsDataGridView;
        private Button btnPreviousClientsDataGridView;
        private Button btnFirstClientsDataGridView;
        private Label label2;
        private Panel panel1;
        private TextBox phoneTextBox;
        private Label label5;
        private TextBox emailTextBox;
        private Label label4;
        private TextBox FullNameTextBox;
        private Label label3;
        private TextBox numberTextBox;
        private Label label6;
        private Button button1;
        private Button EditClientButton;
    }
}
