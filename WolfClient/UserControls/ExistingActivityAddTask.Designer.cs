namespace WolfClient.UserControls
{
    partial class ExistingActivityAddTask
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
            DurationNumericUpDown = new NumericUpDown();
            TaskComboBox = new ComboBox();
            ActivityComboBox = new ComboBox();
            AddActivitySubmit = new Button();
            CommentsRichTextBox = new RichTextBox();
            label8 = new Label();
            ControlComboBox = new ComboBox();
            ControlLabel = new Label();
            label6 = new Label();
            endDateDateTimePicker = new DateTimePicker();
            label5 = new Label();
            ExecitantComboBox = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            ExecutantPriceErrorLabel = new Label();
            TaxPriceErrorLabel = new Label();
            label14 = new Label();
            StatusComboBox = new ComboBox();
            label11 = new Label();
            ExecutantPaymentTextBox = new TextBox();
            label10 = new Label();
            taxCommentRichTexBox = new RichTextBox();
            label9 = new Label();
            TaxTextBox = new TextBox();
            label7 = new Label();
            panel2 = new Panel();
            label13 = new Label();
            panel3 = new Panel();
            ParentActivityLabel = new Label();
            MainExecutantLabel = new Label();
            ExpectedDurationLabel = new Label();
            startDateLabel = new Label();
            ActivityTypeLabel = new Label();
            label1 = new Label();
            label12 = new Label();
            ActivityErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // DurationNumericUpDown
            // 
            DurationNumericUpDown.DecimalPlaces = 2;
            DurationNumericUpDown.Location = new Point(382, 454);
            DurationNumericUpDown.Name = "DurationNumericUpDown";
            DurationNumericUpDown.Size = new Size(326, 27);
            DurationNumericUpDown.TabIndex = 51;
            // 
            // TaskComboBox
            // 
            TaskComboBox.FormattingEnabled = true;
            TaskComboBox.Location = new Point(12, 70);
            TaskComboBox.Name = "TaskComboBox";
            TaskComboBox.Size = new Size(302, 28);
            TaskComboBox.TabIndex = 50;
            // 
            // ActivityComboBox
            // 
            ActivityComboBox.DropDownHeight = 230;
            ActivityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ActivityComboBox.FormattingEnabled = true;
            ActivityComboBox.IntegralHeight = false;
            ActivityComboBox.ItemHeight = 20;
            ActivityComboBox.Location = new Point(5, 75);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(302, 28);
            ActivityComboBox.TabIndex = 49;
            ActivityComboBox.SelectedIndexChanged += ActivityComboBox_SelectedIndexChanged;
            // 
            // AddActivitySubmit
            // 
            AddActivitySubmit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddActivitySubmit.Location = new Point(291, 696);
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
            CommentsRichTextBox.Location = new Point(387, 78);
            CommentsRichTextBox.Margin = new Padding(3, 4, 3, 4);
            CommentsRichTextBox.Name = "CommentsRichTextBox";
            CommentsRichTextBox.Size = new Size(314, 67);
            CommentsRichTextBox.TabIndex = 47;
            CommentsRichTextBox.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(382, 28);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 46;
            label8.Text = "Коментар";
            // 
            // ControlComboBox
            // 
            ControlComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ControlComboBox.FormattingEnabled = true;
            ControlComboBox.Location = new Point(12, 357);
            ControlComboBox.Margin = new Padding(3, 4, 3, 4);
            ControlComboBox.Name = "ControlComboBox";
            ControlComboBox.Size = new Size(302, 28);
            ControlComboBox.TabIndex = 45;
            // 
            // ControlLabel
            // 
            ControlLabel.AutoSize = true;
            ControlLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ControlLabel.Location = new Point(12, 308);
            ControlLabel.Name = "ControlLabel";
            ControlLabel.Size = new Size(92, 25);
            ControlLabel.TabIndex = 44;
            ControlLabel.Text = "Контрол";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(382, 413);
            label6.Name = "label6";
            label6.Size = new Size(140, 25);
            label6.TabIndex = 43;
            label6.Text = "Времетраене";
            // 
            // endDateDateTimePicker
            // 
            endDateDateTimePicker.Location = new Point(12, 170);
            endDateDateTimePicker.Margin = new Padding(3, 4, 3, 4);
            endDateDateTimePicker.Name = "endDateDateTimePicker";
            endDateDateTimePicker.Size = new Size(302, 27);
            endDateDateTimePicker.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 120);
            label5.Name = "label5";
            label5.Size = new Size(317, 25);
            label5.TabIndex = 41;
            label5.Text = "Преценена дата на приключване";
            // 
            // ExecitantComboBox
            // 
            ExecitantComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ExecitantComboBox.FormattingEnabled = true;
            ExecitantComboBox.Location = new Point(12, 259);
            ExecitantComboBox.Margin = new Padding(3, 4, 3, 4);
            ExecitantComboBox.Name = "ExecitantComboBox";
            ExecitantComboBox.Size = new Size(302, 28);
            ExecitantComboBox.TabIndex = 40;
            ExecitantComboBox.SelectedIndexChanged += ExecitantComboBox_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 215);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 39;
            label4.Text = "Изпълнител";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 28);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 38;
            label3.Text = "Задача";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(185, 25);
            label2.TabIndex = 37;
            label2.Text = "Налични дейности";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(ExecutantPriceErrorLabel);
            panel1.Controls.Add(TaxPriceErrorLabel);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(StatusComboBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(ExecutantPaymentTextBox);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(taxCommentRichTexBox);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(TaxTextBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TaskComboBox);
            panel1.Controls.Add(CommentsRichTextBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(DurationNumericUpDown);
            panel1.Controls.Add(ExecitantComboBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(endDateDateTimePicker);
            panel1.Controls.Add(ControlComboBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(ControlLabel);
            panel1.Location = new Point(27, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(745, 500);
            panel1.TabIndex = 54;
            // 
            // ExecutantPriceErrorLabel
            // 
            ExecutantPriceErrorLabel.AutoSize = true;
            ExecutantPriceErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            ExecutantPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            ExecutantPriceErrorLabel.Location = new Point(387, 364);
            ExecutantPriceErrorLabel.Name = "ExecutantPriceErrorLabel";
            ExecutantPriceErrorLabel.Size = new Size(147, 15);
            ExecutantPriceErrorLabel.TabIndex = 61;
            ExecutantPriceErrorLabel.Text = "Моля спазвайте формата";
            // 
            // TaxPriceErrorLabel
            // 
            TaxPriceErrorLabel.AutoSize = true;
            TaxPriceErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            TaxPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            TaxPriceErrorLabel.Location = new Point(387, 174);
            TaxPriceErrorLabel.Name = "TaxPriceErrorLabel";
            TaxPriceErrorLabel.Size = new Size(147, 15);
            TaxPriceErrorLabel.TabIndex = 60;
            TaxPriceErrorLabel.Text = "Моле спазвайте формата";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(-2, -2);
            label14.Name = "label14";
            label14.Size = new Size(43, 15);
            label14.TabIndex = 52;
            label14.Text = "задача";
            // 
            // StatusComboBox
            // 
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Items.AddRange(new object[] { "Зададена", "Завършена", "Оферта" });
            StatusComboBox.Location = new Point(12, 455);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(302, 28);
            StatusComboBox.TabIndex = 59;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(12, 413);
            label11.Name = "label11";
            label11.Size = new Size(78, 25);
            label11.TabIndex = 58;
            label11.Text = "Статус";
            // 
            // ExecutantPaymentTextBox
            // 
            ExecutantPaymentTextBox.Location = new Point(387, 382);
            ExecutantPaymentTextBox.Name = "ExecutantPaymentTextBox";
            ExecutantPaymentTextBox.Size = new Size(314, 27);
            ExecutantPaymentTextBox.TabIndex = 57;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(382, 337);
            label10.Name = "label10";
            label10.Size = new Size(213, 25);
            label10.TabIndex = 56;
            label10.Text = "Хонорар Изпълнител";
            // 
            // taxCommentRichTexBox
            // 
            taxCommentRichTexBox.Location = new Point(387, 256);
            taxCommentRichTexBox.Margin = new Padding(3, 4, 3, 4);
            taxCommentRichTexBox.Name = "taxCommentRichTexBox";
            taxCommentRichTexBox.Size = new Size(314, 77);
            taxCommentRichTexBox.TabIndex = 55;
            taxCommentRichTexBox.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(382, 224);
            label9.Name = "label9";
            label9.Size = new Size(164, 25);
            label9.TabIndex = 54;
            label9.Text = "Коментар такса";
            // 
            // TaxTextBox
            // 
            TaxTextBox.Location = new Point(387, 194);
            TaxTextBox.Name = "TaxTextBox";
            TaxTextBox.Size = new Size(314, 27);
            TaxTextBox.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(382, 149);
            label7.Name = "label7";
            label7.Size = new Size(64, 25);
            label7.TabIndex = 52;
            label7.Text = "Такса";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(ActivityComboBox);
            panel2.Location = new Point(27, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(745, 166);
            panel2.TabIndex = 55;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(-2, -2);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 51;
            label13.Text = "дейност";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientInactiveCaption;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(ParentActivityLabel);
            panel3.Controls.Add(MainExecutantLabel);
            panel3.Controls.Add(ExpectedDurationLabel);
            panel3.Controls.Add(startDateLabel);
            panel3.Controls.Add(ActivityTypeLabel);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(313, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(425, 156);
            panel3.TabIndex = 50;
            // 
            // ParentActivityLabel
            // 
            ParentActivityLabel.AutoSize = true;
            ParentActivityLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            ParentActivityLabel.Location = new Point(8, 125);
            ParentActivityLabel.Name = "ParentActivityLabel";
            ParentActivityLabel.Size = new Size(115, 19);
            ParentActivityLabel.TabIndex = 7;
            ParentActivityLabel.Text = "произлиза от : ";
            // 
            // MainExecutantLabel
            // 
            MainExecutantLabel.AutoSize = true;
            MainExecutantLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            MainExecutantLabel.Location = new Point(8, 92);
            MainExecutantLabel.Name = "MainExecutantLabel";
            MainExecutantLabel.Size = new Size(154, 19);
            MainExecutantLabel.TabIndex = 6;
            MainExecutantLabel.Text = "Главен изпълнител : ";
            // 
            // ExpectedDurationLabel
            // 
            ExpectedDurationLabel.AutoSize = true;
            ExpectedDurationLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            ExpectedDurationLabel.Location = new Point(226, 61);
            ExpectedDurationLabel.Name = "ExpectedDurationLabel";
            ExpectedDurationLabel.Size = new Size(111, 19);
            ExpectedDurationLabel.TabIndex = 5;
            ExpectedDurationLabel.Text = "завършва на : ";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            startDateLabel.Location = new Point(8, 61);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(115, 19);
            startDateLabel.TabIndex = 4;
            startDateLabel.Text = "започнато на : ";
            // 
            // ActivityTypeLabel
            // 
            ActivityTypeLabel.AutoSize = true;
            ActivityTypeLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            ActivityTypeLabel.Location = new Point(8, 31);
            ActivityTypeLabel.Name = "ActivityTypeLabel";
            ActivityTypeLabel.Size = new Size(80, 19);
            ActivityTypeLabel.TabIndex = 2;
            ActivityTypeLabel.Text = "Дейност : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 0;
            label1.Text = "данни за дейност";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(335, 26);
            label12.Name = "label12";
            label12.Size = new Size(0, 20);
            label12.TabIndex = 56;
            // 
            // ActivityErrorProvider
            // 
            ActivityErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ActivityErrorProvider.ContainerControl = this;
            // 
            // ExistingActivityAddTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(label12);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(AddActivitySubmit);
            Name = "ExistingActivityAddTask";
            Size = new Size(797, 754);
            Load += AddActivityTaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ActivityErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown DurationNumericUpDown;
        private ComboBox TaskComboBox;
        private Button AddActivitySubmit;
        private RichTextBox CommentsRichTextBox;
        private Label label8;
        private ComboBox ControlComboBox;
        private Label ControlLabel;
        private Label label6;
        private DateTimePicker endDateDateTimePicker;
        private Label label5;
        private ComboBox ExecitantComboBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox ActivityComboBox;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label MainExecutantLabel;
        private Label ExpectedDurationLabel;
        private Label startDateLabel;
        private Label ActivityTypeLabel;
        private Label ParentActivityLabel;
        private TextBox TaxTextBox;
        private Label label7;
        private RichTextBox taxCommentRichTexBox;
        private Label label9;
        private TextBox ExecutantPaymentTextBox;
        private Label label10;
        private ComboBox StatusComboBox;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label13;
        private ErrorProvider ActivityErrorProvider;
        private Label ExecutantPriceErrorLabel;
        private Label TaxPriceErrorLabel;
    }
}
