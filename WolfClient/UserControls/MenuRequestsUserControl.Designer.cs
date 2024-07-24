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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuRequestsUserControl));
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
            label5 = new Label();
            InvoicesDataGridView = new DataGridView();
            InvoiceId = new DataGridViewTextBoxColumn();
            Sum = new DataGridViewTextBoxColumn();
            button3 = new Button();
            button8 = new Button();
            panel3 = new Panel();
            panel7 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button2 = new Button();
            panel6 = new Panel();
            button29 = new Button();
            checkBox3 = new CheckBox();
            StarredCheckBox = new CheckBox();
            checkBox2 = new CheckBox();
            label6 = new Label();
            checkBox1 = new CheckBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            editRequestButton = new Button();
            DeleteRequestButton = new Button();
            RefreshButton = new Button();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            editActivityButton = new Button();
            CreateDocumentButton = new Button();
            DeleteActivityButton = new Button();
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
            tax = new DataGridViewTextBoxColumn();
            taxComment = new DataGridViewTextBoxColumn();
            ActivityAddButton = new Button();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            button9 = new Button();
            editClientButton = new Button();
            button10 = new Button();
            deleteClientsButton = new Button();
            button11 = new Button();
            button1 = new Button();
            button12 = new Button();
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
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            editPlotButton = new Button();
            DeletePlotsButton = new Button();
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
            button21 = new Button();
            button22 = new Button();
            button23 = new Button();
            button24 = new Button();
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
            button25 = new Button();
            button26 = new Button();
            button27 = new Button();
            button28 = new Button();
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).BeginInit();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
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
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // RequestDataGridView
            // 
            RequestDataGridView.AllowUserToResizeColumns = false;
            RequestDataGridView.AllowUserToResizeRows = false;
            RequestDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RequestDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RequestDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            RequestDataGridView.BackgroundColor = Color.Moccasin;
            RequestDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RequestDataGridView.Columns.AddRange(new DataGridViewColumn[] { RequestId, RequestName, Price, PaymentStatus, Advance, Comments });
            RequestDataGridView.GridColor = SystemColors.ControlText;
            RequestDataGridView.Location = new Point(0, 100);
            RequestDataGridView.Margin = new Padding(3, 4, 3, 4);
            RequestDataGridView.Name = "RequestDataGridView";
            RequestDataGridView.RowHeadersWidth = 51;
            RequestDataGridView.RowTemplate.Height = 24;
            RequestDataGridView.Size = new Size(1334, 434);
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
            RequestTableLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RequestTableLabel.Location = new Point(3, 7);
            RequestTableLabel.Name = "RequestTableLabel";
            RequestTableLabel.Size = new Size(95, 28);
            RequestTableLabel.TabIndex = 1;
            RequestTableLabel.Text = "Поръчки";
            RequestTableLabel.Click += label1_Click_1;
            // 
            // RequestAddButton
            // 
            RequestAddButton.BackColor = Color.Transparent;
            RequestAddButton.BackgroundImage = (Image)resources.GetObject("RequestAddButton.BackgroundImage");
            RequestAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            RequestAddButton.ForeColor = Color.Transparent;
            RequestAddButton.Location = new Point(103, 4);
            RequestAddButton.Margin = new Padding(3, 4, 3, 4);
            RequestAddButton.Name = "RequestAddButton";
            RequestAddButton.Size = new Size(35, 35);
            RequestAddButton.TabIndex = 2;
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
            InvoicesDataGridView.Columns.AddRange(new DataGridViewColumn[] { InvoiceId, Sum });
            InvoicesDataGridView.Location = new Point(-1, 49);
            InvoicesDataGridView.Margin = new Padding(3, 4, 3, 4);
            InvoicesDataGridView.Name = "InvoicesDataGridView";
            InvoicesDataGridView.RowHeadersWidth = 51;
            InvoicesDataGridView.RowTemplate.Height = 24;
            InvoicesDataGridView.Size = new Size(1337, 282);
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
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(193, 7);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(35, 35);
            button3.TabIndex = 13;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button8
            // 
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.Location = new Point(234, 7);
            button8.Name = "button8";
            button8.Size = new Size(35, 35);
            button8.TabIndex = 14;
            button8.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(editRequestButton);
            panel3.Controls.Add(DeleteRequestButton);
            panel3.Controls.Add(RefreshButton);
            panel3.Controls.Add(RequestDataGridView);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(RequestTableLabel);
            panel3.Controls.Add(RequestAddButton);
            panel3.Location = new Point(3, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1337, 564);
            panel3.TabIndex = 17;
            panel3.Paint += panel3_Paint;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.Fixed3D;
            panel7.Controls.Add(button7);
            panel7.Controls.Add(button6);
            panel7.Controls.Add(button5);
            panel7.Controls.Add(button4);
            panel7.Controls.Add(button2);
            panel7.Location = new Point(8, 43);
            panel7.Name = "panel7";
            panel7.Size = new Size(237, 50);
            panel7.TabIndex = 21;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.Location = new Point(187, 3);
            button7.Name = "button7";
            button7.Size = new Size(40, 40);
            button7.TabIndex = 4;
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.Location = new Point(141, 3);
            button6.Name = "button6";
            button6.Size = new Size(40, 40);
            button6.TabIndex = 3;
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(95, 3);
            button5.Name = "button5";
            button5.Size = new Size(40, 40);
            button5.TabIndex = 2;
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Location = new Point(49, 3);
            button4.Name = "button4";
            button4.Size = new Size(40, 40);
            button4.TabIndex = 1;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(40, 40);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(button29);
            panel6.Controls.Add(checkBox3);
            panel6.Controls.Add(StarredCheckBox);
            panel6.Controls.Add(checkBox2);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(checkBox1);
            panel6.Controls.Add(label1);
            panel6.Controls.Add(comboBox2);
            panel6.Controls.Add(textBox1);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(label3);
            panel6.Controls.Add(comboBox1);
            panel6.Location = new Point(251, 24);
            panel6.Name = "panel6";
            panel6.Size = new Size(756, 69);
            panel6.TabIndex = 20;
            // 
            // button29
            // 
            button29.BackColor = Color.Transparent;
            button29.BackgroundImage = (Image)resources.GetObject("button29.BackgroundImage");
            button29.BackgroundImageLayout = ImageLayout.Stretch;
            button29.Location = new Point(714, 3);
            button29.Name = "button29";
            button29.Size = new Size(30, 30);
            button29.TabIndex = 22;
            button29.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(294, 7);
            checkBox3.Name = "checkBox3";
            checkBox3.RightToLeft = RightToLeft.Yes;
            checkBox3.Size = new Size(76, 24);
            checkBox3.TabIndex = 3;
            checkBox3.Text = "Лични";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // StarredCheckBox
            // 
            StarredCheckBox.AutoSize = true;
            StarredCheckBox.Location = new Point(602, 7);
            StarredCheckBox.Name = "StarredCheckBox";
            StarredCheckBox.RightToLeft = RightToLeft.Yes;
            StarredCheckBox.Size = new Size(104, 24);
            StarredCheckBox.TabIndex = 21;
            StarredCheckBox.Text = "със звезда";
            StarredCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(383, 7);
            checkBox2.Name = "checkBox2";
            checkBox2.RightToLeft = RightToLeft.Yes;
            checkBox2.Size = new Size(83, 24);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "за деня";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(-2, -2);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 20;
            label6.Text = "филтри";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(472, 7);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(124, 24);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "за седмицата";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(-1, 35);
            label1.Name = "label1";
            label1.Size = new Size(88, 28);
            label1.TabIndex = 14;
            label1.Text = "Номер : ";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(627, 35);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(117, 28);
            comboBox2.TabIndex = 19;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(89, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 27);
            textBox1.TabIndex = 15;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(539, 35);
            label4.Name = "label4";
            label4.Size = new Size(88, 28);
            label4.TabIndex = 18;
            label4.Text = "Статус :  ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(243, 35);
            label3.Name = "label3";
            label3.Size = new Size(171, 28);
            label3.TabIndex = 16;
            label3.Text = "Статус Плащане : ";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(416, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 28);
            comboBox1.TabIndex = 17;
            // 
            // editRequestButton
            // 
            editRequestButton.BackColor = Color.Transparent;
            editRequestButton.BackgroundImage = (Image)resources.GetObject("editRequestButton.BackgroundImage");
            editRequestButton.BackgroundImageLayout = ImageLayout.Stretch;
            editRequestButton.Location = new Point(175, 4);
            editRequestButton.Name = "editRequestButton";
            editRequestButton.Size = new Size(35, 35);
            editRequestButton.TabIndex = 13;
            editRequestButton.UseVisualStyleBackColor = false;
            editRequestButton.Click += editRequestButton_Click;
            // 
            // DeleteRequestButton
            // 
            DeleteRequestButton.BackColor = Color.Transparent;
            DeleteRequestButton.BackgroundImage = (Image)resources.GetObject("DeleteRequestButton.BackgroundImage");
            DeleteRequestButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteRequestButton.Location = new Point(139, 4);
            DeleteRequestButton.Name = "DeleteRequestButton";
            DeleteRequestButton.Size = new Size(35, 35);
            DeleteRequestButton.TabIndex = 12;
            DeleteRequestButton.UseVisualStyleBackColor = false;
            DeleteRequestButton.Click += DeleteRequestButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BackgroundImage = (Image)resources.GetObject("RefreshButton.BackgroundImage");
            RefreshButton.BackgroundImageLayout = ImageLayout.Stretch;
            RefreshButton.Location = new Point(211, 4);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(35, 35);
            RefreshButton.TabIndex = 11;
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
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
            panel2.Controls.Add(button13);
            panel2.Controls.Add(button14);
            panel2.Controls.Add(button15);
            panel2.Controls.Add(button16);
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
            // button13
            // 
            button13.BackColor = Color.Transparent;
            button13.BackgroundImage = (Image)resources.GetObject("button13.BackgroundImage");
            button13.BackgroundImageLayout = ImageLayout.Stretch;
            button13.Location = new Point(126, 4);
            button13.Name = "button13";
            button13.Size = new Size(35, 35);
            button13.TabIndex = 34;
            button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            button14.BackColor = Color.Transparent;
            button14.BackgroundImage = (Image)resources.GetObject("button14.BackgroundImage");
            button14.BackgroundImageLayout = ImageLayout.Stretch;
            button14.Location = new Point(85, 4);
            button14.Name = "button14";
            button14.Size = new Size(35, 35);
            button14.TabIndex = 33;
            button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            button15.BackColor = Color.Transparent;
            button15.BackgroundImage = (Image)resources.GetObject("button15.BackgroundImage");
            button15.BackgroundImageLayout = ImageLayout.Stretch;
            button15.Location = new Point(44, 4);
            button15.Name = "button15";
            button15.Size = new Size(35, 35);
            button15.TabIndex = 32;
            button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            button16.BackColor = Color.Transparent;
            button16.BackgroundImage = (Image)resources.GetObject("button16.BackgroundImage");
            button16.BackgroundImageLayout = ImageLayout.Stretch;
            button16.Location = new Point(3, 4);
            button16.Name = "button16";
            button16.Size = new Size(35, 35);
            button16.TabIndex = 31;
            button16.UseVisualStyleBackColor = false;
            // 
            // editActivityButton
            // 
            editActivityButton.BackgroundImage = (Image)resources.GetObject("editActivityButton.BackgroundImage");
            editActivityButton.BackgroundImageLayout = ImageLayout.Stretch;
            editActivityButton.Location = new Point(272, 4);
            editActivityButton.Name = "editActivityButton";
            editActivityButton.Size = new Size(35, 35);
            editActivityButton.TabIndex = 14;
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
            ActivityDataGridView.AllowUserToResizeColumns = false;
            ActivityDataGridView.AllowUserToResizeRows = false;
            ActivityDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ActivityDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActivityDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ActivityDataGridView.BackgroundColor = Color.Moccasin;
            ActivityDataGridView.ColumnHeadersHeight = 28;
            ActivityDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ActivityDataGridView.Columns.AddRange(new DataGridViewColumn[] { ParentActivity, Activity, Task, Executant, StartDate, Duration, Control, Plots, Comment, tax, taxComment });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ActivityDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            ActivityDataGridView.Location = new Point(0, 46);
            ActivityDataGridView.Margin = new Padding(3, 4, 3, 4);
            ActivityDataGridView.MinimumSize = new Size(933, 188);
            ActivityDataGridView.Name = "ActivityDataGridView";
            ActivityDataGridView.RowHeadersWidth = 51;
            ActivityDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ActivityDataGridView.RowTemplate.Height = 350;
            ActivityDataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
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
            // ActivityAddButton
            // 
            ActivityAddButton.BackgroundImage = (Image)resources.GetObject("ActivityAddButton.BackgroundImage");
            ActivityAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            ActivityAddButton.Location = new Point(190, 4);
            ActivityAddButton.Margin = new Padding(3, 4, 3, 4);
            ActivityAddButton.Name = "ActivityAddButton";
            ActivityAddButton.Size = new Size(35, 35);
            ActivityAddButton.TabIndex = 28;
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
            panel4.Controls.Add(button9);
            panel4.Controls.Add(editClientButton);
            panel4.Controls.Add(button10);
            panel4.Controls.Add(deleteClientsButton);
            panel4.Controls.Add(button11);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(button12);
            panel4.Controls.Add(clientsDataGridView);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1330, 329);
            panel4.TabIndex = 18;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.BackgroundImage = (Image)resources.GetObject("button9.BackgroundImage");
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button9.Location = new Point(126, 4);
            button9.Name = "button9";
            button9.Size = new Size(35, 35);
            button9.TabIndex = 8;
            button9.UseVisualStyleBackColor = false;
            // 
            // editClientButton
            // 
            editClientButton.BackgroundImage = (Image)resources.GetObject("editClientButton.BackgroundImage");
            editClientButton.BackgroundImageLayout = ImageLayout.Stretch;
            editClientButton.Location = new Point(272, 4);
            editClientButton.Name = "editClientButton";
            editClientButton.Size = new Size(35, 35);
            editClientButton.TabIndex = 14;
            editClientButton.UseVisualStyleBackColor = true;
            editClientButton.Click += editClientButton_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Transparent;
            button10.BackgroundImage = (Image)resources.GetObject("button10.BackgroundImage");
            button10.BackgroundImageLayout = ImageLayout.Stretch;
            button10.Location = new Point(85, 4);
            button10.Name = "button10";
            button10.Size = new Size(35, 35);
            button10.TabIndex = 7;
            button10.UseVisualStyleBackColor = false;
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
            // button11
            // 
            button11.BackColor = Color.Transparent;
            button11.BackgroundImage = (Image)resources.GetObject("button11.BackgroundImage");
            button11.BackgroundImageLayout = ImageLayout.Stretch;
            button11.Location = new Point(44, 4);
            button11.Name = "button11";
            button11.Size = new Size(35, 35);
            button11.TabIndex = 6;
            button11.UseVisualStyleBackColor = false;
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
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button12
            // 
            button12.BackColor = Color.Transparent;
            button12.BackgroundImage = (Image)resources.GetObject("button12.BackgroundImage");
            button12.BackgroundImageLayout = ImageLayout.Stretch;
            button12.Location = new Point(3, 4);
            button12.Name = "button12";
            button12.Size = new Size(35, 35);
            button12.TabIndex = 5;
            button12.UseVisualStyleBackColor = false;
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
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel5);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1336, 335);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "имоти";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(button17);
            panel5.Controls.Add(button18);
            panel5.Controls.Add(button19);
            panel5.Controls.Add(button20);
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
            // button17
            // 
            button17.BackColor = Color.Transparent;
            button17.BackgroundImage = (Image)resources.GetObject("button17.BackgroundImage");
            button17.BackgroundImageLayout = ImageLayout.Stretch;
            button17.Location = new Point(126, 4);
            button17.Name = "button17";
            button17.Size = new Size(35, 35);
            button17.TabIndex = 38;
            button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            button18.BackColor = Color.Transparent;
            button18.BackgroundImage = (Image)resources.GetObject("button18.BackgroundImage");
            button18.BackgroundImageLayout = ImageLayout.Stretch;
            button18.Location = new Point(85, 4);
            button18.Name = "button18";
            button18.Size = new Size(35, 35);
            button18.TabIndex = 37;
            button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            button19.BackColor = Color.Transparent;
            button19.BackgroundImage = (Image)resources.GetObject("button19.BackgroundImage");
            button19.BackgroundImageLayout = ImageLayout.Stretch;
            button19.Location = new Point(44, 4);
            button19.Name = "button19";
            button19.Size = new Size(35, 35);
            button19.TabIndex = 36;
            button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            button20.BackColor = Color.Transparent;
            button20.BackgroundImage = (Image)resources.GetObject("button20.BackgroundImage");
            button20.BackgroundImageLayout = ImageLayout.Stretch;
            button20.Location = new Point(3, 4);
            button20.Name = "button20";
            button20.Size = new Size(35, 35);
            button20.TabIndex = 35;
            button20.UseVisualStyleBackColor = false;
            // 
            // editPlotButton
            // 
            editPlotButton.BackgroundImage = (Image)resources.GetObject("editPlotButton.BackgroundImage");
            editPlotButton.BackgroundImageLayout = ImageLayout.Stretch;
            editPlotButton.Location = new Point(272, 4);
            editPlotButton.Name = "editPlotButton";
            editPlotButton.Size = new Size(35, 35);
            editPlotButton.TabIndex = 14;
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
            PlotsDataGridView.Location = new Point(0, 46);
            PlotsDataGridView.Margin = new Padding(100, 4, 3, 4);
            PlotsDataGridView.Name = "PlotsDataGridView";
            PlotsDataGridView.RowHeadersWidth = 51;
            PlotsDataGridView.RowTemplate.Height = 50;
            PlotsDataGridView.Size = new Size(1330, 282);
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
            PlotsAddButton.BackgroundImage = (Image)resources.GetObject("PlotsAddButton.BackgroundImage");
            PlotsAddButton.BackgroundImageLayout = ImageLayout.Stretch;
            PlotsAddButton.Location = new Point(190, 4);
            PlotsAddButton.Margin = new Padding(3, 4, 3, 4);
            PlotsAddButton.Name = "PlotsAddButton";
            PlotsAddButton.Size = new Size(35, 35);
            PlotsAddButton.TabIndex = 31;
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
            tabPage5.Controls.Add(button21);
            tabPage5.Controls.Add(button22);
            tabPage5.Controls.Add(button23);
            tabPage5.Controls.Add(button24);
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
            // button21
            // 
            button21.BackColor = Color.Transparent;
            button21.BackgroundImage = (Image)resources.GetObject("button21.BackgroundImage");
            button21.BackgroundImageLayout = ImageLayout.Stretch;
            button21.Location = new Point(129, 7);
            button21.Name = "button21";
            button21.Size = new Size(35, 35);
            button21.TabIndex = 42;
            button21.UseVisualStyleBackColor = false;
            // 
            // button22
            // 
            button22.BackColor = Color.Transparent;
            button22.BackgroundImage = (Image)resources.GetObject("button22.BackgroundImage");
            button22.BackgroundImageLayout = ImageLayout.Stretch;
            button22.Location = new Point(88, 7);
            button22.Name = "button22";
            button22.Size = new Size(35, 35);
            button22.TabIndex = 41;
            button22.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            button23.BackColor = Color.Transparent;
            button23.BackgroundImage = (Image)resources.GetObject("button23.BackgroundImage");
            button23.BackgroundImageLayout = ImageLayout.Stretch;
            button23.Location = new Point(47, 7);
            button23.Name = "button23";
            button23.Size = new Size(35, 35);
            button23.TabIndex = 40;
            button23.UseVisualStyleBackColor = false;
            // 
            // button24
            // 
            button24.BackColor = Color.Transparent;
            button24.BackgroundImage = (Image)resources.GetObject("button24.BackgroundImage");
            button24.BackgroundImageLayout = ImageLayout.Stretch;
            button24.Location = new Point(6, 7);
            button24.Name = "button24";
            button24.Size = new Size(35, 35);
            button24.TabIndex = 39;
            button24.UseVisualStyleBackColor = false;
            // 
            // editOwnershipButton
            // 
            editOwnershipButton.BackgroundImage = (Image)resources.GetObject("editOwnershipButton.BackgroundImage");
            editOwnershipButton.BackgroundImageLayout = ImageLayout.Stretch;
            editOwnershipButton.Location = new Point(275, 7);
            editOwnershipButton.Name = "editOwnershipButton";
            editOwnershipButton.Size = new Size(35, 35);
            editOwnershipButton.TabIndex = 14;
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            OwnershipDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            OwnershipDataGridView.Location = new Point(0, 49);
            OwnershipDataGridView.Name = "OwnershipDataGridView";
            OwnershipDataGridView.RowHeadersWidth = 51;
            OwnershipDataGridView.RowTemplate.Height = 29;
            OwnershipDataGridView.Size = new Size(1336, 286);
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
            tabPage4.Controls.Add(button25);
            tabPage4.Controls.Add(button26);
            tabPage4.Controls.Add(button27);
            tabPage4.Controls.Add(button28);
            tabPage4.Controls.Add(button8);
            tabPage4.Controls.Add(InvoicesDataGridView);
            tabPage4.Controls.Add(button3);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1336, 335);
            tabPage4.TabIndex = 5;
            tabPage4.Text = "Фактури и такси";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            button25.BackColor = Color.Transparent;
            button25.BackgroundImage = (Image)resources.GetObject("button25.BackgroundImage");
            button25.BackgroundImageLayout = ImageLayout.Stretch;
            button25.Location = new Point(129, 7);
            button25.Name = "button25";
            button25.Size = new Size(35, 35);
            button25.TabIndex = 46;
            button25.UseVisualStyleBackColor = false;
            // 
            // button26
            // 
            button26.BackColor = Color.Transparent;
            button26.BackgroundImage = (Image)resources.GetObject("button26.BackgroundImage");
            button26.BackgroundImageLayout = ImageLayout.Stretch;
            button26.Location = new Point(88, 7);
            button26.Name = "button26";
            button26.Size = new Size(35, 35);
            button26.TabIndex = 45;
            button26.UseVisualStyleBackColor = false;
            // 
            // button27
            // 
            button27.BackColor = Color.Transparent;
            button27.BackgroundImage = (Image)resources.GetObject("button27.BackgroundImage");
            button27.BackgroundImageLayout = ImageLayout.Stretch;
            button27.Location = new Point(47, 7);
            button27.Name = "button27";
            button27.Size = new Size(35, 35);
            button27.TabIndex = 44;
            button27.UseVisualStyleBackColor = false;
            // 
            // button28
            // 
            button28.BackColor = Color.Transparent;
            button28.BackgroundImage = (Image)resources.GetObject("button28.BackgroundImage");
            button28.BackgroundImageLayout = ImageLayout.Stretch;
            button28.Location = new Point(6, 7);
            button28.Name = "button28";
            button28.Size = new Size(35, 35);
            button28.TabIndex = 43;
            button28.UseVisualStyleBackColor = false;
            // 
            // MenuRequestsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(DocumentsOfOwnershipTab);
            Controls.Add(panel3);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuRequestsUserControl";
            Size = new Size(1350, 972);
            Load += MenuRequestsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)RequestDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)InvoicesDataGridView).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
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
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.Label RequestTableLabel;
        private System.Windows.Forms.Button RequestAddButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView InvoicesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.Button button3;
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
        private DataGridView ActivityDataGridView;
        private Button ActivityAddButton;
        private TabPage tabPage1;
        private Panel panel4;
        private Button button1;
        private DataGridView clientsDataGridView;
        private TabControl DocumentsOfOwnershipTab;
        private TabPage tabPage3;
        private Panel panel5;
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
        private TabPage tabPage5;
        private DataGridView OwnershipDataGridView;
        private Button AddOwnersButton;
        private Button button8;
        private Button DeleteRequestButton;
        private Button DeleteActivityButton;
        private Button deleteClientsButton;
        private Button DeletePlotsButton;
        private Button DeleteOwnershipButton;
        private Button CreateDocumentButton;
        private DataGridViewTextBoxColumn PlotNumberDocTable;
        private DataGridViewTextBoxColumn DocumentId;
        private DataGridViewTextBoxColumn OwnerId;
        private DataGridViewTextBoxColumn EKG;
        private DataGridViewTextBoxColumn OwnerAddress;
        private DataGridViewTextBoxColumn IdealParts;
        private DataGridViewTextBoxColumn PowerOfAttorney;
        private DataGridViewTextBoxColumn ParentActivity;
        private DataGridViewTextBoxColumn Activity;
        private DataGridViewTextBoxColumn Task;
        private DataGridViewTextBoxColumn Executant;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn Control;
        private DataGridViewTextBoxColumn Plots;
        private DataGridViewTextBoxColumn Comment;
        private DataGridViewTextBoxColumn tax;
        private DataGridViewTextBoxColumn taxComment;
        private DataGridViewTextBoxColumn ClientNumber;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn MiddleName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ClientLegalType;
        private Button editRequestButton;
        private Button editActivityButton;
        private Button editClientButton;
        private Button editPlotButton;
        private Button editOwnershipButton;
        private Label label4;
        private Panel panel6;
        private Panel panel7;
        private Button button4;
        private Button button2;
        private Label label6;
        private Label label1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox1;
        private Button button6;
        private Button button5;
        private Button button7;
        private CheckBox StarredCheckBox;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Button button22;
        private Button button23;
        private Button button24;
        private TabPage tabPage4;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button button29;
    }
}
