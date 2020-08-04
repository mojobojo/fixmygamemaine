namespace fixmygamemaine {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.yaw_text = new System.Windows.Forms.Label();
            this.pitch_text = new System.Windows.Forms.Label();
            this.roll_text = new System.Windows.Forms.Label();
            this.x_text = new System.Windows.Forms.Label();
            this.y_text = new System.Windows.Forms.Label();
            this.z_text = new System.Windows.Forms.Label();
            this.hp_text = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 194);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(475, 498);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.Location = new System.Drawing.Point(105, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(288, 174);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(502, 10);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(431, 680);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // yaw_text
            // 
            this.yaw_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yaw_text.AutoSize = true;
            this.yaw_text.Location = new System.Drawing.Point(951, 12);
            this.yaw_text.Name = "yaw_text";
            this.yaw_text.Size = new System.Drawing.Size(31, 13);
            this.yaw_text.TabIndex = 4;
            this.yaw_text.Text = "Yaw:";
            // 
            // pitch_text
            // 
            this.pitch_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pitch_text.AutoSize = true;
            this.pitch_text.Location = new System.Drawing.Point(951, 35);
            this.pitch_text.Name = "pitch_text";
            this.pitch_text.Size = new System.Drawing.Size(34, 13);
            this.pitch_text.TabIndex = 5;
            this.pitch_text.Text = "Pitch:";
            // 
            // roll_text
            // 
            this.roll_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roll_text.AutoSize = true;
            this.roll_text.Location = new System.Drawing.Point(951, 58);
            this.roll_text.Name = "roll_text";
            this.roll_text.Size = new System.Drawing.Size(28, 13);
            this.roll_text.TabIndex = 6;
            this.roll_text.Text = "Roll:";
            // 
            // x_text
            // 
            this.x_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.x_text.AutoSize = true;
            this.x_text.Location = new System.Drawing.Point(951, 82);
            this.x_text.Name = "x_text";
            this.x_text.Size = new System.Drawing.Size(17, 13);
            this.x_text.TabIndex = 7;
            this.x_text.Text = "X:";
            // 
            // y_text
            // 
            this.y_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.y_text.AutoSize = true;
            this.y_text.Location = new System.Drawing.Point(951, 104);
            this.y_text.Name = "y_text";
            this.y_text.Size = new System.Drawing.Size(17, 13);
            this.y_text.TabIndex = 8;
            this.y_text.Text = "Y:";
            // 
            // z_text
            // 
            this.z_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.z_text.AutoSize = true;
            this.z_text.Location = new System.Drawing.Point(951, 126);
            this.z_text.Name = "z_text";
            this.z_text.Size = new System.Drawing.Size(17, 13);
            this.z_text.TabIndex = 9;
            this.z_text.Text = "Z:";
            // 
            // hp_text
            // 
            this.hp_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hp_text.AutoSize = true;
            this.hp_text.Location = new System.Drawing.Point(951, 147);
            this.hp_text.Name = "hp_text";
            this.hp_text.Size = new System.Drawing.Size(25, 13);
            this.hp_text.TabIndex = 10;
            this.hp_text.Text = "HP:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(982, 638);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Kill Larva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(982, 667);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Kill All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 704);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hp_text);
            this.Controls.Add(this.z_text);
            this.Controls.Add(this.y_text);
            this.Controls.Add(this.x_text);
            this.Controls.Add(this.roll_text);
            this.Controls.Add(this.pitch_text);
            this.Controls.Add(this.yaw_text);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Don\'t Hit The Small Spiders";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label yaw_text;
        private System.Windows.Forms.Label pitch_text;
        private System.Windows.Forms.Label roll_text;
        private System.Windows.Forms.Label x_text;
        private System.Windows.Forms.Label y_text;
        private System.Windows.Forms.Label z_text;
        private System.Windows.Forms.Label hp_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

