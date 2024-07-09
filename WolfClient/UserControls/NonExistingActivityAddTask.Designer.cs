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
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // expectedDurationDateTime
            // 
            expectedDurationDateTime.Location = new Point(436, 445);
            expectedDurationDateTime.Margin = new Padding(3, 4, 3, 4);
            expectedDurationDateTime.Name = "expectedDurationDateTime";
            expectedDurationDateTime.Size = new Size(302, 27);
            expectedDurationDateTime.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(431, 382);
            label7.Name = "label7";
            label7.Size = new Size(217, 25);
            label7.TabIndex = 52;
            label7.Text = "Дата На приключване";
            // 
            // DurationNumericUpDown
            // 
            DurationNumericUpDown.DecimalPlaces = 2;
            DurationNumericUpDown.Location = new Point(15, 574);
            DurationNumericUpDown.Name = "DurationNumericUpDown";
            DurationNumericUpDown.Size = new Size(302, 27);
            DurationNumericUpDown.TabIndex = 51;
            // 
            // TaskComboBox
            // 
            TaskComboBox.FormattingEnabled = true;
            TaskComboBox.Location = new Point(15, 186);
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
            ActivityComboBox.Location = new Point(15, 49);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(302, 28);
            ActivityComboBox.TabIndex = 49;
            ActivityComboBox.SelectedIndexChanged += ActivityComboBox_SelectedIndexChanged;
            // 
            // AddActivitySubmit
            // 
            AddActivitySubmit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddActivitySubmit.Location = new Point(560, 699);
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
            CommentsRichTextBox.Location = new Point(441, 58);
            CommentsRichTextBox.Margin = new Padding(3, 4, 3, 4);
            CommentsRichTextBox.Name = "CommentsRichTextBox";
            CommentsRichTextBox.Size = new Size(314, 279);
            CommentsRichTextBox.TabIndex = 47;
            CommentsRichTextBox.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(436, 8);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 46;
            label8.Text = "Коментар";
            // 
            // ControlComboBox
            // 
            ControlComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ControlComboBox.FormattingEnabled = true;
            ControlComboBox.Location = new Point(15, 699);
            ControlComboBox.Margin = new Padding(3, 4, 3, 4);
            ControlComboBox.Name = "ControlComboBox";
            ControlComboBox.Size = new Size(302, 28);
            ControlComboBox.TabIndex = 45;
            // 
            // ControlLabel
            // 
            ControlLabel.AutoSize = true;
            ControlLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ControlLabel.Location = new Point(10, 644);
            ControlLabel.Name = "ControlLabel";
            ControlLabel.Size = new Size(92, 25);
            ControlLabel.TabIndex = 44;
            ControlLabel.Text = "Контрол";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(10, 523);
            label6.Name = "label6";
            label6.Size = new Size(140, 25);
            label6.TabIndex = 43;
            label6.Text = "Времетраене";
            // 
            // startDateDateTimePicker
            // 
            startDateDateTimePicker.Location = new Point(15, 445);
            startDateDateTimePicker.Margin = new Padding(3, 4, 3, 4);
            startDateDateTimePicker.Name = "startDateDateTimePicker";
            startDateDateTimePicker.Size = new Size(302, 27);
            startDateDateTimePicker.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(10, 382);
            label5.Name = "label5";
            label5.Size = new Size(61, 25);
            label5.TabIndex = 41;
            label5.Text = "Дата";
            // 
            // ExecitantComboBox
            // 
            ExecitantComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ExecitantComboBox.FormattingEnabled = true;
            ExecitantComboBox.Location = new Point(15, 308);
            ExecitantComboBox.Margin = new Padding(3, 4, 3, 4);
            ExecitantComboBox.Name = "ExecitantComboBox";
            ExecitantComboBox.Size = new Size(302, 28);
            ExecitantComboBox.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(10, 253);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 39;
            label4.Text = "Изпълнител";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 135);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 38;
            label3.Text = "Задача";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 8);
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
            ParentActivityComboBox.Location = new Point(431, 602);
            ParentActivityComboBox.Name = "ParentActivityComboBox";
            ParentActivityComboBox.Size = new Size(302, 28);
            ParentActivityComboBox.TabIndex = 55;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(431, 558);
            label1.Name = "label1";
            label1.Size = new Size(270, 25);
            label1.TabIndex = 54;
            label1.Text = "Пренасочване към дейност";
            // 
            // NonExistingActivityAddTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(ParentActivityComboBox);
            Controls.Add(label1);
            Controls.Add(expectedDurationDateTime);
            Controls.Add(label7);
            Controls.Add(DurationNumericUpDown);
            Controls.Add(TaskComboBox);
            Controls.Add(ActivityComboBox);
            Controls.Add(AddActivitySubmit);
            Controls.Add(CommentsRichTextBox);
            Controls.Add(label8);
            Controls.Add(ControlComboBox);
            Controls.Add(ControlLabel);
            Controls.Add(label6);
            Controls.Add(startDateDateTimePicker);
            Controls.Add(label5);
            Controls.Add(ExecitantComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "NonExistingActivityAddTask";
            Size = new Size(853, 896);
            Load += AddActivityTaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)DurationNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
