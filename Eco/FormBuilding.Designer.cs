
namespace Eco
{
    partial class FormBuilding
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_postalcode = new System.Windows.Forms.TextBox();
            this.textBox_street = new System.Windows.Forms.TextBox();
            this.textBox_housenumber = new System.Windows.Forms.TextBox();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(100, 154);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 32);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(21, 154);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(62, 32);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Place";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Housenumber";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Street";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Postalcode";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_postalcode
            // 
            this.textBox_postalcode.Location = new System.Drawing.Point(100, 58);
            this.textBox_postalcode.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_postalcode.Name = "textBox_postalcode";
            this.textBox_postalcode.Size = new System.Drawing.Size(102, 20);
            this.textBox_postalcode.TabIndex = 29;
            this.textBox_postalcode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_street
            // 
            this.textBox_street.Location = new System.Drawing.Point(100, 82);
            this.textBox_street.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_street.Name = "textBox_street";
            this.textBox_street.Size = new System.Drawing.Size(102, 20);
            this.textBox_street.TabIndex = 30;
            this.textBox_street.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox_housenumber
            // 
            this.textBox_housenumber.Location = new System.Drawing.Point(100, 106);
            this.textBox_housenumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_housenumber.Name = "textBox_housenumber";
            this.textBox_housenumber.Size = new System.Drawing.Size(102, 20);
            this.textBox_housenumber.TabIndex = 31;
            this.textBox_housenumber.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox_place
            // 
            this.textBox_place.Location = new System.Drawing.Point(100, 130);
            this.textBox_place.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.Size = new System.Drawing.Size(102, 20);
            this.textBox_place.TabIndex = 32;
            this.textBox_place.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Edit Building";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(100, 33);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(102, 20);
            this.textBox_name.TabIndex = 35;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FormBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 207);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_place);
            this.Controls.Add(this.textBox_housenumber);
            this.Controls.Add(this.textBox_street);
            this.Controls.Add(this.textBox_postalcode);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormBuilding";
            this.Text = "CreateBuilding";
            this.Load += new System.EventHandler(this.FormBuilding_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_postalcode;
        private System.Windows.Forms.TextBox textBox_street;
        private System.Windows.Forms.TextBox textBox_housenumber;
        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
    }
}