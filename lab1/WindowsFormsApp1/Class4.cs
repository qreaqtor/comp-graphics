using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RegularPolygonDrawer : IDraw
    {
        Point p;
        int n;
        int width;
        int r;

        public RegularPolygonDrawer(Point p, int r, int n, int w)
        {
            this.p = p;
            this.n = n;
            this.r = r;
            this.width = w;
        }

        public void Draw(Graphics g, Color clr1, Brush brush)
        {
            var pen = new Pen(clr1, this.width);

            var points = new List<Point>();

            var angle = (double)360 / n;
            var step = Math.PI * angle / 180;

            for(var i=0; i < n; i++)
            {
                var y = (int)(r * Math.Sin(step * i)) + p.Y;

                var x = (int)(r * Math.Cos(step * i)) + p.X;

                points.Add(new Point(x, y));
            }

            g.FillPolygon(brush, points.ToArray());
            g.DrawPolygon(pen, points.ToArray());
        }
    }
}
