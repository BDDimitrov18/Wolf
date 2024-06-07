namespace Wolf
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RequestToolStripButton = new System.Windows.Forms.ToolStripLabel();
            this.ObjectToolStripButton = new System.Windows.Forms.ToolStripLabel();
            this.ObjectDataGrid = new System.Windows.Forms.DataGridView();
            this.WorkObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Executant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RequestToolStripButton,
            this.ObjectToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1358, 31);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RequestToolStripButton
            // 
            this.RequestToolStripButton.Name = "RequestToolStripButton";
            this.RequestToolStripButton.Size = new System.Drawing.Size(57, 22);
            this.RequestToolStripButton.Text = "Заявки";
            // 
            // ObjectToolStripButton
            // 
            this.ObjectToolStripButton.Name = "ObjectToolStripButton";
            this.ObjectToolStripButton.Size = new System.Drawing.Size(59, 22);
            this.ObjectToolStripButton.Text = "Обекти";
            // 
            // ObjectDataGrid
            // 
            this.ObjectDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ObjectDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ObjectDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ObjectDataGrid.BackgroundColor = System.Drawing.SystemColors.Info;
            this.ObjectDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObjectDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkObjectId,
            this.NameOfObject,
            this.PriceOfObject});
            this.ObjectDataGrid.Location = new System.Drawing.Point(0, 75);
            this.ObjectDataGrid.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.ObjectDataGrid.MinimumSize = new System.Drawing.Size(401, 249);
            this.ObjectDataGrid.Name = "ObjectDataGrid";
            this.ObjectDataGrid.RowHeadersWidth = 51;
            this.ObjectDataGrid.RowTemplate.Height = 24;
            this.ObjectDataGrid.Size = new System.Drawing.Size(401, 249);
            this.ObjectDataGrid.TabIndex = 6;
            this.ObjectDataGrid.Visible = false;
            // 
            // WorkObjectId
            // 
            this.WorkObjectId.HeaderText = "Номер";
            this.WorkObjectId.MinimumWidth = 6;
            this.WorkObjectId.Name = "WorkObjectId";
            this.WorkObjectId.Width = 79;
            // 
            // NameOfObject
            // 
            this.NameOfObject.HeaderText = "Име на обекта";
            this.NameOfObject.MinimumWidth = 6;
            this.NameOfObject.Name = "NameOfObject";
            this.NameOfObject.Width = 120;
            // 
            // PriceOfObject
            // 
            this.PriceOfObject.HeaderText = "Цена На обекта";
            this.PriceOfObject.MinimumWidth = 6;
            this.PriceOfObject.Name = "PriceOfObject";
            this.PriceOfObject.Width = 128;
            // 
            // PlotsDataGrid
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PlotsDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.PlotsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PlotsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PlotsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PlotsDataGrid.BackgroundColor = System.Drawing.SystemColors.Info;
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
            this.PlotsDataGrid.Location = new System.Drawing.Point(457, 75);
            this.PlotsDataGrid.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.PlotsDataGrid.MinimumSize = new System.Drawing.Size(735, 249);
            this.PlotsDataGrid.Name = "PlotsDataGrid";
            this.PlotsDataGrid.RowHeadersWidth = 51;
            this.PlotsDataGrid.RowTemplate.Height = 24;
            this.PlotsDataGrid.Size = new System.Drawing.Size(892, 249);
            this.PlotsDataGrid.TabIndex = 7;
            this.PlotsDataGrid.Visible = false;
            // 
            // PlotId
            // 
            this.PlotId.HeaderText = "Номер на имота";
            this.PlotId.MinimumWidth = 6;
            this.PlotId.Name = "PlotId";
            this.PlotId.Width = 129;
            // 
            // RegulatedPlotNumber
            // 
            this.RegulatedPlotNumber.HeaderText = "Номер на урегулиран поземлен имот";
            this.RegulatedPlotNumber.MinimumWidth = 6;
            this.RegulatedPlotNumber.Name = "RegulatedPlotNumber";
            this.RegulatedPlotNumber.Width = 227;
            // 
            // neighborhood
            // 
            this.neighborhood.HeaderText = "квартал";
            this.neighborhood.MinimumWidth = 6;
            this.neighborhood.Name = "neighborhood";
            this.neighborhood.Width = 90;
            // 
            // City
            // 
            this.City.HeaderText = "град/село";
            this.City.MinimumWidth = 6;
            this.City.Name = "City";
            this.City.Width = 101;
            // 
            // Municipality
            // 
            this.Municipality.HeaderText = "Община";
            this.Municipality.MinimumWidth = 6;
            this.Municipality.Name = "Municipality";
            this.Municipality.Width = 87;
            // 
            // Street
            // 
            this.Street.HeaderText = "улица";
            this.Street.MinimumWidth = 6;
            this.Street.Name = "Street";
            this.Street.Width = 76;
            // 
            // StreetNumber
            // 
            this.StreetNumber.HeaderText = "Номер На Улицата";
            this.StreetNumber.MinimumWidth = 6;
            this.StreetNumber.Name = "StreetNumber";
            this.StreetNumber.Width = 146;
            // 
            // designation
            // 
            this.designation.HeaderText = "Предназначение";
            this.designation.MinimumWidth = 6;
            this.designation.Name = "designation";
            this.designation.Width = 150;
            // 
            // locality
            // 
            this.locality.HeaderText = "район";
            this.locality.MinimumWidth = 6;
            this.locality.Name = "locality";
            this.locality.Width = 76;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activity,
            this.Task,
            this.Executant,
            this.StartDate,
            this.Duration,
            this.Control,
            this.Comment});
            this.dataGridView1.Location = new System.Drawing.Point(0, 453);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(933, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(933, 150);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.Visible = false;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Дейност";
            this.Activity.MinimumWidth = 6;
            this.Activity.Name = "Activity";
            this.Activity.Width = 125;
            // 
            // Task
            // 
            this.Task.HeaderText = "Задача";
            this.Task.MinimumWidth = 6;
            this.Task.Name = "Task";
            this.Task.Width = 125;
            // 
            // Executant
            // 
            this.Executant.HeaderText = "Изпълнител";
            this.Executant.MinimumWidth = 6;
            this.Executant.Name = "Executant";
            this.Executant.Width = 125;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Дата";
            this.StartDate.MinimumWidth = 6;
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 125;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Времетраене";
            this.Duration.MinimumWidth = 6;
            this.Duration.Name = "Duration";
            this.Duration.Width = 125;
            // 
            // Control
            // 
            this.Control.HeaderText = "Контрол";
            this.Control.MinimumWidth = 6;
            this.Control.Name = "Control";
            this.Control.Width = 125;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Коментар";
            this.Comment.MinimumWidth = 6;
            this.Comment.Name = "Comment";
            this.Comment.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Обекти";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Дейности";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Имоти в селектирания обект";
            this.label3.Visible = false;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(70, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 26);
            this.button2.TabIndex = 14;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(656, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(85, 423);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 26);
            this.button3.TabIndex = 16;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Път Към обекта:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Местоположение на имота: ";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1358, 635);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PlotsDataGrid);
            this.Controls.Add(this.ObjectDataGrid);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel RequestToolStripButton;
        private System.Windows.Forms.ToolStripLabel ObjectToolStripButton;
        private System.Windows.Forms.DataGridView ObjectDataGrid;
        private System.Windows.Forms.DataGridView PlotsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceOfObject;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Executant;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegulatedPlotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn neighborhood;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municipality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn locality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}

