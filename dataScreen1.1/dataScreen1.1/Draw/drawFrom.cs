using System;
using System.Drawing;

namespace dataScreen1._1
{
    abstract class DrawFrom:DrawBasic
    {
        public int xCount = 600;
        public int yCount = 300;
        public Point centerPoint = new Point(40, 360);
        public Font pointFont = new Font("Arial", 8);
        public Brush axespointColor = Brushes.Black;
        public Pen axesColor = new Pen(Color.Red);
        //public String[] xString = new String[] { "1", "2", "3", "4" };
        public Brush axesStringColor = Brushes.Blue;
        private int maxNum = 20;
        public int pointCount = 5;
        public int xSpace = 10;
        public int ySpace = 10;
        public void setpointfont(Font font)
        {
            pointFont = font;
        }
       
        public void setaxesFontColor(Brush color)
        { 
            axespointColor = color;
        }
        public void setmaxNum(int _maxNum)
        {
            maxNum = _maxNum;
        }
        public void drawaxes(String[] xString)
        {
            drawTitle();
            pointCount = xString.Length + 1;
            //横坐标
            Point xPoint = new Point(centerPoint.X + xCount, centerPoint.Y);
            graphics.DrawLine(axesColor, centerPoint, xPoint);

            //纵坐标
            Point yPoint = new Point(centerPoint.X, centerPoint.Y - yCount);
            graphics.DrawLine(axesColor, centerPoint, yPoint);

            //横坐标值
            xSpace = xCount / (xString.Length + 1);
            for(int i = 0; i < xString.Length; i++)
            {
                graphics.DrawLine(axesColor, titlePositon.X + xSpace * (i+1), centerPoint.Y,titlePositon.X + xSpace * (i+1), centerPoint.Y-6);
                graphics.DrawString(xString[i], pointFont, axespointColor, titlePositon.X + xSpace * (i + 1), centerPoint.Y);
            }

            //纵坐标值
            ySpace = yCount / maxNum;
            for(int i = 0;i<maxNum;i++)
            {
                graphics.DrawLine(axesColor, titlePositon.X, centerPoint.Y - ySpace * (i + 1), titlePositon.X + 4, centerPoint.Y - ySpace * (i + 1));
                graphics.DrawString(i.ToString(), pointFont, axespointColor, titlePositon.X - pointFont.Size*3, centerPoint.Y - ySpace * (i + 1)+pointFont.Size);
            }
            graphics.DrawString(maxNum.ToString(), pointFont, axespointColor, titlePositon.X - pointFont.Size * 3, centerPoint.Y - yCount - ySpace + pointFont.Size);
        }
        public Bitmap getFrom()
        {
            return image;   
        }
        public DrawFrom()
        {
            
        }
    }
}
