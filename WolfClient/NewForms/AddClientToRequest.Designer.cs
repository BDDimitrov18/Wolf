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
            AddClientToRequestSubmitButton = new Button();
            AddNonExistingClientButton = new Button();
            AddNonExistingClientLabel = new Label();
            AddClientComboBoxButton = new Button();
            ChooseClientToAddComboBox = new ComboBox();
            AddExistingClientToRequestLabel = new Label();
            AddClientToRequestTitleLabel = new Label();
            SuspendLayout();
            // 
            // AddClientToRequestSubmitButton
            // 
            AddClientToRequestSubmitButton.Location = new Point(320, 811);
            AddClientToRequestSubmitButton.Margin = new Padding(3, 4, 3, 4);
            AddClientToRequestSubmitButton.Name = "AddClientToRequestSubmitButton";
            AddClientToRequestSubmitButton.Size = new Size(132, 45);
            AddClientToRequestSubmitButton.TabIndex = 26;
            AddClientToRequestSubmitButton.Text = "Запази";
            AddClientToRequestSubmitButton.UseVisualStyleBackColor = true;
            // 
            // AddNonExistingClientButton
            // 
            AddNonExistingClientButton.Location = new Point(525, 501);
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
            AddNonExistingClientLabel.Location = new Point(107, 498);
            AddNonExistingClientLabel.Name = "AddNonExistingClientLabel";
            AddNonExistingClientLabel.Size = new Size(412, 25);
            AddNonExistingClientLabel.TabIndex = 24;
            AddNonExistingClientLabel.Text = "Добави нов клиент и го заложи в заявката";
            // 
            // AddClientComboBoxButton
            // 
            AddClientComboBoxButton.Location = new Point(422, 101);
            AddClientComboBoxButton.Margin = new Padding(3, 4, 3, 4);
            AddClientComboBoxButton.Name = "AddClientComboBoxButton";
            AddClientComboBoxButton.Size = new Size(131, 29);
            AddClientComboBoxButton.TabIndex = 23;
            AddClientComboBoxButton.Text = "Добави Поле";
            AddClientComboBoxButton.UseVisualStyleBackColor = true;
            // 
            // ChooseClientToAddComboBox
            // 
            ChooseClientToAddComboBox.FormattingEnabled = true;
            ChooseClientToAddComboBox.Location = new Point(112, 147);
            ChooseClientToAddComboBox.Margin = new Padding(3, 4, 3, 4);
            ChooseClientToAddComboBox.Name = "ChooseClientToAddComboBox";
            ChooseClientToAddComboBox.Size = new Size(294, 28);
            ChooseClientToAddComboBox.TabIndex = 22;
            // 
            // AddExistingClientToRequestLabel
            // 
            AddExistingClientToRequestLabel.AutoSize = true;
            AddExistingClientToRequestLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddExistingClientToRequestLabel.Location = new Point(107, 98);
            AddExistingClientToRequestLabel.Name = "AddExistingClientToRequestLabel";
            AddExistingClientToRequestLabel.Size = new Size(299, 25);
            AddExistingClientToRequestLabel.TabIndex = 21;
            AddExistingClientToRequestLabel.Text = "Заложи Клиент От Наличните";
            // 
            // AddClientToRequestTitleLabel
            // 
            AddClientToRequestTitleLabel.AutoSize = true;
            AddClientToRequestTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            AddClientToRequestTitleLabel.Location = new Point(105, 19);
            AddClientToRequestTitleLabel.Name = "AddClientToRequestTitleLabel";
            AddClientToRequestTitleLabel.Size = new Size(604, 42);
            AddClientToRequestTitleLabel.TabIndex = 20;
            AddClientToRequestTitleLabel.Text = "Добавяне На Клиент Към Заявка";
            // 
            // AddClientToRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 876);
            Controls.Add(AddClientToRequestSubmitButton);
            Controls.Add(AddNonExistingClientButton);
            Controls.Add(AddNonExistingClientLabel);
            Controls.Add(AddClientComboBoxButton);
            Controls.Add(ChooseClientToAddComboBox);
            Controls.Add(AddExistingClientToRequestLabel);
            Controls.Add(AddClientToRequestTitleLabel);
            Name = "AddClientToRequest";
            Text = "AddClientToRequest";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddClientToRequestSubmitButton;
        private Button AddNonExistingClientButton;
        private Label AddNonExistingClientLabel;
        private Button AddClientComboBoxButton;
        private ComboBox ChooseClientToAddComboBox;
        private Label AddExistingClientToRequestLabel;
        private Label AddClientToRequestTitleLabel;
    }
}