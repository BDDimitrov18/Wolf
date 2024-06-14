namespace Wolf
{
    partial class Form1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RequestToolStripButton = new System.Windows.Forms.ToolStripLabel();
            this.ObjectToolStripButton = new System.Windows.Forms.ToolStripLabel();
            this.ClientsStripButton = new System.Windows.Forms.ToolStripLabel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.EmployeesStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RequestToolStripButton,
            this.ObjectToolStripButton,
            this.ClientsStripButton,
            this.EmployeesStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1358, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RequestToolStripButton
            // 
            this.RequestToolStripButton.Name = "RequestToolStripButton";
            this.RequestToolStripButton.Size = new System.Drawing.Size(57, 22);
            this.RequestToolStripButton.Text = "Заявки";
            this.RequestToolStripButton.Click += new System.EventHandler(this.RequestToolStripButton_Click);
            // 
            // ObjectToolStripButton
            // 
            this.ObjectToolStripButton.Name = "ObjectToolStripButton";
            this.ObjectToolStripButton.Size = new System.Drawing.Size(59, 22);
            this.ObjectToolStripButton.Text = "Обекти";
            this.ObjectToolStripButton.Click += new System.EventHandler(this.ObjectToolStripButton_Click);
            // 
            // ClientsStripButton
            // 
            this.ClientsStripButton.Name = "ClientsStripButton";
            this.ClientsStripButton.Size = new System.Drawing.Size(67, 22);
            this.ClientsStripButton.Text = "Клиенти";
            this.ClientsStripButton.Click += new System.EventHandler(this.ClientsStripButton_Click);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Location = new System.Drawing.Point(0, 28);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1358, 607);
            this.panelContent.TabIndex = 21;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // EmployeesStripLabel
            // 
            this.EmployeesStripLabel.Name = "EmployeesStripLabel";
            this.EmployeesStripLabel.Size = new System.Drawing.Size(84, 22);
            this.EmployeesStripLabel.Text = "Служители";
            this.EmployeesStripLabel.Click += new System.EventHandler(this.EmployeesStripLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1358, 635);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel RequestToolStripButton;
        private System.Windows.Forms.ToolStripLabel ObjectToolStripButton;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ToolStripLabel ClientsStripButton;
        private System.Windows.Forms.ToolStripLabel EmployeesStripLabel;
    }
}

