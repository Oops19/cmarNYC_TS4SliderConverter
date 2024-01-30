namespace TS4SliderConverter
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
            this.components = new System.ComponentModel.Container();
            this.PackageSelect_button = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.FolderSelect_button = new System.Windows.Forms.Button();
            this.OutputSelect_button = new System.Windows.Forms.Button();
            this.FolderName = new System.Windows.Forms.TextBox();
            this.OutputName = new System.Windows.Forms.TextBox();
            this.FolderGo_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Subfolders_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoCopy_checkBox = new System.Windows.Forms.CheckBox();
            this.NoRename_checkBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PackageSelect_button
            // 
            this.PackageSelect_button.Location = new System.Drawing.Point(22, 21);
            this.PackageSelect_button.Name = "PackageSelect_button";
            this.PackageSelect_button.Size = new System.Drawing.Size(658, 64);
            this.PackageSelect_button.TabIndex = 2;
            this.PackageSelect_button.Text = "Select Package - sliders will be updated to latest version";
            this.PackageSelect_button.UseVisualStyleBackColor = true;
            this.PackageSelect_button.Click += new System.EventHandler(this.PackageSelect_button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "OR";
            // 
            // FolderSelect_button
            // 
            this.FolderSelect_button.Location = new System.Drawing.Point(0, 19);
            this.FolderSelect_button.Name = "FolderSelect_button";
            this.FolderSelect_button.Size = new System.Drawing.Size(165, 31);
            this.FolderSelect_button.TabIndex = 7;
            this.FolderSelect_button.Text = "Select Input Folder";
            this.FolderSelect_button.UseVisualStyleBackColor = true;
            this.FolderSelect_button.Click += new System.EventHandler(this.FolderSelect_button_Click);
            // 
            // OutputSelect_button
            // 
            this.OutputSelect_button.Location = new System.Drawing.Point(0, 56);
            this.OutputSelect_button.Name = "OutputSelect_button";
            this.OutputSelect_button.Size = new System.Drawing.Size(165, 31);
            this.OutputSelect_button.TabIndex = 22;
            this.OutputSelect_button.Text = "Select Output Folder";
            this.OutputSelect_button.UseVisualStyleBackColor = true;
            this.OutputSelect_button.Click += new System.EventHandler(this.OutputSelect_button_Click);
            // 
            // FolderName
            // 
            this.FolderName.Location = new System.Drawing.Point(171, 25);
            this.FolderName.Name = "FolderName";
            this.FolderName.Size = new System.Drawing.Size(424, 20);
            this.FolderName.TabIndex = 23;
            // 
            // OutputName
            // 
            this.OutputName.Location = new System.Drawing.Point(171, 62);
            this.OutputName.Name = "OutputName";
            this.OutputName.Size = new System.Drawing.Size(424, 20);
            this.OutputName.TabIndex = 24;
            // 
            // FolderGo_button
            // 
            this.FolderGo_button.Location = new System.Drawing.Point(601, 25);
            this.FolderGo_button.Name = "FolderGo_button";
            this.FolderGo_button.Size = new System.Drawing.Size(57, 57);
            this.FolderGo_button.TabIndex = 26;
            this.FolderGo_button.Text = "Go";
            this.FolderGo_button.UseVisualStyleBackColor = true;
            this.FolderGo_button.Click += new System.EventHandler(this.FolderGo_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Subfolders_checkBox);
            this.groupBox2.Controls.Add(this.FolderSelect_button);
            this.groupBox2.Controls.Add(this.OutputSelect_button);
            this.groupBox2.Controls.Add(this.FolderGo_button);
            this.groupBox2.Controls.Add(this.FolderName);
            this.groupBox2.Controls.Add(this.OutputName);
            this.groupBox2.Location = new System.Drawing.Point(22, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 121);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All packages in input folder will be processed and saved in output folder";
            // 
            // Subfolders_checkBox
            // 
            this.Subfolders_checkBox.AutoSize = true;
            this.Subfolders_checkBox.Checked = true;
            this.Subfolders_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Subfolders_checkBox.Location = new System.Drawing.Point(0, 93);
            this.Subfolders_checkBox.Name = "Subfolders_checkBox";
            this.Subfolders_checkBox.Size = new System.Drawing.Size(115, 17);
            this.Subfolders_checkBox.TabIndex = 27;
            this.Subfolders_checkBox.Text = "Include sub-folders";
            this.Subfolders_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoCopy_checkBox);
            this.groupBox1.Controls.Add(this.NoRename_checkBox);
            this.groupBox1.Location = new System.Drawing.Point(22, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 58);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conversion options:";
            // 
            // NoCopy_checkBox
            // 
            this.NoCopy_checkBox.AutoSize = true;
            this.NoCopy_checkBox.Checked = true;
            this.NoCopy_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoCopy_checkBox.Location = new System.Drawing.Point(243, 19);
            this.NoCopy_checkBox.Name = "NoCopy_checkBox";
            this.NoCopy_checkBox.Size = new System.Drawing.Size(184, 17);
            this.NoCopy_checkBox.TabIndex = 29;
            this.NoCopy_checkBox.Text = "Don\'t copy unchanged packages";
            this.NoCopy_checkBox.UseVisualStyleBackColor = true;
            // 
            // NoRename_checkBox
            // 
            this.NoRename_checkBox.AutoSize = true;
            this.NoRename_checkBox.Location = new System.Drawing.Point(7, 19);
            this.NoRename_checkBox.Name = "NoRename_checkBox";
            this.NoRename_checkBox.Size = new System.Drawing.Size(169, 17);
            this.NoRename_checkBox.TabIndex = 28;
            this.NoRename_checkBox.Text = "Don\'t change package names";
            this.NoRename_checkBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PackageSelect_button);
            this.Name = "Form1";
            this.Text = "TS4 Slider Converter v1.1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PackageSelect_button;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FolderSelect_button;
        private System.Windows.Forms.Button OutputSelect_button;
        private System.Windows.Forms.TextBox FolderName;
        private System.Windows.Forms.TextBox OutputName;
        private System.Windows.Forms.Button FolderGo_button;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Subfolders_checkBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox NoCopy_checkBox;
        private System.Windows.Forms.CheckBox NoRename_checkBox;
    }
}

