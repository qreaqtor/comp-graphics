using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class LineDrawer : IDraw
    {
        Point begin;
        Point end;

        int width;

        public LineDrawer(Point b, Point e, int w)
        {
            begin = b;
            end = e;
            width = w;
        }

        public void Draw(Graphics g, Color clr, Brush _)
        {
            var pen = new Pen(clr, width);
            g.DrawLine(pen, begin, end);
        }
    }
}
