using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataScreen1._1
{
    class DrawLineChart : DrawFrom
    {
        public Color lineColor = Color.Blue;
        public override Bitmap draw(String[] xString, Double[] yValue)
        {
            drawaxes(xString);
            Point[] points = new Point[pointCount];
            points[0] = centerPoint;
            for(int i = 1; i < pointCount; i++)
            {
                points[i].X = centerPoint.X + xSpace * i;
                points[i].Y = centerPoint.Y - Convert.ToInt32(yValue[i-1] * ySpace);
            }
            Pen p = new Pen(lineColor);
            graphics.DrawLines(p, points);
            for(int i =1;i<pointCount; i++){
                graphics.DrawString(yValue[i-1].ToString(), pointFont, axespointColor, points[i]);
            }
            return image;
        }
    }
}
