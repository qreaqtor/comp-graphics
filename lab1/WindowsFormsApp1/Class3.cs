using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    enum Element
    {
        line,
        ellipse,
        regPolygon,
        polygon
    }

    interface IDraw
    {
        void Draw(Graphics g, Color clr, Brush brush);
    }
}
