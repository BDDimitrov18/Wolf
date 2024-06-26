using WolfClient.NewForms;

namespace WolfClient.NewForms
{
    partial class MainForm
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
            toolStrip1 = new ToolStrip();
            RequestToolStripButton = new ToolStripLabel();
            ClientsStripButton = new ToolStripLabel();
            EmployeesStripLabel = new ToolStripLabel();
            panelContent = new Panel();
            LoginButton = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { RequestToolStripButton, ClientsStripButton, EmployeesStripLabel });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1358, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // RequestToolStripButton
            // 
            RequestToolStripButton.Name = "RequestToolStripButton";
            RequestToolStripButton.Size = new Size(59, 22);
            RequestToolStripButton.Text = "Обекти";
            RequestToolStripButton.Click += RequestToolStripButton_Click;
            // 
            // ClientsStripButton
            // 
            ClientsStripButton.Name = "ClientsStripButton";
            ClientsStripButton.Size = new Size(67, 22);
            ClientsStripButton.Text = "Клиенти";
            ClientsStripButton.Click += ClientsStripButton_Click;
            // 
            // EmployeesStripLabel
            // 
            EmployeesStripLabel.Name = "EmployeesStripLabel";
            EmployeesStripLabel.Size = new Size(84, 22);
            EmployeesStripLabel.Text = "Служители";
            EmployeesStripLabel.Click += EmployeesStripLabel_Click;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.BackColor = Color.White;
            panelContent.Location = new Point(0, 28);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1358, 620);
            panelContent.TabIndex = 21;
            panelContent.Paint += panelContent_Paint;
            // 
            // LoginButton
            // 
            LoginButton.Anchor = AnchorStyles.Bottom;
            LoginButton.Location = new Point(1211, 665);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(135, 29);
            LoginButton.TabIndex = 22;
            LoginButton.Text = "LogIn";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1358, 706);
            Controls.Add(LoginButton);
            Controls.Add(panelContent);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel RequestToolStripButton;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ToolStripLabel ClientsStripButton;
        private System.Windows.Forms.ToolStripLabel EmployeesStripLabel;
        private Button LoginButton;
    }
}

