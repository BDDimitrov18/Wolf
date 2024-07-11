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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            RequestDataGridView = new DataGridView();
            RequestId = new DataGridViewTextBoxColumn();
            RequestName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            PaymentStatus = new DataGridViewTextBoxColumn();
            Advance = new DataGridViewTextBoxColumn();
            Comments = new DataGridViewTextBoxColumn();
            RequestTableLabel = new Label();
            RequestAddButton = new Button();
            RequestTitleLabel = new Label();
            label5 = new Label();
            InvoicesDataGridView = new DataGridView();
            InvoiceId = new DataGridViewTextBoxColumn();
            Sum = new DataGridViewTextBoxColumn();
            InvoicesTableLabel = new Label();
            button3 = new Button();
            panel1 = new Panel();
            button8 = new Button();
            panel3 = new Panel();
            DeleteRequestButton = new Button();
            RefreshButton = new Button();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            CreateDocumentButton = new Button();
            DeleteActivityButton = new Button();
            ActivityTableLabel = new Label();
            ActivityDataGridView = new DataGridView();
            ParentActivity = new DataGridViewTextBoxColumn();
            Activity = new DataGridViewTextBoxColumn();
            Task = new DataGridViewTextBoxColumn();
            Executant = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Control = new DataGridViewTextBoxColumn();
            Plots = new DataGridViewTextBoxColumn();
            Comment = new DataGridViewTextBoxColumn();
            ActivityAddButton = new Button();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            deleteClientsButton = new Button();
            button1 = new Button();
            ClientsTableLabel = new Label();
            clientsDataGridView = new DataGridView();
            ClientNumber = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            MiddleName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ClientLegalType = new DataGridViewTextBoxColumn();
            DocumentsOfOwnershipTab = new TabControl();
            tabPage3 = new TabPage();
            panel5 = new Panel();
            button5 = new Button();
            PlotsTableLabel = new Label();
            PlotsDataGridView = new DataGridView();
            PlotNumber = new DataGridViewTextBoxColumn();
            RegulatedPlotNumber = new DataGridViewTextBoxColumn();
            neighborhood = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            Municipality = new DataGridViewTextBoxColumn();
            Street = new DataGridViewTextBoxColumn();
            StreetNumber = new DataGridViewTextBoxColumn();
            designation = new DataGridViewTextBoxColumn();
            locality = new DataGridViewTextBoxColumn();
            PlotsAddButton = new Button();
            DestinationOfPlotLabel = new Label();
            tabPage5 = new TabPage();
            button6 = new Button();
            AddOwnersButton = new Button();
            label2 = new Label();
            OwnershipDataGridView = new DataGridView();
            PlotNumberDocTable = new DataGridViewTextBoxColumn();
            DocumentId = new DataGridViewTextBoxColumn();
            OwnerId = new DataGridViewTextBoxColumn();
            EKG = new DataGridViewTextBoxColumn();
            OwnerAddress = new DataGridViewTextBoxColumn();
            IdealParts = new DataGridViewTextBoxColumn();
            PowerOfAttorney = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityDataGridView).BeginInit();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).BeginInit();
            DocumentsOfOwnershipTab.SuspendLayout();
            tabPage3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PlotsDataGridView).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OwnershipDataGridView).BeginInit();
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
            RequestDataGridView.Size = new Size(882, 335);
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
            RequestTableLabel.Size = new Size(71, 20);
            RequestTableLabel.TabIndex = 1;
            RequestTableLabel.Text = "Поръчки";
            RequestTableLabel.Click += label1_Click_1;
            // 
            // RequestAddButton
            // 
            RequestAddButton.Location = new Point(70, 49);
            RequestAddButton.Margin = new Padding(3, 4, 3, 4);
            RequestAddButton.Name = "RequestAddButton";
            RequestAddButton.Size = new Size(26, 29);
            RequestAddButton.TabIndex = 2;
            RequestAddButton.Text = "+";
            RequestAddButton.UseVisualStyleBackColor = true;
            RequestAddButton.Click += button1_Click;
            // 
            // RequestTitleLabel
            // 
            RequestTitleLabel.Anchor = AnchorStyles.Top;
            RequestTitleLabel.AutoSize = true;
            RequestTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            RequestTitleLabel.Location = new Point(604, 42);
            RequestTitleLabel.Name = "RequestTitleLabel";
            RequestTitleLabel.Size = new Size(170, 42);
            RequestTitleLabel.TabIndex = 6;
            RequestTitleLabel.Text = "Поръчки";
            RequestTitleLabel.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 432);
            label5.Name = "label5";
            label5.Size = new Size(124, 20);
            label5.TabIndex = 10;
            label5.Text = "Път Към Обекта:";
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
            InvoicesDataGridView.Location = new Point(0, 84);
            InvoicesDataGridView.Margin = new Padding(3, 4, 3, 4);
            InvoicesDataGridView.Name = "InvoicesDataGridView";
            InvoicesDataGridView.RowHeadersWidth = 51;
            InvoicesDataGridView.RowTemplate.Height = 24;
            InvoicesDataGridView.Size = new Size(359, 335);
            InvoicesDataGridView.TabIndex = 11;
            InvoicesDataGridView.CellContentClick += InvoicesDataGridView_CellContentClick;
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
            InvoicesTableLabel.Location = new Point(3, 53);
            InvoicesTableLabel.Name = "InvoicesTableLabel";
            InvoicesTableLabel.Size = new Size(66, 20);
            InvoicesTableLabel.TabIndex = 12;
            InvoicesTableLabel.Text = "Фактури";
            // 
            // button3
            // 
            button3.Location = new Point(73, 49);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(23, 30);
            button3.TabIndex = 13;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(button8);
            panel1.Controls.Add(InvoicesDataGridView);
            panel1.Controls.Add(InvoicesTableLabel);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(962, 119);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 467);
            panel1.TabIndex = 16;
            panel1.Paint += panel1_Paint;
            // 
            // button8
            // 
            button8.Location = new Point(102, 50);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 14;
            button8.Text = "изтриване";
            button8.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(DeleteRequestButton);
            panel3.Controls.Add(RefreshButton);
            panel3.Controls.Add(RequestDataGridView);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(RequestTableLabel);
            panel3.Controls.Add(RequestAddButton);
            panel3.Location = new Point(33, 119);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(882, 467);
            panel3.TabIndex = 17;
            panel3.Paint += panel3_Paint;
            // 
            // DeleteRequestButton
            // 
            DeleteRequestButton.Location = new Point(202, 48);
            DeleteRequestButton.Name = "DeleteRequestButton";
            DeleteRequestButton.Size = new Size(94, 29);
            DeleteRequestButton.TabIndex = 12;
            DeleteRequestButton.Text = "изтриване";
            DeleteRequestButton.UseVisualStyleBackColor = true;
            DeleteRequestButton.Click += DeleteRequestButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(102, 49);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(94, 29);
            RefreshButton.TabIndex = 11;
            RefreshButton.Text = "Обнови";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1283, 304);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Дейности";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(CreateDocumentButton);
            panel2.Controls.Add(DeleteActivityButton);
            panel2.Controls.Add(ActivityTableLabel);
            panel2.Controls.Add(ActivityDataGridView);
            panel2.Controls.Add(ActivityAddButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1277, 298);
            panel2.TabIndex = 36;
            // 
            // CreateDocumentButton
            // 
            CreateDocumentButton.Location = new Point(1105, 12);
            CreateDocumentButton.Name = "CreateDocumentButton";
            CreateDocumentButton.Size = new Size(155, 29);
            CreateDocumentButton.TabIndex = 30;
            CreateDocumentButton.Text = "Създай Заявление";
            CreateDocumentButton.UseVisualStyleBackColor = true;
            CreateDocumentButton.Click += CreateDocumentButton_Click;
            // 
            // DeleteActivityButton
            // 
            DeleteActivityButton.Location = new Point(119, 12);
            DeleteActivityButton.Name = "DeleteActivityButton";
            DeleteActivityButton.Size = new Size(94, 29);
            DeleteActivityButton.TabIndex = 29;
            DeleteActivityButton.Text = "изтриване";
            DeleteActivityButton.UseVisualStyleBackColor = true;
            DeleteActivityButton.Click += DeleteActivityButton_Click;
            // 
            // ActivityTableLabel
            // 
            ActivityTableLabel.AutoSize = true;
            ActivityTableLabel.Location = new Point(13, 16);
            ActivityTableLabel.Name = "ActivityTableLabel";
            ActivityTableLabel.Size = new Size(76, 20);
            ActivityTableLabel.TabIndex = 24;
            ActivityTableLabel.Text = "Дейности";
            // 
            // ActivityDataGridView
            // 
            ActivityDataGridView.AllowUserToResizeColumns = false;
            ActivityDataGridView.AllowUserToResizeRows = false;
            ActivityDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ActivityDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActivityDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ActivityDataGridView.BackgroundColor = Color.Moccasin;
            ActivityDataGridView.ColumnHeadersHeight = 28;
            ActivityDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ActivityDataGridView.Columns.AddRange(new DataGridViewColumn[] { ParentActivity, Activity, Task, Executant, StartDate, Duration, Control, Plots, Comment });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ActivityDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            ActivityDataGridView.Location = new Point(0, 50);
            ActivityDataGridView.Margin = new Padding(3, 4, 3, 4);
            ActivityDataGridView.MinimumSize = new Size(933, 188);
            ActivityDataGridView.Name = "ActivityDataGridView";
            ActivityDataGridView.RowHeadersWidth = 51;
            ActivityDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ActivityDataGridView.RowTemplate.Height = 350;
            ActivityDataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            ActivityDataGridView.Size = new Size(1277, 247);
            ActivityDataGridView.TabIndex = 22;
            // 
            // ParentActivity
            // 
            ParentActivity.DataPropertyName = "ParentActivity";
            ParentActivity.HeaderText = "Произлиза от";
            ParentActivity.MinimumWidth = 6;
            ParentActivity.Name = "ParentActivity";
            // 
            // Activity
            // 
            Activity.DataPropertyName = "ActivityTypeName";
            Activity.HeaderText = "Дейност";
            Activity.MinimumWidth = 6;
            Activity.Name = "Activity";
            // 
            // Task
            // 
            Task.DataPropertyName = "TaskTypeName";
            Task.HeaderText = "Задача";
            Task.MinimumWidth = 6;
            Task.Name = "Task";
            // 
            // Executant
            // 
            Executant.DataPropertyName = "ExecutantFullName";
            Executant.HeaderText = "Изпълнител";
            Executant.MinimumWidth = 6;
            Executant.Name = "Executant";
            // 
            // StartDate
            // 
            StartDate.DataPropertyName = "StartDate";
            StartDate.HeaderText = "Дата";
            StartDate.MinimumWidth = 6;
            StartDate.Name = "StartDate";
            // 
            // Duration
            // 
            Duration.DataPropertyName = "Duration";
            Duration.HeaderText = "Времетраене";
            Duration.MinimumWidth = 6;
            Duration.Name = "Duration";
            // 
            // Control
            // 
            Control.DataPropertyName = "ControlFullName";
            Control.HeaderText = "Контрол";
            Control.MinimumWidth = 6;
            Control.Name = "Control";
            // 
            // Plots
            // 
            Plots.DataPropertyName = "Identities";
            Plots.HeaderText = "Идентификатори";
            Plots.MinimumWidth = 6;
            Plots.Name = "Plots";
            // 
            // Comment
            // 
            Comment.DataPropertyName = "Comments";
            Comment.HeaderText = "Коментар";
            Comment.MinimumWidth = 6;
            Comment.Name = "Comment";
            // 
            // ActivityAddButton
            // 
            ActivityAddButton.Location = new Point(89, 10);
            ActivityAddButton.Margin = new Padding(3, 4, 3, 4);
            ActivityAddButton.Name = "ActivityAddButton";
            ActivityAddButton.Size = new Size(24, 32);
            ActivityAddButton.TabIndex = 28;
            ActivityAddButton.Text = "+";
            ActivityAddButton.UseVisualStyleBackColor = true;
            ActivityAddButton.Click += ActivityAddButton_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel4);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1283, 304);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Клиенти";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(deleteClientsButton);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(ClientsTableLabel);
            panel4.Controls.Add(clientsDataGridView);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1277, 298);
            panel4.TabIndex = 18;
            // 
            // deleteClientsButton
            // 
            deleteClientsButton.Location = new Point(198, 9);
            deleteClientsButton.Name = "deleteClientsButton";
            deleteClientsButton.Size = new Size(94, 29);
            deleteClientsButton.TabIndex = 12;
            deleteClientsButton.Text = "изтриване";
            deleteClientsButton.UseVisualStyleBackColor = true;
            deleteClientsButton.Click += deleteClientsButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(166, 9);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(26, 29);
            button1.TabIndex = 11;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ClientsTableLabel
            // 
            ClientsTableLabel.AutoSize = true;
            ClientsTableLabel.Location = new Point(0, 13);
            ClientsTableLabel.Name = "ClientsTableLabel";
            ClientsTableLabel.Size = new Size(169, 20);
            ClientsTableLabel.TabIndex = 9;
            ClientsTableLabel.Text = "Клиенти На Поръчката";
            // 
            // clientsDataGridView
            // 
            clientsDataGridView.AllowUserToResizeColumns = false;
            clientsDataGridView.AllowUserToResizeRows = false;
            clientsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            clientsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            clientsDataGridView.BackgroundColor = Color.Moccasin;
            clientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ClientNumber, FirstName, MiddleName, LastName, Phone, Email, Address, ClientLegalType });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            clientsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            clientsDataGridView.GridColor = SystemColors.ControlText;
            clientsDataGridView.Location = new Point(1, 46);
            clientsDataGridView.Margin = new Padding(3, 4, 3, 4);
            clientsDataGridView.Name = "clientsDataGridView";
            clientsDataGridView.RowHeadersWidth = 51;
            clientsDataGridView.RowTemplate.Height = 24;
            clientsDataGridView.Size = new Size(1273, 251);
            clientsDataGridView.TabIndex = 8;
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
            // DocumentsOfOwnershipTab
            // 
            DocumentsOfOwnershipTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DocumentsOfOwnershipTab.Controls.Add(tabPage1);
            DocumentsOfOwnershipTab.Controls.Add(tabPage2);
            DocumentsOfOwnershipTab.Controls.Add(tabPage3);
            DocumentsOfOwnershipTab.Controls.Add(tabPage5);
            DocumentsOfOwnershipTab.Location = new Point(30, 624);
            DocumentsOfOwnershipTab.Name = "DocumentsOfOwnershipTab";
            DocumentsOfOwnershipTab.SelectedIndex = 0;
            DocumentsOfOwnershipTab.Size = new Size(1291, 337);
            DocumentsOfOwnershipTab.TabIndex = 12;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel5);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1283, 304);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "имоти";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(button5);
            panel5.Controls.Add(PlotsTableLabel);
            panel5.Controls.Add(PlotsDataGridView);
            panel5.Controls.Add(PlotsAddButton);
            panel5.Controls.Add(DestinationOfPlotLabel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 3);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1277, 298);
            panel5.TabIndex = 35;
            // 
            // button5
            // 
            button5.Location = new Point(243, 5);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 32;
            button5.Text = "изтриване";
            button5.UseVisualStyleBackColor = true;
            // 
            // PlotsTableLabel
            // 
            PlotsTableLabel.AutoSize = true;
            PlotsTableLabel.BackColor = Color.Transparent;
            PlotsTableLabel.Location = new Point(-3, 9);
            PlotsTableLabel.Name = "PlotsTableLabel";
            PlotsTableLabel.Size = new Size(210, 20);
            PlotsTableLabel.TabIndex = 25;
            PlotsTableLabel.Text = "Имоти в селектирания обект";
            // 
            // PlotsDataGridView
            // 
            PlotsDataGridView.AllowUserToResizeColumns = false;
            PlotsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            PlotsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            PlotsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlotsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PlotsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            PlotsDataGridView.BackgroundColor = Color.Moccasin;
            PlotsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            PlotsDataGridView.ColumnHeadersHeight = 29;
            PlotsDataGridView.Columns.AddRange(new DataGridViewColumn[] { PlotNumber, RegulatedPlotNumber, neighborhood, City, Municipality, Street, StreetNumber, designation, locality });
            PlotsDataGridView.Location = new Point(0, 42);
            PlotsDataGridView.Margin = new Padding(100, 4, 3, 4);
            PlotsDataGridView.Name = "PlotsDataGridView";
            PlotsDataGridView.RowHeadersWidth = 51;
            PlotsDataGridView.RowTemplate.Height = 50;
            PlotsDataGridView.Size = new Size(1277, 259);
            PlotsDataGridView.TabIndex = 21;
            // 
            // PlotNumber
            // 
            PlotNumber.DataPropertyName = "PlotNumber";
            PlotNumber.HeaderText = "Номер на имота";
            PlotNumber.MinimumWidth = 6;
            PlotNumber.Name = "PlotNumber";
            // 
            // RegulatedPlotNumber
            // 
            RegulatedPlotNumber.DataPropertyName = "RegulatedPlotNumber";
            RegulatedPlotNumber.HeaderText = "Номер на урегулиран поземлен имот";
            RegulatedPlotNumber.MinimumWidth = 6;
            RegulatedPlotNumber.Name = "RegulatedPlotNumber";
            // 
            // neighborhood
            // 
            neighborhood.DataPropertyName = "neighborhood";
            neighborhood.HeaderText = "квартал";
            neighborhood.MinimumWidth = 6;
            neighborhood.Name = "neighborhood";
            // 
            // City
            // 
            City.DataPropertyName = "City";
            City.HeaderText = "град/село";
            City.MinimumWidth = 6;
            City.Name = "City";
            // 
            // Municipality
            // 
            Municipality.DataPropertyName = "Municipality";
            Municipality.HeaderText = "Община";
            Municipality.MinimumWidth = 6;
            Municipality.Name = "Municipality";
            // 
            // Street
            // 
            Street.DataPropertyName = "Street";
            Street.HeaderText = "улица";
            Street.MinimumWidth = 6;
            Street.Name = "Street";
            // 
            // StreetNumber
            // 
            StreetNumber.DataPropertyName = "StreetNumber";
            StreetNumber.HeaderText = "Номер На Улицата";
            StreetNumber.MinimumWidth = 6;
            StreetNumber.Name = "StreetNumber";
            // 
            // designation
            // 
            designation.DataPropertyName = "designation";
            designation.HeaderText = "Предназначение";
            designation.MinimumWidth = 6;
            designation.Name = "designation";
            // 
            // locality
            // 
            locality.DataPropertyName = "locality";
            locality.HeaderText = "район";
            locality.MinimumWidth = 6;
            locality.Name = "locality";
            // 
            // PlotsAddButton
            // 
            PlotsAddButton.Location = new Point(213, 4);
            PlotsAddButton.Margin = new Padding(3, 4, 3, 4);
            PlotsAddButton.Name = "PlotsAddButton";
            PlotsAddButton.Size = new Size(24, 32);
            PlotsAddButton.TabIndex = 31;
            PlotsAddButton.Text = "+";
            PlotsAddButton.UseVisualStyleBackColor = true;
            PlotsAddButton.Click += PlotsAddButton_Click;
            // 
            // DestinationOfPlotLabel
            // 
            DestinationOfPlotLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DestinationOfPlotLabel.AutoSize = true;
            DestinationOfPlotLabel.Location = new Point(4, 371);
            DestinationOfPlotLabel.Name = "DestinationOfPlotLabel";
            DestinationOfPlotLabel.Size = new Size(207, 20);
            DestinationOfPlotLabel.TabIndex = 30;
            DestinationOfPlotLabel.Text = "Местоположение на имота: ";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(button6);
            tabPage5.Controls.Add(AddOwnersButton);
            tabPage5.Controls.Add(label2);
            tabPage5.Controls.Add(OwnershipDataGridView);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1283, 304);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Собственост";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(146, 12);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 3;
            button6.Text = "изтриване";
            button6.UseVisualStyleBackColor = true;
            // 
            // AddOwnersButton
            // 
            AddOwnersButton.Location = new Point(110, 12);
            AddOwnersButton.Name = "AddOwnersButton";
            AddOwnersButton.Size = new Size(30, 29);
            AddOwnersButton.TabIndex = 2;
            AddOwnersButton.Text = "+";
            AddOwnersButton.UseVisualStyleBackColor = true;
            AddOwnersButton.Click += AddOwnersButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 16);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 1;
            label2.Text = "Собственост";
            // 
            // OwnershipDataGridView
            // 
            OwnershipDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OwnershipDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OwnershipDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            OwnershipDataGridView.BackgroundColor = Color.Moccasin;
            OwnershipDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OwnershipDataGridView.Columns.AddRange(new DataGridViewColumn[] { PlotNumberDocTable, DocumentId, OwnerId, EKG, OwnerAddress, IdealParts, PowerOfAttorney });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            OwnershipDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            OwnershipDataGridView.Location = new Point(-1, 49);
            OwnershipDataGridView.Name = "OwnershipDataGridView";
            OwnershipDataGridView.RowHeadersWidth = 51;
            OwnershipDataGridView.RowTemplate.Height = 29;
            OwnershipDataGridView.Size = new Size(1284, 255);
            OwnershipDataGridView.TabIndex = 0;
            // 
            // PlotNumberDocTable
            // 
            PlotNumberDocTable.DataPropertyName = "PlotNumber";
            PlotNumberDocTable.HeaderText = "Номер на имот";
            PlotNumberDocTable.MinimumWidth = 6;
            PlotNumberDocTable.Name = "PlotNumberDocTable";
            // 
            // DocumentId
            // 
            DocumentId.DataPropertyName = "NumberTypeDocument";
            DocumentId.HeaderText = "Номер и вид на документ";
            DocumentId.MinimumWidth = 6;
            DocumentId.Name = "DocumentId";
            // 
            // OwnerId
            // 
            OwnerId.DataPropertyName = "NumberTypeOwner";
            OwnerId.HeaderText = "Номер и име на собственик";
            OwnerId.MinimumWidth = 6;
            OwnerId.Name = "OwnerId";
            // 
            // EKG
            // 
            EKG.DataPropertyName = "EGN";
            EKG.HeaderText = "ЕГН/ЕКГ";
            EKG.MinimumWidth = 6;
            EKG.Name = "EKG";
            // 
            // OwnerAddress
            // 
            OwnerAddress.DataPropertyName = "Address";
            OwnerAddress.HeaderText = "Адрес";
            OwnerAddress.MinimumWidth = 6;
            OwnerAddress.Name = "OwnerAddress";
            // 
            // IdealParts
            // 
            IdealParts.DataPropertyName = "IdealParts";
            IdealParts.HeaderText = "Идеални части";
            IdealParts.MinimumWidth = 6;
            IdealParts.Name = "IdealParts";
            // 
            // PowerOfAttorney
            // 
            PowerOfAttorney.DataPropertyName = "PowerOfAttorneyNumber";
            PowerOfAttorney.HeaderText = "Пълномощно Номер";
            PowerOfAttorney.MinimumWidth = 6;
            PowerOfAttorney.Name = "PowerOfAttorney";
            // 
            // MenuRequestsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(DocumentsOfOwnershipTab);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(RequestTitleLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuRequestsUserControl";
            Size = new Size(1350, 972);
            Load += MenuRequestsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityDataGridView).EndInit();
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).EndInit();
            DocumentsOfOwnershipTab.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PlotsDataGridView).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OwnershipDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.Label RequestTableLabel;
        private System.Windows.Forms.Button RequestAddButton;
        private System.Windows.Forms.Label RequestTitleLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView InvoicesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.Label InvoicesTableLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Button RefreshButton;
        private DataGridViewTextBoxColumn RequestId;
        private DataGridViewTextBoxColumn RequestName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn PaymentStatus;
        private DataGridViewTextBoxColumn Advance;
        private DataGridViewTextBoxColumn Comments;
        private TabPage tabPage2;
        private Panel panel2;
        private Label ActivityTableLabel;
        private DataGridView ActivityDataGridView;
        private Button ActivityAddButton;
        private TabPage tabPage1;
        private Panel panel4;
        private Button button1;
        private Label ClientsTableLabel;
        private DataGridView clientsDataGridView;
        private DataGridViewTextBoxColumn ClientNumber;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn MiddleName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ClientLegalType;
        private TabControl DocumentsOfOwnershipTab;
        private TabPage tabPage3;
        private Panel panel5;
        private Label PlotsTableLabel;
        private DataGridView PlotsDataGridView;
        private Button PlotsAddButton;
        private Label DestinationOfPlotLabel;
        private DataGridViewTextBoxColumn PlotNumber;
        private DataGridViewTextBoxColumn RegulatedPlotNumber;
        private DataGridViewTextBoxColumn neighborhood;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn Municipality;
        private DataGridViewTextBoxColumn Street;
        private DataGridViewTextBoxColumn StreetNumber;
        private DataGridViewTextBoxColumn designation;
        private DataGridViewTextBoxColumn locality;
        private DataGridViewTextBoxColumn ParentActivity;
        private DataGridViewTextBoxColumn Activity;
        private DataGridViewTextBoxColumn Task;
        private DataGridViewTextBoxColumn Executant;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn Control;
        private DataGridViewTextBoxColumn Plots;
        private DataGridViewTextBoxColumn Comment;
        private TabPage tabPage5;
        private DataGridView OwnershipDataGridView;
        private Button AddOwnersButton;
        private Label label2;
        private Button button8;
        private Button DeleteRequestButton;
        private Button DeleteActivityButton;
        private Button deleteClientsButton;
        private Button button5;
        private Button button6;
        private Button CreateDocumentButton;
        private DataGridViewTextBoxColumn PlotNumberDocTable;
        private DataGridViewTextBoxColumn DocumentId;
        private DataGridViewTextBoxColumn OwnerId;
        private DataGridViewTextBoxColumn EKG;
        private DataGridViewTextBoxColumn OwnerAddress;
        private DataGridViewTextBoxColumn IdealParts;
        private DataGridViewTextBoxColumn PowerOfAttorney;
    }
}
