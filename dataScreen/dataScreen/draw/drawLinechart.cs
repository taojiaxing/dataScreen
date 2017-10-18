using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//添加画图类
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;

namespace dataScreen
{
    class drawLinechart : Draw
    {
        public override System.Drawing.Image draw(DataTable data, string Name)
        {
            string title = Name;
            string xName = "";
            string yName = "";
            yName = data.Rows[0].ItemArray[0].ToString();
            xName = data.Rows[0].ItemArray[1].ToString();
            //title = data.
            //取得记录数量
            int count = data.Rows.Count;
            //生成Bitmap对像
            Bitmap img = new Bitmap(800, 400);
            //生成绘图对像
            Graphics g = Graphics.FromImage(img);
            //定义黑色画笔
            Pen Bp = new Pen(Color.Black);
            //定义红色画笔
            Pen Rp = new Pen(Color.Red);
            //定义银灰色画笔
            Pen Sp = new Pen(Color.Silver);
            //定义大标题字体
            Font Bfont = new Font("Arial", 12, FontStyle.Bold);
            //定义一般字体
            Font font = new Font("Arial", 6);
            //定义大点的字体
            Font Tfont = new Font("Arial", 9);
            //定义横坐标间隔，(最佳值是总宽度-留空宽度[左右侧都需要])/(记录数量-1)
            int xSpace = (800 - 100) / (count - 1);
            //定义纵坐标间隔,不能随便修改，跟高度和横坐标线的条数有关，最佳值=(绘图的高度-上面留空-下面留空)
            int ySpace = 30;
            //纵坐标最大值和间隔值
            int yMaxValue = 100;
            //绘制底色
            g.DrawRectangle(new Pen(Color.White, 400), 0, 0, img.Width, img.Height);
            //定义黑色过渡型笔刷
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Black, Color.Black, 1.2F, true);
            //定义蓝色过渡型笔刷
            LinearGradientBrush Bluebrush = new LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Blue, Color.Blue, 1.2F, true);
            //绘制大标题
            g.DrawString(title, Bfont, brush, 40, 5);
            //绘制信息简报
            string info = " 曲线图生成时间：" + DateTime.Now.ToString();
            g.DrawString(info, Tfont, Bluebrush, 40, 25);
            //绘制图片边框
            g.DrawRectangle(Bp, 0, 0, img.Width - 1, img.Height - 1);
            //绘制竖坐标轴
            g.DrawLine(Bp, 40, 55, 40, 360);
            //绘制横坐标轴 x2的60是右侧空出部分
            g.DrawLine(Bp, 40, 360, 60 + xSpace * (count - 1), 360);
            //绘制竖坐标标题
            g.DrawString(xName, Tfont, brush, 5, 40);
            //绘制横坐标标题
            g.DrawString(yName, Tfont, brush, 40, 385);
            //绘制竖坐标线
            for (int i = 0; i < count; i++)
            {
                g.DrawLine(Sp, 40 + xSpace * i, 60, 40 + xSpace * i, 360);
            }
            //绘制时间轴坐标标签
            for (int i = 1; i < count; i++)
            {
                string st = data.Rows[i].ItemArray[0].ToString();
                g.DrawString(st, font, brush, 30 + xSpace * i, 370);
            }
            //绘制横坐标线
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(Sp, 40, 60 + ySpace * i, 40 + xSpace * (count - 1), 60 + ySpace * i);
                //横坐标轴的值间隔是最大值除以间隔数
                int s = yMaxValue - i * (yMaxValue / 10);
                //绘制发送量轴坐标标签
                g.DrawString(s.ToString(), font, brush, 10, 60 + ySpace * i);
            }
            //定义纵坐标单位数值=纵坐标最大值/标量最大值（300/30）
            int yAveValue = 300/100;
            //定义曲线转折点
            Point[] p = new Point[count];
            p[0].X = 40;
            p[0].Y = 360;
            for (int i = 1; i < count ; i++)
            {
                p[i].X = 40 + xSpace * i;
                p[i].Y = 360 - Convert.ToInt32(data.Rows[i].ItemArray[1]) * yAveValue;
            }
            //绘制折线图
            g.DrawLines(Rp, p);
            //绘制曲线图
            //g.DrawCurve(Rp, p);
            //绘制自定义张力的曲线图（0.5F是张力值，默认就是这个值）
            //g.DrawCurve(Rp, p, 0.5F);
            //当需要在一个图里绘制多条曲线的时候，就多定义个point数组，然后画出来就可以了。
            for (int i = 1; i < count; i++)
            {
                //绘制发送记录点的发送量
                g.DrawString(data.Rows[i].ItemArray[1].ToString(), font, Bluebrush, p[i].X, p[i].Y - 10);
                //绘制发送记录点
                g.DrawRectangle(Rp, p[i].X - 1, p[i].Y - 1, 2, 2);
            }
            //保存绘制的图片
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);

            //图片输出
            /*Response.Clear();
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(stream.ToArray());*/
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
            return image;
        }
    }
}
