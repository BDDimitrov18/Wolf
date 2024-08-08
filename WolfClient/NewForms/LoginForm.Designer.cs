namespace WolfClient.NewForms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LogInButton = new Button();
            PasswordLabel = new Label();
            PasswordTextBox = new TextBox();
            usernameLabel = new Label();
            userNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // LogInButton
            // 
            LogInButton.Location = new Point(31, 158);
            LogInButton.Margin = new Padding(3, 4, 3, 4);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new Size(176, 39);
            LogInButton.TabIndex = 14;
            LogInButton.Text = "влизане";
            LogInButton.UseVisualStyleBackColor = true;
            LogInButton.Click += LogInButton_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(28, 80);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(62, 20);
            PasswordLabel.TabIndex = 13;
            PasswordLabel.Text = "Парола";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(31, 104);
            PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(176, 27);
            PasswordTextBox.TabIndex = 12;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(28, 9);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(149, 20);
            usernameLabel.TabIndex = 11;
            usernameLabel.Text = "Потребителско Име";
            usernameLabel.Click += usernameLabel_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(31, 33);
            userNameTextBox.Margin = new Padding(3, 4, 3, 4);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(176, 27);
            userNameTextBox.TabIndex = 10;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 207);
            Controls.Add(LogInButton);
            Controls.Add(PasswordLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(userNameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Text = "Wolf: Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LogInButton;
        private Label PasswordLabel;
        private TextBox PasswordTextBox;
        private Label usernameLabel;
        private TextBox userNameTextBox;
    }
}