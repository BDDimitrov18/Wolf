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
            ArchiveStatusComboBox = new ComboBox();
            label15 = new Label();
          
            SuspendLayout();
            // 
            // label4
            // 
            label4.Location = new Point(3, 72);
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.Location = new Point(174, 177);
            cmbPaymentStatus.Size = new Size(160, 28);
            // 
            // label3
            // 
            label3.Location = new Point(3, 177);
            // 
            // CommentsTextBox
            // 
            CommentsTextBox.Location = new Point(3, 443);
            CommentsTextBox.Size = new Size(328, 95);
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(97, 106);
            txtNumber.Size = new Size(237, 27);
            // 
            // label12
            // 
            label12.Location = new Point(3, 412);
            // 
            // statusCheckBox
            // 
            statusCheckBox.Location = new Point(162, 72);
            statusCheckBox.Size = new Size(172, 28);
            // 
            // label11
            // 
            label11.Location = new Point(3, 139);
            // 
            // label1
            // 
            label1.Location = new Point(3, 105);
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(180, 140);
            CityTextBox.Size = new Size(154, 27);
            // 
            // label10
            // 
            label10.Location = new Point(3, 335);
            // 
            // neighborhoodTextBox
            // 
            neighborhoodTextBox.Location = new Point(50, 336);
            // 
            // label9
            // 
            label9.Location = new Point(3, 302);
            // 
            // UPITextBox
            // 
            UPITextBox.Location = new Point(68, 303);
            // 
            // label8
            // 
            label8.Location = new Point(3, 210);
            // 
            // plotNumberTextBox
            // 
            plotNumberTextBox.Location = new Point(146, 211);
            plotNumberTextBox.Size = new Size(188, 27);
            // 
            // EmployeesFilterLabel
            // 
            EmployeesFilterLabel.Location = new Point(337, 415);
            // 
            // EmployeesFilterCheckBoxList
            // 
            EmployeesFilterCheckBoxList.Location = new Point(344, 446);
            EmployeesFilterCheckBoxList.Size = new Size(420, 92);
            // 
            // filtersPanel
            // 
            filtersPanel.Controls.Add(label15);
            filtersPanel.Controls.Add(ArchiveStatusComboBox);
            filtersPanel.Size = new Size(772, 546);
            filtersPanel.Controls.SetChildIndex(requestNameFilter, 0);
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
            filtersPanel.Controls.SetChildIndex(label15, 0);
            // 
            // requestNameFilter
            // 
            requestNameFilter.Location = new Point(3, 272);
            requestNameFilter.Size = new Size(331, 27);
            // 
            // label6
            // 
            label6.Location = new Point(3, 241);
            // 
            // ArchiveStatusComboBox
            // 
            ArchiveStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ArchiveStatusComboBox.FormattingEnabled = true;
            ArchiveStatusComboBox.Items.AddRange(new object[] { "Всички", "Активни", "Архивни" });
            ArchiveStatusComboBox.Location = new Point(171, 38);
            ArchiveStatusComboBox.Name = "ArchiveStatusComboBox";
            ArchiveStatusComboBox.Size = new Size(160, 28);
            ArchiveStatusComboBox.TabIndex = 76;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(3, 38);
            label15.Name = "label15";
            label15.Size = new Size(162, 28);
            label15.TabIndex = 77;
            label15.Text = "Архивен Статус :";
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

        private ComboBox ArchiveStatusComboBox;
        private Label label15;
    }
}
