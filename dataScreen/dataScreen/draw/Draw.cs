using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataScreen
{
    abstract class Draw
    {
        public int x { get; set; }
        public int y { get; set; }
        public abstract Image draw(DataTable data ,string Name);
    }
}
