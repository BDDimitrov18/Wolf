namespace WolfClient.NewForms
{
    partial class AddRequestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
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
            AddRequestTitleLabel = new Label();
            AvailableClientsFlowPanel = new FlowLayoutPanel();
            NotAvailableClientsFlowPanel = new FlowLayoutPanel();
            RequestErrorProvider = new ErrorProvider(components);
            NameOfRequestErrorLabel = new Label();
            FinalPriceErrorLabel = new Label();
            AdvancePriceErrorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)RequestErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // AddRequestButton
            // 
            AddRequestButton.Location = new Point(861, 754);
            AddRequestButton.Margin = new Padding(3, 4, 3, 4);
            AddRequestButton.Name = "AddRequestButton";
            AddRequestButton.Size = new Size(174, 46);
            AddRequestButton.TabIndex = 29;
            AddRequestButton.Text = "Добави Обект";
            AddRequestButton.UseVisualStyleBackColor = true;
            AddRequestButton.Click += AddRequestButton_Click;
            // 
            // AddNonExistingClientButton
            // 
            AddNonExistingClientButton.Location = new Point(652, 534);
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
            AddNonExistingClientLabel.Location = new Point(415, 534);
            AddNonExistingClientLabel.Name = "AddNonExistingClientLabel";
            AddNonExistingClientLabel.Size = new Size(231, 25);
            AddNonExistingClientLabel.TabIndex = 27;
            AddNonExistingClientLabel.Text = "Добави нов заложител";
            // 
            // AddClientComboBoxButton
            // 
            AddClientComboBoxButton.Location = new Point(745, 136);
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
            AddExistingClientToRequestLabel.Location = new Point(415, 134);
            AddExistingClientToRequestLabel.Name = "AddExistingClientToRequestLabel";
            AddExistingClientToRequestLabel.Size = new Size(331, 25);
            AddExistingClientToRequestLabel.TabIndex = 24;
            AddExistingClientToRequestLabel.Text = "Избери заложител от наличните ";
            // 
            // CommentsRichTextBox
            // 
            CommentsRichTextBox.Location = new Point(45, 584);
            CommentsRichTextBox.Margin = new Padding(3, 4, 3, 4);
            CommentsRichTextBox.Name = "CommentsRichTextBox";
            CommentsRichTextBox.Size = new Size(316, 216);
            CommentsRichTextBox.TabIndex = 23;
            CommentsRichTextBox.Text = "";
            // 
            // NewClientsFlowPanel
            // 
            NewClientsFlowPanel.AutoSize = true;
            NewClientsFlowPanel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NewClientsFlowPanel.Location = new Point(40, 534);
            NewClientsFlowPanel.Name = "NewClientsFlowPanel";
            NewClientsFlowPanel.Size = new Size(107, 25);
            NewClientsFlowPanel.TabIndex = 22;
            NewClientsFlowPanel.Text = "Коментар";
            // 
            // AdvanceTextBox
            // 
            AdvanceTextBox.Location = new Point(45, 445);
            AdvanceTextBox.Margin = new Padding(3, 4, 3, 4);
            AdvanceTextBox.Name = "AdvanceTextBox";
            AdvanceTextBox.Size = new Size(253, 27);
            AdvanceTextBox.TabIndex = 21;
            // 
            // AdvanceLabel
            // 
            AdvanceLabel.AutoSize = true;
            AdvanceLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AdvanceLabel.Location = new Point(40, 386);
            AdvanceLabel.Name = "AdvanceLabel";
            AdvanceLabel.Size = new Size(164, 25);
            AdvanceLabel.TabIndex = 20;
            AdvanceLabel.Text = "Преведена сума";
            // 
            // PriceOfRequestTextBox
            // 
            PriceOfRequestTextBox.Location = new Point(45, 316);
            PriceOfRequestTextBox.Margin = new Padding(3, 4, 3, 4);
            PriceOfRequestTextBox.Name = "PriceOfRequestTextBox";
            PriceOfRequestTextBox.Size = new Size(253, 27);
            PriceOfRequestTextBox.TabIndex = 19;
            // 
            // PriceOfRequestLabel
            // 
            PriceOfRequestLabel.AutoSize = true;
            PriceOfRequestLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PriceOfRequestLabel.Location = new Point(40, 257);
            PriceOfRequestLabel.Name = "PriceOfRequestLabel";
            PriceOfRequestLabel.Size = new Size(321, 25);
            PriceOfRequestLabel.TabIndex = 18;
            PriceOfRequestLabel.Text = "Цяла сума за Финални Продукти";
            // 
            // NameOfRequestTextBox
            // 
            NameOfRequestTextBox.Location = new Point(45, 185);
            NameOfRequestTextBox.Margin = new Padding(3, 4, 3, 4);
            NameOfRequestTextBox.Name = "NameOfRequestTextBox";
            NameOfRequestTextBox.Size = new Size(253, 27);
            NameOfRequestTextBox.TabIndex = 17;
            // 
            // NameOfRequestTiltleLabel
            // 
            NameOfRequestTiltleLabel.AutoSize = true;
            NameOfRequestTiltleLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameOfRequestTiltleLabel.Location = new Point(40, 134);
            NameOfRequestTiltleLabel.Name = "NameOfRequestTiltleLabel";
            NameOfRequestTiltleLabel.Size = new Size(185, 25);
            NameOfRequestTiltleLabel.TabIndex = 16;
            NameOfRequestTiltleLabel.Text = "Име На поръчката";
            // 
            // AddRequestTitleLabel
            // 
            AddRequestTitleLabel.AutoSize = true;
            AddRequestTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            AddRequestTitleLabel.Location = new Point(319, 35);
            AddRequestTitleLabel.Name = "AddRequestTitleLabel";
            AddRequestTitleLabel.Size = new Size(406, 42);
            AddRequestTitleLabel.TabIndex = 15;
            AddRequestTitleLabel.Text = "Добавяне На поръчка";
            AddRequestTitleLabel.Click += AddRequestTitleLabel_Click;
            // 
            // AvailableClientsFlowPanel
            // 
            AvailableClientsFlowPanel.AutoScroll = true;
            AvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            AvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            AvailableClientsFlowPanel.Location = new Point(415, 172);
            AvailableClientsFlowPanel.Name = "AvailableClientsFlowPanel";
            AvailableClientsFlowPanel.Size = new Size(461, 283);
            AvailableClientsFlowPanel.TabIndex = 32;
            // 
            // NotAvailableClientsFlowPanel
            // 
            NotAvailableClientsFlowPanel.AutoScroll = true;
            NotAvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            NotAvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            NotAvailableClientsFlowPanel.Location = new Point(415, 584);
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
            NameOfRequestErrorLabel.Location = new Point(45, 166);
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
            FinalPriceErrorLabel.Location = new Point(45, 297);
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
            AdvancePriceErrorLabel.Location = new Point(45, 426);
            AdvancePriceErrorLabel.Name = "AdvancePriceErrorLabel";
            AdvancePriceErrorLabel.Size = new Size(171, 15);
            AdvancePriceErrorLabel.TabIndex = 36;
            AdvancePriceErrorLabel.Text = "Спазвайте формата на цената";
            // 
            // AddRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1047, 836);
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
            Controls.Add(AddRequestTitleLabel);
            MaximumSize = new Size(1065, 883);
            MinimumSize = new Size(1065, 883);
            Name = "AddRequestForm";
            Text = "AddRequestForm";
            Load += AddRequestForm_Load;
            ((System.ComponentModel.ISupportInitialize)RequestErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddRequestButton;
        private Button AddNonExistingClientButton;
        private Label AddNonExistingClientLabel;
        private Button AddClientComboBoxButton;
        private Label AddExistingClientToRequestLabel;
        private RichTextBox CommentsRichTextBox;
        private Label NewClientsFlowPanel;
        private TextBox AdvanceTextBox;
        private Label AdvanceLabel;
        private TextBox PriceOfRequestTextBox;
        private Label PriceOfRequestLabel;
        private TextBox NameOfRequestTextBox;
        private Label NameOfRequestTiltleLabel;
        private Label AddRequestTitleLabel;
        private Panel NewClientsPanel;
        private FlowLayoutPanel AvailableClientsFlowPanel;
        private Panel panel1;
        private FlowLayoutPanel NotAvailableClientsFlowPanel;
        private ErrorProvider RequestErrorProvider;
        private Label NameOfRequestErrorLabel;
        private Label AdvancePriceErrorLabel;
        private Label FinalPriceErrorLabel;
    }
}