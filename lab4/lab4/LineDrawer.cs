using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
	internal class LineDrawer
	{
		Pen pen;

		Graphics graphics;

		public LineDrawer(Graphics g, Color clr, int w)
		{
			graphics = g;

			pen = new Pen(clr, w);
		}

		public void Draw(float x1, float y1, float x2, float y2)
		{
			graphics.DrawLine(pen, x1, y1, x2, y2);
		}
	}
}
