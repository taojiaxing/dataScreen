using System;
using System.Data;


namespace dataScreen
{
    abstract class dataReader
    {
        public DataSet Data { get; set; }
        public abstract DataTable Reader(Object Path);
    }
}
