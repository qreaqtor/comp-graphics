using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EllipseDrawer : IDraw
    {
        Point p;
        Size sz;
        int width;

        public EllipseDrawer(Point p, Size sz, int w)
        {
            this.p = p;
            this.sz = sz;
            this.width = w;
        }

        public void Draw(Graphics g, Color clr1, Brush brush)
        {
            var rect = new Rectangle(p, sz);

            var pen = new Pen(clr1, this.width);

            var font = new Font(FontFamily.GenericSansSerif, 14);

            g.FillEllipse(brush, rect);
            g.DrawEllipse(pen, rect);
            g.DrawString("эллипс", font, brush, new Point(p.X, p.Y+sz.Height));
        }
    }
}
