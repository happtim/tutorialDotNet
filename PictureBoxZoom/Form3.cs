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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //测试drawImage
        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");

            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);

            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, srcRect, units);
        }
    }
}
