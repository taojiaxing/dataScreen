using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace dataScreen
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<List<Object>> souce = new List<List<Object>>();
            ExcelReader reader = new ExcelReader();
            DataTable data = reader.Reader("test.xlsx");
            drawLinechart d = new drawLinechart();
            DataTable a = new DataTable();
            /*a.Columns.Add("testDate", typeof(string));
            a.Columns.Add("testValue", typeof(string));
            for(int i = 0; i < 12; i++)
            {
                DataRow row = a.NewRow();
                row["testdata"] = i;
                row["testValue"] = 1 + i;
                a.Rows.Add(row);
            }*/
            d.draw(data);
           // Object i = data.Rows[0].ItemArray[0];
            //souce = reader.tableToArrye();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
