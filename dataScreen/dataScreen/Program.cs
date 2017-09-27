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
            Object i = data.Rows[4].ItemArray[3];
            souce = reader.tableToArrye();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
