namespace WolfClient.UserControls
{
    partial class AddOwnerFromAvailable
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
            ClientsListComboBox = new ComboBox();
            DeleteUserControlButton = new Button();
            SuspendLayout();
            // 
            // ClientsListComboBox
            // 
            ClientsListComboBox.FormattingEnabled = true;
            ClientsListComboBox.Location = new Point(0, 0);
            ClientsListComboBox.Name = "ClientsListComboBox";
            ClientsListComboBox.Size = new Size(270, 28);
            ClientsListComboBox.TabIndex = 0;
            ClientsListComboBox.SelectedIndexChanged += ClientsListComboBox_SelectedIndexChanged;
            // 
            // DeleteUserControlButton
            // 
            DeleteUserControlButton.Location = new Point(300, -1);
            DeleteUserControlButton.Name = "DeleteUserControlButton";
            DeleteUserControlButton.Size = new Size(109, 29);
            DeleteUserControlButton.TabIndex = 1;
            DeleteUserControlButton.Text = "Delete";
            DeleteUserControlButton.UseVisualStyleBackColor = true;
            DeleteUserControlButton.Click += DeleteUserControlButton_Click;
            // 
            // AddClientFromAvailable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(DeleteUserControlButton);
            Controls.Add(ClientsListComboBox);
            Name = "AddClientFromAvailable";
            Size = new Size(412, 28);
            Load += AddClientFromAvailable_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox ClientsListComboBox;
        private Button DeleteUserControlButton;
    }
}
