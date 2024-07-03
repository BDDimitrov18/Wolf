namespace WolfClient.NewForms
{
    partial class AddOwnerForm
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
            label2 = new Label();
            EGNTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            TOMComboBox = new TextBox();
            label5 = new Label();
            RegisterComboBox = new TextBox();
            label6 = new Label();
            DocumentTypeComboBox = new ComboBox();
            label7 = new Label();
            IssingDateTimePicker = new DateTimePicker();
            label8 = new Label();
            CaseComboBox = new TextBox();
            label9 = new Label();
            label10 = new Label();
            Issuer = new ComboBox();
            label11 = new Label();
            TypeOfOwnership = new ComboBox();
            label12 = new Label();
            IdealPartsPanel = new Panel();
            panel2 = new Panel();
            DocumentNumberComboBox = new ComboBox();
            registeringDateTimePicker = new DateTimePicker();
            label22 = new Label();
            label20 = new Label();
            IdealPartsTypeComboBox = new ComboBox();
            panel3 = new Panel();
            wayOfAcquiringComboBox = new ComboBox();
            label15 = new Label();
            NameTextBox = new TextBox();
            label21 = new Label();
            AddressTextBox = new TextBox();
            label13 = new Label();
            panel4 = new Panel();
            label19 = new Label();
            plotStreetLabel = new Label();
            plotCityLabel = new Label();
            plotComboBox = new ComboBox();
            plotTypeLabel = new Label();
            plotLocalityLabel = new Label();
            label14 = new Label();
            SubmitButton = new Button();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(192, -2);
            label1.Name = "label1";
            label1.Size = new Size(447, 50);
            label1.TabIndex = 0;
            label1.Text = "Добавяне на Собственик";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 25);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 1;
            label2.Text = "ЕГН/БУЛСТАТ";
            // 
            // EGNTextBox
            // 
            EGNTextBox.Location = new Point(18, 56);
            EGNTextBox.Name = "EGNTextBox";
            EGNTextBox.Size = new Size(292, 27);
            EGNTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 95);
            label3.Name = "label3";
            label3.Size = new Size(51, 28);
            label3.TabIndex = 3;
            label3.Text = "Име";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 42);
            label4.Name = "label4";
            label4.Size = new Size(141, 28);
            label4.TabIndex = 5;
            label4.Text = "Документ Вид";
            // 
            // TOMComboBox
            // 
            TOMComboBox.Location = new Point(219, 161);
            TOMComboBox.Name = "TOMComboBox";
            TOMComboBox.Size = new Size(163, 27);
            TOMComboBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(219, 130);
            label5.Name = "label5";
            label5.Size = new Size(48, 28);
            label5.TabIndex = 7;
            label5.Text = "Том";
            // 
            // RegisterComboBox
            // 
            RegisterComboBox.Location = new Point(17, 262);
            RegisterComboBox.Name = "RegisterComboBox";
            RegisterComboBox.Size = new Size(164, 27);
            RegisterComboBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(17, 231);
            label6.Name = "label6";
            label6.Size = new Size(94, 28);
            label6.TabIndex = 9;
            label6.Text = "Регистър";
            // 
            // DocumentTypeComboBox
            // 
            DocumentTypeComboBox.FormattingEnabled = true;
            DocumentTypeComboBox.Items.AddRange(new object[] { "нотариален акт", "договор за делба", "договор за покупко продажба", "завещание", "акт за общинска собственост", "акт за държавна собственост", "постановление ЧСИ", "договор за отстъпено право на строеж", "дружествен договор" });
            DocumentTypeComboBox.Location = new Point(17, 73);
            DocumentTypeComboBox.Name = "DocumentTypeComboBox";
            DocumentTypeComboBox.Size = new Size(366, 28);
            DocumentTypeComboBox.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(17, 130);
            label7.Name = "label7";
            label7.Size = new Size(74, 28);
            label7.TabIndex = 12;
            label7.Text = "Номер";
            // 
            // IssingDateTimePicker
            // 
            IssingDateTimePicker.Location = new Point(17, 359);
            IssingDateTimePicker.Name = "IssingDateTimePicker";
            IssingDateTimePicker.Size = new Size(164, 27);
            IssingDateTimePicker.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(17, 328);
            label8.Name = "label8";
            label8.Size = new Size(171, 28);
            label8.TabIndex = 15;
            label8.Text = "Дата на издаване";
            // 
            // CaseComboBox
            // 
            CaseComboBox.Location = new Point(219, 262);
            CaseComboBox.Name = "CaseComboBox";
            CaseComboBox.Size = new Size(163, 27);
            CaseComboBox.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(219, 231);
            label9.Name = "label9";
            label9.Size = new Size(59, 28);
            label9.TabIndex = 16;
            label9.Text = "Дело";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(17, 517);
            label10.Name = "label10";
            label10.Size = new Size(86, 28);
            label10.TabIndex = 18;
            label10.Text = "Издател";
            // 
            // Issuer
            // 
            Issuer.FormattingEnabled = true;
            Issuer.Items.AddRange(new object[] { "Агенция по Вписвания при РС ", "Община ", "Областен управител", "Общинска служба замеделие", "Окръжен народен съвет", "", "", "", "" });
            Issuer.Location = new Point(17, 548);
            Issuer.Name = "Issuer";
            Issuer.Size = new Size(365, 28);
            Issuer.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(17, 426);
            label11.Name = "label11";
            label11.Size = new Size(166, 28);
            label11.TabIndex = 20;
            label11.Text = "Вид Собственост";
            label11.Click += label11_Click;
            // 
            // TypeOfOwnership
            // 
            TypeOfOwnership.FormattingEnabled = true;
            TypeOfOwnership.Items.AddRange(new object[] { "Няма Данни", "Държавна публична", "Държавна частна", "Общинска публична", "Общинска частна", "Частна", "Частна кооперативна", "Частна обществени оргранизации", "Частна чужди физически и юридически лица", "Частна международни организации", "Частна религиозни организации", "Съсобственост", "Изключителна държавна собственост", "стопанисвана от държавата по чл.14а от ЗВСГЗГФ", "държавна собственост по чл.6 от ЗВСГЗГФ", "Стопанисвано от Общината" });
            TypeOfOwnership.Location = new Point(17, 457);
            TypeOfOwnership.Name = "TypeOfOwnership";
            TypeOfOwnership.Size = new Size(366, 28);
            TypeOfOwnership.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(18, 247);
            label12.Name = "label12";
            label12.Size = new Size(148, 28);
            label12.TabIndex = 22;
            label12.Text = "Идеални части";
            // 
            // IdealPartsPanel
            // 
            IdealPartsPanel.BorderStyle = BorderStyle.Fixed3D;
            IdealPartsPanel.Location = new Point(201, 278);
            IdealPartsPanel.Name = "IdealPartsPanel";
            IdealPartsPanel.Size = new Size(182, 28);
            IdealPartsPanel.TabIndex = 23;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(DocumentNumberComboBox);
            panel2.Controls.Add(registeringDateTimePicker);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(TOMComboBox);
            panel2.Controls.Add(TypeOfOwnership);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(RegisterComboBox);
            panel2.Controls.Add(Issuer);
            panel2.Controls.Add(DocumentTypeComboBox);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(CaseComboBox);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(IssingDateTimePicker);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(458, 62);
            panel2.Name = "panel2";
            panel2.Size = new Size(424, 609);
            panel2.TabIndex = 24;
            // 
            // DocumentNumberComboBox
            // 
            DocumentNumberComboBox.FormattingEnabled = true;
            DocumentNumberComboBox.Location = new Point(17, 161);
            DocumentNumberComboBox.Name = "DocumentNumberComboBox";
            DocumentNumberComboBox.Size = new Size(163, 28);
            DocumentNumberComboBox.TabIndex = 27;
            // 
            // registeringDateTimePicker
            // 
            registeringDateTimePicker.Location = new Point(219, 359);
            registeringDateTimePicker.Name = "registeringDateTimePicker";
            registeringDateTimePicker.Size = new Size(164, 27);
            registeringDateTimePicker.TabIndex = 25;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(219, 328);
            label22.Name = "label22";
            label22.Size = new Size(186, 28);
            label22.TabIndex = 26;
            label22.Text = "Дата регистриране";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label20.ForeColor = SystemColors.Desktop;
            label20.Location = new Point(3, -2);
            label20.Name = "label20";
            label20.Size = new Size(59, 15);
            label20.TabIndex = 8;
            label20.Text = "документ";
            // 
            // IdealPartsTypeComboBox
            // 
            IdealPartsTypeComboBox.FormattingEnabled = true;
            IdealPartsTypeComboBox.Items.AddRange(new object[] { "дроб", "плаваща запетая" });
            IdealPartsTypeComboBox.Location = new Point(18, 278);
            IdealPartsTypeComboBox.Name = "IdealPartsTypeComboBox";
            IdealPartsTypeComboBox.Size = new Size(163, 28);
            IdealPartsTypeComboBox.TabIndex = 24;
            IdealPartsTypeComboBox.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(wayOfAcquiringComboBox);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(NameTextBox);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(AddressTextBox);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(IdealPartsTypeComboBox);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(EGNTextBox);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(IdealPartsPanel);
            panel3.Location = new Point(12, 268);
            panel3.Name = "panel3";
            panel3.Size = new Size(416, 403);
            panel3.TabIndex = 25;
            // 
            // wayOfAcquiringComboBox
            // 
            wayOfAcquiringComboBox.DropDownWidth = 366;
            wayOfAcquiringComboBox.FormattingEnabled = true;
            wayOfAcquiringComboBox.Items.AddRange(new object[] { "Дарение", "Покупко делба", "наследство", "давност" });
            wayOfAcquiringComboBox.Location = new Point(18, 358);
            wayOfAcquiringComboBox.Name = "wayOfAcquiringComboBox";
            wayOfAcquiringComboBox.Size = new Size(364, 28);
            wayOfAcquiringComboBox.TabIndex = 28;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(18, 327);
            label15.Name = "label15";
            label15.Size = new Size(233, 28);
            label15.TabIndex = 27;
            label15.Text = "Начин На Придобиване";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(18, 126);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(292, 27);
            NameTextBox.TabIndex = 26;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label21.ForeColor = SystemColors.Desktop;
            label21.Location = new Point(3, 0);
            label21.Name = "label21";
            label21.Size = new Size(70, 15);
            label21.TabIndex = 25;
            label21.Text = "собственик";
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(18, 204);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(292, 27);
            AddressTextBox.TabIndex = 6;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(18, 173);
            label13.Name = "label13";
            label13.Size = new Size(67, 28);
            label13.TabIndex = 5;
            label13.Text = "Адрес";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.GradientActiveCaption;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(label19);
            panel4.Controls.Add(plotStreetLabel);
            panel4.Controls.Add(plotCityLabel);
            panel4.Controls.Add(plotComboBox);
            panel4.Controls.Add(plotTypeLabel);
            panel4.Controls.Add(plotLocalityLabel);
            panel4.Controls.Add(label14);
            panel4.Location = new Point(12, 62);
            panel4.Name = "panel4";
            panel4.Size = new Size(416, 184);
            panel4.TabIndex = 26;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = SystemColors.Desktop;
            label19.Location = new Point(3, 0);
            label19.Name = "label19";
            label19.Size = new Size(35, 15);
            label19.TabIndex = 7;
            label19.Text = "имот";
            // 
            // plotStreetLabel
            // 
            plotStreetLabel.AutoSize = true;
            plotStreetLabel.Location = new Point(18, 138);
            plotStreetLabel.Name = "plotStreetLabel";
            plotStreetLabel.Size = new Size(61, 20);
            plotStreetLabel.TabIndex = 6;
            plotStreetLabel.Text = "улица : ";
            // 
            // plotCityLabel
            // 
            plotCityLabel.AutoSize = true;
            plotCityLabel.Location = new Point(18, 79);
            plotCityLabel.Name = "plotCityLabel";
            plotCityLabel.Size = new Size(51, 20);
            plotCityLabel.TabIndex = 5;
            plotCityLabel.Text = "град : ";
            // 
            // plotComboBox
            // 
            plotComboBox.FormattingEnabled = true;
            plotComboBox.Location = new Point(100, 15);
            plotComboBox.Name = "plotComboBox";
            plotComboBox.Size = new Size(239, 28);
            plotComboBox.TabIndex = 4;
            plotComboBox.SelectedIndexChanged += plotComboBox_SelectedIndexChanged;
            // 
            // plotTypeLabel
            // 
            plotTypeLabel.AutoSize = true;
            plotTypeLabel.Location = new Point(18, 50);
            plotTypeLabel.Name = "plotTypeLabel";
            plotTypeLabel.Size = new Size(41, 20);
            plotTypeLabel.TabIndex = 3;
            plotTypeLabel.Text = "вид :";
            // 
            // plotLocalityLabel
            // 
            plotLocalityLabel.AutoSize = true;
            plotLocalityLabel.Location = new Point(18, 109);
            plotLocalityLabel.Name = "plotLocalityLabel";
            plotLocalityLabel.Size = new Size(67, 20);
            plotLocalityLabel.TabIndex = 2;
            plotLocalityLabel.Text = "област : ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(18, 11);
            label14.Name = "label14";
            label14.Size = new Size(76, 28);
            label14.TabIndex = 0;
            label14.Text = "Имот: ";
            label14.Click += label14_Click;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(393, 677);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(108, 29);
            SubmitButton.TabIndex = 27;
            SubmitButton.Text = "Добавяне";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // AddOwnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(894, 718);
            Controls.Add(SubmitButton);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label1);
            Name = "AddOwnerForm";
            Text = "AddOwnerForm";
            Load += AddOwnerForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox EGNTextBox;
        private Label label3;
        private Label label4;
        private TextBox TOMComboBox;
        private Label label5;
        private TextBox RegisterComboBox;
        private Label label6;
        private ComboBox DocumentTypeComboBox;
        private Label label7;
        private DateTimePicker IssingDateTimePicker;
        private Label label8;
        private TextBox CaseComboBox;
        private Label label9;
        private Label label10;
        private ComboBox Issuer;
        private Label label11;
        private ComboBox TypeOfOwnership;
        private Label label12;
        private Panel IdealPartsPanel;
        private Panel panel2;
        private Panel panel3;
        private TextBox AddressTextBox;
        private Label label13;
        private ComboBox IdealPartsTypeComboBox;
        private Panel panel4;
        private Label plotTypeLabel;
        private Label plotLocalityLabel;
        private Label label14;
        private Button SubmitButton;
        private Label plotCityLabel;
        private ComboBox plotComboBox;
        private Label plotStreetLabel;
        private Label label20;
        private Label label21;
        private Label label19;
        private ComboBox DocumentNumberComboBox;
        private DateTimePicker registeringDateTimePicker;
        private Label label22;
        private TextBox NameTextBox;
        private ComboBox wayOfAcquiringComboBox;
        private Label label15;
    }
}