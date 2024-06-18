namespace WolfClient.NewForms
{
    partial class AddWorkObjectForm
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
            AddWorkObjectSubmitFormButton = new Button();
            panel1 = new Panel();
            NameOfWorkObjectLabel = new Label();
            NameOfWorkObjectTextBox = new TextBox();
            PriceOfWorkObjectLabel = new Label();
            PriceOfWorkObjectTextBox = new TextBox();
            AddRequestToWorkObjectComboBox = new ComboBox();
            AddRequestToWorkObjectLabel = new Label();
            AddWorkObjectTitleLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // AddWorkObjectSubmitFormButton
            // 
            AddWorkObjectSubmitFormButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddWorkObjectSubmitFormButton.Location = new Point(136, 523);
            AddWorkObjectSubmitFormButton.Margin = new Padding(3, 4, 3, 4);
            AddWorkObjectSubmitFormButton.Name = "AddWorkObjectSubmitFormButton";
            AddWorkObjectSubmitFormButton.Size = new Size(185, 55);
            AddWorkObjectSubmitFormButton.TabIndex = 14;
            AddWorkObjectSubmitFormButton.Text = "Добави Обект";
            AddWorkObjectSubmitFormButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(NameOfWorkObjectLabel);
            panel1.Controls.Add(NameOfWorkObjectTextBox);
            panel1.Controls.Add(PriceOfWorkObjectLabel);
            panel1.Controls.Add(PriceOfWorkObjectTextBox);
            panel1.Location = new Point(136, 272);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 206);
            panel1.TabIndex = 13;
            // 
            // NameOfWorkObjectLabel
            // 
            NameOfWorkObjectLabel.AutoSize = true;
            NameOfWorkObjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameOfWorkObjectLabel.Location = new Point(3, 0);
            NameOfWorkObjectLabel.Name = "NameOfWorkObjectLabel";
            NameOfWorkObjectLabel.Size = new Size(154, 25);
            NameOfWorkObjectLabel.TabIndex = 1;
            NameOfWorkObjectLabel.Text = "Име на Обекта";
            // 
            // NameOfWorkObjectTextBox
            // 
            NameOfWorkObjectTextBox.Location = new Point(8, 46);
            NameOfWorkObjectTextBox.Margin = new Padding(3, 4, 3, 4);
            NameOfWorkObjectTextBox.Name = "NameOfWorkObjectTextBox";
            NameOfWorkObjectTextBox.Size = new Size(186, 27);
            NameOfWorkObjectTextBox.TabIndex = 2;
            // 
            // PriceOfWorkObjectLabel
            // 
            PriceOfWorkObjectLabel.AutoSize = true;
            PriceOfWorkObjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PriceOfWorkObjectLabel.Location = new Point(3, 120);
            PriceOfWorkObjectLabel.Name = "PriceOfWorkObjectLabel";
            PriceOfWorkObjectLabel.Size = new Size(158, 25);
            PriceOfWorkObjectLabel.TabIndex = 3;
            PriceOfWorkObjectLabel.Text = "Цена на Обекта";
            // 
            // PriceOfWorkObjectTextBox
            // 
            PriceOfWorkObjectTextBox.Location = new Point(8, 166);
            PriceOfWorkObjectTextBox.Margin = new Padding(3, 4, 3, 4);
            PriceOfWorkObjectTextBox.Name = "PriceOfWorkObjectTextBox";
            PriceOfWorkObjectTextBox.Size = new Size(186, 27);
            PriceOfWorkObjectTextBox.TabIndex = 4;
            // 
            // AddRequestToWorkObjectComboBox
            // 
            AddRequestToWorkObjectComboBox.FormattingEnabled = true;
            AddRequestToWorkObjectComboBox.Location = new Point(136, 178);
            AddRequestToWorkObjectComboBox.Margin = new Padding(3, 4, 3, 4);
            AddRequestToWorkObjectComboBox.Name = "AddRequestToWorkObjectComboBox";
            AddRequestToWorkObjectComboBox.Size = new Size(236, 28);
            AddRequestToWorkObjectComboBox.TabIndex = 12;
            // 
            // AddRequestToWorkObjectLabel
            // 
            AddRequestToWorkObjectLabel.AutoSize = true;
            AddRequestToWorkObjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddRequestToWorkObjectLabel.Location = new Point(131, 129);
            AddRequestToWorkObjectLabel.Name = "AddRequestToWorkObjectLabel";
            AddRequestToWorkObjectLabel.Size = new Size(327, 25);
            AddRequestToWorkObjectLabel.TabIndex = 11;
            AddRequestToWorkObjectLabel.Text = "Добавяне на Обект към заявката";
            // 
            // AddWorkObjectTitleLabel
            // 
            AddWorkObjectTitleLabel.AutoSize = true;
            AddWorkObjectTitleLabel.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point);
            AddWorkObjectTitleLabel.Location = new Point(97, 34);
            AddWorkObjectTitleLabel.Name = "AddWorkObjectTitleLabel";
            AddWorkObjectTitleLabel.Size = new Size(361, 42);
            AddWorkObjectTitleLabel.TabIndex = 10;
            AddWorkObjectTitleLabel.Text = "Добавяне на Обект";
            // 
            // AddWorkObjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(549, 641);
            Controls.Add(AddWorkObjectSubmitFormButton);
            Controls.Add(panel1);
            Controls.Add(AddRequestToWorkObjectComboBox);
            Controls.Add(AddRequestToWorkObjectLabel);
            Controls.Add(AddWorkObjectTitleLabel);
            Name = "AddWorkObjectForm";
            Text = "AddWorkObjectForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddWorkObjectSubmitFormButton;
        private Panel panel1;
        private Label NameOfWorkObjectLabel;
        private TextBox NameOfWorkObjectTextBox;
        private Label PriceOfWorkObjectLabel;
        private TextBox PriceOfWorkObjectTextBox;
        private ComboBox AddRequestToWorkObjectComboBox;
        private Label AddRequestToWorkObjectLabel;
        private Label AddWorkObjectTitleLabel;
    }
}