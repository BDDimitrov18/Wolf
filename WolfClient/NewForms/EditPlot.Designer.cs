namespace WolfClient.NewForms
{
    partial class EditPlot
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
            components = new System.ComponentModel.Container();
            AddPlotToObjectSubmitButton = new Button();
            StreetTextBox = new TextBox();
            StreetNumberTextBox = new TextBox();
            NeighborhoodTextBox = new TextBox();
            RegulatedNumberTextBox = new TextBox();
            DesignationComboBox = new ComboBox();
            DesignationLabel = new Label();
            StreetNumberLabel = new Label();
            StreetLabel = new Label();
            neighborhoodLabel = new Label();
            RegulatedNumberLabel = new Label();
            localityLabel = new Label();
            Municipality = new Label();
            CityLabel = new Label();
            PlotNumberComboBox = new ComboBox();
            PlotNumberLabel = new Label();
            AddPlotInObjectTitleLabel = new Label();
            CityTextBox = new TextBox();
            MunicipalityTextBox = new TextBox();
            LocalityTextBox = new TextBox();
            plotNumberValidationLabel = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // AddPlotToObjectSubmitButton
            // 
            AddPlotToObjectSubmitButton.Location = new Point(354, 605);
            AddPlotToObjectSubmitButton.Margin = new Padding(3, 4, 3, 4);
            AddPlotToObjectSubmitButton.Name = "AddPlotToObjectSubmitButton";
            AddPlotToObjectSubmitButton.Size = new Size(152, 46);
            AddPlotToObjectSubmitButton.TabIndex = 48;
            AddPlotToObjectSubmitButton.Text = "Залагане";
            AddPlotToObjectSubmitButton.UseVisualStyleBackColor = true;
            AddPlotToObjectSubmitButton.Click += AddPlotToObjectSubmitButton_Click;
            // 
            // StreetTextBox
            // 
            StreetTextBox.Location = new Point(329, 404);
            StreetTextBox.Margin = new Padding(3, 4, 3, 4);
            StreetTextBox.Name = "StreetTextBox";
            StreetTextBox.Size = new Size(208, 27);
            StreetTextBox.TabIndex = 47;
            // 
            // StreetNumberTextBox
            // 
            StreetNumberTextBox.Location = new Point(329, 529);
            StreetNumberTextBox.Margin = new Padding(3, 4, 3, 4);
            StreetNumberTextBox.Name = "StreetNumberTextBox";
            StreetNumberTextBox.Size = new Size(208, 27);
            StreetNumberTextBox.TabIndex = 46;
            // 
            // NeighborhoodTextBox
            // 
            NeighborhoodTextBox.Location = new Point(329, 280);
            NeighborhoodTextBox.Margin = new Padding(3, 4, 3, 4);
            NeighborhoodTextBox.Name = "NeighborhoodTextBox";
            NeighborhoodTextBox.Size = new Size(208, 27);
            NeighborhoodTextBox.TabIndex = 45;
            // 
            // RegulatedNumberTextBox
            // 
            RegulatedNumberTextBox.Location = new Point(329, 167);
            RegulatedNumberTextBox.Margin = new Padding(3, 4, 3, 4);
            RegulatedNumberTextBox.Name = "RegulatedNumberTextBox";
            RegulatedNumberTextBox.Size = new Size(208, 27);
            RegulatedNumberTextBox.TabIndex = 44;
            // 
            // DesignationComboBox
            // 
            DesignationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DesignationComboBox.FormattingEnabled = true;
            DesignationComboBox.Items.AddRange(new object[] { "горска територия", "урбанизирана", "територия на транспорта", "замеделска", "територия заета от води и водни обекти", "защитена", "нарушена", "урбанизирана територия - защитена", "замеделска територия - защитена", "горска територия - защитена" });
            DesignationComboBox.Location = new Point(40, 625);
            DesignationComboBox.Margin = new Padding(3, 4, 3, 4);
            DesignationComboBox.Name = "DesignationComboBox";
            DesignationComboBox.Size = new Size(208, 28);
            DesignationComboBox.TabIndex = 43;
            // 
            // DesignationLabel
            // 
            DesignationLabel.AutoSize = true;
            DesignationLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DesignationLabel.Location = new Point(40, 574);
            DesignationLabel.Name = "DesignationLabel";
            DesignationLabel.Size = new Size(168, 25);
            DesignationLabel.TabIndex = 42;
            DesignationLabel.Text = "Предназначение";
            // 
            // StreetNumberLabel
            // 
            StreetNumberLabel.AutoSize = true;
            StreetNumberLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StreetNumberLabel.Location = new Point(324, 478);
            StreetNumberLabel.Name = "StreetNumberLabel";
            StreetNumberLabel.Size = new Size(182, 25);
            StreetNumberLabel.TabIndex = 41;
            StreetNumberLabel.Text = "Номер на улицата";
            // 
            // StreetLabel
            // 
            StreetLabel.AutoSize = true;
            StreetLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StreetLabel.Location = new Point(329, 353);
            StreetLabel.Name = "StreetLabel";
            StreetLabel.Size = new Size(69, 25);
            StreetLabel.TabIndex = 40;
            StreetLabel.Text = "Улица";
            // 
            // neighborhoodLabel
            // 
            neighborhoodLabel.AutoSize = true;
            neighborhoodLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            neighborhoodLabel.Location = new Point(329, 229);
            neighborhoodLabel.Name = "neighborhoodLabel";
            neighborhoodLabel.Size = new Size(89, 25);
            neighborhoodLabel.TabIndex = 39;
            neighborhoodLabel.Text = "Квартал";
            // 
            // RegulatedNumberLabel
            // 
            RegulatedNumberLabel.AutoSize = true;
            RegulatedNumberLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RegulatedNumberLabel.Location = new Point(323, 108);
            RegulatedNumberLabel.Name = "RegulatedNumberLabel";
            RegulatedNumberLabel.Size = new Size(214, 50);
            RegulatedNumberLabel.TabIndex = 38;
            RegulatedNumberLabel.Text = "Номер на урегулиран \r\nпоземлен имот";
            // 
            // localityLabel
            // 
            localityLabel.AutoSize = true;
            localityLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localityLabel.Location = new Point(35, 477);
            localityLabel.Name = "localityLabel";
            localityLabel.Size = new Size(82, 25);
            localityLabel.TabIndex = 36;
            localityLabel.Text = "Област";
            // 
            // Municipality
            // 
            Municipality.AutoSize = true;
            Municipality.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Municipality.Location = new Point(35, 353);
            Municipality.Name = "Municipality";
            Municipality.Size = new Size(87, 25);
            Municipality.TabIndex = 34;
            Municipality.Text = "Община";
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CityLabel.Location = new Point(35, 229);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(167, 25);
            CityLabel.TabIndex = 32;
            CityLabel.Text = "Населено място";
            // 
            // PlotNumberComboBox
            // 
            PlotNumberComboBox.FormattingEnabled = true;
            PlotNumberComboBox.Location = new Point(40, 167);
            PlotNumberComboBox.Margin = new Padding(3, 4, 3, 4);
            PlotNumberComboBox.Name = "PlotNumberComboBox";
            PlotNumberComboBox.Size = new Size(208, 28);
            PlotNumberComboBox.TabIndex = 31;
            PlotNumberComboBox.TextChanged += PlotNumberComboBox_TextChanged;
            // 
            // PlotNumberLabel
            // 
            PlotNumberLabel.AutoSize = true;
            PlotNumberLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PlotNumberLabel.Location = new Point(35, 116);
            PlotNumberLabel.Name = "PlotNumberLabel";
            PlotNumberLabel.Size = new Size(167, 25);
            PlotNumberLabel.TabIndex = 30;
            PlotNumberLabel.Text = "Номер на имота";
            // 
            // AddPlotInObjectTitleLabel
            // 
            AddPlotInObjectTitleLabel.AutoSize = true;
            AddPlotInObjectTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            AddPlotInObjectTitleLabel.Location = new Point(100, 23);
            AddPlotInObjectTitleLabel.Name = "AddPlotInObjectTitleLabel";
            AddPlotInObjectTitleLabel.Size = new Size(395, 42);
            AddPlotInObjectTitleLabel.TabIndex = 29;
            AddPlotInObjectTitleLabel.Text = "Редактиране на имот";
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(40, 280);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(208, 27);
            CityTextBox.TabIndex = 51;
            // 
            // MunicipalityTextBox
            // 
            MunicipalityTextBox.Location = new Point(40, 391);
            MunicipalityTextBox.Name = "MunicipalityTextBox";
            MunicipalityTextBox.Size = new Size(208, 27);
            MunicipalityTextBox.TabIndex = 52;
            // 
            // LocalityTextBox
            // 
            LocalityTextBox.Location = new Point(40, 519);
            LocalityTextBox.Name = "LocalityTextBox";
            LocalityTextBox.Size = new Size(208, 27);
            LocalityTextBox.TabIndex = 53;
            // 
            // plotNumberValidationLabel
            // 
            plotNumberValidationLabel.AutoSize = true;
            plotNumberValidationLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            plotNumberValidationLabel.ForeColor = SystemColors.GradientActiveCaption;
            plotNumberValidationLabel.Location = new Point(40, 143);
            plotNumberValidationLabel.Name = "plotNumberValidationLabel";
            plotNumberValidationLabel.Size = new Size(267, 15);
            plotNumberValidationLabel.TabIndex = 54;
            plotNumberValidationLabel.Text = "Невалиден формат. (######.####.####.??.????)";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditPlot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(574, 664);
            Controls.Add(plotNumberValidationLabel);
            Controls.Add(LocalityTextBox);
            Controls.Add(MunicipalityTextBox);
            Controls.Add(CityTextBox);
            Controls.Add(AddPlotToObjectSubmitButton);
            Controls.Add(StreetTextBox);
            Controls.Add(StreetNumberTextBox);
            Controls.Add(NeighborhoodTextBox);
            Controls.Add(RegulatedNumberTextBox);
            Controls.Add(DesignationComboBox);
            Controls.Add(DesignationLabel);
            Controls.Add(StreetNumberLabel);
            Controls.Add(StreetLabel);
            Controls.Add(neighborhoodLabel);
            Controls.Add(RegulatedNumberLabel);
            Controls.Add(localityLabel);
            Controls.Add(Municipality);
            Controls.Add(CityLabel);
            Controls.Add(PlotNumberComboBox);
            Controls.Add(PlotNumberLabel);
            Controls.Add(AddPlotInObjectTitleLabel);
            Name = "EditPlot";
            Text = "AddPlotToObject";
            Load += AddPlotToObject_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddPlotToObjectSubmitButton;
        private TextBox StreetTextBox;
        private TextBox StreetNumberTextBox;
        private TextBox NeighborhoodTextBox;
        private TextBox RegulatedNumberTextBox;
        private ComboBox DesignationComboBox;
        private Label DesignationLabel;
        private Label StreetNumberLabel;
        private Label StreetLabel;
        private Label neighborhoodLabel;
        private Label RegulatedNumberLabel;
        private Label localityLabel;
        private Label Municipality;
        private Label CityLabel;
        private ComboBox PlotNumberComboBox;
        private Label PlotNumberLabel;
        private Label AddPlotInObjectTitleLabel;
        private TextBox CityTextBox;
        private TextBox MunicipalityTextBox;
        private TextBox LocalityTextBox;
        private Label plotNumberValidationLabel;
        private ErrorProvider errorProvider;
    }
}