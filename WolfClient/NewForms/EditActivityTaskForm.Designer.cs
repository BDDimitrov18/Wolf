namespace WolfClient.NewForms
{
    partial class EditActivityTaskForm
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
            AvailableChoicePanel = new Panel();
            panel2 = new Panel();
            label19 = new Label();
            taskStartDateTimePicker = new DateTimePicker();
            label15 = new Label();
            ExecutantPaymentTextBox = new TextBox();
            label17 = new Label();
            TaxCommentRichTextBox = new RichTextBox();
            label16 = new Label();
            TaxTextBox = new TextBox();
            label12 = new Label();
            label3 = new Label();
            TaskComboBox = new ComboBox();
            DurationNumericUpDown = new NumericUpDown();
            ControlComboBox = new ComboBox();
            StatusComboBox = new ComboBox();
            ControlLabel = new Label();
            label5 = new Label();
            label10 = new Label();
            startDateDateTimePicker = new DateTimePicker();
            label6 = new Label();
            CommentsRichTextBox = new RichTextBox();
            ExecitantComboBox = new ComboBox();
            label8 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            ActivityStartDatePicker = new DateTimePicker();
            label18 = new Label();
            label13 = new Label();
            MainExecutantComboBox = new ComboBox();
            label2 = new Label();
            ActivityComboBox = new ComboBox();
            label11 = new Label();
            expectedDurationDateTime = new DateTimePicker();
            label7 = new Label();
            PaymentMainExecutantTextBox = new TextBox();
            ParentActivityComboBox = new ComboBox();
            label9 = new Label();
            label14 = new Label();
            AddActivitySubmit = new Button();
            AvailableChoicePanel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 9);
            label1.Name = "label1";
            label1.Size = new Size(690, 42);
            label1.TabIndex = 16;
            label1.Text = "Редактиране на задача и/или дейност";
            label1.Click += label1_Click;
            // 
            // AvailableChoicePanel
            // 
            AvailableChoicePanel.BackColor = SystemColors.ActiveCaption;
            AvailableChoicePanel.Controls.Add(panel2);
            AvailableChoicePanel.Controls.Add(panel1);
            AvailableChoicePanel.Controls.Add(AddActivitySubmit);
            AvailableChoicePanel.Location = new Point(4, 54);
            AvailableChoicePanel.Name = "AvailableChoicePanel";
            AvailableChoicePanel.Size = new Size(707, 929);
            AvailableChoicePanel.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label19);
            panel2.Controls.Add(taskStartDateTimePicker);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(ExecutantPaymentTextBox);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(TaxCommentRichTextBox);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(TaxTextBox);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(TaskComboBox);
            panel2.Controls.Add(DurationNumericUpDown);
            panel2.Controls.Add(ControlComboBox);
            panel2.Controls.Add(StatusComboBox);
            panel2.Controls.Add(ControlLabel);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(startDateDateTimePicker);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(CommentsRichTextBox);
            panel2.Controls.Add(ExecitantComboBox);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(9, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 582);
            panel2.TabIndex = 64;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(12, 498);
            label19.Name = "label19";
            label19.Size = new Size(188, 25);
            label19.TabIndex = 68;
            label19.Text = "Дата на започване";
            // 
            // taskStartDateTimePicker
            // 
            taskStartDateTimePicker.Location = new Point(8, 546);
            taskStartDateTimePicker.Margin = new Padding(3, 4, 3, 4);
            taskStartDateTimePicker.Name = "taskStartDateTimePicker";
            taskStartDateTimePicker.Size = new Size(302, 27);
            taskStartDateTimePicker.TabIndex = 69;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(350, 341);
            label15.Name = "label15";
            label15.Size = new Size(213, 25);
            label15.TabIndex = 67;
            label15.Text = "Хонорар Изпълнител";
            // 
            // ExecutantPaymentTextBox
            // 
            ExecutantPaymentTextBox.Location = new Point(350, 383);
            ExecutantPaymentTextBox.Name = "ExecutantPaymentTextBox";
            ExecutantPaymentTextBox.Size = new Size(314, 27);
            ExecutantPaymentTextBox.TabIndex = 66;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(350, 140);
            label17.Name = "label17";
            label17.Size = new Size(64, 25);
            label17.TabIndex = 65;
            label17.Text = "Такса";
            // 
            // TaxCommentRichTextBox
            // 
            TaxCommentRichTextBox.Location = new Point(350, 260);
            TaxCommentRichTextBox.Margin = new Padding(3, 4, 3, 4);
            TaxCommentRichTextBox.Name = "TaxCommentRichTextBox";
            TaxCommentRichTextBox.Size = new Size(314, 73);
            TaxCommentRichTextBox.TabIndex = 64;
            TaxCommentRichTextBox.Text = "";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(350, 222);
            label16.Name = "label16";
            label16.Size = new Size(190, 25);
            label16.TabIndex = 63;
            label16.Text = "Коментар на такса";
            // 
            // TaxTextBox
            // 
            TaxTextBox.Location = new Point(350, 182);
            TaxTextBox.Name = "TaxTextBox";
            TaxTextBox.Size = new Size(314, 27);
            TaxTextBox.TabIndex = 62;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(-2, 0);
            label12.Name = "label12";
            label12.Size = new Size(43, 15);
            label12.TabIndex = 60;
            label12.Text = "задача";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 25);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 38;
            label3.Text = "Задача";
            // 
            // TaskComboBox
            // 
            TaskComboBox.FormattingEnabled = true;
            TaskComboBox.Location = new Point(8, 63);
            TaskComboBox.Name = "TaskComboBox";
            TaskComboBox.Size = new Size(302, 28);
            TaskComboBox.TabIndex = 50;
            // 
            // DurationNumericUpDown
            // 
            DurationNumericUpDown.DecimalPlaces = 2;
            DurationNumericUpDown.Location = new Point(350, 455);
            DurationNumericUpDown.Name = "DurationNumericUpDown";
            DurationNumericUpDown.Size = new Size(302, 27);
            DurationNumericUpDown.TabIndex = 51;
            // 
            // ControlComboBox
            // 
            ControlComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ControlComboBox.FormattingEnabled = true;
            ControlComboBox.Location = new Point(8, 455);
            ControlComboBox.Margin = new Padding(3, 4, 3, 4);
            ControlComboBox.Name = "ControlComboBox";
            ControlComboBox.Size = new Size(302, 28);
            ControlComboBox.TabIndex = 45;
            // 
            // StatusComboBox
            // 
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Items.AddRange(new object[] { "Зададена", "Завършена", "Оферта" });
            StatusComboBox.Location = new Point(8, 247);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(302, 28);
            StatusComboBox.TabIndex = 59;
            // 
            // ControlLabel
            // 
            ControlLabel.AutoSize = true;
            ControlLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ControlLabel.Location = new Point(12, 411);
            ControlLabel.Name = "ControlLabel";
            ControlLabel.Size = new Size(92, 25);
            ControlLabel.TabIndex = 44;
            ControlLabel.Text = "Контрол";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 111);
            label5.Name = "label5";
            label5.Size = new Size(325, 25);
            label5.TabIndex = 41;
            label5.Text = "Преценена Дата на Приключване";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(12, 205);
            label10.Name = "label10";
            label10.Size = new Size(78, 25);
            label10.TabIndex = 58;
            label10.Text = "Статус";
            // 
            // startDateDateTimePicker
            // 
            startDateDateTimePicker.Location = new Point(8, 159);
            startDateDateTimePicker.Margin = new Padding(3, 4, 3, 4);
            startDateDateTimePicker.Name = "startDateDateTimePicker";
            startDateDateTimePicker.Size = new Size(302, 27);
            startDateDateTimePicker.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(350, 411);
            label6.Name = "label6";
            label6.Size = new Size(140, 25);
            label6.TabIndex = 43;
            label6.Text = "Времетраене";
            // 
            // CommentsRichTextBox
            // 
            CommentsRichTextBox.Location = new Point(350, 63);
            CommentsRichTextBox.Margin = new Padding(3, 4, 3, 4);
            CommentsRichTextBox.Name = "CommentsRichTextBox";
            CommentsRichTextBox.Size = new Size(314, 73);
            CommentsRichTextBox.TabIndex = 47;
            CommentsRichTextBox.Text = "";
            // 
            // ExecitantComboBox
            // 
            ExecitantComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ExecitantComboBox.FormattingEnabled = true;
            ExecitantComboBox.Location = new Point(8, 354);
            ExecitantComboBox.Margin = new Padding(3, 4, 3, 4);
            ExecitantComboBox.Name = "ExecitantComboBox";
            ExecitantComboBox.Size = new Size(302, 28);
            ExecitantComboBox.TabIndex = 40;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(350, 25);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 46;
            label8.Text = "Коментар";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 301);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 39;
            label4.Text = "Изпълнител";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(ActivityStartDatePicker);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(MainExecutantComboBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ActivityComboBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(expectedDurationDateTime);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(PaymentMainExecutantTextBox);
            panel1.Controls.Add(ParentActivityComboBox);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label14);
            panel1.Location = new Point(9, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(681, 282);
            panel1.TabIndex = 63;
            // 
            // ActivityStartDatePicker
            // 
            ActivityStartDatePicker.Location = new Point(336, 243);
            ActivityStartDatePicker.Margin = new Padding(3, 4, 3, 4);
            ActivityStartDatePicker.Name = "ActivityStartDatePicker";
            ActivityStartDatePicker.Size = new Size(302, 27);
            ActivityStartDatePicker.TabIndex = 64;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(331, 200);
            label18.Name = "label18";
            label18.Size = new Size(188, 25);
            label18.TabIndex = 63;
            label18.Text = "Дата на започване";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(-2, 0);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 62;
            label13.Text = "дейност";
            // 
            // MainExecutantComboBox
            // 
            MainExecutantComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MainExecutantComboBox.FormattingEnabled = true;
            MainExecutantComboBox.Location = new Point(336, 151);
            MainExecutantComboBox.Margin = new Padding(3, 4, 3, 4);
            MainExecutantComboBox.Name = "MainExecutantComboBox";
            MainExecutantComboBox.Size = new Size(302, 28);
            MainExecutantComboBox.TabIndex = 61;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 37;
            label2.Text = "Дейност";
            // 
            // ActivityComboBox
            // 
            ActivityComboBox.DropDownHeight = 230;
            ActivityComboBox.FormattingEnabled = true;
            ActivityComboBox.IntegralHeight = false;
            ActivityComboBox.ItemHeight = 20;
            ActivityComboBox.Location = new Point(8, 52);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(302, 28);
            ActivityComboBox.TabIndex = 49;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(331, 96);
            label11.Name = "label11";
            label11.Size = new Size(197, 25);
            label11.TabIndex = 60;
            label11.Text = "Главен изпълнител";
            // 
            // expectedDurationDateTime
            // 
            expectedDurationDateTime.Location = new Point(339, 52);
            expectedDurationDateTime.Margin = new Padding(3, 4, 3, 4);
            expectedDurationDateTime.Name = "expectedDurationDateTime";
            expectedDurationDateTime.Size = new Size(302, 27);
            expectedDurationDateTime.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(8, 106);
            label7.Name = "label7";
            label7.Size = new Size(270, 25);
            label7.TabIndex = 54;
            label7.Text = "Пренасочване към дейност";
            // 
            // PaymentMainExecutantTextBox
            // 
            PaymentMainExecutantTextBox.Location = new Point(8, 243);
            PaymentMainExecutantTextBox.Name = "PaymentMainExecutantTextBox";
            PaymentMainExecutantTextBox.Size = new Size(302, 27);
            PaymentMainExecutantTextBox.TabIndex = 57;
            // 
            // ParentActivityComboBox
            // 
            ParentActivityComboBox.DropDownHeight = 230;
            ParentActivityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ParentActivityComboBox.FormattingEnabled = true;
            ParentActivityComboBox.IntegralHeight = false;
            ParentActivityComboBox.ItemHeight = 20;
            ParentActivityComboBox.Location = new Point(8, 150);
            ParentActivityComboBox.Name = "ParentActivityComboBox";
            ParentActivityComboBox.Size = new Size(302, 28);
            ParentActivityComboBox.TabIndex = 55;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(331, 11);
            label9.Name = "label9";
            label9.Size = new Size(322, 25);
            label9.TabIndex = 52;
            label9.Text = "Преценена Дата на приключване";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(8, 198);
            label14.Name = "label14";
            label14.Size = new Size(243, 25);
            label14.TabIndex = 56;
            label14.Text = "Хонорар гл. Изпълнител";
            // 
            // AddActivitySubmit
            // 
            AddActivitySubmit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddActivitySubmit.Location = new Point(245, 885);
            AddActivitySubmit.Margin = new Padding(3, 4, 3, 4);
            AddActivitySubmit.Name = "AddActivitySubmit";
            AddActivitySubmit.Size = new Size(195, 40);
            AddActivitySubmit.TabIndex = 62;
            AddActivitySubmit.Text = "редактирай";
            AddActivitySubmit.UseVisualStyleBackColor = true;
            AddActivitySubmit.Click += AddActivitySubmit_Click;
            // 
            // EditActivityTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(717, 981);
            Controls.Add(AvailableChoicePanel);
            Controls.Add(label1);
            MaximumSize = new Size(735, 1095);
            MinimumSize = new Size(735, 1028);
            Name = "EditActivityTaskForm";
            Text = "AddActivityTaskForm";
            WindowState = FormWindowState.Maximized;
            Load += EditActivityTaskForm_Load;
            AvailableChoicePanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel AvailableChoicePanel;
        private Panel panel2;
        private Label label15;
        private TextBox ExecutantPaymentTextBox;
        private Label label17;
        private RichTextBox TaxCommentRichTextBox;
        private Label label16;
        private TextBox TaxTextBox;
        private Label label12;
        private Label label3;
        private ComboBox TaskComboBox;
        private NumericUpDown DurationNumericUpDown;
        private ComboBox ControlComboBox;
        private ComboBox StatusComboBox;
        private Label ControlLabel;
        private Label label5;
        private Label label10;
        private DateTimePicker startDateDateTimePicker;
        private Label label6;
        private RichTextBox CommentsRichTextBox;
        private ComboBox ExecitantComboBox;
        private Label label8;
        private Label label4;
        private Panel panel1;
        private Label label13;
        private ComboBox MainExecutantComboBox;
        private Label label2;
        private ComboBox ActivityComboBox;
        private Label label11;
        private DateTimePicker expectedDurationDateTime;
        private Label label7;
        private TextBox PaymentMainExecutantTextBox;
        private ComboBox ParentActivityComboBox;
        private Label label9;
        private Label label14;
        private Button AddActivitySubmit;
        private DateTimePicker ActivityStartDatePicker;
        private Label label18;
        private Label label19;
        private DateTimePicker taskStartDateTimePicker;
    }
}