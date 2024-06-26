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
            AddActivitySubmit = new Button();
            richTextBox1 = new RichTextBox();
            label8 = new Label();
            ControlComboBox = new ComboBox();
            ControlLabel = new Label();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            ExecitantComboBox = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ActivityComboBox = new ComboBox();
            TaskComboBox = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // AddActivitySubmit
            // 
            AddActivitySubmit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddActivitySubmit.Location = new Point(606, 820);
            AddActivitySubmit.Margin = new Padding(3, 4, 3, 4);
            AddActivitySubmit.Name = "AddActivitySubmit";
            AddActivitySubmit.Size = new Size(195, 56);
            AddActivitySubmit.TabIndex = 31;
            AddActivitySubmit.Text = "Добави дейност";
            AddActivitySubmit.UseVisualStyleBackColor = true;
            AddActivitySubmit.Click += AddActivitySubmit_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(487, 179);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(314, 279);
            richTextBox1.TabIndex = 30;
            richTextBox1.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(482, 129);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 29;
            label8.Text = "Коментар";
            // 
            // ControlComboBox
            // 
            ControlComboBox.FormattingEnabled = true;
            ControlComboBox.Location = new Point(61, 820);
            ControlComboBox.Margin = new Padding(3, 4, 3, 4);
            ControlComboBox.Name = "ControlComboBox";
            ControlComboBox.Size = new Size(302, 28);
            ControlComboBox.TabIndex = 28;
            ControlComboBox.SelectedIndexChanged += ControlComboBox_SelectedIndexChanged;
            // 
            // ControlLabel
            // 
            ControlLabel.AutoSize = true;
            ControlLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ControlLabel.Location = new Point(56, 765);
            ControlLabel.Name = "ControlLabel";
            ControlLabel.Size = new Size(92, 25);
            ControlLabel.TabIndex = 27;
            ControlLabel.Text = "Контрол";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(56, 644);
            label6.Name = "label6";
            label6.Size = new Size(140, 25);
            label6.TabIndex = 25;
            label6.Text = "Времетраене";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(61, 566);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(302, 27);
            dateTimePicker1.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(56, 503);
            label5.Name = "label5";
            label5.Size = new Size(61, 25);
            label5.TabIndex = 23;
            label5.Text = "Дата";
            // 
            // ExecitantComboBox
            // 
            ExecitantComboBox.FormattingEnabled = true;
            ExecitantComboBox.Location = new Point(61, 429);
            ExecitantComboBox.Margin = new Padding(3, 4, 3, 4);
            ExecitantComboBox.Name = "ExecitantComboBox";
            ExecitantComboBox.Size = new Size(302, 28);
            ExecitantComboBox.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(56, 374);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 21;
            label4.Text = "Изпълнител";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(56, 256);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 19;
            label3.Text = "Задача";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(56, 129);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 17;
            label2.Text = "Дейност";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(220, 25);
            label1.Name = "label1";
            label1.Size = new Size(409, 42);
            label1.TabIndex = 16;
            label1.Text = "Добавяне На Дейност";
            // 
            // ActivityComboBox
            // 
            ActivityComboBox.DropDownHeight = 230;
            ActivityComboBox.FormattingEnabled = true;
            ActivityComboBox.IntegralHeight = false;
            ActivityComboBox.ItemHeight = 20;
            ActivityComboBox.Location = new Point(61, 170);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(302, 28);
            ActivityComboBox.TabIndex = 32;
            ActivityComboBox.SelectedIndexChanged += ActivityComboBox_SelectedIndexChanged;
            // 
            // TaskComboBox
            // 
            TaskComboBox.FormattingEnabled = true;
            TaskComboBox.Location = new Point(61, 307);
            TaskComboBox.Name = "TaskComboBox";
            TaskComboBox.Size = new Size(302, 28);
            TaskComboBox.TabIndex = 33;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(61, 695);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(302, 27);
            numericUpDown1.TabIndex = 34;
            // 
            // AddActivityTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(853, 896);
            Controls.Add(numericUpDown1);
            Controls.Add(TaskComboBox);
            Controls.Add(ActivityComboBox);
            Controls.Add(AddActivitySubmit);
            Controls.Add(richTextBox1);
            Controls.Add(label8);
            Controls.Add(ControlComboBox);
            Controls.Add(ControlLabel);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(ExecitantComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddActivityTaskForm";
            Text = "AddActivityTaskForm";
            Load += AddActivityTaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddActivitySubmit;
        private RichTextBox richTextBox1;
        private Label label8;
        private ComboBox ControlComboBox;
        private Label ControlLabel;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private ComboBox ExecitantComboBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox ActivityComboBox;
        private ComboBox TaskComboBox;
        private NumericUpDown numericUpDown1;
    }
}