namespace WolfClient.UserControls
{
    partial class AddClientFromNotAvalable
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
            label1 = new Label();
            DeleteUserControlButton = new Button();
            DisplayNameLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 4);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // DeleteUserControlButton
            // 
            DeleteUserControlButton.Location = new Point(316, 0);
            DeleteUserControlButton.Name = "DeleteUserControlButton";
            DeleteUserControlButton.Size = new Size(94, 29);
            DeleteUserControlButton.TabIndex = 1;
            DeleteUserControlButton.Text = "Delete";
            DeleteUserControlButton.UseVisualStyleBackColor = true;
            DeleteUserControlButton.Click += DeleteUserControlButton_Click;
            // 
            // DisplayNameLabel
            // 
            DisplayNameLabel.AutoSize = true;
            DisplayNameLabel.Location = new Point(7, 4);
            DisplayNameLabel.Name = "DisplayNameLabel";
            DisplayNameLabel.Size = new Size(92, 20);
            DisplayNameLabel.TabIndex = 2;
            DisplayNameLabel.Text = "RandomText";
            // 
            // AddClientFromNotAvalable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(DisplayNameLabel);
            Controls.Add(DeleteUserControlButton);
            Controls.Add(label1);
            Name = "AddClientFromNotAvalable";
            Size = new Size(410, 28);
            Load += AddClientFromNotAvalable_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button DeleteUserControlButton;
        private Label DisplayNameLabel;
    }
}
