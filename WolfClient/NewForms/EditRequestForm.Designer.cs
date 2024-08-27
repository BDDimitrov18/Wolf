namespace WolfClient.NewForms
{
    partial class EditRequestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRequestForm));
            AddRequestButton = new Button();
            AddNonExistingClientButton = new Button();
            AddNonExistingClientLabel = new Label();
            AddClientComboBoxButton = new Button();
            AddExistingClientToRequestLabel = new Label();
            CommentsRichTextBox = new RichTextBox();
            NewClientsFlowPanel = new Label();
            AdvanceTextBox = new TextBox();
            AdvanceLabel = new Label();
            PriceOfRequestTextBox = new TextBox();
            PriceOfRequestLabel = new Label();
            NameOfRequestTextBox = new TextBox();
            NameOfRequestTiltleLabel = new Label();
            AvailableClientsFlowPanel = new FlowLayoutPanel();
            NotAvailableClientsFlowPanel = new FlowLayoutPanel();
            RequestErrorProvider = new ErrorProvider(components);
            NameOfRequestErrorLabel = new Label();
            FinalPriceErrorLabel = new Label();
            AdvancePriceErrorLabel = new Label();
            PathTextBox = new TextBox();
            openFilesButton = new Button();
            label1 = new Label();
            label2 = new Label();
            RequestCreatorComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)RequestErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // AddRequestButton
            // 
            AddRequestButton.Location = new Point(354, 710);
            AddRequestButton.Margin = new Padding(3, 4, 3, 4);
            AddRequestButton.Name = "AddRequestButton";
            AddRequestButton.Size = new Size(174, 46);
            AddRequestButton.TabIndex = 29;
            AddRequestButton.Text = "Редактиране";
            AddRequestButton.UseVisualStyleBackColor = true;
            AddRequestButton.Click += AddRequestButton_Click;
            // 
            // AddNonExistingClientButton
            // 
            AddNonExistingClientButton.Location = new Point(624, 409);
            AddNonExistingClientButton.Margin = new Padding(3, 4, 3, 4);
            AddNonExistingClientButton.Name = "AddNonExistingClientButton";
            AddNonExistingClientButton.Size = new Size(163, 29);
            AddNonExistingClientButton.TabIndex = 28;
            AddNonExistingClientButton.Text = "Добави заложител";
            AddNonExistingClientButton.UseVisualStyleBackColor = true;
            AddNonExistingClientButton.Click += AddNonExistingClientButton_Click;
            // 
            // AddNonExistingClientLabel
            // 
            AddNonExistingClientLabel.AutoSize = true;
            AddNonExistingClientLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddNonExistingClientLabel.Location = new Point(387, 409);
            AddNonExistingClientLabel.Name = "AddNonExistingClientLabel";
            AddNonExistingClientLabel.Size = new Size(231, 25);
            AddNonExistingClientLabel.TabIndex = 27;
            AddNonExistingClientLabel.Text = "Добави нов заложител";
            // 
            // AddClientComboBoxButton
            // 
            AddClientComboBoxButton.Location = new Point(717, 11);
            AddClientComboBoxButton.Margin = new Padding(3, 4, 3, 4);
            AddClientComboBoxButton.Name = "AddClientComboBoxButton";
            AddClientComboBoxButton.Size = new Size(131, 29);
            AddClientComboBoxButton.TabIndex = 26;
            AddClientComboBoxButton.Text = "Добави Поле";
            AddClientComboBoxButton.UseVisualStyleBackColor = true;
            AddClientComboBoxButton.Click += AddClientComboBoxButton_Click;
            // 
            // AddExistingClientToRequestLabel
            // 
            AddExistingClientToRequestLabel.AutoSize = true;
            AddExistingClientToRequestLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddExistingClientToRequestLabel.Location = new Point(387, 9);
            AddExistingClientToRequestLabel.Name = "AddExistingClientToRequestLabel";
            AddExistingClientToRequestLabel.Size = new Size(331, 25);
            AddExistingClientToRequestLabel.TabIndex = 24;
            AddExistingClientToRequestLabel.Text = "Избери заложител от наличните ";
            // 
            // CommentsRichTextBox
            // 
            CommentsRichTextBox.Location = new Point(17, 532);
            CommentsRichTextBox.Margin = new Padding(3, 4, 3, 4);
            CommentsRichTextBox.Name = "CommentsRichTextBox";
            CommentsRichTextBox.Size = new Size(316, 143);
            CommentsRichTextBox.TabIndex = 23;
            CommentsRichTextBox.Text = "";
            // 
            // NewClientsFlowPanel
            // 
            NewClientsFlowPanel.AutoSize = true;
            NewClientsFlowPanel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NewClientsFlowPanel.Location = new Point(17, 503);
            NewClientsFlowPanel.Name = "NewClientsFlowPanel";
            NewClientsFlowPanel.Size = new Size(107, 25);
            NewClientsFlowPanel.TabIndex = 22;
            NewClientsFlowPanel.Text = "Коментар";
            // 
            // AdvanceTextBox
            // 
            AdvanceTextBox.Location = new Point(17, 267);
            AdvanceTextBox.Margin = new Padding(3, 4, 3, 4);
            AdvanceTextBox.Name = "AdvanceTextBox";
            AdvanceTextBox.Size = new Size(253, 27);
            AdvanceTextBox.TabIndex = 21;
            // 
            // AdvanceLabel
            // 
            AdvanceLabel.AutoSize = true;
            AdvanceLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AdvanceLabel.Location = new Point(12, 208);
            AdvanceLabel.Name = "AdvanceLabel";
            AdvanceLabel.Size = new Size(164, 25);
            AdvanceLabel.TabIndex = 20;
            AdvanceLabel.Text = "Преведена сума";
            // 
            // PriceOfRequestTextBox
            // 
            PriceOfRequestTextBox.Location = new Point(17, 158);
            PriceOfRequestTextBox.Margin = new Padding(3, 4, 3, 4);
            PriceOfRequestTextBox.Name = "PriceOfRequestTextBox";
            PriceOfRequestTextBox.Size = new Size(253, 27);
            PriceOfRequestTextBox.TabIndex = 19;
            // 
            // PriceOfRequestLabel
            // 
            PriceOfRequestLabel.AutoSize = true;
            PriceOfRequestLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PriceOfRequestLabel.Location = new Point(12, 99);
            PriceOfRequestLabel.Name = "PriceOfRequestLabel";
            PriceOfRequestLabel.Size = new Size(321, 25);
            PriceOfRequestLabel.TabIndex = 18;
            PriceOfRequestLabel.Text = "Цяла сума за Финални Продукти";
            // 
            // NameOfRequestTextBox
            // 
            NameOfRequestTextBox.Location = new Point(17, 60);
            NameOfRequestTextBox.Margin = new Padding(3, 4, 3, 4);
            NameOfRequestTextBox.Name = "NameOfRequestTextBox";
            NameOfRequestTextBox.Size = new Size(253, 27);
            NameOfRequestTextBox.TabIndex = 17;
            // 
            // NameOfRequestTiltleLabel
            // 
            NameOfRequestTiltleLabel.AutoSize = true;
            NameOfRequestTiltleLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameOfRequestTiltleLabel.Location = new Point(12, 9);
            NameOfRequestTiltleLabel.Name = "NameOfRequestTiltleLabel";
            NameOfRequestTiltleLabel.Size = new Size(185, 25);
            NameOfRequestTiltleLabel.TabIndex = 16;
            NameOfRequestTiltleLabel.Text = "Име На поръчката";
            // 
            // AvailableClientsFlowPanel
            // 
            AvailableClientsFlowPanel.AutoScroll = true;
            AvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            AvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            AvailableClientsFlowPanel.Location = new Point(387, 47);
            AvailableClientsFlowPanel.Name = "AvailableClientsFlowPanel";
            AvailableClientsFlowPanel.Size = new Size(461, 283);
            AvailableClientsFlowPanel.TabIndex = 32;
            // 
            // NotAvailableClientsFlowPanel
            // 
            NotAvailableClientsFlowPanel.AutoScroll = true;
            NotAvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            NotAvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            NotAvailableClientsFlowPanel.Location = new Point(387, 459);
            NotAvailableClientsFlowPanel.Name = "NotAvailableClientsFlowPanel";
            NotAvailableClientsFlowPanel.Size = new Size(410, 216);
            NotAvailableClientsFlowPanel.TabIndex = 33;
            // 
            // RequestErrorProvider
            // 
            RequestErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            RequestErrorProvider.ContainerControl = this;
            // 
            // NameOfRequestErrorLabel
            // 
            NameOfRequestErrorLabel.AutoSize = true;
            NameOfRequestErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            NameOfRequestErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            NameOfRequestErrorLabel.Location = new Point(17, 41);
            NameOfRequestErrorLabel.Name = "NameOfRequestErrorLabel";
            NameOfRequestErrorLabel.Size = new Size(114, 15);
            NameOfRequestErrorLabel.TabIndex = 34;
            NameOfRequestErrorLabel.Text = "Моля въведете име";
            // 
            // FinalPriceErrorLabel
            // 
            FinalPriceErrorLabel.AutoSize = true;
            FinalPriceErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            FinalPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            FinalPriceErrorLabel.Location = new Point(17, 139);
            FinalPriceErrorLabel.Name = "FinalPriceErrorLabel";
            FinalPriceErrorLabel.Size = new Size(171, 15);
            FinalPriceErrorLabel.TabIndex = 35;
            FinalPriceErrorLabel.Text = "Спазвайте формата на цената";
            // 
            // AdvancePriceErrorLabel
            // 
            AdvancePriceErrorLabel.AutoSize = true;
            AdvancePriceErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            AdvancePriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            AdvancePriceErrorLabel.Location = new Point(17, 248);
            AdvancePriceErrorLabel.Name = "AdvancePriceErrorLabel";
            AdvancePriceErrorLabel.Size = new Size(171, 15);
            AdvancePriceErrorLabel.TabIndex = 36;
            AdvancePriceErrorLabel.Text = "Спазвайте формата на цената";
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(17, 446);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(316, 27);
            PathTextBox.TabIndex = 42;
            // 
            // openFilesButton
            // 
            openFilesButton.Location = new Point(215, 409);
            openFilesButton.Name = "openFilesButton";
            openFilesButton.Size = new Size(118, 29);
            openFilesButton.TabIndex = 41;
            openFilesButton.Text = "отвори";
            openFilesButton.UseVisualStyleBackColor = true;
            openFilesButton.Click += openFilesButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(17, 409);
            label1.Name = "label1";
            label1.Size = new Size(197, 25);
            label1.TabIndex = 40;
            label1.Text = "Път към поръчката";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(17, 321);
            label2.Name = "label2";
            label2.Size = new Size(185, 25);
            label2.TabIndex = 44;
            label2.Text = "Създал поръчката";
            // 
            // RequestCreatorComboBox
            // 
            RequestCreatorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RequestCreatorComboBox.FormattingEnabled = true;
            RequestCreatorComboBox.Location = new Point(17, 362);
            RequestCreatorComboBox.Name = "RequestCreatorComboBox";
            RequestCreatorComboBox.Size = new Size(253, 28);
            RequestCreatorComboBox.TabIndex = 43;
            // 
            // EditRequestForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(878, 760);
            Controls.Add(label2);
            Controls.Add(RequestCreatorComboBox);
            Controls.Add(PathTextBox);
            Controls.Add(openFilesButton);
            Controls.Add(label1);
            Controls.Add(AdvancePriceErrorLabel);
            Controls.Add(FinalPriceErrorLabel);
            Controls.Add(NameOfRequestErrorLabel);
            Controls.Add(NotAvailableClientsFlowPanel);
            Controls.Add(AvailableClientsFlowPanel);
            Controls.Add(AddRequestButton);
            Controls.Add(AddNonExistingClientButton);
            Controls.Add(AddNonExistingClientLabel);
            Controls.Add(AddClientComboBoxButton);
            Controls.Add(AddExistingClientToRequestLabel);
            Controls.Add(CommentsRichTextBox);
            Controls.Add(NewClientsFlowPanel);
            Controls.Add(AdvanceTextBox);
            Controls.Add(AdvanceLabel);
            Controls.Add(PriceOfRequestTextBox);
            Controls.Add(PriceOfRequestLabel);
            Controls.Add(NameOfRequestTextBox);
            Controls.Add(NameOfRequestTiltleLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(896, 807);
            MinimumSize = new Size(896, 807);
            Name = "EditRequestForm";
            Text = "Wolf: Редактиране на поръчка";
            Load += AddRequestForm_Load;
            ((System.ComponentModel.ISupportInitialize)RequestErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button AddRequestButton;
        protected Button AddNonExistingClientButton;
        protected Label AddNonExistingClientLabel;
        protected Button AddClientComboBoxButton;
        protected Label AddExistingClientToRequestLabel;
        protected RichTextBox CommentsRichTextBox;
        protected Label NewClientsFlowPanel;
        protected TextBox AdvanceTextBox;
        protected Label AdvanceLabel;
        protected TextBox PriceOfRequestTextBox;
        protected Label PriceOfRequestLabel;
        protected TextBox NameOfRequestTextBox;
        protected Label NameOfRequestTiltleLabel;
        protected Panel NewClientsPanel;
        protected FlowLayoutPanel AvailableClientsFlowPanel;
        protected Panel panel1;
        protected FlowLayoutPanel NotAvailableClientsFlowPanel;
        protected ErrorProvider RequestErrorProvider;
        protected Label NameOfRequestErrorLabel;
        protected Label AdvancePriceErrorLabel;
        protected Label FinalPriceErrorLabel;
        protected TextBox PathTextBox;
        protected Button openFilesButton;
        protected Label label1;
        protected Label label2;
        protected ComboBox RequestCreatorComboBox;
        private System.ComponentModel.IContainer components;
    }
}