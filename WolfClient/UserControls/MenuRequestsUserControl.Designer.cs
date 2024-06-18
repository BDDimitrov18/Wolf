using WolfClient.NewForms;

namespace WolfClient.UserControls
{
    partial class MenuRequestsUserControl
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
            this.RequestDataGridView = new System.Windows.Forms.DataGridView();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Advance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestTableLabel = new System.Windows.Forms.Label();
            this.RequestAddButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecutantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityTableLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.RequestTitleLabel = new System.Windows.Forms.Label();
            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.ClientNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientsTableLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InvoicesDataGridView = new System.Windows.Forms.DataGridView();
            this.InvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoicesTableLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.ActivityDataGridView = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDataGridView)).BeginInit();
            this.ActivityDataGridView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequestDataGridView
            // 
            this.RequestDataGridView.AllowUserToResizeColumns = false;
            this.RequestDataGridView.AllowUserToResizeRows = false;
            this.RequestDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.RequestDataGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.RequestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestId,
            this.Price,
            this.PaymentStatus,
            this.Advance,
            this.ClientName,
            this.Comments});
            this.RequestDataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.RequestDataGridView.Location = new System.Drawing.Point(0, 67);
            this.RequestDataGridView.Name = "RequestDataGridView";
            this.RequestDataGridView.RowHeadersWidth = 51;
            this.RequestDataGridView.RowTemplate.Height = 24;
            this.RequestDataGridView.Size = new System.Drawing.Size(798, 268);
            this.RequestDataGridView.TabIndex = 0;
            // 
            // RequestId
            // 
            this.RequestId.HeaderText = "Номер";
            this.RequestId.MinimumWidth = 6;
            this.RequestId.Name = "RequestId";
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // PaymentStatus
            // 
            this.PaymentStatus.HeaderText = "Статус на Плащане";
            this.PaymentStatus.MinimumWidth = 6;
            this.PaymentStatus.Name = "PaymentStatus";
            // 
            // Advance
            // 
            this.Advance.HeaderText = "Аванс";
            this.Advance.MinimumWidth = 6;
            this.Advance.Name = "Advance";
            // 
            // ClientName
            // 
            this.ClientName.HeaderText = "Име на клиент";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            // 
            // Comments
            // 
            this.Comments.HeaderText = "Коментар";
            this.Comments.MinimumWidth = 6;
            this.Comments.Name = "Comments";
            // 
            // RequestTableLabel
            // 
            this.RequestTableLabel.AutoSize = true;
            this.RequestTableLabel.Location = new System.Drawing.Point(-3, 42);
            this.RequestTableLabel.Name = "RequestTableLabel";
            this.RequestTableLabel.Size = new System.Drawing.Size(54, 16);
            this.RequestTableLabel.TabIndex = 1;
            this.RequestTableLabel.Text = "Заявки";
            this.RequestTableLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // RequestAddButton
            // 
            this.RequestAddButton.Location = new System.Drawing.Point(57, 39);
            this.RequestAddButton.Name = "RequestAddButton";
            this.RequestAddButton.Size = new System.Drawing.Size(26, 23);
            this.RequestAddButton.TabIndex = 2;
            this.RequestAddButton.Text = "+";
            this.RequestAddButton.UseVisualStyleBackColor = true;
            this.RequestAddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activity,
            this.TaskName,
            this.ExecutantId,
            this.Date,
            this.Duration,
            this.Control,
            this.Comment});
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.Location = new System.Drawing.Point(0, 80);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(940, 185);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Дейност";
            this.Activity.MinimumWidth = 6;
            this.Activity.Name = "Activity";
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Задача";
            this.TaskName.MinimumWidth = 6;
            this.TaskName.Name = "TaskName";
            // 
            // ExecutantId
            // 
            this.ExecutantId.HeaderText = "Изпълнител";
            this.ExecutantId.MinimumWidth = 6;
            this.ExecutantId.Name = "ExecutantId";
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Времетраене";
            this.Duration.MinimumWidth = 6;
            this.Duration.Name = "Duration";
            // 
            // Control
            // 
            this.Control.HeaderText = "Контрол";
            this.Control.MinimumWidth = 6;
            this.Control.Name = "Control";
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Коментар";
            this.Comment.MinimumWidth = 6;
            this.Comment.Name = "Comment";
            // 
            // ActivityTableLabel
            // 
            this.ActivityTableLabel.AutoSize = true;
            this.ActivityTableLabel.Location = new System.Drawing.Point(-4, 54);
            this.ActivityTableLabel.Name = "ActivityTableLabel";
            this.ActivityTableLabel.Size = new System.Drawing.Size(70, 16);
            this.ActivityTableLabel.TabIndex = 4;
            this.ActivityTableLabel.Text = "Дейности";
            this.ActivityTableLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RequestTitleLabel
            // 
            this.RequestTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RequestTitleLabel.AutoSize = true;
            this.RequestTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestTitleLabel.Location = new System.Drawing.Point(604, 34);
            this.RequestTitleLabel.Name = "RequestTitleLabel";
            this.RequestTitleLabel.Size = new System.Drawing.Size(142, 42);
            this.RequestTitleLabel.TabIndex = 6;
            this.RequestTitleLabel.Text = "Заявки";
            this.RequestTitleLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.AllowUserToResizeColumns = false;
            this.clientsDataGridView.AllowUserToResizeRows = false;
            this.clientsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.clientsDataGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientNumber,
            this.FirstName,
            this.LastName,
            this.Phone,
            this.Email});
            this.clientsDataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.clientsDataGridView.Location = new System.Drawing.Point(0, 67);
            this.clientsDataGridView.Name = "clientsDataGridView";
            this.clientsDataGridView.RowHeadersWidth = 51;
            this.clientsDataGridView.RowTemplate.Height = 24;
            this.clientsDataGridView.Size = new System.Drawing.Size(459, 268);
            this.clientsDataGridView.TabIndex = 8;
            // 
            // ClientNumber
            // 
            this.ClientNumber.HeaderText = "Номер";
            this.ClientNumber.MinimumWidth = 6;
            this.ClientNumber.Name = "ClientNumber";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Име";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Фамилия";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Телефон";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // ClientsTableLabel
            // 
            this.ClientsTableLabel.AutoSize = true;
            this.ClientsTableLabel.Location = new System.Drawing.Point(3, 39);
            this.ClientsTableLabel.Name = "ClientsTableLabel";
            this.ClientsTableLabel.Size = new System.Drawing.Size(148, 16);
            this.ClientsTableLabel.TabIndex = 9;
            this.ClientsTableLabel.Text = "Клиенти На Заявката";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Път Към Заявката:";
            // 
            // InvoicesDataGridView
            // 
            this.InvoicesDataGridView.AllowUserToResizeColumns = false;
            this.InvoicesDataGridView.AllowUserToResizeRows = false;
            this.InvoicesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoicesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InvoicesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.InvoicesDataGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.InvoicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvoicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceId,
            this.Sum});
            this.InvoicesDataGridView.Location = new System.Drawing.Point(0, 80);
            this.InvoicesDataGridView.Name = "InvoicesDataGridView";
            this.InvoicesDataGridView.RowHeadersWidth = 51;
            this.InvoicesDataGridView.RowTemplate.Height = 24;
            this.InvoicesDataGridView.Size = new System.Drawing.Size(331, 185);
            this.InvoicesDataGridView.TabIndex = 11;
            // 
            // InvoiceId
            // 
            this.InvoiceId.HeaderText = "Номер";
            this.InvoiceId.MinimumWidth = 6;
            this.InvoiceId.Name = "InvoiceId";
            // 
            // Sum
            // 
            this.Sum.HeaderText = "Сума";
            this.Sum.MinimumWidth = 6;
            this.Sum.Name = "Sum";
            // 
            // InvoicesTableLabel
            // 
            this.InvoicesTableLabel.AutoSize = true;
            this.InvoicesTableLabel.Location = new System.Drawing.Point(0, 54);
            this.InvoicesTableLabel.Name = "InvoicesTableLabel";
            this.InvoicesTableLabel.Size = new System.Drawing.Size(64, 16);
            this.InvoicesTableLabel.TabIndex = 12;
            this.InvoicesTableLabel.Text = "Фактури";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(70, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ActivityDataGridView
            // 
            this.ActivityDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ActivityDataGridView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ActivityDataGridView.Controls.Add(this.ActivityTableLabel);
            this.ActivityDataGridView.Controls.Add(this.dataGridView2);
            this.ActivityDataGridView.Controls.Add(this.button2);
            this.ActivityDataGridView.Location = new System.Drawing.Point(33, 468);
            this.ActivityDataGridView.Name = "ActivityDataGridView";
            this.ActivityDataGridView.Size = new System.Drawing.Size(943, 271);
            this.ActivityDataGridView.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.InvoicesDataGridView);
            this.panel1.Controls.Add(this.InvoicesTableLabel);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(998, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 271);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.RequestDataGridView);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.RequestTableLabel);
            this.panel3.Controls.Add(this.RequestAddButton);
            this.panel3.Location = new System.Drawing.Point(33, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 335);
            this.panel3.TabIndex = 17;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.ClientsTableLabel);
            this.panel4.Controls.Add(this.clientsDataGridView);
            this.panel4.Location = new System.Drawing.Point(870, 95);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(459, 335);
            this.panel4.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MenuRequestsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ActivityDataGridView);
            this.Controls.Add(this.RequestTitleLabel);
            this.Name = "MenuRequestsUserControl";
            this.Size = new System.Drawing.Size(1350, 769);
            this.Load += new System.EventHandler(this.MenuRequestsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDataGridView)).EndInit();
            this.ActivityDataGridView.ResumeLayout(false);
            this.ActivityDataGridView.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Advance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.Label RequestTableLabel;
        private System.Windows.Forms.Button RequestAddButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecutantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Label ActivityTableLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label RequestTitleLabel;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Label ClientsTableLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView InvoicesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.Label InvoicesTableLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel ActivityDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
    }
}
