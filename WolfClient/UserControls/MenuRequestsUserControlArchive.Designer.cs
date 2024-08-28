namespace WolfClient.UserControls
{
    partial class MenuRequestsUserControlArchive
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
            label6 = new Label();
            ArchiveStatusComboBox = new ComboBox();
            panel3.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            DocumentsOfOwnershipTab.SuspendLayout();
            tabPage3.SuspendLayout();
            panel5.SuspendLayout();
            tabPage5.SuspendLayout();
            panel7.SuspendLayout();
            tabPage4.SuspendLayout();
            filtersPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Location = new Point(3, 96);
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.Items.AddRange(new object[] { "", "Платен", "Не Платен", "Аванс" });
            cmbPaymentStatus.Location = new Point(175, 219);
            // 
            // label3
            // 
            label3.Location = new Point(3, 219);
            // 
            // CommentsTextBox
            // 
            CommentsTextBox.Location = new Point(3, 400);
            CommentsTextBox.Size = new Size(328, 95);
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(91, 139);
            // 
            // label12
            // 
            label12.Location = new Point(3, 369);
            // 
            // statusCheckBox
            // 
            statusCheckBox.Items.AddRange(new object[] { "", "Зададена", "Завършена", "Оферта" });
            statusCheckBox.Location = new Point(156, 96);
            // 
            // label11
            // 
            label11.Location = new Point(3, 179);
            // 
            // label1
            // 
            label1.Location = new Point(3, 139);
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(174, 179);
            // 
            // label10
            // 
            label10.Location = new Point(3, 341);
            // 
            // neighborhoodTextBox
            // 
            neighborhoodTextBox.Location = new Point(47, 341);
            // 
            // label9
            // 
            label9.Location = new Point(3, 300);
            // 
            // UPITextBox
            // 
            UPITextBox.Location = new Point(65, 300);
            // 
            // label8
            // 
            label8.Location = new Point(3, 258);
            // 
            // plotNumberTextBox
            // 
            plotNumberTextBox.Location = new Point(140, 259);
            // 
            // EmployeesFilterLabel
            // 
            EmployeesFilterLabel.Location = new Point(337, 369);
            // 
            // EmployeesFilterCheckBoxList
            // 
            EmployeesFilterCheckBoxList.Location = new Point(344, 400);
            EmployeesFilterCheckBoxList.Size = new Size(420, 92);
            // 
            // filtersPanel
            // 
            filtersPanel.Controls.Add(ArchiveStatusComboBox);
            filtersPanel.Controls.Add(label6);
            filtersPanel.Size = new Size(772, 510);
            filtersPanel.Controls.SetChildIndex(plotNumberTextBox, 0);
            filtersPanel.Controls.SetChildIndex(label8, 0);
            filtersPanel.Controls.SetChildIndex(UPITextBox, 0);
            filtersPanel.Controls.SetChildIndex(chkPersonal, 0);
            filtersPanel.Controls.SetChildIndex(label9, 0);
            filtersPanel.Controls.SetChildIndex(chkStarred, 0);
            filtersPanel.Controls.SetChildIndex(neighborhoodTextBox, 0);
            filtersPanel.Controls.SetChildIndex(chkForDay, 0);
            filtersPanel.Controls.SetChildIndex(label10, 0);
            filtersPanel.Controls.SetChildIndex(chkForWeek, 0);
            filtersPanel.Controls.SetChildIndex(CityTextBox, 0);
            filtersPanel.Controls.SetChildIndex(label1, 0);
            filtersPanel.Controls.SetChildIndex(label11, 0);
            filtersPanel.Controls.SetChildIndex(statusCheckBox, 0);
            filtersPanel.Controls.SetChildIndex(label12, 0);
            filtersPanel.Controls.SetChildIndex(txtNumber, 0);
            filtersPanel.Controls.SetChildIndex(CommentsTextBox, 0);
            filtersPanel.Controls.SetChildIndex(label3, 0);
            filtersPanel.Controls.SetChildIndex(label13, 0);
            filtersPanel.Controls.SetChildIndex(cmbPaymentStatus, 0);
            filtersPanel.Controls.SetChildIndex(label4, 0);
            filtersPanel.Controls.SetChildIndex(label14, 0);
            filtersPanel.Controls.SetChildIndex(overdueFilter, 0);
            filtersPanel.Controls.SetChildIndex(AddClientButton, 0);
            filtersPanel.Controls.SetChildIndex(button2, 0);
            filtersPanel.Controls.SetChildIndex(EmployeesFilterLabel, 0);
            filtersPanel.Controls.SetChildIndex(EmployeesFilterCheckBoxList, 0);
            filtersPanel.Controls.SetChildIndex(label6, 0);
            filtersPanel.Controls.SetChildIndex(ArchiveStatusComboBox, 0);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 55);
            label6.Name = "label6";
            label6.Size = new Size(162, 28);
            label6.TabIndex = 75;
            label6.Text = "Архивен Статус :";
            // 
            // ArchiveStatusComboBox
            // 
            ArchiveStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ArchiveStatusComboBox.FormattingEnabled = true;
            ArchiveStatusComboBox.Items.AddRange(new object[] { "Всички", "Активни", "Архивни" });
            ArchiveStatusComboBox.Location = new Point(171, 59);
            ArchiveStatusComboBox.Name = "ArchiveStatusComboBox";
            ArchiveStatusComboBox.Size = new Size(160, 28);
            ArchiveStatusComboBox.TabIndex = 76;
            // 
            // MenuRequestsUserControlArchive
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "MenuRequestsUserControlArchive";
            Controls.SetChildIndex(panel3, 0);
            Controls.SetChildIndex(DocumentsOfOwnershipTab, 0);
            Controls.SetChildIndex(filtersPanel, 0);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            DocumentsOfOwnershipTab.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabPage5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            filtersPanel.ResumeLayout(false);
            filtersPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private ComboBox ArchiveStatusComboBox;
    }
}
