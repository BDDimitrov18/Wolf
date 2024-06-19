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
            button3 = new Button();
            AddNonExistingClientButton = new Button();
            AddNonExistingClientLabel = new Label();
            AddClientComboBoxButton = new Button();
            AddExistingClientToRequestLabel = new Label();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            AdvanceTextBox = new TextBox();
            AdvanceLabel = new Label();
            PriceOfRequestTextBox = new TextBox();
            PriceOfRequestLabel = new Label();
            NameOfRequestTextBox = new TextBox();
            NameOfRequestTiltleLabel = new Label();
            AddRequestTitleLabel = new Label();
            panel3 = new Panel();
            AvailableClientsFlowPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            AvailableClientsFlowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(833, 755);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(174, 46);
            button3.TabIndex = 29;
            button3.Text = "Добави Заявка";
            button3.UseVisualStyleBackColor = true;
            // 
            // AddNonExistingClientButton
            // 
            AddNonExistingClientButton.Location = new Point(833, 536);
            AddNonExistingClientButton.Margin = new Padding(3, 4, 3, 4);
            AddNonExistingClientButton.Name = "AddNonExistingClientButton";
            AddNonExistingClientButton.Size = new Size(134, 29);
            AddNonExistingClientButton.TabIndex = 28;
            AddNonExistingClientButton.Text = "Добави Клиент";
            AddNonExistingClientButton.UseVisualStyleBackColor = true;
            AddNonExistingClientButton.Click += AddNonExistingClientButton_Click;
            // 
            // AddNonExistingClientLabel
            // 
            AddNonExistingClientLabel.AutoSize = true;
            AddNonExistingClientLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddNonExistingClientLabel.Location = new Point(415, 534);
            AddNonExistingClientLabel.Name = "AddNonExistingClientLabel";
            AddNonExistingClientLabel.Size = new Size(412, 25);
            AddNonExistingClientLabel.TabIndex = 27;
            AddNonExistingClientLabel.Text = "Добави нов клиент и го заложи в заявката";
            // 
            // AddClientComboBoxButton
            // 
            AddClientComboBoxButton.Location = new Point(730, 136);
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
            AddExistingClientToRequestLabel.Size = new Size(299, 25);
            AddExistingClientToRequestLabel.TabIndex = 24;
            AddExistingClientToRequestLabel.Text = "Заложи Клиент От Наличните";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(45, 584);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(316, 216);
            richTextBox1.TabIndex = 23;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(40, 534);
            label5.Name = "label5";
            label5.Size = new Size(107, 25);
            label5.TabIndex = 22;
            label5.Text = "Коментар";
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
            NameOfRequestTiltleLabel.Size = new Size(173, 25);
            NameOfRequestTiltleLabel.TabIndex = 16;
            NameOfRequestTiltleLabel.Text = "Име На Заявката";
            // 
            // AddRequestTitleLabel
            // 
            AddRequestTitleLabel.AutoSize = true;
            AddRequestTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            AddRequestTitleLabel.Location = new Point(319, 35);
            AddRequestTitleLabel.Name = "AddRequestTitleLabel";
            AddRequestTitleLabel.Size = new Size(384, 42);
            AddRequestTitleLabel.TabIndex = 15;
            AddRequestTitleLabel.Text = "Добавяне На Заявка";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Location = new Point(415, 584);
            panel3.Name = "panel3";
            panel3.Size = new Size(410, 216);
            panel3.TabIndex = 31;
            // 
            // AvailableClientsFlowPanel
            // 
            AvailableClientsFlowPanel.AutoScroll = true;
            AvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            AvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            AvailableClientsFlowPanel.Controls.Add(panel1);
            AvailableClientsFlowPanel.Location = new Point(415, 172);
            AvailableClientsFlowPanel.Name = "AvailableClientsFlowPanel";
            AvailableClientsFlowPanel.Size = new Size(461, 283);
            AvailableClientsFlowPanel.TabIndex = 32;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(412, 28);
            panel1.TabIndex = 0;
            // 
            // AddRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1047, 836);
            Controls.Add(AvailableClientsFlowPanel);
            Controls.Add(panel3);
            Controls.Add(button3);
            Controls.Add(AddNonExistingClientButton);
            Controls.Add(AddNonExistingClientLabel);
            Controls.Add(AddClientComboBoxButton);
            Controls.Add(AddExistingClientToRequestLabel);
            Controls.Add(richTextBox1);
            Controls.Add(label5);
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
            AvailableClientsFlowPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button AddNonExistingClientButton;
        private Label AddNonExistingClientLabel;
        private Button AddClientComboBoxButton;
        private Label AddExistingClientToRequestLabel;
        private RichTextBox richTextBox1;
        private Label label5;
        private TextBox AdvanceTextBox;
        private Label AdvanceLabel;
        private TextBox PriceOfRequestTextBox;
        private Label PriceOfRequestLabel;
        private TextBox NameOfRequestTextBox;
        private Label NameOfRequestTiltleLabel;
        private Label AddRequestTitleLabel;
        private Panel panel3;
        private FlowLayoutPanel AvailableClientsFlowPanel;
        private Panel panel1;
    }
}