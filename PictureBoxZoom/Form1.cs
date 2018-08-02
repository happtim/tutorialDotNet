using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBoxZoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //this.pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            this.lbl_pic_height.Text = pictureBox1.Height + "";
            this.lbl_pic_width.Text = pictureBox1.Width + "";

        }

        private void btn_zoomin_Click(object sender, EventArgs e)
        {

            this.pictureBox1.Dock = DockStyle.None;
            this.pictureBox1.Height = (int)(this.pictureBox1.Height * 0.9);
            this.pictureBox1.Width = (int)(this.pictureBox1.Width * 0.9);
            this.lbl_pic_height.Text = pictureBox1.Height + "";
            this.lbl_pic_width.Text = pictureBox1.Width + "";
        }

        private void btn_zoomout_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Dock = DockStyle.None;
            this.pictureBox1.Height = (int)(pictureBox1.Height * 1.1);
            this.pictureBox1.Width = (int)(pictureBox1.Width * 1.1);
            this.lbl_pic_height.Text = pictureBox1.Height + "";
            this.lbl_pic_width.Text = pictureBox1.Width + "";
            btn_dock.Text = "Fill";
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            
            this.pictureBox1.Height = this.splitContainer1.Panel1.Height;
            this.pictureBox1.Width = this.splitContainer1.Panel1.Width;
            this.pictureBox1.Dock = DockStyle.Fill;
            this.lbl_pic_height.Text = pictureBox1.Height + "";
            this.lbl_pic_width.Text = pictureBox1.Width + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Dock == DockStyle.Fill){
                btn_dock.Text = "None";
                pictureBox1.Dock = DockStyle.None;
            }else {
                btn_dock.Text = "Fill";
                pictureBox1.Dock = DockStyle.Fill;
            }
                
            this.lbl_pic_height.Text = pictureBox1.Height + "";
            this.lbl_pic_width.Text = pictureBox1.Width + "";
        }
    }
}
