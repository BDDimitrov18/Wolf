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
            label1 = new Label();
            ActivityChoiceComboBox = new ComboBox();
            AvailableChoicePanel = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(608, 42);
            label1.TabIndex = 16;
            label1.Text = "Добавяне на задача към дейност";
            label1.Click += label1_Click;
            // 
            // ActivityChoiceComboBox
            // 
            ActivityChoiceComboBox.FormattingEnabled = true;
            ActivityChoiceComboBox.Items.AddRange(new object[] { "От Налични Дейности", "Към Нова дейност" });
            ActivityChoiceComboBox.Location = new Point(12, 97);
            ActivityChoiceComboBox.Name = "ActivityChoiceComboBox";
            ActivityChoiceComboBox.Size = new Size(218, 28);
            ActivityChoiceComboBox.TabIndex = 17;
            ActivityChoiceComboBox.SelectedIndexChanged += ActivityChoiceComboBox_SelectedIndexChanged;
            // 
            // AvailableChoicePanel
            // 
            AvailableChoicePanel.Location = new Point(12, 131);
            AvailableChoicePanel.Name = "AvailableChoicePanel";
            AvailableChoicePanel.Size = new Size(800, 900);
            AvailableChoicePanel.TabIndex = 18;
            // 
            // AddActivityTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(826, 1048);
            Controls.Add(AvailableChoicePanel);
            Controls.Add(ActivityChoiceComboBox);
            Controls.Add(label1);
            MaximumSize = new Size(844, 1095);
            MinimumSize = new Size(844, 1028);
            Name = "AddActivityTaskForm";
            Text = "AddActivityTaskForm";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ComboBox ActivityChoiceComboBox;
        private Panel AvailableChoicePanel;
    }
}