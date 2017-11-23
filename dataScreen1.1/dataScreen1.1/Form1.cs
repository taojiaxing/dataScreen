using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataScreen1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawLineChart line = new DrawLineChart();
            String[] xString = new String[] { "1", "2", "3", "4", "1", "2", "3", "4", "1", "2", "3", "4" };
            Double[] yString = new Double[] { 12.5, 20, 8, 2, 12.5, 20, 8, 2, 12.5, 20, 8, 2, };
            Font font = new Font("Arial", 25);
            line.setmaxNum(20);
            line.settitleFont(font);
            line.draw(xString, yString);
            
            
            Image img = line.getFrom();
            pictureBox1.Image = img;
        }
    }
}
