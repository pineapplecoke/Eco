namespace Eco
{
    partial class FormStart
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.treeViewBuilding = new System.Windows.Forms.TreeView();
            this.buttonEditWall = new System.Windows.Forms.Button();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(16, 82);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(400, 43);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete Object";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // treeViewBuilding
            // 
            this.treeViewBuilding.Location = new System.Drawing.Point(13, 63);
            this.treeViewBuilding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewBuilding.Name = "treeViewBuilding";
            this.treeViewBuilding.Size = new System.Drawing.Size(324, 453);
            this.treeViewBuilding.TabIndex = 2;
            this.treeViewBuilding.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBuilding_AfterSelect);
            this.treeViewBuilding.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewBuilding_MouseDown);
            // 
            // buttonEditWall
            // 
            this.buttonEditWall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditWall.Enabled = false;
            this.buttonEditWall.Location = new System.Drawing.Point(16, 34);
            this.buttonEditWall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditWall.Name = "buttonEditWall";
            this.buttonEditWall.Size = new System.Drawing.Size(400, 43);
            this.buttonEditWall.TabIndex = 15;
            this.buttonEditWall.Text = "Edit Object";
            this.buttonEditWall.UseVisualStyleBackColor = true;
            this.buttonEditWall.Click += new System.EventHandler(this.buttonEditWall_Click);
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateReport.Location = new System.Drawing.Point(16, 34);
            this.buttonCreateReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(400, 43);
            this.buttonCreateReport.TabIndex = 16;
            this.buttonCreateReport.Text = "Create Report";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Enabled = false;
            this.buttonCreate.Location = new System.Drawing.Point(347, 21);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(69, 43);
            this.buttonCreate.TabIndex = 18;
            this.buttonCreate.Text = "Add";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(64, 27);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(267, 27);
            this.textBoxName.TabIndex = 20;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonCreate);
            this.groupBox5.Controls.Add(this.textBoxName);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(360, 64);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(432, 78);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Add Objects";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "All Objects:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEditWall);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Location = new System.Drawing.Point(360, 156);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(432, 148);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Objects";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCreateReport);
            this.groupBox2.Location = new System.Drawing.Point(360, 320);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(432, 96);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(820, 26);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem2.Text = "Open";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem3.Text = "Save";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(360, 421);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(432, 96);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Overview";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(16, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Create Overview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 23);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(759, 105);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Location = new System.Drawing.Point(16, 523);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(775, 137);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Information";
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 681);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.treeViewBuilding);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1061, 728);
            this.MinimumSize = new System.Drawing.Size(834, 494);
            this.Name = "FormStart";
            this.Text = "Eco 1.2";
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TreeView treeViewBuilding;
        private System.Windows.Forms.Button buttonEditWall;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

