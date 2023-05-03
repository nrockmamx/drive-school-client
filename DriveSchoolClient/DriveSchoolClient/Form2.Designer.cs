namespace DriveSchoolClient
{
    partial class Form2
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
            this.textBox_SsidSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SsidSearch = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button_FingerRead = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_status = new System.Windows.Forms.Label();
            this.pictureBox_finger = new System.Windows.Forms.PictureBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox_Witdth = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox_Qulity = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox_EnrollIndex = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_BioType = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label_template = new System.Windows.Forms.Label();
            this.label_finger = new System.Windows.Forms.Label();
            this.textBox_ssidRead = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_finger)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_SsidSearch
            // 
            this.textBox_SsidSearch.Location = new System.Drawing.Point(71, 33);
            this.textBox_SsidSearch.Name = "textBox_SsidSearch";
            this.textBox_SsidSearch.Size = new System.Drawing.Size(191, 20);
            this.textBox_SsidSearch.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "เลขบัตร";
            // 
            // button_SsidSearch
            // 
            this.button_SsidSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_SsidSearch.Location = new System.Drawing.Point(284, 31);
            this.button_SsidSearch.Name = "button_SsidSearch";
            this.button_SsidSearch.Size = new System.Drawing.Size(75, 23);
            this.button_SsidSearch.TabIndex = 3;
            this.button_SsidSearch.Text = "ค้นหา";
            this.button_SsidSearch.UseVisualStyleBackColor = true;
            this.button_SsidSearch.Click += new System.EventHandler(this.button_SsidSearch_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button_FingerRead);
            this.groupBox8.Location = new System.Drawing.Point(375, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(273, 55);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "เพิ่มข้อมูล";
            // 
            // button_FingerRead
            // 
            this.button_FingerRead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_FingerRead.Location = new System.Drawing.Point(25, 19);
            this.button_FingerRead.Name = "button_FingerRead";
            this.button_FingerRead.Size = new System.Drawing.Size(83, 23);
            this.button_FingerRead.TabIndex = 6;
            this.button_FingerRead.Text = "แสกนลายนิ้วมือ";
            this.button_FingerRead.UseVisualStyleBackColor = true;
            this.button_FingerRead.Click += new System.EventHandler(this.button_FingerRead_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.textBox_ssidRead);
            this.groupBox7.Controls.Add(this.pictureBox1);
            this.groupBox7.Controls.Add(this.label_status);
            this.groupBox7.Controls.Add(this.pictureBox_finger);
            this.groupBox7.Controls.Add(this.textBox_Height);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.textBox_Witdth);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.textBox_Qulity);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.textBox_EnrollIndex);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.textBox_BioType);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Location = new System.Drawing.Point(12, 73);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(931, 343);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ลายนิ้วมือ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(633, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.label_status.ForeColor = System.Drawing.Color.Lime;
            this.label_status.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_status.Location = new System.Drawing.Point(647, 120);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(228, 42);
            this.label_status.TabIndex = 6;
            this.label_status.Text = "กำลังอ่านนิ้วมือ";
            this.label_status.Visible = false;
            // 
            // pictureBox_finger
            // 
            this.pictureBox_finger.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_finger.Location = new System.Drawing.Point(287, 19);
            this.pictureBox_finger.Name = "pictureBox_finger";
            this.pictureBox_finger.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_finger.TabIndex = 12;
            this.pictureBox_finger.TabStop = false;
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(88, 153);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.ReadOnly = true;
            this.textBox_Height.Size = new System.Drawing.Size(177, 20);
            this.textBox_Height.TabIndex = 11;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(40, 156);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(36, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "height";
            // 
            // textBox_Witdth
            // 
            this.textBox_Witdth.Location = new System.Drawing.Point(88, 127);
            this.textBox_Witdth.Name = "textBox_Witdth";
            this.textBox_Witdth.ReadOnly = true;
            this.textBox_Witdth.Size = new System.Drawing.Size(177, 20);
            this.textBox_Witdth.TabIndex = 9;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(40, 130);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 13);
            this.label25.TabIndex = 8;
            this.label25.Text = "Witdth";
            // 
            // textBox_Qulity
            // 
            this.textBox_Qulity.Location = new System.Drawing.Point(87, 101);
            this.textBox_Qulity.Name = "textBox_Qulity";
            this.textBox_Qulity.ReadOnly = true;
            this.textBox_Qulity.Size = new System.Drawing.Size(177, 20);
            this.textBox_Qulity.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(44, 104);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = "Qulity";
            // 
            // textBox_EnrollIndex
            // 
            this.textBox_EnrollIndex.Location = new System.Drawing.Point(87, 75);
            this.textBox_EnrollIndex.Name = "textBox_EnrollIndex";
            this.textBox_EnrollIndex.ReadOnly = true;
            this.textBox_EnrollIndex.Size = new System.Drawing.Size(177, 20);
            this.textBox_EnrollIndex.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(19, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Enroll Index";
            // 
            // textBox_BioType
            // 
            this.textBox_BioType.Location = new System.Drawing.Point(87, 49);
            this.textBox_BioType.Name = "textBox_BioType";
            this.textBox_BioType.ReadOnly = true;
            this.textBox_BioType.Size = new System.Drawing.Size(177, 20);
            this.textBox_BioType.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(31, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "BioType";
            // 
            // label_template
            // 
            this.label_template.AutoSize = true;
            this.label_template.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_template.Location = new System.Drawing.Point(111, 419);
            this.label_template.Name = "label_template";
            this.label_template.Size = new System.Drawing.Size(41, 13);
            this.label_template.TabIndex = 10;
            this.label_template.Text = "label27";
            this.label_template.Visible = false;
            // 
            // label_finger
            // 
            this.label_finger.AutoSize = true;
            this.label_finger.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_finger.Location = new System.Drawing.Point(32, 419);
            this.label_finger.Name = "label_finger";
            this.label_finger.Size = new System.Drawing.Size(61, 13);
            this.label_finger.TabIndex = 9;
            this.label_finger.Text = "label_finger";
            this.label_finger.Visible = false;
            // 
            // textBox_ssidRead
            // 
            this.textBox_ssidRead.Location = new System.Drawing.Point(87, 23);
            this.textBox_ssidRead.Name = "textBox_ssidRead";
            this.textBox_ssidRead.ReadOnly = true;
            this.textBox_ssidRead.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_ssidRead.Size = new System.Drawing.Size(177, 20);
            this.textBox_ssidRead.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(34, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "เลขบัตร";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(973, 450);
            this.Controls.Add(this.label_template);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.label_finger);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.textBox_SsidSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_SsidSearch);
            this.Name = "Form2";
            this.Text = "ชมพู , พาสปอท Version 1.01";
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_finger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_SsidSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_SsidSearch;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button_FingerRead;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.PictureBox pictureBox_finger;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox_Witdth;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox_Qulity;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox_EnrollIndex;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_BioType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label_template;
        private System.Windows.Forms.Label label_finger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ssidRead;
    }
}