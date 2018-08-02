namespace PictureBoxZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_zoomout = new System.Windows.Forms.Button();
            this.btn_zoomin = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_pic_height = new System.Windows.Forms.Label();
            this.lbl_pic_width = new System.Windows.Forms.Label();
            this.btn_dock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_dock);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_zoomout);
            this.splitContainer1.Panel2.Controls.Add(this.btn_zoomin);
            this.splitContainer1.Panel2.Controls.Add(this.btn_reset);
            this.splitContainer1.Size = new System.Drawing.Size(851, 455);
            this.splitContainer1.SplitterDistance = 697;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(697, 455);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_zoomout
            // 
            this.btn_zoomout.Location = new System.Drawing.Point(13, 149);
            this.btn_zoomout.Name = "btn_zoomout";
            this.btn_zoomout.Size = new System.Drawing.Size(89, 31);
            this.btn_zoomout.TabIndex = 2;
            this.btn_zoomout.Text = "ZoomOut";
            this.btn_zoomout.UseVisualStyleBackColor = true;
            this.btn_zoomout.Click += new System.EventHandler(this.btn_zoomout_Click);
            // 
            // btn_zoomin
            // 
            this.btn_zoomin.Location = new System.Drawing.Point(13, 97);
            this.btn_zoomin.Name = "btn_zoomin";
            this.btn_zoomin.Size = new System.Drawing.Size(89, 31);
            this.btn_zoomin.TabIndex = 1;
            this.btn_zoomin.Text = "ZoomIn";
            this.btn_zoomin.UseVisualStyleBackColor = true;
            this.btn_zoomin.Click += new System.EventHandler(this.btn_zoomin_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(13, 46);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(89, 31);
            this.btn_reset.TabIndex = 0;
            this.btn_reset.Text = "reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_pic_width);
            this.groupBox1.Controls.Add(this.lbl_pic_height);
            this.groupBox1.Location = new System.Drawing.Point(13, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "picture";
            // 
            // lbl_pic_height
            // 
            this.lbl_pic_height.AutoSize = true;
            this.lbl_pic_height.Location = new System.Drawing.Point(16, 35);
            this.lbl_pic_height.Name = "lbl_pic_height";
            this.lbl_pic_height.Size = new System.Drawing.Size(0, 18);
            this.lbl_pic_height.TabIndex = 0;
            // 
            // lbl_pic_width
            // 
            this.lbl_pic_width.AutoSize = true;
            this.lbl_pic_width.Location = new System.Drawing.Point(16, 68);
            this.lbl_pic_width.Name = "lbl_pic_width";
            this.lbl_pic_width.Size = new System.Drawing.Size(0, 18);
            this.lbl_pic_width.TabIndex = 1;
            // 
            // btn_dock
            // 
            this.btn_dock.Location = new System.Drawing.Point(13, 199);
            this.btn_dock.Name = "btn_dock";
            this.btn_dock.Size = new System.Drawing.Size(89, 31);
            this.btn_dock.TabIndex = 4;
            this.btn_dock.Text = "Fill";
            this.btn_dock.UseVisualStyleBackColor = true;
            this.btn_dock.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 455);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_zoomout;
        private System.Windows.Forms.Button btn_zoomin;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_pic_width;
        private System.Windows.Forms.Label lbl_pic_height;
        private System.Windows.Forms.Button btn_dock;
    }
}

