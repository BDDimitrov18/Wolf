namespace WolfClient.NewForms
{
    partial class inqueriesUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inqueriesUserForm));
            firstDate = new DateTimePicker();
            firstDateLabel = new Label();
            label1 = new Label();
            SecondDate = new DateTimePicker();
            flowLayoutPanel1 = new FlowLayoutPanel();
            AllTasksInqueri = new Button();
            label3 = new Label();
            label4 = new Label();
            paymentStatusCheckBoxList = new CheckedListBox();
            allPaymentStatusCheckBox = new CheckBox();
            checkedListBox3 = new CheckedListBox();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            label8 = new Label();
            checkedListBox4 = new CheckedListBox();
            allActivityCheckBox = new CheckBox();
            allTasksButton = new CheckBox();
            taskStatusAllCheckBox = new CheckBox();
            label9 = new Label();
            taskStatusCheckBoxList = new CheckedListBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel3 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // firstDate
            // 
            firstDate.Location = new Point(0, 33);
            firstDate.Name = "firstDate";
            firstDate.Size = new Size(250, 27);
            firstDate.TabIndex = 0;
            // 
            // firstDateLabel
            // 
            firstDateLabel.AutoSize = true;
            firstDateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstDateLabel.Location = new Point(0, 2);
            firstDateLabel.Name = "firstDateLabel";
            firstDateLabel.Size = new Size(79, 28);
            firstDateLabel.TabIndex = 1;
            firstDateLabel.Text = "От дата";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 78);
            label1.Name = "label1";
            label1.Size = new Size(85, 28);
            label1.TabIndex = 3;
            label1.Text = "До Дата";
            // 
            // SecondDate
            // 
            SecondDate.Location = new Point(0, 109);
            SecondDate.Name = "SecondDate";
            SecondDate.Size = new Size(250, 27);
            SecondDate.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel1.Controls.Add(AllTasksInqueri);
            flowLayoutPanel1.Location = new Point(0, 31);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 631);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // AllTasksInqueri
            // 
            AllTasksInqueri.Location = new Point(3, 3);
            AllTasksInqueri.Name = "AllTasksInqueri";
            AllTasksInqueri.Size = new Size(243, 57);
            AllTasksInqueri.TabIndex = 0;
            AllTasksInqueri.Text = "Справка оборот на Задачи";
            AllTasksInqueri.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(195, 28);
            label3.TabIndex = 7;
            label3.Text = "Списък със справки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 2);
            label4.Name = "label4";
            label4.Size = new Size(218, 56);
            label4.TabIndex = 9;
            label4.Text = "За поръчки със статус \r\nна плащане :";
            // 
            // paymentStatusCheckBoxList
            // 
            paymentStatusCheckBoxList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            paymentStatusCheckBoxList.BackColor = SystemColors.ActiveCaption;
            paymentStatusCheckBoxList.FormattingEnabled = true;
            paymentStatusCheckBoxList.Items.AddRange(new object[] { "Платен", "Аванс", "Не платен" });
            paymentStatusCheckBoxList.Location = new Point(0, 61);
            paymentStatusCheckBoxList.Name = "paymentStatusCheckBoxList";
            paymentStatusCheckBoxList.Size = new Size(244, 180);
            paymentStatusCheckBoxList.TabIndex = 8;
            // 
            // allPaymentStatusCheckBox
            // 
            allPaymentStatusCheckBox.AutoSize = true;
            allPaymentStatusCheckBox.Location = new Point(168, 34);
            allPaymentStatusCheckBox.Name = "allPaymentStatusCheckBox";
            allPaymentStatusCheckBox.Size = new Size(79, 24);
            allPaymentStatusCheckBox.TabIndex = 11;
            allPaymentStatusCheckBox.Text = "всички";
            allPaymentStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkedListBox3
            // 
            checkedListBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox3.BackColor = SystemColors.ActiveCaption;
            checkedListBox3.FormattingEnabled = true;
            checkedListBox3.Location = new Point(3, 82);
            checkedListBox3.Name = "checkedListBox3";
            checkedListBox3.Size = new Size(492, 224);
            checkedListBox3.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(197, 28);
            label5.TabIndex = 13;
            label5.Text = "За дейности от вид: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(267, 27);
            textBox1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 28);
            label6.Name = "label6";
            label6.Size = new Size(145, 20);
            label6.TabIndex = 15;
            label6.Text = "(сортирай по текст)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(-1, 26);
            label7.Name = "label7";
            label7.Size = new Size(145, 20);
            label7.TabIndex = 19;
            label7.Text = "(сортирай по текст)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(-1, 47);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(274, 27);
            textBox2.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(-1, -2);
            label8.Name = "label8";
            label8.Size = new Size(174, 28);
            label8.TabIndex = 17;
            label8.Text = "За задачи от вид: ";
            // 
            // checkedListBox4
            // 
            checkedListBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox4.BackColor = SystemColors.ActiveCaption;
            checkedListBox4.FormattingEnabled = true;
            checkedListBox4.Location = new Point(-1, 80);
            checkedListBox4.Name = "checkedListBox4";
            checkedListBox4.Size = new Size(496, 246);
            checkedListBox4.TabIndex = 16;
            // 
            // allActivityCheckBox
            // 
            allActivityCheckBox.AutoSize = true;
            allActivityCheckBox.Location = new Point(203, 6);
            allActivityCheckBox.Name = "allActivityCheckBox";
            allActivityCheckBox.Size = new Size(79, 24);
            allActivityCheckBox.TabIndex = 20;
            allActivityCheckBox.Text = "всички";
            allActivityCheckBox.UseVisualStyleBackColor = true;
            // 
            // allTasksButton
            // 
            allTasksButton.AutoSize = true;
            allTasksButton.Location = new Point(180, 4);
            allTasksButton.Name = "allTasksButton";
            allTasksButton.Size = new Size(79, 24);
            allTasksButton.TabIndex = 21;
            allTasksButton.Text = "всички";
            allTasksButton.UseVisualStyleBackColor = true;
            // 
            // taskStatusAllCheckBox
            // 
            taskStatusAllCheckBox.AutoSize = true;
            taskStatusAllCheckBox.Location = new Point(116, 34);
            taskStatusAllCheckBox.Name = "taskStatusAllCheckBox";
            taskStatusAllCheckBox.Size = new Size(79, 24);
            taskStatusAllCheckBox.TabIndex = 24;
            taskStatusAllCheckBox.Text = "всички";
            taskStatusAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(0, 2);
            label9.Name = "label9";
            label9.Size = new Size(110, 56);
            label9.TabIndex = 23;
            label9.Text = "За задачи \r\nсъс статус: ";
            // 
            // taskStatusCheckBoxList
            // 
            taskStatusCheckBoxList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            taskStatusCheckBoxList.BackColor = SystemColors.ActiveCaption;
            taskStatusCheckBoxList.FormattingEnabled = true;
            taskStatusCheckBoxList.Items.AddRange(new object[] { "Зададена", "Завършена", "Оферта" });
            taskStatusCheckBoxList.Location = new Point(-1, 59);
            taskStatusCheckBoxList.Name = "taskStatusCheckBoxList";
            taskStatusCheckBoxList.Size = new Size(239, 202);
            taskStatusCheckBoxList.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(firstDateLabel);
            panel1.Controls.Add(firstDate);
            panel1.Controls.Add(SecondDate);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 18);
            panel1.Margin = new Padding(15);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 666);
            panel1.TabIndex = 25;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel7, 0, 1);
            tableLayoutPanel2.Controls.Add(panel8, 0, 0);
            tableLayoutPanel2.Location = new Point(1, 143);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(250, 523);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.Controls.Add(allPaymentStatusCheckBox);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(paymentStatusCheckBoxList);
            panel7.Location = new Point(3, 264);
            panel7.Name = "panel7";
            panel7.Size = new Size(244, 256);
            panel7.TabIndex = 12;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(taskStatusAllCheckBox);
            panel8.Controls.Add(label9);
            panel8.Controls.Add(taskStatusCheckBoxList);
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(244, 255);
            panel8.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Location = new Point(281, 18);
            panel2.Margin = new Padding(15);
            panel2.Name = "panel2";
            panel2.Size = new Size(507, 666);
            panel2.TabIndex = 26;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel6, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(504, 663);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(label8);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(checkedListBox4);
            panel6.Controls.Add(textBox2);
            panel6.Controls.Add(allTasksButton);
            panel6.Location = new Point(3, 334);
            panel6.Name = "panel6";
            panel6.Size = new Size(498, 326);
            panel6.TabIndex = 26;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(allActivityCheckBox);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(checkedListBox3);
            panel5.Controls.Add(textBox1);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(498, 325);
            panel5.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Location = new Point(818, 18);
            panel3.Margin = new Padding(15);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 666);
            panel3.TabIndex = 27;
            // 
            // inqueriesUserForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1080, 696);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "inqueriesUserForm";
            Text = "Wolf Archive: Справки ";
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected DateTimePicker firstDate;
        protected Label firstDateLabel;
        protected Label label1;
        protected DateTimePicker SecondDate;
        protected FlowLayoutPanel flowLayoutPanel1;
        protected Label label3;
        protected Label label4;
        protected CheckedListBox paymentStatusCheckBoxList;
        protected CheckBox allPaymentStatusCheckBox;
        protected CheckedListBox checkedListBox3;
        protected Label label5;
        protected TextBox textBox1;
        protected Label label6;
        protected Label label7;
        protected TextBox textBox2;
        protected Label label8;
        protected CheckedListBox checkedListBox4;
        protected CheckBox allActivityCheckBox;
        protected CheckBox allTasksButton;
        protected CheckBox taskStatusAllCheckBox;
        protected Label label9;
        protected CheckedListBox taskStatusCheckBoxList;
        protected Button AllTasksInqueri;
        protected Panel panel1;
        protected Panel panel2;
        protected Panel panel3;
        protected TableLayoutPanel tableLayoutPanel1;
        protected Panel panel5;
        protected Panel panel6;
        protected Panel panel8;
        protected Panel panel7;
        protected TableLayoutPanel tableLayoutPanel2;
    }
}