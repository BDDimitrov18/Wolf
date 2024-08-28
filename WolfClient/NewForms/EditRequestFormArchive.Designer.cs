namespace WolfClient.NewForms
{
    partial class EditRequestFormArchive
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
            ArchiveStatusComboBox = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)RequestErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // CommentsRichTextBox
            // 
            CommentsRichTextBox.Location = new Point(12, 577);
            // 
            // NewClientsFlowPanel
            // 
            NewClientsFlowPanel.Location = new Point(12, 548);
            // 
            // AdvanceTextBox
            // 
            AdvanceTextBox.Location = new Point(17, 240);
            // 
            // AdvanceLabel
            // 
            AdvanceLabel.Location = new Point(12, 181);
            // 
            // PriceOfRequestTextBox
            // 
            PriceOfRequestTextBox.Location = new Point(17, 150);
            // 
            // PriceOfRequestLabel
            // 
            PriceOfRequestLabel.Location = new Point(12, 91);
            // 
            // AdvancePriceErrorLabel
            // 
            AdvancePriceErrorLabel.Location = new Point(17, 221);
            // 
            // FinalPriceErrorLabel
            // 
            FinalPriceErrorLabel.Location = new Point(17, 131);
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(17, 410);
            // 
            // openFilesButton
            // 
            openFilesButton.Location = new Point(215, 373);
            // 
            // label1
            // 
            label1.Location = new Point(17, 373);
            // 
            // label2
            // 
            label2.Location = new Point(17, 282);
            // 
            // RequestCreatorComboBox
            // 
            RequestCreatorComboBox.Location = new Point(17, 323);
            // 
            // ArchiveStatusComboBox
            // 
            ArchiveStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ArchiveStatusComboBox.FormattingEnabled = true;
            ArchiveStatusComboBox.Items.AddRange(new object[] { "Active", "Archived" });
            ArchiveStatusComboBox.Location = new Point(17, 492);
            ArchiveStatusComboBox.Name = "ArchiveStatusComboBox";
            ArchiveStatusComboBox.Size = new Size(316, 28);
            ArchiveStatusComboBox.TabIndex = 46;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 459);
            label3.Name = "label3";
            label3.Size = new Size(220, 28);
            label3.TabIndex = 47;
            label3.Text = "Статус на архивиране :";
            // 
            // EditRequestFormArchive
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            ClientSize = new Size(878, 760);
            Controls.Add(label3);
            Controls.Add(ArchiveStatusComboBox);
            Name = "EditRequestFormArchive";
            Text = "Wolf Archive : Редактиране на поръчка";
            Controls.SetChildIndex(NameOfRequestTiltleLabel, 0);
            Controls.SetChildIndex(NameOfRequestTextBox, 0);
            Controls.SetChildIndex(PriceOfRequestLabel, 0);
            Controls.SetChildIndex(PriceOfRequestTextBox, 0);
            Controls.SetChildIndex(AdvanceLabel, 0);
            Controls.SetChildIndex(AdvanceTextBox, 0);
            Controls.SetChildIndex(NewClientsFlowPanel, 0);
            Controls.SetChildIndex(CommentsRichTextBox, 0);
            Controls.SetChildIndex(AddExistingClientToRequestLabel, 0);
            Controls.SetChildIndex(AddClientComboBoxButton, 0);
            Controls.SetChildIndex(AddNonExistingClientLabel, 0);
            Controls.SetChildIndex(AddNonExistingClientButton, 0);
            Controls.SetChildIndex(AddRequestButton, 0);
            Controls.SetChildIndex(NameOfRequestErrorLabel, 0);
            Controls.SetChildIndex(FinalPriceErrorLabel, 0);
            Controls.SetChildIndex(AdvancePriceErrorLabel, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(openFilesButton, 0);
            Controls.SetChildIndex(PathTextBox, 0);
            Controls.SetChildIndex(RequestCreatorComboBox, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(ArchiveStatusComboBox, 0);
            Controls.SetChildIndex(label3, 0);
            ((System.ComponentModel.ISupportInitialize)RequestErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ArchiveStatusComboBox;
        private Label label3;
    }
}