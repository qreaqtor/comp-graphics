using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class PolygonDrawer : IDraw
    {
        Point[] points;
        int width;

        public PolygonDrawer(Point[] points, int w)
        {
            this.points = points;
            this.width = w;
        }

        public void Draw(Graphics g, Color clr1, Brush brush)
        {
            var pen = new Pen(clr1, this.width);

            g.FillPolygon(brush, points.ToArray());
            g.DrawPolygon(pen, points.ToArray());
        }
    }

}
