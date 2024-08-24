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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            RequestToolStripButton = new ToolStripLabel();
            ClientsStripButton = new ToolStripLabel();
            panelContent = new Panel();
            LoginButton = new Button();
            SpravkiButton = new Button();
            UserPanel = new Panel();
            UserLabel = new Label();
            toolStrip1.SuspendLayout();
            UserPanel.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { RequestToolStripButton, ClientsStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1358, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // RequestToolStripButton
            // 
            RequestToolStripButton.Name = "RequestToolStripButton";
            RequestToolStripButton.Size = new Size(71, 22);
            RequestToolStripButton.Text = "Поръчки";
            RequestToolStripButton.Click += RequestToolStripButton_Click;
            // 
            // ClientsStripButton
            // 
            ClientsStripButton.Name = "ClientsStripButton";
            ClientsStripButton.Size = new Size(67, 22);
            ClientsStripButton.Text = "Клиенти";
            ClientsStripButton.Click += ClientsStripButton_Click;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.BackColor = Color.White;
            panelContent.Location = new Point(0, 28);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1358, 678);
            panelContent.TabIndex = 21;
            panelContent.Paint += panelContent_Paint;
            // 
            // LoginButton
            // 
            LoginButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoginButton.Location = new Point(1215, 35);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(135, 29);
            LoginButton.TabIndex = 22;
            LoginButton.Text = "LogIn";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // SpravkiButton
            // 
            SpravkiButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SpravkiButton.BackgroundImageLayout = ImageLayout.Stretch;
            SpravkiButton.Location = new Point(1215, 70);
            SpravkiButton.Name = "SpravkiButton";
            SpravkiButton.Size = new Size(135, 29);
            SpravkiButton.TabIndex = 23;
            SpravkiButton.Text = "Справки";
            SpravkiButton.UseVisualStyleBackColor = true;
            SpravkiButton.Click += SpravkiButton_Click;
            // 
            // UserPanel
            // 
            UserPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UserPanel.BackColor = SystemColors.ActiveCaption;
            UserPanel.Controls.Add(UserLabel);
            UserPanel.Location = new Point(1064, 2);
            UserPanel.Name = "UserPanel";
            UserPanel.RightToLeft = RightToLeft.Yes;
            UserPanel.Size = new Size(294, 22);
            UserPanel.TabIndex = 24;
            // 
            // UserLabel
            // 
            UserLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserLabel.AutoSize = true;
            UserLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            UserLabel.Location = new Point(0, 0);
            UserLabel.Name = "UserLabel";
            UserLabel.RightToLeft = RightToLeft.No;
            UserLabel.Size = new Size(112, 23);
            UserLabel.TabIndex = 0;
            UserLabel.Text = "Потребител: ";
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1358, 706);
            Controls.Add(UserPanel);
            Controls.Add(SpravkiButton);
            Controls.Add(LoginButton);
            Controls.Add(panelContent);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Wolf: Управление на поръчки";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            UserPanel.ResumeLayout(false);
            UserPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel RequestToolStripButton;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ToolStripLabel ClientsStripButton;
        private Button LoginButton;
        private Button SpravkiButton;
        private Panel UserPanel;
        private Label UserLabel;
    }
}

