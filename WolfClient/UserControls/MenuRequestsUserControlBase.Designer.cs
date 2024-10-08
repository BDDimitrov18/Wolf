﻿using WolfClient.NewForms;

namespace WolfClient.UserControls
{
    partial class MenuRequestsUserControlBase
    {

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
        protected void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuRequestsUserControlBase));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            RequestDataGridView = new DataGridView();
            RequestId = new DataGridViewTextBoxColumn();
            RequestName = new DataGridViewTextBoxColumn();
            PaymentStatus = new DataGridViewTextBoxColumn();
            Comments = new DataGridViewTextBoxColumn();
            PlotsInfo = new DataGridViewTextBoxColumn();
            RequestTableLabel = new Label();
            RequestAddButton = new Button();
            label5 = new Label();
            InvoicesDataGridView = new DataGridView();
            number = new DataGridViewTextBoxColumn();
            Sum = new DataGridViewTextBoxColumn();
            addInvoiceButton = new Button();
            DeleteInvoiceButton = new Button();
            panel3 = new Panel();
            PathLink = new LinkLabel();
            panel7 = new Panel();
            starRequestButton = new Button();
            btnLastRequestsDataGridView = new Button();
            btnNextRequestsDataGridView = new Button();
            btnPreviousRequestsDataGridView = new Button();
            btnFirstRequestsDataGridView = new Button();
            editRequestButton = new Button();
            DeleteRequestButton = new Button();
            RefreshButton = new Button();
            RequestFiltersApplyButton = new Button();
            filtersPanel = new Panel();
            requestNameFilter = new TextBox();
            label6 = new Label();
            EmployeesFilterCheckBoxList = new CheckedListBox();
            EmployeesFilterLabel = new Label();
            OwnersFlowLayoutPanelFilter = new FlowLayoutPanel();
            button2 = new Button();
            AddClientButton = new Button();
            clientsFlowLayoutPanel = new FlowLayoutPanel();
            overdueFilter = new CheckBox();
            label14 = new Label();
            label4 = new Label();
            cmbPaymentStatus = new ComboBox();
            label13 = new Label();
            label3 = new Label();
            CommentsTextBox = new RichTextBox();
            txtNumber = new TextBox();
            label12 = new Label();
            statusCheckBox = new ComboBox();
            label11 = new Label();
            label1 = new Label();
            CityTextBox = new TextBox();
            chkForWeek = new CheckBox();
            label10 = new Label();
            chkForDay = new CheckBox();
            neighborhoodTextBox = new TextBox();
            chkStarred = new CheckBox();
            label9 = new Label();
            chkPersonal = new CheckBox();
            UPITextBox = new TextBox();
            label8 = new Label();
            plotNumberTextBox = new TextBox();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            panel1 = new Panel();
            overdueTasksFilter = new CheckBox();
            taskStatusComboBox = new ComboBox();
            label7 = new Label();
            ApplyActivityFiltersButton = new Button();
            label2 = new Label();
            taskDayCheck = new CheckBox();
            taskSelfCheck = new CheckBox();
            taskWeekCheck = new CheckBox();
            btnLastActivityDataGridView = new Button();
            btnNextActivityDataGridView = new Button();
            btnPreviousActivityDataGridView = new Button();
            btnFirstActivityDataGridView = new Button();
            editActivityButton = new Button();
            CreateDocumentButton = new Button();
            DeleteActivityButton = new Button();
            ActivityDataGridView = new DataGridView();
            ParentActivity = new DataGridViewTextBoxColumn();
            Activity = new DataGridViewTextBoxColumn();
            MainExecutantName = new DataGridViewTextBoxColumn();
            MainExecutantPayment = new DataGridViewTextBoxColumn();
            Plots = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            ActivityEndDate = new DataGridViewTextBoxColumn();
            Task = new DataGridViewTextBoxColumn();
            Executant = new DataGridViewTextBoxColumn();
            TaskExecutantPayment = new DataGridViewTextBoxColumn();
            TaskStartDate = new DataGridViewTextBoxColumn();
            TaskEndDate = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Control = new DataGridViewTextBoxColumn();
            Comment = new DataGridViewTextBoxColumn();
            tax = new DataGridViewTextBoxColumn();
            taxComment = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ActivityAddButton = new Button();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            btnLastClientsDataGridView = new Button();
            editClientButton = new Button();
            btnNextClientsDataGridView = new Button();
            deleteClientsButton = new Button();
            btnPreviousClientsDataGridView = new Button();
            button1 = new Button();
            btnFirstClientsDataGridView = new Button();
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
            btnLastPlotsDataGridView = new Button();
            btnNextPlotsDataGridView = new Button();
            btnPreviousPlotsDataGridView = new Button();
            btnFirstPlotsDataGridView = new Button();
            editPlotButton = new Button();
            DeletePlotsButton = new Button();
            PlotsDataGridView = new DataGridView();
            ActivityName = new DataGridViewTextBoxColumn();
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
            btnLastOwnershipDataGridView = new Button();
            btnNextOwnershipDataGridView = new Button();
            btnPreviousOwnershipDataGridView = new Button();
            btnFirstOwnershipDataGridView = new Button();
            editOwnershipButton = new Button();
            DeleteOwnershipButton = new Button();
            AddOwnersButton = new Button();
            OwnershipDataGridView = new DataGridView();
            PlotNumberDocTable = new DataGridViewTextBoxColumn();
            DocumentId = new DataGridViewTextBoxColumn();
            OwnerId = new DataGridViewTextBoxColumn();
            EKG = new DataGridViewTextBoxColumn();
            OwnerAddress = new DataGridViewTextBoxColumn();
            IdealParts = new DataGridViewTextBoxColumn();
            PowerOfAttorney = new DataGridViewTextBoxColumn();
            tabPage4 = new TabPage();
            EditInvoiceButton = new Button();
            btnLastInvoicesDataGridView = new Button();
            btnNextInvoicesDataGridView = new Button();
            btnPreviousInvoicesDataGridView = new Button();
            btnFirstInvoicesDataGridView = new Button();
            StarContextMenuStrip = new ContextMenuStrip(components);
            AvailableColors = new ToolStripMenuItem();
            ChooseColor = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).BeginInit();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            filtersPanel.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
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
            tabPage4.SuspendLayout();
            StarContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // RequestDataGridView
            // 
            RequestDataGridView.AllowUserToResizeRows = false;
            RequestDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RequestDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RequestDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            RequestDataGridView.BackgroundColor = Color.Moccasin;
            RequestDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RequestDataGridView.Columns.AddRange(new DataGridViewColumn[] { RequestId, RequestName, PaymentStatus, Comments, PlotsInfo });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            RequestDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            RequestDataGridView.GridColor = SystemColors.ControlText;
            RequestDataGridView.Location = new Point(0, 135);
            RequestDataGridView.Margin = new Padding(3, 4, 3, 4);
            RequestDataGridView.Name = "RequestDataGridView";
            RequestDataGridView.RowHeadersWidth = 51;
            RequestDataGridView.RowTemplate.Height = 24;
            RequestDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RequestDataGridView.Size = new Size(1334, 399);
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
            // PaymentStatus
            // 
            PaymentStatus.DataPropertyName = "PaymentStatus";
            PaymentStatus.HeaderText = "Статус на Плащане";
            PaymentStatus.MinimumWidth = 6;
            PaymentStatus.Name = "PaymentStatus";
            // 
            // Comments
            // 
            Comments.DataPropertyName = "Comments";
            Comments.HeaderText = "Коментар";
            Comments.MinimumWidth = 6;
            Comments.Name = "Comments";
            // 
            // PlotsInfo
            // 
            PlotsInfo.DataPropertyName = "PlotsInfo";
            PlotsInfo.HeaderText = "Идентификатори";
            PlotsInfo.MinimumWidth = 6;
            PlotsInfo.Name = "PlotsInfo";
            // 
            // RequestTableLabel
            // 
            RequestTableLabel.AutoSize = true;
            RequestTableLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RequestTableLabel.Location = new Point(3, 41);
            RequestTableLabel.Name = "RequestTableLabel";
            RequestTableLabel.Size = new Size(95, 28);
            RequestTableLabel.TabIndex = 1;
            RequestTableLabel.Text = "Поръчки";
            RequestTableLabel.Click += label1_Click_1;
            // 
            // RequestAddButton
            // 
            RequestAddButton.AccessibleDescription = "Shift + F1";
            RequestAddButton.BackColor = Color.Transparent;
            RequestAddButton.BackgroundImage = (Image)resources.GetObject("RequestAddButton.BackgroundImage");
            RequestAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            RequestAddButton.ForeColor = Color.Transparent;
            RequestAddButton.Location = new Point(92, 31);
            RequestAddButton.Margin = new Padding(3, 4, 3, 4);
            RequestAddButton.Name = "RequestAddButton";
            RequestAddButton.Size = new Size(45, 45);
            RequestAddButton.TabIndex = 2;
            toolTip1.SetToolTip(RequestAddButton, "Shift+F1");
            RequestAddButton.UseVisualStyleBackColor = false;
            RequestAddButton.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 538);
            label5.Name = "label5";
            label5.Size = new Size(141, 23);
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
            InvoicesDataGridView.Columns.AddRange(new DataGridViewColumn[] { number, Sum });
            InvoicesDataGridView.Location = new Point(-1, 49);
            InvoicesDataGridView.Margin = new Padding(3, 4, 3, 4);
            InvoicesDataGridView.Name = "InvoicesDataGridView";
            InvoicesDataGridView.RowHeadersWidth = 51;
            InvoicesDataGridView.RowTemplate.Height = 24;
            InvoicesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InvoicesDataGridView.Size = new Size(1337, 282);
            InvoicesDataGridView.TabIndex = 11;
            InvoicesDataGridView.CellContentClick += InvoicesDataGridView_CellContentClick;
            // 
            // number
            // 
            number.DataPropertyName = "number";
            number.HeaderText = "Номер";
            number.MinimumWidth = 6;
            number.Name = "number";
            // 
            // Sum
            // 
            Sum.DataPropertyName = "Sum";
            Sum.HeaderText = "Сума";
            Sum.MinimumWidth = 6;
            Sum.Name = "Sum";
            // 
            // addInvoiceButton
            // 
            addInvoiceButton.BackgroundImage = (Image)resources.GetObject("addInvoiceButton.BackgroundImage");
            addInvoiceButton.BackgroundImageLayout = ImageLayout.Stretch;
            addInvoiceButton.Location = new Point(193, 7);
            addInvoiceButton.Margin = new Padding(3, 4, 3, 4);
            addInvoiceButton.Name = "addInvoiceButton";
            addInvoiceButton.Size = new Size(35, 35);
            addInvoiceButton.TabIndex = 13;
            toolTip1.SetToolTip(addInvoiceButton, "F1");
            addInvoiceButton.UseVisualStyleBackColor = true;
            addInvoiceButton.Click += button3_Click;
            // 
            // DeleteInvoiceButton
            // 
            DeleteInvoiceButton.BackgroundImage = (Image)resources.GetObject("DeleteInvoiceButton.BackgroundImage");
            DeleteInvoiceButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteInvoiceButton.Location = new Point(234, 7);
            DeleteInvoiceButton.Name = "DeleteInvoiceButton";
            DeleteInvoiceButton.Size = new Size(35, 35);
            DeleteInvoiceButton.TabIndex = 14;
            DeleteInvoiceButton.UseVisualStyleBackColor = true;
            DeleteInvoiceButton.Click += DeleteInvoiceButton_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(RequestAddButton);
            panel3.Controls.Add(PathLink);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(editRequestButton);
            panel3.Controls.Add(DeleteRequestButton);
            panel3.Controls.Add(RefreshButton);
            panel3.Controls.Add(RequestDataGridView);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(RequestTableLabel);
            panel3.Controls.Add(RequestFiltersApplyButton);
            panel3.Location = new Point(3, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1337, 564);
            panel3.TabIndex = 17;
            panel3.Paint += panel3_Paint;
            // 
            // PathLink
            // 
            PathLink.AutoSize = true;
            PathLink.Location = new Point(139, 541);
            PathLink.Name = "PathLink";
            PathLink.Size = new Size(76, 20);
            PathLink.TabIndex = 22;
            PathLink.TabStop = true;
            PathLink.Text = "linkLabel1";
            PathLink.LinkClicked += PathLink_LinkClicked;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.Fixed3D;
            panel7.Controls.Add(starRequestButton);
            panel7.Controls.Add(btnLastRequestsDataGridView);
            panel7.Controls.Add(btnNextRequestsDataGridView);
            panel7.Controls.Add(btnPreviousRequestsDataGridView);
            panel7.Controls.Add(btnFirstRequestsDataGridView);
            panel7.Location = new Point(8, 77);
            panel7.Name = "panel7";
            panel7.Size = new Size(237, 50);
            panel7.TabIndex = 21;
            // 
            // starRequestButton
            // 
            starRequestButton.BackColor = Color.Transparent;
            starRequestButton.BackgroundImage = (Image)resources.GetObject("starRequestButton.BackgroundImage");
            starRequestButton.BackgroundImageLayout = ImageLayout.Stretch;
            starRequestButton.Location = new Point(187, 3);
            starRequestButton.Name = "starRequestButton";
            starRequestButton.Size = new Size(40, 40);
            starRequestButton.TabIndex = 4;
            starRequestButton.UseVisualStyleBackColor = false;
            starRequestButton.Click += starRequestButton_Click;
            // 
            // btnLastRequestsDataGridView
            // 
            btnLastRequestsDataGridView.BackColor = Color.Transparent;
            btnLastRequestsDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastRequestsDataGridView.BackgroundImage");
            btnLastRequestsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastRequestsDataGridView.Location = new Point(141, 3);
            btnLastRequestsDataGridView.Name = "btnLastRequestsDataGridView";
            btnLastRequestsDataGridView.Size = new Size(40, 40);
            btnLastRequestsDataGridView.TabIndex = 3;
            btnLastRequestsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnNextRequestsDataGridView
            // 
            btnNextRequestsDataGridView.BackColor = Color.Transparent;
            btnNextRequestsDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextRequestsDataGridView.BackgroundImage");
            btnNextRequestsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextRequestsDataGridView.Location = new Point(95, 3);
            btnNextRequestsDataGridView.Name = "btnNextRequestsDataGridView";
            btnNextRequestsDataGridView.Size = new Size(40, 40);
            btnNextRequestsDataGridView.TabIndex = 2;
            btnNextRequestsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnPreviousRequestsDataGridView
            // 
            btnPreviousRequestsDataGridView.BackColor = Color.Transparent;
            btnPreviousRequestsDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousRequestsDataGridView.BackgroundImage");
            btnPreviousRequestsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousRequestsDataGridView.Location = new Point(49, 3);
            btnPreviousRequestsDataGridView.Name = "btnPreviousRequestsDataGridView";
            btnPreviousRequestsDataGridView.Size = new Size(40, 40);
            btnPreviousRequestsDataGridView.TabIndex = 1;
            btnPreviousRequestsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnFirstRequestsDataGridView
            // 
            btnFirstRequestsDataGridView.BackColor = Color.Transparent;
            btnFirstRequestsDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstRequestsDataGridView.BackgroundImage");
            btnFirstRequestsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstRequestsDataGridView.Location = new Point(3, 3);
            btnFirstRequestsDataGridView.Name = "btnFirstRequestsDataGridView";
            btnFirstRequestsDataGridView.Size = new Size(40, 40);
            btnFirstRequestsDataGridView.TabIndex = 0;
            btnFirstRequestsDataGridView.UseVisualStyleBackColor = false;
            // 
            // editRequestButton
            // 
            editRequestButton.BackColor = Color.Transparent;
            editRequestButton.BackgroundImage = (Image)resources.GetObject("editRequestButton.BackgroundImage");
            editRequestButton.BackgroundImageLayout = ImageLayout.Stretch;
            editRequestButton.Location = new Point(194, 31);
            editRequestButton.Name = "editRequestButton";
            editRequestButton.Size = new Size(45, 45);
            editRequestButton.TabIndex = 13;
            toolTip1.SetToolTip(editRequestButton, "Shift+F2");
            editRequestButton.UseVisualStyleBackColor = false;
            editRequestButton.Click += editRequestButton_Click;
            // 
            // DeleteRequestButton
            // 
            DeleteRequestButton.BackColor = Color.Transparent;
            DeleteRequestButton.BackgroundImage = (Image)resources.GetObject("DeleteRequestButton.BackgroundImage");
            DeleteRequestButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteRequestButton.Location = new Point(143, 31);
            DeleteRequestButton.Name = "DeleteRequestButton";
            DeleteRequestButton.Size = new Size(45, 45);
            DeleteRequestButton.TabIndex = 12;
            DeleteRequestButton.UseVisualStyleBackColor = false;
            DeleteRequestButton.Click += DeleteRequestButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BackgroundImage = (Image)resources.GetObject("RefreshButton.BackgroundImage");
            RefreshButton.BackgroundImageLayout = ImageLayout.Stretch;
            RefreshButton.Location = new Point(245, 32);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(45, 45);
            RefreshButton.TabIndex = 11;
            toolTip1.SetToolTip(RefreshButton, "F5");
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // RequestFiltersApplyButton
            // 
            RequestFiltersApplyButton.BackColor = Color.Transparent;
            RequestFiltersApplyButton.BackgroundImage = (Image)resources.GetObject("RequestFiltersApplyButton.BackgroundImage");
            RequestFiltersApplyButton.BackgroundImageLayout = ImageLayout.Stretch;
            RequestFiltersApplyButton.Location = new Point(251, 83);
            RequestFiltersApplyButton.Name = "RequestFiltersApplyButton";
            RequestFiltersApplyButton.Size = new Size(40, 40);
            RequestFiltersApplyButton.TabIndex = 54;
            toolTip1.SetToolTip(RequestFiltersApplyButton, "Cntrl + F");
            RequestFiltersApplyButton.UseVisualStyleBackColor = false;
            RequestFiltersApplyButton.Click += RequestFiltersApplyButton_Click_1;
            // 
            // filtersPanel
            // 
            filtersPanel.BackColor = SystemColors.ActiveCaption;
            filtersPanel.BorderStyle = BorderStyle.Fixed3D;
            filtersPanel.Controls.Add(requestNameFilter);
            filtersPanel.Controls.Add(label6);
            filtersPanel.Controls.Add(EmployeesFilterCheckBoxList);
            filtersPanel.Controls.Add(EmployeesFilterLabel);
            filtersPanel.Controls.Add(OwnersFlowLayoutPanelFilter);
            filtersPanel.Controls.Add(button2);
            filtersPanel.Controls.Add(AddClientButton);
            filtersPanel.Controls.Add(clientsFlowLayoutPanel);
            filtersPanel.Controls.Add(overdueFilter);
            filtersPanel.Controls.Add(label14);
            filtersPanel.Controls.Add(label4);
            filtersPanel.Controls.Add(cmbPaymentStatus);
            filtersPanel.Controls.Add(label13);
            filtersPanel.Controls.Add(label3);
            filtersPanel.Controls.Add(CommentsTextBox);
            filtersPanel.Controls.Add(txtNumber);
            filtersPanel.Controls.Add(label12);
            filtersPanel.Controls.Add(statusCheckBox);
            filtersPanel.Controls.Add(label11);
            filtersPanel.Controls.Add(label1);
            filtersPanel.Controls.Add(CityTextBox);
            filtersPanel.Controls.Add(chkForWeek);
            filtersPanel.Controls.Add(label10);
            filtersPanel.Controls.Add(chkForDay);
            filtersPanel.Controls.Add(neighborhoodTextBox);
            filtersPanel.Controls.Add(chkStarred);
            filtersPanel.Controls.Add(label9);
            filtersPanel.Controls.Add(chkPersonal);
            filtersPanel.Controls.Add(UPITextBox);
            filtersPanel.Controls.Add(label8);
            filtersPanel.Controls.Add(plotNumberTextBox);
            filtersPanel.Location = new Point(540, 41);
            filtersPanel.Name = "filtersPanel";
            filtersPanel.Size = new Size(772, 507);
            filtersPanel.TabIndex = 23;
            filtersPanel.Visible = false;
            // 
            // requestNameFilter
            // 
            requestNameFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            requestNameFilter.Location = new Point(3, 280);
            requestNameFilter.Name = "requestNameFilter";
            requestNameFilter.Size = new Size(328, 27);
            requestNameFilter.TabIndex = 76;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 249);
            label6.Name = "label6";
            label6.Size = new Size(149, 28);
            label6.TabIndex = 75;
            label6.Text = "Име поръчка : ";
            // 
            // EmployeesFilterCheckBoxList
            // 
            EmployeesFilterCheckBoxList.BackColor = SystemColors.GradientActiveCaption;
            EmployeesFilterCheckBoxList.FormattingEnabled = true;
            EmployeesFilterCheckBoxList.Location = new Point(181, 408);
            EmployeesFilterCheckBoxList.Name = "EmployeesFilterCheckBoxList";
            EmployeesFilterCheckBoxList.Size = new Size(583, 92);
            EmployeesFilterCheckBoxList.TabIndex = 74;
            // 
            // EmployeesFilterLabel
            // 
            EmployeesFilterLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            EmployeesFilterLabel.AutoSize = true;
            EmployeesFilterLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeesFilterLabel.Location = new Point(3, 411);
            EmployeesFilterLabel.Name = "EmployeesFilterLabel";
            EmployeesFilterLabel.Size = new Size(158, 28);
            EmployeesFilterLabel.TabIndex = 72;
            EmployeesFilterLabel.Text = "За Служители :  ";
            // 
            // OwnersFlowLayoutPanelFilter
            // 
            OwnersFlowLayoutPanelFilter.AutoScroll = true;
            OwnersFlowLayoutPanelFilter.BackColor = SystemColors.GradientActiveCaption;
            OwnersFlowLayoutPanelFilter.BorderStyle = BorderStyle.Fixed3D;
            OwnersFlowLayoutPanelFilter.FlowDirection = FlowDirection.RightToLeft;
            OwnersFlowLayoutPanelFilter.Location = new Point(344, 251);
            OwnersFlowLayoutPanelFilter.Name = "OwnersFlowLayoutPanelFilter";
            OwnersFlowLayoutPanelFilter.Size = new Size(421, 151);
            OwnersFlowLayoutPanelFilter.TabIndex = 69;
            // 
            // button2
            // 
            button2.Location = new Point(479, 220);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 71;
            button2.Text = "Добави";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // AddClientButton
            // 
            AddClientButton.Location = new Point(435, 33);
            AddClientButton.Name = "AddClientButton";
            AddClientButton.Size = new Size(94, 29);
            AddClientButton.TabIndex = 70;
            AddClientButton.Text = "Добави";
            AddClientButton.UseVisualStyleBackColor = true;
            AddClientButton.Click += AddClientButton_Click;
            // 
            // clientsFlowLayoutPanel
            // 
            clientsFlowLayoutPanel.AutoScroll = true;
            clientsFlowLayoutPanel.BackColor = SystemColors.GradientActiveCaption;
            clientsFlowLayoutPanel.BorderStyle = BorderStyle.Fixed3D;
            clientsFlowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            clientsFlowLayoutPanel.Location = new Point(343, 61);
            clientsFlowLayoutPanel.Name = "clientsFlowLayoutPanel";
            clientsFlowLayoutPanel.Size = new Size(421, 153);
            clientsFlowLayoutPanel.TabIndex = 68;
            // 
            // overdueFilter
            // 
            overdueFilter.AutoSize = true;
            overdueFilter.Location = new Point(228, 1);
            overdueFilter.Name = "overdueFilter";
            overdueFilter.RightToLeft = RightToLeft.Yes;
            overdueFilter.Size = new Size(119, 24);
            overdueFilter.TabIndex = 67;
            overdueFilter.Text = "Просрочени";
            overdueFilter.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(344, 217);
            label14.Name = "label14";
            label14.Size = new Size(129, 28);
            label14.TabIndex = 66;
            label14.Text = "Собственик: ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 34);
            label4.Name = "label4";
            label4.Size = new Size(151, 28);
            label4.TabIndex = 51;
            label4.Text = "Статус Задача:  ";
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cmbPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Items.AddRange(new object[] { "", "Платен", "Не Платен", "Аванс" });
            cmbPaymentStatus.Location = new Point(175, 129);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(156, 28);
            cmbPaymentStatus.TabIndex = 50;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(343, 30);
            label13.Name = "label13";
            label13.Size = new Size(86, 28);
            label13.TabIndex = 65;
            label13.Text = "Клиент: ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 129);
            label3.Name = "label3";
            label3.Size = new Size(171, 28);
            label3.TabIndex = 49;
            label3.Text = "Статус Плащане : ";
            // 
            // CommentsTextBox
            // 
            CommentsTextBox.Location = new Point(3, 343);
            CommentsTextBox.Name = "CommentsTextBox";
            CommentsTextBox.Size = new Size(328, 59);
            CommentsTextBox.TabIndex = 64;
            CommentsTextBox.Text = "";
            // 
            // txtNumber
            // 
            txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtNumber.Location = new Point(91, 65);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(240, 27);
            txtNumber.TabIndex = 48;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(3, 310);
            label12.Name = "label12";
            label12.Size = new Size(218, 28);
            label12.TabIndex = 63;
            label12.Text = "Търсене по коментар: ";
            // 
            // statusCheckBox
            // 
            statusCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            statusCheckBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCheckBox.FormattingEnabled = true;
            statusCheckBox.Items.AddRange(new object[] { "", "Зададена", "Завършена", "Оферта" });
            statusCheckBox.Location = new Point(156, 34);
            statusCheckBox.Name = "statusCheckBox";
            statusCheckBox.Size = new Size(175, 28);
            statusCheckBox.TabIndex = 52;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(3, 98);
            label11.Name = "label11";
            label11.Size = new Size(171, 28);
            label11.TabIndex = 61;
            label11.Text = "Населено Място: ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 65);
            label1.Name = "label1";
            label1.Size = new Size(88, 28);
            label1.TabIndex = 47;
            label1.Text = "Номер : ";
            // 
            // CityTextBox
            // 
            CityTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            CityTextBox.Location = new Point(174, 98);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(157, 27);
            CityTextBox.TabIndex = 62;
            // 
            // chkForWeek
            // 
            chkForWeek.AutoSize = true;
            chkForWeek.Location = new Point(531, 1);
            chkForWeek.Name = "chkForWeek";
            chkForWeek.RightToLeft = RightToLeft.Yes;
            chkForWeek.Size = new Size(124, 24);
            chkForWeek.TabIndex = 44;
            chkForWeek.Text = "за седмицата";
            chkForWeek.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(3, 221);
            label10.Name = "label10";
            label10.Size = new Size(44, 28);
            label10.TabIndex = 59;
            label10.Text = "Кв: ";
            // 
            // chkForDay
            // 
            chkForDay.AutoSize = true;
            chkForDay.Location = new Point(442, 1);
            chkForDay.Name = "chkForDay";
            chkForDay.RightToLeft = RightToLeft.Yes;
            chkForDay.Size = new Size(83, 24);
            chkForDay.TabIndex = 45;
            chkForDay.Text = "за деня";
            chkForDay.UseVisualStyleBackColor = true;
            // 
            // neighborhoodTextBox
            // 
            neighborhoodTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            neighborhoodTextBox.Location = new Point(47, 221);
            neighborhoodTextBox.Name = "neighborhoodTextBox";
            neighborhoodTextBox.Size = new Size(284, 27);
            neighborhoodTextBox.TabIndex = 60;
            // 
            // chkStarred
            // 
            chkStarred.AutoSize = true;
            chkStarred.Location = new Point(661, 1);
            chkStarred.Name = "chkStarred";
            chkStarred.RightToLeft = RightToLeft.Yes;
            chkStarred.Size = new Size(104, 24);
            chkStarred.TabIndex = 53;
            chkStarred.Text = "със звезда";
            chkStarred.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(3, 190);
            label9.Name = "label9";
            label9.Size = new Size(56, 28);
            label9.TabIndex = 57;
            label9.Text = "Упи: ";
            // 
            // chkPersonal
            // 
            chkPersonal.AutoSize = true;
            chkPersonal.Location = new Point(353, 1);
            chkPersonal.Name = "chkPersonal";
            chkPersonal.RightToLeft = RightToLeft.Yes;
            chkPersonal.Size = new Size(76, 24);
            chkPersonal.TabIndex = 46;
            chkPersonal.Text = "Лични";
            chkPersonal.UseVisualStyleBackColor = true;
            // 
            // UPITextBox
            // 
            UPITextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            UPITextBox.Location = new Point(65, 190);
            UPITextBox.Name = "UPITextBox";
            UPITextBox.Size = new Size(266, 27);
            UPITextBox.TabIndex = 58;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(3, 159);
            label8.Name = "label8";
            label8.Size = new Size(137, 28);
            label8.TabIndex = 55;
            label8.Text = "Номер Имот: ";
            // 
            // plotNumberTextBox
            // 
            plotNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            plotNumberTextBox.Location = new Point(140, 160);
            plotNumberTextBox.Name = "plotNumberTextBox";
            plotNumberTextBox.Size = new Size(191, 27);
            plotNumberTextBox.TabIndex = 56;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1336, 335);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Дейности";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(btnLastActivityDataGridView);
            panel2.Controls.Add(btnNextActivityDataGridView);
            panel2.Controls.Add(btnPreviousActivityDataGridView);
            panel2.Controls.Add(btnFirstActivityDataGridView);
            panel2.Controls.Add(editActivityButton);
            panel2.Controls.Add(CreateDocumentButton);
            panel2.Controls.Add(DeleteActivityButton);
            panel2.Controls.Add(ActivityDataGridView);
            panel2.Controls.Add(ActivityAddButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1330, 329);
            panel2.TabIndex = 36;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BackColor = Color.Gainsboro;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(overdueTasksFilter);
            panel1.Controls.Add(taskStatusComboBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(ApplyActivityFiltersButton);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(taskDayCheck);
            panel1.Controls.Add(taskSelfCheck);
            panel1.Controls.Add(taskWeekCheck);
            panel1.Location = new Point(662, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(667, 41);
            panel1.TabIndex = 35;
            // 
            // overdueTasksFilter
            // 
            overdueTasksFilter.AutoSize = true;
            overdueTasksFilter.Location = new Point(3, 16);
            overdueTasksFilter.Name = "overdueTasksFilter";
            overdueTasksFilter.Size = new Size(119, 24);
            overdueTasksFilter.TabIndex = 28;
            overdueTasksFilter.Text = "Просрочени";
            overdueTasksFilter.UseVisualStyleBackColor = true;
            // 
            // taskStatusComboBox
            // 
            taskStatusComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            taskStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            taskStatusComboBox.FormattingEnabled = true;
            taskStatusComboBox.Items.AddRange(new object[] { "", "Зададена", "Завършена", "Оферта" });
            taskStatusComboBox.Location = new Point(503, 10);
            taskStatusComboBox.Name = "taskStatusComboBox";
            taskStatusComboBox.Size = new Size(117, 28);
            taskStatusComboBox.TabIndex = 27;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(418, 9);
            label7.Name = "label7";
            label7.Size = new Size(88, 28);
            label7.TabIndex = 26;
            label7.Text = "Статус :  ";
            // 
            // ApplyActivityFiltersButton
            // 
            ApplyActivityFiltersButton.BackColor = Color.Transparent;
            ApplyActivityFiltersButton.BackgroundImage = (Image)resources.GetObject("ApplyActivityFiltersButton.BackgroundImage");
            ApplyActivityFiltersButton.BackgroundImageLayout = ImageLayout.Stretch;
            ApplyActivityFiltersButton.Location = new Point(626, 7);
            ApplyActivityFiltersButton.Name = "ApplyActivityFiltersButton";
            ApplyActivityFiltersButton.Size = new Size(30, 30);
            ApplyActivityFiltersButton.TabIndex = 23;
            ApplyActivityFiltersButton.UseVisualStyleBackColor = false;
            ApplyActivityFiltersButton.Click += ApplyActivityFiltersButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(-2, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 25;
            label2.Text = "филтри";
            // 
            // taskDayCheck
            // 
            taskDayCheck.AutoSize = true;
            taskDayCheck.Location = new Point(200, 16);
            taskDayCheck.Name = "taskDayCheck";
            taskDayCheck.RightToLeft = RightToLeft.Yes;
            taskDayCheck.Size = new Size(83, 24);
            taskDayCheck.TabIndex = 24;
            taskDayCheck.Text = "за деня";
            taskDayCheck.UseVisualStyleBackColor = true;
            // 
            // taskSelfCheck
            // 
            taskSelfCheck.AutoSize = true;
            taskSelfCheck.Location = new Point(118, 16);
            taskSelfCheck.Name = "taskSelfCheck";
            taskSelfCheck.RightToLeft = RightToLeft.Yes;
            taskSelfCheck.Size = new Size(76, 24);
            taskSelfCheck.TabIndex = 23;
            taskSelfCheck.Text = "Лични";
            taskSelfCheck.UseVisualStyleBackColor = true;
            // 
            // taskWeekCheck
            // 
            taskWeekCheck.AutoSize = true;
            taskWeekCheck.Location = new Point(289, 16);
            taskWeekCheck.Name = "taskWeekCheck";
            taskWeekCheck.RightToLeft = RightToLeft.Yes;
            taskWeekCheck.Size = new Size(124, 24);
            taskWeekCheck.TabIndex = 23;
            taskWeekCheck.Text = "за седмицата";
            taskWeekCheck.UseVisualStyleBackColor = true;
            // 
            // btnLastActivityDataGridView
            // 
            btnLastActivityDataGridView.BackColor = Color.Transparent;
            btnLastActivityDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastActivityDataGridView.BackgroundImage");
            btnLastActivityDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastActivityDataGridView.Location = new Point(126, 4);
            btnLastActivityDataGridView.Name = "btnLastActivityDataGridView";
            btnLastActivityDataGridView.Size = new Size(35, 35);
            btnLastActivityDataGridView.TabIndex = 34;
            btnLastActivityDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnNextActivityDataGridView
            // 
            btnNextActivityDataGridView.BackColor = Color.Transparent;
            btnNextActivityDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextActivityDataGridView.BackgroundImage");
            btnNextActivityDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextActivityDataGridView.Location = new Point(85, 4);
            btnNextActivityDataGridView.Name = "btnNextActivityDataGridView";
            btnNextActivityDataGridView.Size = new Size(35, 35);
            btnNextActivityDataGridView.TabIndex = 33;
            btnNextActivityDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnPreviousActivityDataGridView
            // 
            btnPreviousActivityDataGridView.BackColor = Color.Transparent;
            btnPreviousActivityDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousActivityDataGridView.BackgroundImage");
            btnPreviousActivityDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousActivityDataGridView.Location = new Point(44, 4);
            btnPreviousActivityDataGridView.Name = "btnPreviousActivityDataGridView";
            btnPreviousActivityDataGridView.Size = new Size(35, 35);
            btnPreviousActivityDataGridView.TabIndex = 32;
            btnPreviousActivityDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnFirstActivityDataGridView
            // 
            btnFirstActivityDataGridView.BackColor = Color.Transparent;
            btnFirstActivityDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstActivityDataGridView.BackgroundImage");
            btnFirstActivityDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstActivityDataGridView.Location = new Point(3, 4);
            btnFirstActivityDataGridView.Name = "btnFirstActivityDataGridView";
            btnFirstActivityDataGridView.Size = new Size(35, 35);
            btnFirstActivityDataGridView.TabIndex = 31;
            btnFirstActivityDataGridView.UseVisualStyleBackColor = false;
            // 
            // editActivityButton
            // 
            editActivityButton.BackgroundImage = (Image)resources.GetObject("editActivityButton.BackgroundImage");
            editActivityButton.BackgroundImageLayout = ImageLayout.Stretch;
            editActivityButton.Location = new Point(272, 4);
            editActivityButton.Name = "editActivityButton";
            editActivityButton.Size = new Size(35, 35);
            editActivityButton.TabIndex = 14;
            toolTip1.SetToolTip(editActivityButton, "F2");
            editActivityButton.UseVisualStyleBackColor = true;
            editActivityButton.Click += editActivityButton_Click;
            // 
            // CreateDocumentButton
            // 
            CreateDocumentButton.BackgroundImage = (Image)resources.GetObject("CreateDocumentButton.BackgroundImage");
            CreateDocumentButton.BackgroundImageLayout = ImageLayout.Stretch;
            CreateDocumentButton.Location = new Point(335, 4);
            CreateDocumentButton.Name = "CreateDocumentButton";
            CreateDocumentButton.Size = new Size(35, 35);
            CreateDocumentButton.TabIndex = 30;
            CreateDocumentButton.UseVisualStyleBackColor = true;
            CreateDocumentButton.Click += CreateDocumentButton_Click;
            // 
            // DeleteActivityButton
            // 
            DeleteActivityButton.BackgroundImage = (Image)resources.GetObject("DeleteActivityButton.BackgroundImage");
            DeleteActivityButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteActivityButton.Location = new Point(231, 4);
            DeleteActivityButton.Name = "DeleteActivityButton";
            DeleteActivityButton.Size = new Size(35, 35);
            DeleteActivityButton.TabIndex = 29;
            DeleteActivityButton.UseVisualStyleBackColor = true;
            DeleteActivityButton.Click += DeleteActivityButton_Click;
            // 
            // ActivityDataGridView
            // 
            ActivityDataGridView.AllowUserToResizeRows = false;
            ActivityDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ActivityDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActivityDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ActivityDataGridView.BackgroundColor = Color.Moccasin;
            ActivityDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ActivityDataGridView.ColumnHeadersHeight = 60;
            ActivityDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ActivityDataGridView.Columns.AddRange(new DataGridViewColumn[] { ParentActivity, Activity, MainExecutantName, MainExecutantPayment, Plots, StartDate, ActivityEndDate, Task, Executant, TaskExecutantPayment, TaskStartDate, TaskEndDate, Duration, Control, Comment, tax, taxComment, Status });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ActivityDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            ActivityDataGridView.Location = new Point(0, 46);
            ActivityDataGridView.Margin = new Padding(3, 4, 3, 4);
            ActivityDataGridView.MinimumSize = new Size(933, 188);
            ActivityDataGridView.Name = "ActivityDataGridView";
            ActivityDataGridView.RowHeadersWidth = 51;
            ActivityDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ActivityDataGridView.RowTemplate.Height = 350;
            ActivityDataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            ActivityDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ActivityDataGridView.Size = new Size(1330, 282);
            ActivityDataGridView.TabIndex = 22;
            ActivityDataGridView.CellContentClick += ActivityDataGridView_CellContentClick;
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
            // MainExecutantName
            // 
            MainExecutantName.DataPropertyName = "MainExecutantName";
            MainExecutantName.HeaderText = "Главен Изпълнител";
            MainExecutantName.MinimumWidth = 6;
            MainExecutantName.Name = "MainExecutantName";
            // 
            // MainExecutantPayment
            // 
            MainExecutantPayment.DataPropertyName = "MainExecutantPayment";
            MainExecutantPayment.HeaderText = "Хонорар гл. Изпълнител";
            MainExecutantPayment.MinimumWidth = 6;
            MainExecutantPayment.Name = "MainExecutantPayment";
            // 
            // Plots
            // 
            Plots.DataPropertyName = "Identities";
            Plots.HeaderText = "Идентификатори";
            Plots.MinimumWidth = 6;
            Plots.Name = "Plots";
            // 
            // StartDate
            // 
            StartDate.DataPropertyName = "StartDate";
            StartDate.HeaderText = "Започване на дейност";
            StartDate.MinimumWidth = 6;
            StartDate.Name = "StartDate";
            // 
            // ActivityEndDate
            // 
            ActivityEndDate.DataPropertyName = "ActivityEndDate";
            ActivityEndDate.HeaderText = "Приключване на дейност";
            ActivityEndDate.MinimumWidth = 6;
            ActivityEndDate.Name = "ActivityEndDate";
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
            // TaskExecutantPayment
            // 
            TaskExecutantPayment.DataPropertyName = "TaskExecutantPayment";
            TaskExecutantPayment.HeaderText = "Хонорар изпълнител задача";
            TaskExecutantPayment.MinimumWidth = 6;
            TaskExecutantPayment.Name = "TaskExecutantPayment";
            // 
            // TaskStartDate
            // 
            TaskStartDate.DataPropertyName = "TaskStartDate";
            TaskStartDate.HeaderText = "Започване на задача";
            TaskStartDate.MinimumWidth = 6;
            TaskStartDate.Name = "TaskStartDate";
            // 
            // TaskEndDate
            // 
            TaskEndDate.DataPropertyName = "TaskEndDate";
            TaskEndDate.HeaderText = "Приключване на задача";
            TaskEndDate.MinimumWidth = 6;
            TaskEndDate.Name = "TaskEndDate";
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
            // Comment
            // 
            Comment.DataPropertyName = "Comments";
            Comment.HeaderText = "Коментар";
            Comment.MinimumWidth = 6;
            Comment.Name = "Comment";
            // 
            // tax
            // 
            tax.DataPropertyName = "tax";
            tax.HeaderText = "такса";
            tax.MinimumWidth = 6;
            tax.Name = "tax";
            // 
            // taxComment
            // 
            taxComment.DataPropertyName = "taxComment";
            taxComment.HeaderText = "такса коментар";
            taxComment.MinimumWidth = 6;
            taxComment.Name = "taxComment";
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Статус";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // ActivityAddButton
            // 
            ActivityAddButton.BackgroundImage = (Image)resources.GetObject("ActivityAddButton.BackgroundImage");
            ActivityAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            ActivityAddButton.Location = new Point(190, 4);
            ActivityAddButton.Margin = new Padding(3, 4, 3, 4);
            ActivityAddButton.Name = "ActivityAddButton";
            ActivityAddButton.Size = new Size(35, 35);
            ActivityAddButton.TabIndex = 28;
            toolTip1.SetToolTip(ActivityAddButton, "F1");
            ActivityAddButton.UseVisualStyleBackColor = true;
            ActivityAddButton.Click += ActivityAddButton_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel4);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1336, 335);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Клиенти";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(btnLastClientsDataGridView);
            panel4.Controls.Add(editClientButton);
            panel4.Controls.Add(btnNextClientsDataGridView);
            panel4.Controls.Add(deleteClientsButton);
            panel4.Controls.Add(btnPreviousClientsDataGridView);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(btnFirstClientsDataGridView);
            panel4.Controls.Add(clientsDataGridView);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1330, 329);
            panel4.TabIndex = 18;
            // 
            // btnLastClientsDataGridView
            // 
            btnLastClientsDataGridView.BackColor = Color.Transparent;
            btnLastClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastClientsDataGridView.BackgroundImage");
            btnLastClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastClientsDataGridView.Location = new Point(126, 4);
            btnLastClientsDataGridView.Name = "btnLastClientsDataGridView";
            btnLastClientsDataGridView.Size = new Size(35, 35);
            btnLastClientsDataGridView.TabIndex = 8;
            btnLastClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // editClientButton
            // 
            editClientButton.BackgroundImage = (Image)resources.GetObject("editClientButton.BackgroundImage");
            editClientButton.BackgroundImageLayout = ImageLayout.Stretch;
            editClientButton.Location = new Point(272, 4);
            editClientButton.Name = "editClientButton";
            editClientButton.Size = new Size(35, 35);
            editClientButton.TabIndex = 14;
            toolTip1.SetToolTip(editClientButton, "F2");
            editClientButton.UseVisualStyleBackColor = true;
            editClientButton.Click += editClientButton_Click;
            // 
            // btnNextClientsDataGridView
            // 
            btnNextClientsDataGridView.BackColor = Color.Transparent;
            btnNextClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextClientsDataGridView.BackgroundImage");
            btnNextClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextClientsDataGridView.Location = new Point(85, 4);
            btnNextClientsDataGridView.Name = "btnNextClientsDataGridView";
            btnNextClientsDataGridView.Size = new Size(35, 35);
            btnNextClientsDataGridView.TabIndex = 7;
            btnNextClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // deleteClientsButton
            // 
            deleteClientsButton.BackgroundImage = (Image)resources.GetObject("deleteClientsButton.BackgroundImage");
            deleteClientsButton.BackgroundImageLayout = ImageLayout.Stretch;
            deleteClientsButton.Location = new Point(231, 4);
            deleteClientsButton.Name = "deleteClientsButton";
            deleteClientsButton.Size = new Size(35, 35);
            deleteClientsButton.TabIndex = 12;
            deleteClientsButton.UseVisualStyleBackColor = true;
            deleteClientsButton.Click += deleteClientsButton_Click;
            // 
            // btnPreviousClientsDataGridView
            // 
            btnPreviousClientsDataGridView.BackColor = Color.Transparent;
            btnPreviousClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousClientsDataGridView.BackgroundImage");
            btnPreviousClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousClientsDataGridView.Location = new Point(44, 4);
            btnPreviousClientsDataGridView.Name = "btnPreviousClientsDataGridView";
            btnPreviousClientsDataGridView.Size = new Size(35, 35);
            btnPreviousClientsDataGridView.TabIndex = 6;
            btnPreviousClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(190, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(35, 35);
            button1.TabIndex = 11;
            toolTip1.SetToolTip(button1, "F1");
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnFirstClientsDataGridView
            // 
            btnFirstClientsDataGridView.BackColor = Color.Transparent;
            btnFirstClientsDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstClientsDataGridView.BackgroundImage");
            btnFirstClientsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstClientsDataGridView.Location = new Point(3, 4);
            btnFirstClientsDataGridView.Name = "btnFirstClientsDataGridView";
            btnFirstClientsDataGridView.Size = new Size(35, 35);
            btnFirstClientsDataGridView.TabIndex = 5;
            btnFirstClientsDataGridView.UseVisualStyleBackColor = false;
            // 
            // clientsDataGridView
            // 
            clientsDataGridView.AllowUserToResizeRows = false;
            clientsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            clientsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            clientsDataGridView.BackgroundColor = Color.Moccasin;
            clientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ClientNumber, FirstName, MiddleName, LastName, Phone, Email, Address, ClientLegalType });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            clientsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            clientsDataGridView.GridColor = SystemColors.ControlText;
            clientsDataGridView.Location = new Point(1, 46);
            clientsDataGridView.Margin = new Padding(3, 4, 3, 4);
            clientsDataGridView.Name = "clientsDataGridView";
            clientsDataGridView.RowHeadersWidth = 51;
            clientsDataGridView.RowTemplate.Height = 24;
            clientsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsDataGridView.Size = new Size(1326, 282);
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
            DocumentsOfOwnershipTab.Controls.Add(tabPage4);
            DocumentsOfOwnershipTab.Location = new Point(3, 593);
            DocumentsOfOwnershipTab.Name = "DocumentsOfOwnershipTab";
            DocumentsOfOwnershipTab.SelectedIndex = 0;
            DocumentsOfOwnershipTab.Size = new Size(1344, 368);
            DocumentsOfOwnershipTab.TabIndex = 12;
            toolTip1.SetToolTip(DocumentsOfOwnershipTab, "F1");
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel5);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1336, 335);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Имоти";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnLastPlotsDataGridView);
            panel5.Controls.Add(btnNextPlotsDataGridView);
            panel5.Controls.Add(btnPreviousPlotsDataGridView);
            panel5.Controls.Add(btnFirstPlotsDataGridView);
            panel5.Controls.Add(editPlotButton);
            panel5.Controls.Add(DeletePlotsButton);
            panel5.Controls.Add(PlotsDataGridView);
            panel5.Controls.Add(PlotsAddButton);
            panel5.Controls.Add(DestinationOfPlotLabel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 3);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1330, 329);
            panel5.TabIndex = 35;
            // 
            // btnLastPlotsDataGridView
            // 
            btnLastPlotsDataGridView.BackColor = Color.Transparent;
            btnLastPlotsDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastPlotsDataGridView.BackgroundImage");
            btnLastPlotsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastPlotsDataGridView.Location = new Point(126, 4);
            btnLastPlotsDataGridView.Name = "btnLastPlotsDataGridView";
            btnLastPlotsDataGridView.Size = new Size(35, 35);
            btnLastPlotsDataGridView.TabIndex = 38;
            btnLastPlotsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnNextPlotsDataGridView
            // 
            btnNextPlotsDataGridView.BackColor = Color.Transparent;
            btnNextPlotsDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextPlotsDataGridView.BackgroundImage");
            btnNextPlotsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextPlotsDataGridView.Location = new Point(85, 4);
            btnNextPlotsDataGridView.Name = "btnNextPlotsDataGridView";
            btnNextPlotsDataGridView.Size = new Size(35, 35);
            btnNextPlotsDataGridView.TabIndex = 37;
            btnNextPlotsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnPreviousPlotsDataGridView
            // 
            btnPreviousPlotsDataGridView.BackColor = Color.Transparent;
            btnPreviousPlotsDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousPlotsDataGridView.BackgroundImage");
            btnPreviousPlotsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousPlotsDataGridView.Location = new Point(44, 4);
            btnPreviousPlotsDataGridView.Name = "btnPreviousPlotsDataGridView";
            btnPreviousPlotsDataGridView.Size = new Size(35, 35);
            btnPreviousPlotsDataGridView.TabIndex = 36;
            btnPreviousPlotsDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnFirstPlotsDataGridView
            // 
            btnFirstPlotsDataGridView.BackColor = Color.Transparent;
            btnFirstPlotsDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstPlotsDataGridView.BackgroundImage");
            btnFirstPlotsDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstPlotsDataGridView.Location = new Point(3, 4);
            btnFirstPlotsDataGridView.Name = "btnFirstPlotsDataGridView";
            btnFirstPlotsDataGridView.Size = new Size(35, 35);
            btnFirstPlotsDataGridView.TabIndex = 35;
            btnFirstPlotsDataGridView.UseVisualStyleBackColor = false;
            // 
            // editPlotButton
            // 
            editPlotButton.BackgroundImage = (Image)resources.GetObject("editPlotButton.BackgroundImage");
            editPlotButton.BackgroundImageLayout = ImageLayout.Stretch;
            editPlotButton.Location = new Point(272, 4);
            editPlotButton.Name = "editPlotButton";
            editPlotButton.Size = new Size(35, 35);
            editPlotButton.TabIndex = 14;
            toolTip1.SetToolTip(editPlotButton, "F2");
            editPlotButton.UseVisualStyleBackColor = true;
            editPlotButton.Click += editPlotButton_Click;
            // 
            // DeletePlotsButton
            // 
            DeletePlotsButton.BackgroundImage = (Image)resources.GetObject("DeletePlotsButton.BackgroundImage");
            DeletePlotsButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeletePlotsButton.Location = new Point(231, 4);
            DeletePlotsButton.Name = "DeletePlotsButton";
            DeletePlotsButton.Size = new Size(35, 35);
            DeletePlotsButton.TabIndex = 32;
            DeletePlotsButton.UseVisualStyleBackColor = true;
            DeletePlotsButton.Click += DeletePlotsButton_Click;
            // 
            // PlotsDataGridView
            // 
            PlotsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            PlotsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            PlotsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlotsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PlotsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            PlotsDataGridView.BackgroundColor = Color.Moccasin;
            PlotsDataGridView.ColumnHeadersHeight = 29;
            PlotsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ActivityName, PlotNumber, RegulatedPlotNumber, neighborhood, City, Municipality, Street, StreetNumber, designation, locality });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            PlotsDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            PlotsDataGridView.Location = new Point(0, 46);
            PlotsDataGridView.Margin = new Padding(100, 4, 3, 4);
            PlotsDataGridView.Name = "PlotsDataGridView";
            PlotsDataGridView.RowHeadersWidth = 51;
            PlotsDataGridView.RowTemplate.Height = 50;
            PlotsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PlotsDataGridView.Size = new Size(1330, 282);
            PlotsDataGridView.TabIndex = 21;
            // 
            // ActivityName
            // 
            ActivityName.DataPropertyName = "ActivityName";
            ActivityName.HeaderText = "Дейност";
            ActivityName.MinimumWidth = 6;
            ActivityName.Name = "ActivityName";
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
            PlotsAddButton.BackgroundImage = (Image)resources.GetObject("PlotsAddButton.BackgroundImage");
            PlotsAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            PlotsAddButton.Location = new Point(190, 4);
            PlotsAddButton.Margin = new Padding(3, 4, 3, 4);
            PlotsAddButton.Name = "PlotsAddButton";
            PlotsAddButton.Size = new Size(35, 35);
            PlotsAddButton.TabIndex = 31;
            toolTip1.SetToolTip(PlotsAddButton, "F1");
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
            tabPage5.Controls.Add(btnLastOwnershipDataGridView);
            tabPage5.Controls.Add(btnNextOwnershipDataGridView);
            tabPage5.Controls.Add(btnPreviousOwnershipDataGridView);
            tabPage5.Controls.Add(btnFirstOwnershipDataGridView);
            tabPage5.Controls.Add(editOwnershipButton);
            tabPage5.Controls.Add(DeleteOwnershipButton);
            tabPage5.Controls.Add(AddOwnersButton);
            tabPage5.Controls.Add(OwnershipDataGridView);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1336, 335);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Собственост";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnLastOwnershipDataGridView
            // 
            btnLastOwnershipDataGridView.BackColor = Color.Transparent;
            btnLastOwnershipDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastOwnershipDataGridView.BackgroundImage");
            btnLastOwnershipDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastOwnershipDataGridView.Location = new Point(129, 7);
            btnLastOwnershipDataGridView.Name = "btnLastOwnershipDataGridView";
            btnLastOwnershipDataGridView.Size = new Size(35, 35);
            btnLastOwnershipDataGridView.TabIndex = 42;
            btnLastOwnershipDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnNextOwnershipDataGridView
            // 
            btnNextOwnershipDataGridView.BackColor = Color.Transparent;
            btnNextOwnershipDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextOwnershipDataGridView.BackgroundImage");
            btnNextOwnershipDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextOwnershipDataGridView.Location = new Point(88, 7);
            btnNextOwnershipDataGridView.Name = "btnNextOwnershipDataGridView";
            btnNextOwnershipDataGridView.Size = new Size(35, 35);
            btnNextOwnershipDataGridView.TabIndex = 41;
            btnNextOwnershipDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnPreviousOwnershipDataGridView
            // 
            btnPreviousOwnershipDataGridView.BackColor = Color.Transparent;
            btnPreviousOwnershipDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousOwnershipDataGridView.BackgroundImage");
            btnPreviousOwnershipDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousOwnershipDataGridView.Location = new Point(47, 7);
            btnPreviousOwnershipDataGridView.Name = "btnPreviousOwnershipDataGridView";
            btnPreviousOwnershipDataGridView.Size = new Size(35, 35);
            btnPreviousOwnershipDataGridView.TabIndex = 40;
            btnPreviousOwnershipDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnFirstOwnershipDataGridView
            // 
            btnFirstOwnershipDataGridView.BackColor = Color.Transparent;
            btnFirstOwnershipDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstOwnershipDataGridView.BackgroundImage");
            btnFirstOwnershipDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstOwnershipDataGridView.Location = new Point(6, 7);
            btnFirstOwnershipDataGridView.Name = "btnFirstOwnershipDataGridView";
            btnFirstOwnershipDataGridView.Size = new Size(35, 35);
            btnFirstOwnershipDataGridView.TabIndex = 39;
            btnFirstOwnershipDataGridView.UseVisualStyleBackColor = false;
            // 
            // editOwnershipButton
            // 
            editOwnershipButton.BackgroundImage = (Image)resources.GetObject("editOwnershipButton.BackgroundImage");
            editOwnershipButton.BackgroundImageLayout = ImageLayout.Stretch;
            editOwnershipButton.Location = new Point(275, 7);
            editOwnershipButton.Name = "editOwnershipButton";
            editOwnershipButton.Size = new Size(35, 35);
            editOwnershipButton.TabIndex = 14;
            toolTip1.SetToolTip(editOwnershipButton, "F2");
            editOwnershipButton.UseVisualStyleBackColor = true;
            editOwnershipButton.Click += editOwnershipButton_Click;
            // 
            // DeleteOwnershipButton
            // 
            DeleteOwnershipButton.BackgroundImage = (Image)resources.GetObject("DeleteOwnershipButton.BackgroundImage");
            DeleteOwnershipButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteOwnershipButton.Location = new Point(234, 7);
            DeleteOwnershipButton.Name = "DeleteOwnershipButton";
            DeleteOwnershipButton.Size = new Size(35, 35);
            DeleteOwnershipButton.TabIndex = 3;
            DeleteOwnershipButton.UseVisualStyleBackColor = true;
            DeleteOwnershipButton.Click += DeleteOwnershipButton_Click;
            // 
            // AddOwnersButton
            // 
            AddOwnersButton.BackgroundImage = (Image)resources.GetObject("AddOwnersButton.BackgroundImage");
            AddOwnersButton.BackgroundImageLayout = ImageLayout.Stretch;
            AddOwnersButton.Location = new Point(193, 7);
            AddOwnersButton.Name = "AddOwnersButton";
            AddOwnersButton.Size = new Size(35, 35);
            AddOwnersButton.TabIndex = 2;
            toolTip1.SetToolTip(AddOwnersButton, "F1");
            AddOwnersButton.UseVisualStyleBackColor = true;
            AddOwnersButton.Click += AddOwnersButton_Click;
            // 
            // OwnershipDataGridView
            // 
            OwnershipDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OwnershipDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OwnershipDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            OwnershipDataGridView.BackgroundColor = Color.Moccasin;
            OwnershipDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OwnershipDataGridView.Columns.AddRange(new DataGridViewColumn[] { PlotNumberDocTable, DocumentId, OwnerId, EKG, OwnerAddress, IdealParts, PowerOfAttorney });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            OwnershipDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            OwnershipDataGridView.Location = new Point(0, 49);
            OwnershipDataGridView.Name = "OwnershipDataGridView";
            OwnershipDataGridView.RowHeadersWidth = 51;
            OwnershipDataGridView.RowTemplate.Height = 29;
            OwnershipDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            OwnershipDataGridView.Size = new Size(1333, 286);
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
            // tabPage4
            // 
            tabPage4.Controls.Add(EditInvoiceButton);
            tabPage4.Controls.Add(btnLastInvoicesDataGridView);
            tabPage4.Controls.Add(btnNextInvoicesDataGridView);
            tabPage4.Controls.Add(btnPreviousInvoicesDataGridView);
            tabPage4.Controls.Add(btnFirstInvoicesDataGridView);
            tabPage4.Controls.Add(DeleteInvoiceButton);
            tabPage4.Controls.Add(InvoicesDataGridView);
            tabPage4.Controls.Add(addInvoiceButton);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1336, 335);
            tabPage4.TabIndex = 5;
            tabPage4.Text = "Фактури и такси";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // EditInvoiceButton
            // 
            EditInvoiceButton.BackgroundImage = (Image)resources.GetObject("EditInvoiceButton.BackgroundImage");
            EditInvoiceButton.BackgroundImageLayout = ImageLayout.Stretch;
            EditInvoiceButton.Location = new Point(275, 7);
            EditInvoiceButton.Name = "EditInvoiceButton";
            EditInvoiceButton.Size = new Size(35, 35);
            EditInvoiceButton.TabIndex = 47;
            toolTip1.SetToolTip(EditInvoiceButton, "F2");
            EditInvoiceButton.UseVisualStyleBackColor = true;
            EditInvoiceButton.Click += EditInvoiceButton_Click;
            // 
            // btnLastInvoicesDataGridView
            // 
            btnLastInvoicesDataGridView.BackColor = Color.Transparent;
            btnLastInvoicesDataGridView.BackgroundImage = (Image)resources.GetObject("btnLastInvoicesDataGridView.BackgroundImage");
            btnLastInvoicesDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnLastInvoicesDataGridView.Location = new Point(129, 7);
            btnLastInvoicesDataGridView.Name = "btnLastInvoicesDataGridView";
            btnLastInvoicesDataGridView.Size = new Size(35, 35);
            btnLastInvoicesDataGridView.TabIndex = 46;
            btnLastInvoicesDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnNextInvoicesDataGridView
            // 
            btnNextInvoicesDataGridView.BackColor = Color.Transparent;
            btnNextInvoicesDataGridView.BackgroundImage = (Image)resources.GetObject("btnNextInvoicesDataGridView.BackgroundImage");
            btnNextInvoicesDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextInvoicesDataGridView.Location = new Point(88, 7);
            btnNextInvoicesDataGridView.Name = "btnNextInvoicesDataGridView";
            btnNextInvoicesDataGridView.Size = new Size(35, 35);
            btnNextInvoicesDataGridView.TabIndex = 45;
            btnNextInvoicesDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnPreviousInvoicesDataGridView
            // 
            btnPreviousInvoicesDataGridView.BackColor = Color.Transparent;
            btnPreviousInvoicesDataGridView.BackgroundImage = (Image)resources.GetObject("btnPreviousInvoicesDataGridView.BackgroundImage");
            btnPreviousInvoicesDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousInvoicesDataGridView.Location = new Point(47, 7);
            btnPreviousInvoicesDataGridView.Name = "btnPreviousInvoicesDataGridView";
            btnPreviousInvoicesDataGridView.Size = new Size(35, 35);
            btnPreviousInvoicesDataGridView.TabIndex = 44;
            btnPreviousInvoicesDataGridView.UseVisualStyleBackColor = false;
            // 
            // btnFirstInvoicesDataGridView
            // 
            btnFirstInvoicesDataGridView.BackColor = Color.Transparent;
            btnFirstInvoicesDataGridView.BackgroundImage = (Image)resources.GetObject("btnFirstInvoicesDataGridView.BackgroundImage");
            btnFirstInvoicesDataGridView.BackgroundImageLayout = ImageLayout.Stretch;
            btnFirstInvoicesDataGridView.Location = new Point(6, 7);
            btnFirstInvoicesDataGridView.Name = "btnFirstInvoicesDataGridView";
            btnFirstInvoicesDataGridView.Size = new Size(35, 35);
            btnFirstInvoicesDataGridView.TabIndex = 43;
            btnFirstInvoicesDataGridView.UseVisualStyleBackColor = false;
            // 
            // StarContextMenuStrip
            // 
            StarContextMenuStrip.ImageScalingSize = new Size(20, 20);
            StarContextMenuStrip.Items.AddRange(new ToolStripItem[] { AvailableColors, ChooseColor });
            StarContextMenuStrip.Name = "contextMenuStrip1";
            StarContextMenuStrip.Size = new Size(201, 52);
            // 
            // AvailableColors
            // 
            AvailableColors.Name = "AvailableColors";
            AvailableColors.Size = new Size(200, 24);
            AvailableColors.Text = "Налични цветове";
            // 
            // ChooseColor
            // 
            ChooseColor.Name = "ChooseColor";
            ChooseColor.Size = new Size(200, 24);
            ChooseColor.Text = "Избери Цвят";
            // 
            // MenuRequestsUserControlBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(filtersPanel);
            Controls.Add(DocumentsOfOwnershipTab);
            Controls.Add(panel3);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuRequestsUserControlBase";
            Size = new Size(1350, 972);
            Load += MenuRequestsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            filtersPanel.ResumeLayout(false);
            filtersPanel.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityDataGridView).EndInit();
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).EndInit();
            DocumentsOfOwnershipTab.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PlotsDataGridView).EndInit();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OwnershipDataGridView).EndInit();
            tabPage4.ResumeLayout(false);
            StarContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        protected System.Windows.Forms.DataGridView RequestDataGridView;
        protected System.Windows.Forms.Label RequestTableLabel;
        protected System.Windows.Forms.Button RequestAddButton;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.DataGridView InvoicesDataGridView;
        protected System.Windows.Forms.Button addInvoiceButton;
        protected System.Windows.Forms.Panel panel3;
        protected Button RefreshButton;
        protected TabPage tabPage2;
        protected Panel panel2;
        protected Panel panel1;
        protected DataGridView ActivityDataGridView;
        protected Button ActivityAddButton;
        protected TabPage tabPage1;
        protected Panel panel4;
        protected Button button1;
        protected DataGridView clientsDataGridView;
        protected TabControl DocumentsOfOwnershipTab;
        protected TabPage tabPage3;
        protected Panel panel5;
        protected DataGridView PlotsDataGridView;
        protected Button PlotsAddButton;
        protected Label DestinationOfPlotLabel;
        protected TabPage tabPage5;
        protected DataGridView OwnershipDataGridView;
        protected Button AddOwnersButton;
        protected Button DeleteInvoiceButton;
        protected Button DeleteRequestButton;
        protected Button DeleteActivityButton;
        protected Button deleteClientsButton;
        protected Button DeletePlotsButton;
        protected Button DeleteOwnershipButton;
        protected Button CreateDocumentButton;
        protected DataGridViewTextBoxColumn PlotNumberDocTable;
        protected DataGridViewTextBoxColumn DocumentId;
        protected DataGridViewTextBoxColumn OwnerId;
        protected DataGridViewTextBoxColumn EKG;
        protected DataGridViewTextBoxColumn OwnerAddress;
        protected DataGridViewTextBoxColumn IdealParts;
        protected DataGridViewTextBoxColumn PowerOfAttorney;
        protected DataGridViewTextBoxColumn ClientNumber;
        protected DataGridViewTextBoxColumn FirstName;
        protected DataGridViewTextBoxColumn MiddleName;
        protected DataGridViewTextBoxColumn LastName;
        protected DataGridViewTextBoxColumn Phone;
        protected DataGridViewTextBoxColumn Email;
        protected DataGridViewTextBoxColumn Address;
        protected DataGridViewTextBoxColumn ClientLegalType;
        protected Button editRequestButton;
        protected Button editActivityButton;
        protected Button editClientButton;
        protected Button editPlotButton;
        protected Button editOwnershipButton;
        protected Panel panel7;
        protected Button btnPreviousRequestsDataGridView;
        protected Button btnFirstRequestsDataGridView;
        protected Button btnLastRequestsDataGridView;
        protected Button btnNextRequestsDataGridView;
        protected Button starRequestButton;
        protected Button btnLastClientsDataGridView;
        protected Button btnNextClientsDataGridView;
        protected Button btnPreviousClientsDataGridView;
        protected Button btnFirstClientsDataGridView;
        protected Button btnLastActivityDataGridView;
        protected Button btnNextActivityDataGridView;
        protected Button btnPreviousActivityDataGridView;
        protected Button btnFirstActivityDataGridView;
        protected Button btnLastPlotsDataGridView;
        protected Button btnNextPlotsDataGridView;
        protected Button btnPreviousPlotsDataGridView;
        protected Button btnFirstPlotsDataGridView;
        protected Button btnLastOwnershipDataGridView;
        protected Button btnNextOwnershipDataGridView;
        protected Button btnPreviousOwnershipDataGridView;
        protected Button btnFirstOwnershipDataGridView;
        protected TabPage tabPage4;
        protected Button btnLastInvoicesDataGridView;
        protected Button btnNextInvoicesDataGridView;
        protected Button btnPreviousInvoicesDataGridView;
        protected Button btnFirstInvoicesDataGridView;
        protected CheckBox taskSelfCheck;
        protected Label label2;
        protected CheckBox taskDayCheck;
        protected CheckBox taskWeekCheck;
        protected Button ApplyActivityFiltersButton;
        protected ComboBox taskStatusComboBox;
        protected Label label7;
        protected DataGridViewTextBoxColumn ActivityName;
        protected DataGridViewTextBoxColumn PlotNumber;
        protected DataGridViewTextBoxColumn RegulatedPlotNumber;
        protected DataGridViewTextBoxColumn neighborhood;
        protected DataGridViewTextBoxColumn City;
        protected DataGridViewTextBoxColumn Municipality;
        protected DataGridViewTextBoxColumn Street;
        protected DataGridViewTextBoxColumn StreetNumber;
        protected DataGridViewTextBoxColumn designation;
        protected DataGridViewTextBoxColumn locality;
        protected LinkLabel PathLink;
        protected DataGridViewTextBoxColumn number;
        protected DataGridViewTextBoxColumn Sum;
        protected Button EditInvoiceButton;
        protected DataGridViewTextBoxColumn RequestId;
        protected DataGridViewTextBoxColumn RequestName;
        protected DataGridViewTextBoxColumn PaymentStatus;
        protected DataGridViewTextBoxColumn Comments;
        protected DataGridViewTextBoxColumn PlotsInfo;
        protected Button button2;
        protected Button AddClientButton;
        protected FlowLayoutPanel clientsFlowLayoutPanel;
        protected CheckBox overdueFilter;
        protected Label label14;
        protected Label label4;
        protected ComboBox cmbPaymentStatus;
        protected Label label13;
        protected Label label3;
        protected RichTextBox CommentsTextBox;
        protected TextBox txtNumber;
        protected Label label12;
        protected ComboBox statusCheckBox;
        protected Label label11;
        protected Label label1;
        protected TextBox CityTextBox;
        protected CheckBox chkForWeek;
        protected Label label10;
        protected CheckBox chkForDay;
        protected TextBox neighborhoodTextBox;
        protected CheckBox chkStarred;
        protected Label label9;
        protected CheckBox chkPersonal;
        protected TextBox UPITextBox;
        protected Button RequestFiltersApplyButton;
        protected Label label8;
        protected TextBox plotNumberTextBox;
        protected FlowLayoutPanel OwnersFlowLayoutPanelFilter;
        protected ContextMenuStrip StarContextMenuStrip;
        protected ToolStripMenuItem AvailableColors;
        protected ToolStripMenuItem ChooseColor;
        protected DataGridViewTextBoxColumn ParentActivity;
        protected DataGridViewTextBoxColumn Activity;
        protected DataGridViewTextBoxColumn MainExecutantName;
        protected DataGridViewTextBoxColumn MainExecutantPayment;
        protected DataGridViewTextBoxColumn Plots;
        protected DataGridViewTextBoxColumn StartDate;
        protected DataGridViewTextBoxColumn ActivityEndDate;
        protected DataGridViewTextBoxColumn Task;
        protected DataGridViewTextBoxColumn Executant;
        protected DataGridViewTextBoxColumn TaskExecutantPayment;
        protected DataGridViewTextBoxColumn TaskStartDate;
        protected DataGridViewTextBoxColumn TaskEndDate;
        protected DataGridViewTextBoxColumn Duration;
        protected DataGridViewTextBoxColumn Control;
        protected DataGridViewTextBoxColumn Comment;
        protected DataGridViewTextBoxColumn tax;
        protected DataGridViewTextBoxColumn taxComment;
        protected DataGridViewTextBoxColumn Status;
        protected Label EmployeesFilterLabel;
        protected CheckedListBox EmployeesFilterCheckBoxList;
        public Panel filtersPanel;
        protected CheckBox overdueTasksFilter;
        protected TextBox requestNameFilter;
        protected Label label6;
        private System.ComponentModel.IContainer components;
        private ToolTip toolTip1;
    }
}

