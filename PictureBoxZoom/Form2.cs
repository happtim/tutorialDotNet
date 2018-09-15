using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBoxZoom
{
    //类似图片的放大缩小功能
    public partial class Form2 : Form
    {

        private Image loadedImage;
        private float scale = 1.0f;
        Rectangle zoomArea = new Rectangle();
        Rectangle originArea = new Rectangle();

        public Form2()
        {
            InitializeComponent();
            this.pictureBox1.MouseWheel += new MouseEventHandler(picBox1_MouseWheel);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void picBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom(e.Delta);
        }

        private void zoom(int delta)
        {
            if (delta >= 1)
            {
                resize(0.1f);
            }
            else if (delta <= -1)
            {
                resize(-0.1f);
            }
        }

        private void resize(float c)
        {
            scale += c;

            pictureBox1.Width  = zoomArea.Width = (int) (scale * originArea.Width);
            pictureBox1.Height = zoomArea.Height = (int) (scale * originArea.Height);
          
            pictureBox1.Image = ZoomImage(loadedImage, originArea, zoomArea);
            pictureBox1.Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (loadedImage != null)
                {
                    loadedImage.Dispose();
                }
                try
                {

                    loadedImage = Image.FromFile(openFileDialog1.FileName);

                    originArea.Width = loadedImage.Width;
                    originArea.Height = loadedImage.Height;

                    zoomArea.Width = loadedImage.Width;
                    zoomArea.Height = loadedImage.Height;

                    //宽图
                    if (loadedImage.Width >= loadedImage.Height) {
                        if (loadedImage.Width > this.panel1.Width) {
                            zoomArea.Width = this.panel1.Width;
                            scale = (float)this.panel1.Width / loadedImage.Width;
                            zoomArea.Height =(int) (loadedImage.Height * scale);
                        }
                    }
                    //长图
                    else
                    {
                        if(loadedImage.Height  > this.panel1.Height)
                        {
                            zoomArea.Height = this.panel1.Height;
                            scale = (float)this.panel1.Height / loadedImage.Height;
                            zoomArea.Width =(int) (loadedImage.Width * scale);
                        }
                    }
                    pictureBox1.Width = this.panel1.Width;
                    pictureBox1.Height = this.panel1.Height;
                    
                    pictureBox1.Image = ZoomImage(loadedImage, originArea, zoomArea);
                    pictureBox1.Refresh();

                }
                catch (Exception)
                {
                    MessageBox.Show("Image Is Too Large.");
                }
            }
        }


        private Image ZoomImage(Image input, Rectangle originArea, Rectangle sourceArea)
        {
            Bitmap newBmp = new Bitmap(sourceArea.Width, sourceArea.Height);

            using (Graphics g = Graphics.FromImage(newBmp))
            {
                //high interpolation
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(input, sourceArea, originArea, GraphicsUnit.Pixel);
            }

            return newBmp;
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "X:" + e.X + " Y:" + e.Y;
        }
    }
}
