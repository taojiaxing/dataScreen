using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataScreen1._1
{
    abstract class DrawBasic
    {
        public int width = 800;
        public int hight = 400;
        public Color backgroundColor = Color.White;
        private Font titleFont = new Font("Arial", 6);
        private Brush titleColor = Brushes.Black;
        private String Title = "text";
        public Point titlePositon = new Point(40, 10);
        public Graphics graphics;
        public Bitmap image;
        public void setTitile(String _title)
        {
            Title = _title;
        }
        public void settitleFont(Font font)
        {
            titleFont = font;
        }
        public void settitleColor(Brush color)
        {
            titleColor = color;
        }
        public void Basic()
        {
            Bitmap img = new Bitmap(width, hight);
            image = img;
            Graphics gra = Graphics.FromImage(image);
            gra.Clear(backgroundColor);
            gra.SmoothingMode = SmoothingMode.HighQuality;
            gra.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            gra.PixelOffsetMode = PixelOffsetMode.Half;
            graphics = gra;
        }
        public void drawTitle()
        {
            Basic();
            graphics.DrawString(Title, titleFont, titleColor, titlePositon.X, titlePositon.Y);
            
        }
        public abstract Bitmap draw(String[] xString, Double[] yValue);
    }
}
