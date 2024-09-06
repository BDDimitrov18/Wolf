namespace WolfClient.NewForms
{
    partial class EditInvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditInvoiceForm));
            AddButton = new Button();
            label2 = new Label();
            NumberTextBox = new TextBox();
            SumTextBox = new TextBox();
            label3 = new Label();
            SumErrorLabel = new Label();
            InvoiceErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)InvoiceErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddButton.Location = new Point(12, 186);
            AddButton.Margin = new Padding(3, 4, 3, 4);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(141, 48);
            AddButton.TabIndex = 7;
            AddButton.Text = "Добави";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(74, 28);
            label2.TabIndex = 8;
            label2.Text = "Номер";
            // 
            // NumberTextBox
            // 
            NumberTextBox.Location = new Point(12, 49);
            NumberTextBox.Name = "NumberTextBox";
            NumberTextBox.Size = new Size(136, 27);
            NumberTextBox.TabIndex = 9;
            // 
            // SumTextBox
            // 
            SumTextBox.Location = new Point(12, 128);
            SumTextBox.Name = "SumTextBox";
            SumTextBox.Size = new Size(136, 27);
            SumTextBox.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 82);
            label3.Name = "label3";
            label3.Size = new Size(58, 28);
            label3.TabIndex = 10;
            label3.Text = "Сума";
            // 
            // SumErrorLabel
            // 
            SumErrorLabel.AutoSize = true;
            SumErrorLabel.BackColor = Color.Transparent;
            SumErrorLabel.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            SumErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            SumErrorLabel.Location = new Point(12, 110);
            SumErrorLabel.Name = "SumErrorLabel";
            SumErrorLabel.Size = new Size(147, 15);
            SumErrorLabel.TabIndex = 12;
            SumErrorLabel.Text = "Моля спазвайте формата";
            // 
            // InvoiceErrorProvider
            // 
            InvoiceErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            InvoiceErrorProvider.ContainerControl = this;
            // 
            // EditInvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(178, 239);
            Controls.Add(SumErrorLabel);
            Controls.Add(SumTextBox);
            Controls.Add(label3);
            Controls.Add(NumberTextBox);
            Controls.Add(label2);
            Controls.Add(AddButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditInvoiceForm";
            Text = "Wolf: Редактиране на фактура ";
            Load += EditInvoiceForm_Load;
            ((System.ComponentModel.ISupportInitialize)InvoiceErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Label label2;
        private TextBox NumberTextBox;
        private TextBox SumTextBox;
        private Label label3;
        private Label SumErrorLabel;
        private ErrorProvider InvoiceErrorProvider;
    }
}