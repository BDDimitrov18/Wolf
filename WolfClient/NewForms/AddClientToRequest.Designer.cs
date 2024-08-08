namespace WolfClient.NewForms
{
    partial class AddClientToRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClientToRequest));
            AddClientToRequestSubmitButton = new Button();
            AddNonExistingClientButton = new Button();
            AddNonExistingClientLabel = new Label();
            AddClientComboBoxButton = new Button();
            AddExistingClientToRequestLabel = new Label();
            AvailableClientsFlowPanel = new FlowLayoutPanel();
            NotAvailableClientsFlowPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // AddClientToRequestSubmitButton
            // 
            AddClientToRequestSubmitButton.Location = new Point(225, 722);
            AddClientToRequestSubmitButton.Margin = new Padding(3, 4, 3, 4);
            AddClientToRequestSubmitButton.Name = "AddClientToRequestSubmitButton";
            AddClientToRequestSubmitButton.Size = new Size(132, 45);
            AddClientToRequestSubmitButton.TabIndex = 26;
            AddClientToRequestSubmitButton.Text = "Запази";
            AddClientToRequestSubmitButton.UseVisualStyleBackColor = true;
            AddClientToRequestSubmitButton.Click += AddClientToRequestSubmitButton_Click;
            // 
            // AddNonExistingClientButton
            // 
            AddNonExistingClientButton.Location = new Point(444, 409);
            AddNonExistingClientButton.Margin = new Padding(3, 4, 3, 4);
            AddNonExistingClientButton.Name = "AddNonExistingClientButton";
            AddNonExistingClientButton.Size = new Size(134, 29);
            AddNonExistingClientButton.TabIndex = 25;
            AddNonExistingClientButton.Text = "Добави Клиент";
            AddNonExistingClientButton.UseVisualStyleBackColor = true;
            AddNonExistingClientButton.Click += AddNonExistingClientButton_Click;
            // 
            // AddNonExistingClientLabel
            // 
            AddNonExistingClientLabel.AutoSize = true;
            AddNonExistingClientLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddNonExistingClientLabel.Location = new Point(12, 409);
            AddNonExistingClientLabel.Name = "AddNonExistingClientLabel";
            AddNonExistingClientLabel.Size = new Size(426, 25);
            AddNonExistingClientLabel.TabIndex = 24;
            AddNonExistingClientLabel.Text = "Добави нов клиент и го заложи в поръчката";
            // 
            // AddClientComboBoxButton
            // 
            AddClientComboBoxButton.Location = new Point(317, 9);
            AddClientComboBoxButton.Margin = new Padding(3, 4, 3, 4);
            AddClientComboBoxButton.Name = "AddClientComboBoxButton";
            AddClientComboBoxButton.Size = new Size(131, 29);
            AddClientComboBoxButton.TabIndex = 23;
            AddClientComboBoxButton.Text = "Добави Поле";
            AddClientComboBoxButton.UseVisualStyleBackColor = true;
            AddClientComboBoxButton.Click += AddClientComboBoxButton_Click;
            // 
            // AddExistingClientToRequestLabel
            // 
            AddExistingClientToRequestLabel.AutoSize = true;
            AddExistingClientToRequestLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddExistingClientToRequestLabel.Location = new Point(12, 9);
            AddExistingClientToRequestLabel.Name = "AddExistingClientToRequestLabel";
            AddExistingClientToRequestLabel.Size = new Size(299, 25);
            AddExistingClientToRequestLabel.TabIndex = 21;
            AddExistingClientToRequestLabel.Text = "Заложи Клиент От Наличните";
            // 
            // AvailableClientsFlowPanel
            // 
            AvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            AvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            AvailableClientsFlowPanel.Location = new Point(12, 58);
            AvailableClientsFlowPanel.Name = "AvailableClientsFlowPanel";
            AvailableClientsFlowPanel.Size = new Size(461, 326);
            AvailableClientsFlowPanel.TabIndex = 27;
            AvailableClientsFlowPanel.Paint += flowLayoutPanel1_Paint;
            // 
            // NotAvailableClientsFlowPanel
            // 
            NotAvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            NotAvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            NotAvailableClientsFlowPanel.Location = new Point(12, 473);
            NotAvailableClientsFlowPanel.Name = "NotAvailableClientsFlowPanel";
            NotAvailableClientsFlowPanel.Size = new Size(410, 216);
            NotAvailableClientsFlowPanel.TabIndex = 28;
            // 
            // AddClientToRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(592, 781);
            Controls.Add(NotAvailableClientsFlowPanel);
            Controls.Add(AvailableClientsFlowPanel);
            Controls.Add(AddClientToRequestSubmitButton);
            Controls.Add(AddNonExistingClientButton);
            Controls.Add(AddNonExistingClientLabel);
            Controls.Add(AddClientComboBoxButton);
            Controls.Add(AddExistingClientToRequestLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddClientToRequest";
            Text = "Wolf: Добавяне на клиент към поръчка";
            Load += AddClientToRequest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddClientToRequestSubmitButton;
        private Button AddNonExistingClientButton;
        private Label AddNonExistingClientLabel;
        private Button AddClientComboBoxButton;
        private Label AddExistingClientToRequestLabel;
        private FlowLayoutPanel AvailableClientsFlowPanel;
        private FlowLayoutPanel NotAvailableClientsFlowPanel;
    }
}