namespace WolfClient.NewForms
{
    partial class AddActivityTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddActivityTaskForm));
            ActivityChoiceComboBox = new ComboBox();
            AvailableChoicePanel = new Panel();
            SuspendLayout();
            // 
            // ActivityChoiceComboBox
            // 
            ActivityChoiceComboBox.FormattingEnabled = true;
            ActivityChoiceComboBox.Items.AddRange(new object[] { "От Налични Дейности", "Към Нова дейност" });
            ActivityChoiceComboBox.Location = new Point(12, 12);
            ActivityChoiceComboBox.Name = "ActivityChoiceComboBox";
            ActivityChoiceComboBox.Size = new Size(218, 28);
            ActivityChoiceComboBox.TabIndex = 17;
            ActivityChoiceComboBox.SelectedIndexChanged += ActivityChoiceComboBox_SelectedIndexChanged;
            // 
            // AvailableChoicePanel
            // 
            AvailableChoicePanel.Location = new Point(12, 46);
            AvailableChoicePanel.Name = "AvailableChoicePanel";
            AvailableChoicePanel.Size = new Size(800, 900);
            AvailableChoicePanel.TabIndex = 18;
            // 
            // AddActivityTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(826, 981);
            Controls.Add(AvailableChoicePanel);
            Controls.Add(ActivityChoiceComboBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(844, 1095);
            MinimumSize = new Size(844, 1028);
            Name = "AddActivityTaskForm";
            Text = "Wolf: Добавяне на задача";
            WindowState = FormWindowState.Maximized;
            Load += AddActivityTaskForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private ComboBox ActivityChoiceComboBox;
        private Panel AvailableChoicePanel;
    }
}