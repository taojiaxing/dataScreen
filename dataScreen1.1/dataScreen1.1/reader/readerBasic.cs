using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataScreen1._1
{
    abstract class readerBasic
    {
        public DataSet Data { get; set; }
        public abstract DataTable Reader(String Path);
    }
}
