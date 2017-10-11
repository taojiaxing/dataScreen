using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataScreen
{
    abstract class Style
    {
        public Font font { get; set; }
        public Color color { get; set; }
        public abstract Boolean style(Font font, Color color);
    }
}
