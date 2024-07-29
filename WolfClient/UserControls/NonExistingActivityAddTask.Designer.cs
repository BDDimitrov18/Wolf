namespace WolfClient.UserControls
{
    partial class NonExistingActivityAddTask
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
            components = new System.ComponentModel.Container();
            expectedDurationDateTime = new DateTimePicker();
            label7 = new Label();
            DurationNumericUpDown = new NumericUpDown();
            TaskComboBox = new ComboBox();
            ActivityComboBox = new ComboBox();
            AddActivitySubmit = new Button();
            CommentsRichTextBox = new RichTextBox();
            label8 = new Label();
            ControlComboBox = new ComboBox();
            ControlLabel = new Label();
            label6 = new Label();
            startDateDateTimePicker = new DateTimePicker();
            label5 = new Label();
            ExecitantComboBox = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ParentActivityComboBox = new ComboBox();
            label1 = new Label();
            label9 = new Label();
            PaymentMainExecutantTextBox = new TextBox();
            label10 = new Label();
            StatusComboBox = new ComboBox();
            panel1 = new Panel();
            MainExecutantPaymentErrorLabel = new Label();
            label13 = new Label();
            MainExecutantComboBox = new ComboBox();
            label11 = new Label();
            panel2 = new Panel();
            ExecutantPriceErrorLabel = new Label();
            TaxPriceErrorLabel = new Label();
            label15 = new Label();
            ExecutantPaymentTextBox = new TextBox();
            label17 = new Label();
            TaxCommentRichTextBox = new RichTextBox();
            label16 = new Label();
            TaxTextBox = new TextBox();
            label12 = new Label();
            ActivityErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityErrorProvider).BeginInit();
            SuspendLayout();
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
            label7.Location = new Point(331, 11);
            label7.Name = "label7";
            label7.Size = new Size(322, 25);
            label7.TabIndex = 52;
            label7.Text = "Преценена Дата на приключване";
            // 
            // DurationNumericUpDown
            // 
            DurationNumericUpDown.DecimalPlaces = 2;
            DurationNumericUpDown.Location = new Point(350, 455);
            DurationNumericUpDown.Name = "DurationNumericUpDown";
            DurationNumericUpDown.Size = new Size(302, 27);
            DurationNumericUpDown.TabIndex = 51;
            // 
            // TaskComboBox
            // 
            TaskComboBox.FormattingEnabled = true;
            TaskComboBox.Location = new Point(8, 63);
            TaskComboBox.Name = "TaskComboBox";
            TaskComboBox.Size = new Size(302, 28);
            TaskComboBox.TabIndex = 50;
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
            ActivityComboBox.SelectedIndexChanged += ActivityComboBox_SelectedIndexChanged;
            // 
            // AddActivitySubmit
            // 
            AddActivitySubmit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddActivitySubmit.Location = new Point(245, 837);
            AddActivitySubmit.Margin = new Padding(3, 4, 3, 4);
            AddActivitySubmit.Name = "AddActivitySubmit";
            AddActivitySubmit.Size = new Size(195, 56);
            AddActivitySubmit.TabIndex = 48;
            AddActivitySubmit.Text = "Добави дейност";
            AddActivitySubmit.UseVisualStyleBackColor = true;
            AddActivitySubmit.Click += AddActivitySubmit_Click;
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
            // startDateDateTimePicker
            // 
            startDateDateTimePicker.Location = new Point(8, 159);
            startDateDateTimePicker.Margin = new Padding(3, 4, 3, 4);
            startDateDateTimePicker.Name = "startDateDateTimePicker";
            startDateDateTimePicker.Size = new Size(302, 27);
            startDateDateTimePicker.TabIndex = 42;
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
            label5.Click += label5_Click;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 25);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 38;
            label3.Text = "Задача";
            label3.Click += label3_Click;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 106);
            label1.Name = "label1";
            label1.Size = new Size(270, 25);
            label1.TabIndex = 54;
            label1.Text = "Пренасочване към дейност";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(8, 198);
            label9.Name = "label9";
            label9.Size = new Size(243, 25);
            label9.TabIndex = 56;
            label9.Text = "Хонорар гл. Изпълнител";
            // 
            // PaymentMainExecutantTextBox
            // 
            PaymentMainExecutantTextBox.Location = new Point(8, 243);
            PaymentMainExecutantTextBox.Name = "PaymentMainExecutantTextBox";
            PaymentMainExecutantTextBox.Size = new Size(302, 27);
            PaymentMainExecutantTextBox.TabIndex = 57;
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
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(MainExecutantPaymentErrorLabel);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(MainExecutantComboBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ActivityComboBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(expectedDurationDateTime);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(PaymentMainExecutantTextBox);
            panel1.Controls.Add(ParentActivityComboBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(13, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(681, 296);
            panel1.TabIndex = 60;
            // 
            // MainExecutantPaymentErrorLabel
            // 
            MainExecutantPaymentErrorLabel.AutoSize = true;
            MainExecutantPaymentErrorLabel.BackColor = SystemColors.GradientActiveCaption;
            MainExecutantPaymentErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            MainExecutantPaymentErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            MainExecutantPaymentErrorLabel.Location = new Point(8, 225);
            MainExecutantPaymentErrorLabel.Name = "MainExecutantPaymentErrorLabel";
            MainExecutantPaymentErrorLabel.Size = new Size(147, 15);
            MainExecutantPaymentErrorLabel.TabIndex = 63;
            MainExecutantPaymentErrorLabel.Text = "Моля спазвайте формата";
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
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(ExecutantPriceErrorLabel);
            panel2.Controls.Add(TaxPriceErrorLabel);
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
            panel2.Location = new Point(13, 315);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 491);
            panel2.TabIndex = 61;
            // 
            // ExecutantPriceErrorLabel
            // 
            ExecutantPriceErrorLabel.AutoSize = true;
            ExecutantPriceErrorLabel.BackColor = SystemColors.GradientActiveCaption;
            ExecutantPriceErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            ExecutantPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            ExecutantPriceErrorLabel.Location = new Point(350, 366);
            ExecutantPriceErrorLabel.Name = "ExecutantPriceErrorLabel";
            ExecutantPriceErrorLabel.Size = new Size(147, 15);
            ExecutantPriceErrorLabel.TabIndex = 68;
            ExecutantPriceErrorLabel.Text = "Моля спазвайте формата";
            // 
            // TaxPriceErrorLabel
            // 
            TaxPriceErrorLabel.AutoSize = true;
            TaxPriceErrorLabel.BackColor = SystemColors.GradientActiveCaption;
            TaxPriceErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            TaxPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            TaxPriceErrorLabel.Location = new Point(350, 164);
            TaxPriceErrorLabel.Name = "TaxPriceErrorLabel";
            TaxPriceErrorLabel.Size = new Size(147, 15);
            TaxPriceErrorLabel.TabIndex = 64;
            TaxPriceErrorLabel.Text = "Моля спазвайте формата";
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
            // ActivityErrorProvider
            // 
            ActivityErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ActivityErrorProvider.ContainerControl = this;
            // 
            // NonExistingActivityAddTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(AddActivitySubmit);
            Name = "NonExistingActivityAddTask";
            Size = new Size(707, 900);
            Load += AddActivityTaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker expectedDurationDateTime;
        private Label label7;
        private NumericUpDown DurationNumericUpDown;
        private ComboBox TaskComboBox;
        private ComboBox ActivityComboBox;
        private Button AddActivitySubmit;
        private RichTextBox CommentsRichTextBox;
        private Label label8;
        private ComboBox ControlComboBox;
        private Label ControlLabel;
        private Label label6;
        private DateTimePicker startDateDateTimePicker;
        private Label label5;
        private ComboBox ExecitantComboBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox ParentActivityComboBox;
        private Label label1;
        private Label label9;
        private TextBox PaymentMainExecutantTextBox;
        private Label label10;
        private ComboBox StatusComboBox;
        private Panel panel1;
        private Panel panel2;
        private ComboBox MainExecutantComboBox;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label17;
        private RichTextBox TaxCommentRichTextBox;
        private Label label16;
        private TextBox TaxTextBox;
        private Label label15;
        private TextBox ExecutantPaymentTextBox;
        private Label MainExecutantPaymentErrorLabel;
        private Label ExecutantPriceErrorLabel;
        private Label TaxPriceErrorLabel;
        private ErrorProvider ActivityErrorProvider;
    }
}
