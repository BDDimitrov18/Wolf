using WolfClient.NewForms;
namespace WolfClient.UserControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DestinationOfPlotLabel = new System.Windows.Forms.Label();
            this.PathToObjectFileLabel = new System.Windows.Forms.Label();
            this.ActivityAddButton = new System.Windows.Forms.Button();
            this.WorkObjectsAddButton = new System.Windows.Forms.Button();
            this.PlotsTableLabel = new System.Windows.Forms.Label();
            this.ActivityTableLabel = new System.Windows.Forms.Label();
            this.WorkObjectsTableLabel = new System.Windows.Forms.Label();
            this.ActivityDataGridView = new System.Windows.Forms.DataGridView();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Executant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlotsDataGridView = new System.Windows.Forms.DataGridView();
            this.PlotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegulatedPlotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neighborhood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkObjectDataGridView = new System.Windows.Forms.DataGridView();
            this.WorkObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlotsAddButton = new System.Windows.Forms.Button();
            this.ObjectsTitleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkObjectDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DestinationOfPlotLabel
            // 
            this.DestinationOfPlotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationOfPlotLabel.AutoSize = true;
            this.DestinationOfPlotLabel.Location = new System.Drawing.Point(4, 297);
            this.DestinationOfPlotLabel.Name = "DestinationOfPlotLabel";
            this.DestinationOfPlotLabel.Size = new System.Drawing.Size(189, 16);
            this.DestinationOfPlotLabel.TabIndex = 30;
            this.DestinationOfPlotLabel.Text = "Местоположение на имота: ";
            this.DestinationOfPlotLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // PathToObjectFileLabel
            // 
            this.PathToObjectFileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PathToObjectFileLabel.AutoSize = true;
            this.PathToObjectFileLabel.Location = new System.Drawing.Point(-1, 297);
            this.PathToObjectFileLabel.Name = "PathToObjectFileLabel";
            this.PathToObjectFileLabel.Size = new System.Drawing.Size(114, 16);
            this.PathToObjectFileLabel.TabIndex = 29;
            this.PathToObjectFileLabel.Text = "Път Към обекта:";
            // 
            // ActivityAddButton
            // 
            this.ActivityAddButton.Location = new System.Drawing.Point(89, 8);
            this.ActivityAddButton.Name = "ActivityAddButton";
            this.ActivityAddButton.Size = new System.Drawing.Size(24, 26);
            this.ActivityAddButton.TabIndex = 28;
            this.ActivityAddButton.Text = "+";
            this.ActivityAddButton.UseVisualStyleBackColor = true;
            this.ActivityAddButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // WorkObjectsAddButton
            // 
            this.WorkObjectsAddButton.Location = new System.Drawing.Point(72, 2);
            this.WorkObjectsAddButton.Name = "WorkObjectsAddButton";
            this.WorkObjectsAddButton.Size = new System.Drawing.Size(24, 26);
            this.WorkObjectsAddButton.TabIndex = 26;
            this.WorkObjectsAddButton.Text = "+";
            this.WorkObjectsAddButton.UseVisualStyleBackColor = true;
            this.WorkObjectsAddButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // PlotsTableLabel
            // 
            this.PlotsTableLabel.AutoSize = true;
            this.PlotsTableLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlotsTableLabel.Location = new System.Drawing.Point(-3, 7);
            this.PlotsTableLabel.Name = "PlotsTableLabel";
            this.PlotsTableLabel.Size = new System.Drawing.Size(196, 16);
            this.PlotsTableLabel.TabIndex = 25;
            this.PlotsTableLabel.Text = "Имоти в селектирания обект";
            // 
            // ActivityTableLabel
            // 
            this.ActivityTableLabel.AutoSize = true;
            this.ActivityTableLabel.Location = new System.Drawing.Point(13, 13);
            this.ActivityTableLabel.Name = "ActivityTableLabel";
            this.ActivityTableLabel.Size = new System.Drawing.Size(70, 16);
            this.ActivityTableLabel.TabIndex = 24;
            this.ActivityTableLabel.Text = "Дейности";
            // 
            // WorkObjectsTableLabel
            // 
            this.WorkObjectsTableLabel.AutoSize = true;
            this.WorkObjectsTableLabel.Location = new System.Drawing.Point(11, 7);
            this.WorkObjectsTableLabel.Name = "WorkObjectsTableLabel";
            this.WorkObjectsTableLabel.Size = new System.Drawing.Size(55, 16);
            this.WorkObjectsTableLabel.TabIndex = 23;
            this.WorkObjectsTableLabel.Text = "Обекти";
            this.WorkObjectsTableLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // ActivityDataGridView
            // 
            this.ActivityDataGridView.AllowUserToResizeColumns = false;
            this.ActivityDataGridView.AllowUserToResizeRows = false;
            this.ActivityDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivityDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ActivityDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ActivityDataGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.ActivityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActivityDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activity,
            this.Task,
            this.Executant,
            this.StartDate,
            this.Duration,
            this.Control,
            this.Comment});
            this.ActivityDataGridView.Location = new System.Drawing.Point(0, 38);
            this.ActivityDataGridView.MinimumSize = new System.Drawing.Size(933, 150);
            this.ActivityDataGridView.Name = "ActivityDataGridView";
            this.ActivityDataGridView.RowHeadersWidth = 51;
            this.ActivityDataGridView.RowTemplate.Height = 24;
            this.ActivityDataGridView.Size = new System.Drawing.Size(1318, 225);
            this.ActivityDataGridView.TabIndex = 22;
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
            // PlotsDataGridView
            // 
            this.PlotsDataGridView.AllowUserToResizeColumns = false;
            this.PlotsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PlotsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.PlotsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlotsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlotsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PlotsDataGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.PlotsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PlotsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlotsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlotId,
            this.RegulatedPlotNumber,
            this.neighborhood,
            this.City,
            this.Municipality,
            this.Street,
            this.StreetNumber,
            this.designation,
            this.locality});
            this.PlotsDataGridView.Location = new System.Drawing.Point(0, 30);
            this.PlotsDataGridView.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.PlotsDataGridView.MinimumSize = new System.Drawing.Size(735, 249);
            this.PlotsDataGridView.Name = "PlotsDataGridView";
            this.PlotsDataGridView.RowHeadersWidth = 51;
            this.PlotsDataGridView.RowTemplate.Height = 24;
            this.PlotsDataGridView.Size = new System.Drawing.Size(860, 249);
            this.PlotsDataGridView.TabIndex = 21;
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
            // WorkObjectDataGridView
            // 
            this.WorkObjectDataGridView.AllowUserToResizeColumns = false;
            this.WorkObjectDataGridView.AllowUserToResizeRows = false;
            this.WorkObjectDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkObjectDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.WorkObjectDataGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.WorkObjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkObjectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkObjectId,
            this.NameOfObject,
            this.PriceOfObject});
            this.WorkObjectDataGridView.Location = new System.Drawing.Point(2, 30);
            this.WorkObjectDataGridView.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.WorkObjectDataGridView.MinimumSize = new System.Drawing.Size(401, 249);
            this.WorkObjectDataGridView.Name = "WorkObjectDataGridView";
            this.WorkObjectDataGridView.RowHeadersWidth = 51;
            this.WorkObjectDataGridView.RowTemplate.Height = 24;
            this.WorkObjectDataGridView.Size = new System.Drawing.Size(401, 249);
            this.WorkObjectDataGridView.TabIndex = 20;
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
            // PlotsAddButton
            // 
            this.PlotsAddButton.Location = new System.Drawing.Point(205, 2);
            this.PlotsAddButton.Name = "PlotsAddButton";
            this.PlotsAddButton.Size = new System.Drawing.Size(24, 26);
            this.PlotsAddButton.TabIndex = 31;
            this.PlotsAddButton.Text = "+";
            this.PlotsAddButton.UseVisualStyleBackColor = true;
            this.PlotsAddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ObjectsTitleLabel
            // 
            this.ObjectsTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ObjectsTitleLabel.AutoSize = true;
            this.ObjectsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectsTitleLabel.Location = new System.Drawing.Point(604, 34);
            this.ObjectsTitleLabel.Name = "ObjectsTitleLabel";
            this.ObjectsTitleLabel.Size = new System.Drawing.Size(146, 42);
            this.ObjectsTitleLabel.TabIndex = 32;
            this.ObjectsTitleLabel.Text = "Обекти";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WorkObjectDataGridView);
            this.panel1.Controls.Add(this.WorkObjectsTableLabel);
            this.panel1.Controls.Add(this.WorkObjectsAddButton);
            this.panel1.Controls.Add(this.PathToObjectFileLabel);
            this.panel1.Location = new System.Drawing.Point(29, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 325);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.PlotsTableLabel);
            this.panel2.Controls.Add(this.PlotsDataGridView);
            this.panel2.Controls.Add(this.PlotsAddButton);
            this.panel2.Controls.Add(this.DestinationOfPlotLabel);
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
            this.panel3.Controls.Add(this.ActivityTableLabel);
            this.panel3.Controls.Add(this.ActivityDataGridView);
            this.panel3.Controls.Add(this.ActivityAddButton);
            this.panel3.Location = new System.Drawing.Point(29, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1321, 263);
            this.panel3.TabIndex = 35;
            // 
            // MenuObjectsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ObjectsTitleLabel);
            this.Name = "MenuObjectsUserControl";
            this.Size = new System.Drawing.Size(1350, 787);
            this.Load += new System.EventHandler(this.MenuObjectsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActivityDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkObjectDataGridView)).EndInit();
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

        private System.Windows.Forms.Label DestinationOfPlotLabel;
        private System.Windows.Forms.Label PathToObjectFileLabel;
        private System.Windows.Forms.Button ActivityAddButton;
        private System.Windows.Forms.Button WorkObjectsAddButton;
        private System.Windows.Forms.Label PlotsTableLabel;
        private System.Windows.Forms.Label ActivityTableLabel;
        private System.Windows.Forms.Label WorkObjectsTableLabel;
        private System.Windows.Forms.DataGridView ActivityDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Executant;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridView PlotsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegulatedPlotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn neighborhood;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municipality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn locality;
        private System.Windows.Forms.DataGridView WorkObjectDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceOfObject;
        private System.Windows.Forms.Button PlotsAddButton;
        private System.Windows.Forms.Label ObjectsTitleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
