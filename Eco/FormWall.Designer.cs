namespace Eco
{
    partial class FormWall
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(76, 29);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(102, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Items.AddRange(new object[] {
            "wood",
            "concrete",
            "masonry"});
            this.comboBoxMaterial.Location = new System.Drawing.Point(76, 64);
            this.comboBoxMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(102, 21);
            this.comboBoxMaterial.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Material";
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.DecimalPlaces = 2;
            this.numericUpDownLength.Location = new System.Drawing.Point(118, 100);
            this.numericUpDownLength.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLength.TabIndex = 4;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.DecimalPlaces = 2;
            this.numericUpDownWidth.Location = new System.Drawing.Point(118, 127);
            this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownWidth.TabIndex = 5;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.DecimalPlaces = 2;
            this.numericUpDownHeight.Location = new System.Drawing.Point(118, 155);
            this.numericUpDownHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownHeight.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Length";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Height";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(24, 194);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(62, 32);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(118, 194);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 32);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 239);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMaterial);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormWall";
            this.Text = "FormWall";
            this.Load += new System.EventHandler(this.FormWall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}