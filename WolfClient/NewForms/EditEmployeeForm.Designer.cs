namespace WolfClient.NewForms
{
    partial class EditEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeForm));
            AddEmployeeSubmitButton = new Button();
            EmailTextBox = new TextBox();
            EmailLabel = new Label();
            PhoneTextBox = new TextBox();
            PhoneLabel = new Label();
            LastNameTextBox = new TextBox();
            LastNameLabel = new Label();
            SecondNameTextBox = new TextBox();
            SecondNameLabel = new Label();
            NameTextBox = new TextBox();
            NameLabel = new Label();
            EmployeeFormErrorProvider = new ErrorProvider(components);
            NameErrorLabel = new Label();
            SurnameErrorLabel = new Label();
            LastNameErrorLabel = new Label();
            PhoneErrorLabel = new Label();
            EmailErrorLabel = new Label();
            outsiderCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)EmployeeFormErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // AddEmployeeSubmitButton
            // 
            AddEmployeeSubmitButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddEmployeeSubmitButton.Location = new Point(100, 516);
            AddEmployeeSubmitButton.Margin = new Padding(3, 4, 3, 4);
            AddEmployeeSubmitButton.Name = "AddEmployeeSubmitButton";
            AddEmployeeSubmitButton.Size = new Size(125, 42);
            AddEmployeeSubmitButton.TabIndex = 23;
            AddEmployeeSubmitButton.Text = "Запази";
            AddEmployeeSubmitButton.UseVisualStyleBackColor = true;
            AddEmployeeSubmitButton.Click += AddEmployeeSubmitButton_Click;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(17, 433);
            EmailTextBox.Margin = new Padding(3, 4, 3, 4);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(293, 27);
            EmailTextBox.TabIndex = 22;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel.Location = new Point(12, 389);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(60, 25);
            EmailLabel.TabIndex = 21;
            EmailLabel.Text = "Email";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(17, 337);
            PhoneTextBox.Margin = new Padding(3, 4, 3, 4);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(293, 27);
            PhoneTextBox.TabIndex = 20;
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PhoneLabel.Location = new Point(12, 293);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(99, 25);
            PhoneLabel.TabIndex = 19;
            PhoneLabel.Text = "Телефон";
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(17, 243);
            LastNameTextBox.Margin = new Padding(3, 4, 3, 4);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(293, 27);
            LastNameTextBox.TabIndex = 18;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LastNameLabel.Location = new Point(12, 199);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(103, 25);
            LastNameLabel.TabIndex = 17;
            LastNameLabel.Text = "Фамилия";
            LastNameLabel.Click += LastNameLabel_Click;
            // 
            // SecondNameTextBox
            // 
            SecondNameTextBox.Location = new Point(17, 154);
            SecondNameTextBox.Margin = new Padding(3, 4, 3, 4);
            SecondNameTextBox.Name = "SecondNameTextBox";
            SecondNameTextBox.Size = new Size(293, 27);
            SecondNameTextBox.TabIndex = 16;
            // 
            // SecondNameLabel
            // 
            SecondNameLabel.AutoSize = true;
            SecondNameLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SecondNameLabel.Location = new Point(12, 110);
            SecondNameLabel.Name = "SecondNameLabel";
            SecondNameLabel.Size = new Size(98, 25);
            SecondNameLabel.TabIndex = 15;
            SecondNameLabel.Text = "Презиме";
            SecondNameLabel.Click += SecondNameLabel_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(17, 65);
            NameTextBox.Margin = new Padding(3, 4, 3, 4);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(293, 27);
            NameTextBox.TabIndex = 14;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameLabel.Location = new Point(12, 21);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(54, 25);
            NameLabel.TabIndex = 13;
            NameLabel.Text = "Име";
            NameLabel.Click += NameLabel_Click;
            // 
            // EmployeeFormErrorProvider
            // 
            EmployeeFormErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            EmployeeFormErrorProvider.ContainerControl = this;
            // 
            // NameErrorLabel
            // 
            NameErrorLabel.AutoSize = true;
            NameErrorLabel.BackColor = Color.Transparent;
            NameErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            NameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            NameErrorLabel.Location = new Point(17, 46);
            NameErrorLabel.Name = "NameErrorLabel";
            NameErrorLabel.Size = new Size(125, 15);
            NameErrorLabel.TabIndex = 24;
            NameErrorLabel.Text = "Моля попълнете име";
            // 
            // SurnameErrorLabel
            // 
            SurnameErrorLabel.AutoSize = true;
            SurnameErrorLabel.BackColor = Color.Transparent;
            SurnameErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            SurnameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            SurnameErrorLabel.Location = new Point(17, 135);
            SurnameErrorLabel.Name = "SurnameErrorLabel";
            SurnameErrorLabel.Size = new Size(150, 15);
            SurnameErrorLabel.TabIndex = 25;
            SurnameErrorLabel.Text = "Моля попълнете презиме";
            SurnameErrorLabel.Click += label3_Click;
            // 
            // LastNameErrorLabel
            // 
            LastNameErrorLabel.AutoSize = true;
            LastNameErrorLabel.BackColor = Color.Transparent;
            LastNameErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            LastNameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            LastNameErrorLabel.Location = new Point(17, 224);
            LastNameErrorLabel.Name = "LastNameErrorLabel";
            LastNameErrorLabel.Size = new Size(154, 15);
            LastNameErrorLabel.TabIndex = 26;
            LastNameErrorLabel.Text = "Моля попълнете фамилия";
            // 
            // PhoneErrorLabel
            // 
            PhoneErrorLabel.AutoSize = true;
            PhoneErrorLabel.BackColor = Color.Transparent;
            PhoneErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            PhoneErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            PhoneErrorLabel.Location = new Point(17, 318);
            PhoneErrorLabel.Name = "PhoneErrorLabel";
            PhoneErrorLabel.Size = new Size(219, 15);
            PhoneErrorLabel.TabIndex = 27;
            PhoneErrorLabel.Text = "Моля спазвайте формата на телефона";
            // 
            // EmailErrorLabel
            // 
            EmailErrorLabel.AutoSize = true;
            EmailErrorLabel.BackColor = Color.Transparent;
            EmailErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            EmailErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            EmailErrorLabel.Location = new Point(17, 414);
            EmailErrorLabel.Name = "EmailErrorLabel";
            EmailErrorLabel.Size = new Size(208, 15);
            EmailErrorLabel.TabIndex = 28;
            EmailErrorLabel.Text = "Моля спазвайте формата на имейла";
            EmailErrorLabel.Click += label6_Click;
            // 
            // outsiderCheckBox
            // 
            outsiderCheckBox.AutoSize = true;
            outsiderCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            outsiderCheckBox.Location = new Point(17, 477);
            outsiderCheckBox.Name = "outsiderCheckBox";
            outsiderCheckBox.Size = new Size(319, 32);
            outsiderCheckBox.TabIndex = 29;
            outsiderCheckBox.Text = "Външен служител(изпълнител)";
            outsiderCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(340, 563);
            Controls.Add(outsiderCheckBox);
            Controls.Add(EmailErrorLabel);
            Controls.Add(PhoneErrorLabel);
            Controls.Add(LastNameErrorLabel);
            Controls.Add(SurnameErrorLabel);
            Controls.Add(NameErrorLabel);
            Controls.Add(AddEmployeeSubmitButton);
            Controls.Add(EmailTextBox);
            Controls.Add(EmailLabel);
            Controls.Add(PhoneTextBox);
            Controls.Add(PhoneLabel);
            Controls.Add(LastNameTextBox);
            Controls.Add(LastNameLabel);
            Controls.Add(SecondNameTextBox);
            Controls.Add(SecondNameLabel);
            Controls.Add(NameTextBox);
            Controls.Add(NameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddEmployeeForm";
            Text = "Wolf: Добавяне на служител";
            Load += AddEmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)EmployeeFormErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddEmployeeSubmitButton;
        private TextBox EmailTextBox;
        private Label EmailLabel;
        private TextBox PhoneTextBox;
        private Label PhoneLabel;
        private TextBox LastNameTextBox;
        private Label LastNameLabel;
        private TextBox SecondNameTextBox;
        private Label SecondNameLabel;
        private TextBox NameTextBox;
        private Label NameLabel;
        private ErrorProvider EmployeeFormErrorProvider;
        private Label NameErrorLabel;
        private Label SurnameErrorLabel;
        private Label LastNameErrorLabel;
        private Label PhoneErrorLabel;
        private Label EmailErrorLabel;
        private CheckBox outsiderCheckBox;
    }
}