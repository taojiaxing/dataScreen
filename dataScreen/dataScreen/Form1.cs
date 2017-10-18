using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataScreen
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void display_Click(object sender, EventArgs e)
        {

        }
        private void open_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "D:\\";            // 这里是初始的路径名
            openFileDialog1.Filter = "所有文件|*.*";  //设置打开文件的类型
            openFileDialog1.RestoreDirectory = true;              //设置是否还原当前目录
            openFileDialog1.FilterIndex = 0;                      //设置打开文件类型的索引
            string path = "";                      //用于保存打开文件的路径
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                textBox_path.Text = path;
            }
        }
        private void textBox_path_TextChanged(object sender, EventArgs e)
        {

        }
        private void read_Click(object sender, EventArgs e)
        {
            ExcelReader reader = new ExcelReader();
            DataTable data = reader.Reader(textBox_path.Text);
            drawLinechart d = new drawLinechart();
            string s = Path.GetFileNameWithoutExtension(textBox_path.Text);
            /* DataTable a = new DataTable();
             a.Columns.Add("testvalue");
             a.Columns.Add("testdate");

             for (int i = 0; i < 5; i++)
             {
                 DataRow row = a.NewRow();
                 row["testvalue"] = "12";
                 row["testdate"] = "2008-12-2 0:18:00";
                 a.Rows.Add(row);
             }
             for (int i = 0; i < 5; i++)
             {
                 DataRow row = a.NewRow();
                 row["testvalue"] = "2";
                 row["testdate"] = "2008-12-2 0:18:00";
                 a.Rows.Add(row);
             }*/

            display.Image = d.draw(data, s);
        }

        private void titleFont_Click(object sender, EventArgs e)
        {

        }

    }
}
