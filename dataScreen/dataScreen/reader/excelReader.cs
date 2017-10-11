using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace dataScreen
{
    class ExcelReader : fileReader
    {
        public override DataTable Reader(object Path)
        {
            try
            {

                //连接字符串
                string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; // Office 07及以上版本 不能出现多余的空格 而且分号注意
                //string connstring = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + Path + ":Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; //Office 07以下版本 
                using (OleDbConnection conn = new OleDbConnection(connstring))
                {
                    conn.Open();
                    DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                    string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
                    string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串

                    OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                    Data = new DataSet();
                    ada.Fill(Data);
                    return Data.Tables[0];
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<List<Object>> tableToArrye()   //将dataTable转换为二维数组
        {
            int x = Data.Tables[0].Rows.Count - 1;
            int y = Data.Tables[0].Columns.Count - 1;
            List<List<Object>> Souce = new List<List<Object>>();
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++ )
                {
                    Souce[i][j] = Data.Tables[0].Rows[i].ItemArray[j];
                }   
            }
            return Souce;
        }
    }
}
