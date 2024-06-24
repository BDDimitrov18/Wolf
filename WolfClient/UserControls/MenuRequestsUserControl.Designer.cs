using WolfClient.NewForms;

namespace WolfClient.UserControls
{
    partial class MenuRequestsUserControl
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
            RequestDataGridView = new DataGridView();
            RequestId = new DataGridViewTextBoxColumn();
            RequestName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            PaymentStatus = new DataGridViewTextBoxColumn();
            Advance = new DataGridViewTextBoxColumn();
            Comments = new DataGridViewTextBoxColumn();
            RequestTableLabel = new Label();
            RequestAddButton = new Button();
            dataGridView2 = new DataGridView();
            Activity = new DataGridViewTextBoxColumn();
            TaskName = new DataGridViewTextBoxColumn();
            ExecutantId = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Control = new DataGridViewTextBoxColumn();
            Comment = new DataGridViewTextBoxColumn();
            ActivityTableLabel = new Label();
            button2 = new Button();
            RequestTitleLabel = new Label();
            clientsDataGridView = new DataGridView();
            ClientsTableLabel = new Label();
            label5 = new Label();
            InvoicesDataGridView = new DataGridView();
            InvoiceId = new DataGridViewTextBoxColumn();
            Sum = new DataGridViewTextBoxColumn();
            InvoicesTableLabel = new Label();
            button3 = new Button();
            ActivityDataGridView = new Panel();
            panel1 = new Panel();
            panel3 = new Panel();
            RefreshButton = new Button();
            panel4 = new Panel();
            button1 = new Button();
            ClientNumber = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            MiddleName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ClientLegalType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).BeginInit();
            ActivityDataGridView.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // RequestDataGridView
            // 
            RequestDataGridView.AllowUserToResizeColumns = false;
            RequestDataGridView.AllowUserToResizeRows = false;
            RequestDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RequestDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            RequestDataGridView.BackgroundColor = Color.Moccasin;
            RequestDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RequestDataGridView.Columns.AddRange(new DataGridViewColumn[] { RequestId, RequestName, Price, PaymentStatus, Advance, Comments });
            RequestDataGridView.GridColor = SystemColors.ControlText;
            RequestDataGridView.Location = new Point(0, 84);
            RequestDataGridView.Margin = new Padding(3, 4, 3, 4);
            RequestDataGridView.Name = "RequestDataGridView";
            RequestDataGridView.RowHeadersWidth = 51;
            RequestDataGridView.RowTemplate.Height = 24;
            RequestDataGridView.Size = new Size(798, 335);
            RequestDataGridView.TabIndex = 0;
            // 
            // RequestId
            // 
            RequestId.DataPropertyName = "RequestId";
            RequestId.HeaderText = "Номер";
            RequestId.MinimumWidth = 6;
            RequestId.Name = "RequestId";
            // 
            // RequestName
            // 
            RequestName.DataPropertyName = "RequestName";
            RequestName.HeaderText = "Име";
            RequestName.MinimumWidth = 6;
            RequestName.Name = "RequestName";
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Цена";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            // 
            // PaymentStatus
            // 
            PaymentStatus.DataPropertyName = "PaymentStatus";
            PaymentStatus.HeaderText = "Статус на Плащане";
            PaymentStatus.MinimumWidth = 6;
            PaymentStatus.Name = "PaymentStatus";
            // 
            // Advance
            // 
            Advance.DataPropertyName = "Advance";
            Advance.HeaderText = "Аванс";
            Advance.MinimumWidth = 6;
            Advance.Name = "Advance";
            // 
            // Comments
            // 
            Comments.DataPropertyName = "Comments";
            Comments.HeaderText = "Коментар";
            Comments.MinimumWidth = 6;
            Comments.Name = "Comments";
            // 
            // RequestTableLabel
            // 
            RequestTableLabel.AutoSize = true;
            RequestTableLabel.Location = new Point(-3, 52);
            RequestTableLabel.Name = "RequestTableLabel";
            RequestTableLabel.Size = new Size(57, 20);
            RequestTableLabel.TabIndex = 1;
            RequestTableLabel.Text = "Заявки";
            RequestTableLabel.Click += label1_Click_1;
            // 
            // RequestAddButton
            // 
            RequestAddButton.Location = new Point(57, 49);
            RequestAddButton.Margin = new Padding(3, 4, 3, 4);
            RequestAddButton.Name = "RequestAddButton";
            RequestAddButton.Size = new Size(26, 29);
            RequestAddButton.TabIndex = 2;
            RequestAddButton.Text = "+";
            RequestAddButton.UseVisualStyleBackColor = true;
            RequestAddButton.Click += button1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.BackgroundColor = Color.Moccasin;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Activity, TaskName, ExecutantId, Date, Duration, Control, Comment });
            dataGridView2.GridColor = SystemColors.ActiveCaptionText;
            dataGridView2.Location = new Point(0, 100);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 24;
            dataGridView2.Size = new Size(940, 231);
            dataGridView2.TabIndex = 3;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Activity
            // 
            Activity.HeaderText = "Дейност";
            Activity.MinimumWidth = 6;
            Activity.Name = "Activity";
            // 
            // TaskName
            // 
            TaskName.HeaderText = "Задача";
            TaskName.MinimumWidth = 6;
            TaskName.Name = "TaskName";
            // 
            // ExecutantId
            // 
            ExecutantId.HeaderText = "Изпълнител";
            ExecutantId.MinimumWidth = 6;
            ExecutantId.Name = "ExecutantId";
            // 
            // Date
            // 
            Date.HeaderText = "Дата";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            // 
            // Duration
            // 
            Duration.HeaderText = "Времетраене";
            Duration.MinimumWidth = 6;
            Duration.Name = "Duration";
            // 
            // Control
            // 
            Control.HeaderText = "Контрол";
            Control.MinimumWidth = 6;
            Control.Name = "Control";
            // 
            // Comment
            // 
            Comment.HeaderText = "Коментар";
            Comment.MinimumWidth = 6;
            Comment.Name = "Comment";
            // 
            // ActivityTableLabel
            // 
            ActivityTableLabel.AutoSize = true;
            ActivityTableLabel.Location = new Point(-4, 68);
            ActivityTableLabel.Name = "ActivityTableLabel";
            ActivityTableLabel.Size = new Size(76, 20);
            ActivityTableLabel.TabIndex = 4;
            ActivityTableLabel.Text = "Дейности";
            ActivityTableLabel.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(72, 64);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(26, 29);
            button2.TabIndex = 5;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // RequestTitleLabel
            // 
            RequestTitleLabel.Anchor = AnchorStyles.Top;
            RequestTitleLabel.AutoSize = true;
            RequestTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            RequestTitleLabel.Location = new Point(604, 42);
            RequestTitleLabel.Name = "RequestTitleLabel";
            RequestTitleLabel.Size = new Size(142, 42);
            RequestTitleLabel.TabIndex = 6;
            RequestTitleLabel.Text = "Заявки";
            RequestTitleLabel.Click += label3_Click;
            // 
            // clientsDataGridView
            // 
            clientsDataGridView.AllowUserToResizeColumns = false;
            clientsDataGridView.AllowUserToResizeRows = false;
            clientsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            clientsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            clientsDataGridView.BackgroundColor = Color.Moccasin;
            clientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ClientNumber, FirstName, MiddleName, LastName, Phone, Email, Address, ClientLegalType });
            clientsDataGridView.GridColor = SystemColors.ControlText;
            clientsDataGridView.Location = new Point(0, 84);
            clientsDataGridView.Margin = new Padding(3, 4, 3, 4);
            clientsDataGridView.Name = "clientsDataGridView";
            clientsDataGridView.RowHeadersWidth = 51;
            clientsDataGridView.RowTemplate.Height = 24;
            clientsDataGridView.Size = new Size(459, 335);
            clientsDataGridView.TabIndex = 8;
            // 
            // ClientsTableLabel
            // 
            ClientsTableLabel.AutoSize = true;
            ClientsTableLabel.Location = new Point(3, 49);
            ClientsTableLabel.Name = "ClientsTableLabel";
            ClientsTableLabel.Size = new Size(155, 20);
            ClientsTableLabel.TabIndex = 9;
            ClientsTableLabel.Text = "Клиенти На Заявката";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 418);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 10;
            label5.Text = "Път Към Заявката:";
            // 
            // InvoicesDataGridView
            // 
            InvoicesDataGridView.AllowUserToResizeColumns = false;
            InvoicesDataGridView.AllowUserToResizeRows = false;
            InvoicesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InvoicesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InvoicesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            InvoicesDataGridView.BackgroundColor = Color.Moccasin;
            InvoicesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InvoicesDataGridView.Columns.AddRange(new DataGridViewColumn[] { InvoiceId, Sum });
            InvoicesDataGridView.Location = new Point(0, 100);
            InvoicesDataGridView.Margin = new Padding(3, 4, 3, 4);
            InvoicesDataGridView.Name = "InvoicesDataGridView";
            InvoicesDataGridView.RowHeadersWidth = 51;
            InvoicesDataGridView.RowTemplate.Height = 24;
            InvoicesDataGridView.Size = new Size(331, 231);
            InvoicesDataGridView.TabIndex = 11;
            // 
            // InvoiceId
            // 
            InvoiceId.HeaderText = "Номер";
            InvoiceId.MinimumWidth = 6;
            InvoiceId.Name = "InvoiceId";
            // 
            // Sum
            // 
            Sum.HeaderText = "Сума";
            Sum.MinimumWidth = 6;
            Sum.Name = "Sum";
            // 
            // InvoicesTableLabel
            // 
            InvoicesTableLabel.AutoSize = true;
            InvoicesTableLabel.Location = new Point(0, 68);
            InvoicesTableLabel.Name = "InvoicesTableLabel";
            InvoicesTableLabel.Size = new Size(66, 20);
            InvoicesTableLabel.TabIndex = 12;
            InvoicesTableLabel.Text = "Фактури";
            // 
            // button3
            // 
            button3.Location = new Point(70, 64);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(23, 30);
            button3.TabIndex = 13;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ActivityDataGridView
            // 
            ActivityDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ActivityDataGridView.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ActivityDataGridView.Controls.Add(ActivityTableLabel);
            ActivityDataGridView.Controls.Add(dataGridView2);
            ActivityDataGridView.Controls.Add(button2);
            ActivityDataGridView.Location = new Point(33, 585);
            ActivityDataGridView.Margin = new Padding(3, 4, 3, 4);
            ActivityDataGridView.Name = "ActivityDataGridView";
            ActivityDataGridView.Size = new Size(943, 339);
            ActivityDataGridView.TabIndex = 15;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(InvoicesDataGridView);
            panel1.Controls.Add(InvoicesTableLabel);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(998, 585);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 339);
            panel1.TabIndex = 16;
            panel1.Paint += panel1_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(RefreshButton);
            panel3.Controls.Add(RequestDataGridView);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(RequestTableLabel);
            panel3.Controls.Add(RequestAddButton);
            panel3.Location = new Point(33, 119);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(798, 419);
            panel3.TabIndex = 17;
            panel3.Paint += panel3_Paint;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(89, 49);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(94, 29);
            RefreshButton.TabIndex = 11;
            RefreshButton.Text = "Обнови";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(button1);
            panel4.Controls.Add(ClientsTableLabel);
            panel4.Controls.Add(clientsDataGridView);
            panel4.Location = new Point(870, 119);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(459, 419);
            panel4.TabIndex = 18;
            // 
            // button1
            // 
            button1.Location = new Point(157, 44);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(26, 29);
            button1.TabIndex = 11;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ClientNumber
            // 
            ClientNumber.DataPropertyName = "ClientId";
            ClientNumber.HeaderText = "Номер";
            ClientNumber.MinimumWidth = 6;
            ClientNumber.Name = "ClientNumber";
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
            // MenuRequestsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(ActivityDataGridView);
            Controls.Add(RequestTitleLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuRequestsUserControl";
            Size = new Size(1350, 961);
            Load += MenuRequestsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).EndInit();
            ActivityDataGridView.ResumeLayout(false);
            ActivityDataGridView.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.Label RequestTableLabel;
        private System.Windows.Forms.Button RequestAddButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecutantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Label ActivityTableLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label RequestTitleLabel;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.Label ClientsTableLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView InvoicesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.Label InvoicesTableLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel ActivityDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private Button RefreshButton;
        private DataGridViewTextBoxColumn RequestId;
        private DataGridViewTextBoxColumn RequestName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn PaymentStatus;
        private DataGridViewTextBoxColumn Advance;
        private DataGridViewTextBoxColumn Comments;
        private DataGridViewTextBoxColumn ClientNumber;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn MiddleName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ClientLegalType;
    }
}
