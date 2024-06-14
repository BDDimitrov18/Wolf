namespace Wolf
{
    partial class MenuObjectsUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Executant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlotsDataGrid = new System.Windows.Forms.DataGridView();
            this.PlotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegulatedPlotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neighborhood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectDataGrid = new System.Windows.Forms.DataGridView();
            this.WorkObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Местоположение на имота: ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Път Към обекта:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 26);
            this.button3.TabIndex = 28;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 26);
            this.button2.TabIndex = 26;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(-3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Имоти в селектирания обект";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Дейности";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Обекти";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activity,
            this.Task,
            this.Executant,
            this.StartDate,
            this.Duration,
            this.Control,
            this.Comment});
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(933, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1318, 225);
            this.dataGridView1.TabIndex = 22;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Дейност";
            this.Activity.MinimumWidth = 6;
            this.Activity.Name = "Activity";
            // 
            // Task
            // 
            this.Task.HeaderText = "Задача";
            this.Task.MinimumWidth = 6;
            this.Task.Name = "Task";
            // 
            // Executant
            // 
            this.Executant.HeaderText = "Изпълнител";
            this.Executant.MinimumWidth = 6;
            this.Executant.Name = "Executant";
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Дата";
            this.StartDate.MinimumWidth = 6;
            this.StartDate.Name = "StartDate";
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
            // PlotsDataGrid
            // 
            this.PlotsDataGrid.AllowUserToResizeColumns = false;
            this.PlotsDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PlotsDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.PlotsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlotsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlotsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PlotsDataGrid.BackgroundColor = System.Drawing.Color.Moccasin;
            this.PlotsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PlotsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlotsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlotId,
            this.RegulatedPlotNumber,
            this.neighborhood,
            this.City,
            this.Municipality,
            this.Street,
            this.StreetNumber,
            this.designation,
            this.locality});
            this.PlotsDataGrid.Location = new System.Drawing.Point(0, 30);
            this.PlotsDataGrid.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.PlotsDataGrid.MinimumSize = new System.Drawing.Size(735, 249);
            this.PlotsDataGrid.Name = "PlotsDataGrid";
            this.PlotsDataGrid.RowHeadersWidth = 51;
            this.PlotsDataGrid.RowTemplate.Height = 24;
            this.PlotsDataGrid.Size = new System.Drawing.Size(860, 249);
            this.PlotsDataGrid.TabIndex = 21;
            // 
            // PlotId
            // 
            this.PlotId.HeaderText = "Номер на имота";
            this.PlotId.MinimumWidth = 6;
            this.PlotId.Name = "PlotId";
            // 
            // RegulatedPlotNumber
            // 
            this.RegulatedPlotNumber.HeaderText = "Номер на урегулиран поземлен имот";
            this.RegulatedPlotNumber.MinimumWidth = 6;
            this.RegulatedPlotNumber.Name = "RegulatedPlotNumber";
            // 
            // neighborhood
            // 
            this.neighborhood.HeaderText = "квартал";
            this.neighborhood.MinimumWidth = 6;
            this.neighborhood.Name = "neighborhood";
            // 
            // City
            // 
            this.City.HeaderText = "град/село";
            this.City.MinimumWidth = 6;
            this.City.Name = "City";
            // 
            // Municipality
            // 
            this.Municipality.HeaderText = "Община";
            this.Municipality.MinimumWidth = 6;
            this.Municipality.Name = "Municipality";
            // 
            // Street
            // 
            this.Street.HeaderText = "улица";
            this.Street.MinimumWidth = 6;
            this.Street.Name = "Street";
            // 
            // StreetNumber
            // 
            this.StreetNumber.HeaderText = "Номер На Улицата";
            this.StreetNumber.MinimumWidth = 6;
            this.StreetNumber.Name = "StreetNumber";
            // 
            // designation
            // 
            this.designation.HeaderText = "Предназначение";
            this.designation.MinimumWidth = 6;
            this.designation.Name = "designation";
            // 
            // locality
            // 
            this.locality.HeaderText = "район";
            this.locality.MinimumWidth = 6;
            this.locality.Name = "locality";
            // 
            // ObjectDataGrid
            // 
            this.ObjectDataGrid.AllowUserToResizeColumns = false;
            this.ObjectDataGrid.AllowUserToResizeRows = false;
            this.ObjectDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ObjectDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ObjectDataGrid.BackgroundColor = System.Drawing.Color.Moccasin;
            this.ObjectDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObjectDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkObjectId,
            this.NameOfObject,
            this.PriceOfObject});
            this.ObjectDataGrid.Location = new System.Drawing.Point(2, 30);
            this.ObjectDataGrid.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.ObjectDataGrid.MinimumSize = new System.Drawing.Size(401, 249);
            this.ObjectDataGrid.Name = "ObjectDataGrid";
            this.ObjectDataGrid.RowHeadersWidth = 51;
            this.ObjectDataGrid.RowTemplate.Height = 24;
            this.ObjectDataGrid.Size = new System.Drawing.Size(401, 249);
            this.ObjectDataGrid.TabIndex = 20;
            // 
            // WorkObjectId
            // 
            this.WorkObjectId.HeaderText = "Номер";
            this.WorkObjectId.MinimumWidth = 6;
            this.WorkObjectId.Name = "WorkObjectId";
            // 
            // NameOfObject
            // 
            this.NameOfObject.HeaderText = "Име на обекта";
            this.NameOfObject.MinimumWidth = 6;
            this.NameOfObject.Name = "NameOfObject";
            // 
            // PriceOfObject
            // 
            this.PriceOfObject.HeaderText = "Цена На обекта";
            this.PriceOfObject.MinimumWidth = 6;
            this.PriceOfObject.Name = "PriceOfObject";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 26);
            this.button1.TabIndex = 31;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(604, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 42);
            this.label5.TabIndex = 32;
            this.label5.Text = "Обекти";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ObjectDataGrid);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(29, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 325);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.PlotsDataGrid);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(487, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 325);
            this.panel2.TabIndex = 34;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(29, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1321, 263);
            this.panel3.TabIndex = 35;
            // 
            // MenuObjectsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Name = "MenuObjectsUserControl";
            this.Size = new System.Drawing.Size(1350, 787);
            this.Load += new System.EventHandler(this.MenuObjectsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Executant;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridView PlotsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegulatedPlotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn neighborhood;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municipality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn locality;
        private System.Windows.Forms.DataGridView ObjectDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceOfObject;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
