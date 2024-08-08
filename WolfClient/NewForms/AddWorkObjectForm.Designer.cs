namespace WolfClient.NewForms
{
    partial class AddWorkObjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWorkObjectForm));
            AddWorkObjectSubmitFormButton = new Button();
            panel1 = new Panel();
            NameOfWorkObjectLabel = new Label();
            NameOfWorkObjectTextBox = new TextBox();
            PriceOfWorkObjectLabel = new Label();
            PriceOfWorkObjectTextBox = new TextBox();
            AddRequestToWorkObjectComboBox = new ComboBox();
            AddRequestToWorkObjectLabel = new Label();
            AddWorkObjectTitleLabel = new Label();
            NotAvailableClientsFlowPanel = new FlowLayoutPanel();
            AvailableClientsFlowPanel = new FlowLayoutPanel();
            AddNonExistingClientButton = new Button();
            AddNonExistingClientLabel = new Label();
            AddClientComboBoxButton = new Button();
            AddExistingClientToRequestLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // AddWorkObjectSubmitFormButton
            // 
            AddWorkObjectSubmitFormButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddWorkObjectSubmitFormButton.Location = new Point(414, 625);
            AddWorkObjectSubmitFormButton.Margin = new Padding(3, 4, 3, 4);
            AddWorkObjectSubmitFormButton.Name = "AddWorkObjectSubmitFormButton";
            AddWorkObjectSubmitFormButton.Size = new Size(185, 55);
            AddWorkObjectSubmitFormButton.TabIndex = 14;
            AddWorkObjectSubmitFormButton.Text = "Добави Обект";
            AddWorkObjectSubmitFormButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(NameOfWorkObjectLabel);
            panel1.Controls.Add(NameOfWorkObjectTextBox);
            panel1.Controls.Add(PriceOfWorkObjectLabel);
            panel1.Controls.Add(PriceOfWorkObjectTextBox);
            panel1.Location = new Point(30, 273);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(269, 206);
            panel1.TabIndex = 13;
            // 
            // NameOfWorkObjectLabel
            // 
            NameOfWorkObjectLabel.AutoSize = true;
            NameOfWorkObjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameOfWorkObjectLabel.Location = new Point(3, 0);
            NameOfWorkObjectLabel.Name = "NameOfWorkObjectLabel";
            NameOfWorkObjectLabel.Size = new Size(154, 25);
            NameOfWorkObjectLabel.TabIndex = 1;
            NameOfWorkObjectLabel.Text = "Име на Обекта";
            // 
            // NameOfWorkObjectTextBox
            // 
            NameOfWorkObjectTextBox.Location = new Point(8, 46);
            NameOfWorkObjectTextBox.Margin = new Padding(3, 4, 3, 4);
            NameOfWorkObjectTextBox.Name = "NameOfWorkObjectTextBox";
            NameOfWorkObjectTextBox.Size = new Size(226, 27);
            NameOfWorkObjectTextBox.TabIndex = 2;
            // 
            // PriceOfWorkObjectLabel
            // 
            PriceOfWorkObjectLabel.AutoSize = true;
            PriceOfWorkObjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PriceOfWorkObjectLabel.Location = new Point(3, 120);
            PriceOfWorkObjectLabel.Name = "PriceOfWorkObjectLabel";
            PriceOfWorkObjectLabel.Size = new Size(158, 25);
            PriceOfWorkObjectLabel.TabIndex = 3;
            PriceOfWorkObjectLabel.Text = "Цена на Обекта";
            // 
            // PriceOfWorkObjectTextBox
            // 
            PriceOfWorkObjectTextBox.Location = new Point(8, 166);
            PriceOfWorkObjectTextBox.Margin = new Padding(3, 4, 3, 4);
            PriceOfWorkObjectTextBox.Name = "PriceOfWorkObjectTextBox";
            PriceOfWorkObjectTextBox.Size = new Size(226, 27);
            PriceOfWorkObjectTextBox.TabIndex = 4;
            // 
            // AddRequestToWorkObjectComboBox
            // 
            AddRequestToWorkObjectComboBox.FormattingEnabled = true;
            AddRequestToWorkObjectComboBox.Location = new Point(30, 179);
            AddRequestToWorkObjectComboBox.Margin = new Padding(3, 4, 3, 4);
            AddRequestToWorkObjectComboBox.Name = "AddRequestToWorkObjectComboBox";
            AddRequestToWorkObjectComboBox.Size = new Size(236, 28);
            AddRequestToWorkObjectComboBox.TabIndex = 12;
            // 
            // AddRequestToWorkObjectLabel
            // 
            AddRequestToWorkObjectLabel.AutoSize = true;
            AddRequestToWorkObjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddRequestToWorkObjectLabel.Location = new Point(25, 130);
            AddRequestToWorkObjectLabel.Name = "AddRequestToWorkObjectLabel";
            AddRequestToWorkObjectLabel.Size = new Size(360, 25);
            AddRequestToWorkObjectLabel.TabIndex = 11;
            AddRequestToWorkObjectLabel.Text = "Залагане Към коя заявка да е обекта";
            // 
            // AddWorkObjectTitleLabel
            // 
            AddWorkObjectTitleLabel.AutoSize = true;
            AddWorkObjectTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            AddWorkObjectTitleLabel.Location = new Point(335, 30);
            AddWorkObjectTitleLabel.Name = "AddWorkObjectTitleLabel";
            AddWorkObjectTitleLabel.Size = new Size(361, 42);
            AddWorkObjectTitleLabel.TabIndex = 10;
            AddWorkObjectTitleLabel.Text = "Добавяне на Обект";
            // 
            // NotAvailableClientsFlowPanel
            // 
            NotAvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            NotAvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            NotAvailableClientsFlowPanel.Location = new Point(476, 423);
            NotAvailableClientsFlowPanel.Name = "NotAvailableClientsFlowPanel";
            NotAvailableClientsFlowPanel.Size = new Size(410, 138);
            NotAvailableClientsFlowPanel.TabIndex = 35;
            // 
            // AvailableClientsFlowPanel
            // 
            AvailableClientsFlowPanel.BackColor = SystemColors.ActiveCaption;
            AvailableClientsFlowPanel.BorderStyle = BorderStyle.Fixed3D;
            AvailableClientsFlowPanel.Location = new Point(476, 179);
            AvailableClientsFlowPanel.Name = "AvailableClientsFlowPanel";
            AvailableClientsFlowPanel.Size = new Size(461, 169);
            AvailableClientsFlowPanel.TabIndex = 34;
            // 
            // AddNonExistingClientButton
            // 
            AddNonExistingClientButton.Location = new Point(894, 366);
            AddNonExistingClientButton.Margin = new Padding(3, 4, 3, 4);
            AddNonExistingClientButton.Name = "AddNonExistingClientButton";
            AddNonExistingClientButton.Size = new Size(134, 29);
            AddNonExistingClientButton.TabIndex = 32;
            AddNonExistingClientButton.Text = "Добави Клиент";
            AddNonExistingClientButton.UseVisualStyleBackColor = true;
            // 
            // AddNonExistingClientLabel
            // 
            AddNonExistingClientLabel.AutoSize = true;
            AddNonExistingClientLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddNonExistingClientLabel.Location = new Point(476, 366);
            AddNonExistingClientLabel.Name = "AddNonExistingClientLabel";
            AddNonExistingClientLabel.Size = new Size(412, 25);
            AddNonExistingClientLabel.TabIndex = 31;
            AddNonExistingClientLabel.Text = "Добави нов клиент и го заложи в заявката";
            // 
            // AddClientComboBoxButton
            // 
            AddClientComboBoxButton.Location = new Point(791, 133);
            AddClientComboBoxButton.Margin = new Padding(3, 4, 3, 4);
            AddClientComboBoxButton.Name = "AddClientComboBoxButton";
            AddClientComboBoxButton.Size = new Size(131, 29);
            AddClientComboBoxButton.TabIndex = 30;
            AddClientComboBoxButton.Text = "Добави Поле";
            AddClientComboBoxButton.UseVisualStyleBackColor = true;
            // 
            // AddExistingClientToRequestLabel
            // 
            AddExistingClientToRequestLabel.AutoSize = true;
            AddExistingClientToRequestLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddExistingClientToRequestLabel.Location = new Point(476, 130);
            AddExistingClientToRequestLabel.Name = "AddExistingClientToRequestLabel";
            AddExistingClientToRequestLabel.Size = new Size(299, 25);
            AddExistingClientToRequestLabel.TabIndex = 29;
            AddExistingClientToRequestLabel.Text = "Заложи Клиент От Наличните";
            // 
            // AddWorkObjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1055, 687);
            Controls.Add(NotAvailableClientsFlowPanel);
            Controls.Add(AvailableClientsFlowPanel);
            Controls.Add(AddNonExistingClientButton);
            Controls.Add(AddNonExistingClientLabel);
            Controls.Add(AddClientComboBoxButton);
            Controls.Add(AddExistingClientToRequestLabel);
            Controls.Add(AddWorkObjectSubmitFormButton);
            Controls.Add(panel1);
            Controls.Add(AddRequestToWorkObjectComboBox);
            Controls.Add(AddRequestToWorkObjectLabel);
            Controls.Add(AddWorkObjectTitleLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddWorkObjectForm";
            Text = "Wolf: Добавяне на обект";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddWorkObjectSubmitFormButton;
        private Panel panel1;
        private Label NameOfWorkObjectLabel;
        private TextBox NameOfWorkObjectTextBox;
        private Label PriceOfWorkObjectLabel;
        private TextBox PriceOfWorkObjectTextBox;
        private ComboBox AddRequestToWorkObjectComboBox;
        private Label AddRequestToWorkObjectLabel;
        private Label AddWorkObjectTitleLabel;
        private FlowLayoutPanel NotAvailableClientsFlowPanel;
        private FlowLayoutPanel AvailableClientsFlowPanel;
        private Button AddNonExistingClientButton;
        private Label AddNonExistingClientLabel;
        private Button AddClientComboBoxButton;
        private Label AddExistingClientToRequestLabel;
    }
}