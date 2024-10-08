﻿namespace WolfClient.NewForms
{
    partial class AddClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClientForm));
            LegalTypeTextBox = new ComboBox();
            label8 = new Label();
            AddressTextBox = new TextBox();
            label7 = new Label();
            EmailTextBox = new TextBox();
            label6 = new Label();
            PhoneTextBox = new TextBox();
            label5 = new Label();
            LastNameTextBox = new TextBox();
            label4 = new Label();
            SecondNameTextBox = new TextBox();
            label3 = new Label();
            NameTextBox = new TextBox();
            label2 = new Label();
            AddClientButton = new Button();
            UsernameErrorProvider = new ErrorProvider(components);
            NameErrorLabel = new Label();
            PhoneErrorLabel = new Label();
            EmailErrorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)UsernameErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // LegalTypeTextBox
            // 
            LegalTypeTextBox.FormattingEnabled = true;
            LegalTypeTextBox.Items.AddRange(new object[] { "Физическо лице", "Юридическо лице", "Държавата", "Общината" });
            LegalTypeTextBox.Location = new Point(285, 274);
            LegalTypeTextBox.Margin = new Padding(3, 4, 3, 4);
            LegalTypeTextBox.Name = "LegalTypeTextBox";
            LegalTypeTextBox.Size = new Size(232, 28);
            LegalTypeTextBox.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(285, 226);
            label8.Name = "label8";
            label8.Size = new Size(61, 25);
            label8.TabIndex = 28;
            label8.Text = "Лице";
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(285, 163);
            AddressTextBox.Margin = new Padding(3, 4, 3, 4);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(232, 27);
            AddressTextBox.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(280, 114);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 26;
            label7.Text = "Address";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(285, 58);
            EmailTextBox.Margin = new Padding(3, 4, 3, 4);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(232, 27);
            EmailTextBox.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(280, 9);
            label6.Name = "label6";
            label6.Size = new Size(60, 25);
            label6.TabIndex = 24;
            label6.Text = "Email";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(17, 389);
            PhoneTextBox.Margin = new Padding(3, 4, 3, 4);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(232, 27);
            PhoneTextBox.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 340);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 22;
            label5.Text = "Телефон";
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(17, 275);
            LastNameTextBox.Margin = new Padding(3, 4, 3, 4);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(232, 27);
            LastNameTextBox.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 226);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 20;
            label4.Text = "Фамилия";
            // 
            // SecondNameTextBox
            // 
            SecondNameTextBox.Location = new Point(17, 163);
            SecondNameTextBox.Margin = new Padding(3, 4, 3, 4);
            SecondNameTextBox.Name = "SecondNameTextBox";
            SecondNameTextBox.Size = new Size(232, 27);
            SecondNameTextBox.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 114);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 18;
            label3.Text = "Презиме";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(17, 57);
            NameTextBox.Margin = new Padding(3, 4, 3, 4);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(232, 27);
            NameTextBox.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 16;
            label2.Text = "Име";
            // 
            // AddClientButton
            // 
            AddClientButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddClientButton.Location = new Point(352, 379);
            AddClientButton.Margin = new Padding(3, 4, 3, 4);
            AddClientButton.Name = "AddClientButton";
            AddClientButton.Size = new Size(125, 42);
            AddClientButton.TabIndex = 30;
            AddClientButton.Text = "Запази";
            AddClientButton.UseVisualStyleBackColor = true;
            AddClientButton.Click += AddClientButton_Click;
            // 
            // UsernameErrorProvider
            // 
            UsernameErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            UsernameErrorProvider.ContainerControl = this;
            // 
            // NameErrorLabel
            // 
            NameErrorLabel.AutoSize = true;
            NameErrorLabel.BackColor = Color.Transparent;
            NameErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            NameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            NameErrorLabel.Location = new Point(17, 38);
            NameErrorLabel.Name = "NameErrorLabel";
            NameErrorLabel.Size = new Size(158, 15);
            NameErrorLabel.TabIndex = 31;
            NameErrorLabel.Text = "Задължително въвдете име";
            // 
            // PhoneErrorLabel
            // 
            PhoneErrorLabel.AutoSize = true;
            PhoneErrorLabel.BackColor = Color.Transparent;
            PhoneErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            PhoneErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            PhoneErrorLabel.Location = new Point(17, 370);
            PhoneErrorLabel.Name = "PhoneErrorLabel";
            PhoneErrorLabel.Size = new Size(187, 15);
            PhoneErrorLabel.TabIndex = 32;
            PhoneErrorLabel.Text = "Спазвайте формата на телефона";
            // 
            // EmailErrorLabel
            // 
            EmailErrorLabel.AutoSize = true;
            EmailErrorLabel.BackColor = Color.Transparent;
            EmailErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            EmailErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            EmailErrorLabel.Location = new Point(285, 39);
            EmailErrorLabel.Name = "EmailErrorLabel";
            EmailErrorLabel.Size = new Size(163, 15);
            EmailErrorLabel.TabIndex = 33;
            EmailErrorLabel.Text = "Спазвайте формата на Email";
            // 
            // AddClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(549, 442);
            Controls.Add(EmailErrorLabel);
            Controls.Add(PhoneErrorLabel);
            Controls.Add(NameErrorLabel);
            Controls.Add(AddClientButton);
            Controls.Add(LegalTypeTextBox);
            Controls.Add(label8);
            Controls.Add(AddressTextBox);
            Controls.Add(label7);
            Controls.Add(EmailTextBox);
            Controls.Add(label6);
            Controls.Add(PhoneTextBox);
            Controls.Add(label5);
            Controls.Add(LastNameTextBox);
            Controls.Add(label4);
            Controls.Add(SecondNameTextBox);
            Controls.Add(label3);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddClientForm";
            Text = "Wolf: Добавяне на клиент";
            Load += AddClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)UsernameErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox LegalTypeTextBox;
        private Label label8;
        private TextBox AddressTextBox;
        private Label label7;
        private TextBox EmailTextBox;
        private Label label6;
        private TextBox PhoneTextBox;
        private Label label5;
        private TextBox LastNameTextBox;
        private Label label4;
        private TextBox SecondNameTextBox;
        private Label label3;
        private TextBox NameTextBox;
        private Label label2;
        private Button AddClientButton;
        private ErrorProvider UsernameErrorProvider;
        private Label NameErrorLabel;
        private Label EmailErrorLabel;
        private Label PhoneErrorLabel;
    }
}