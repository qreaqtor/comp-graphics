using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab4
{
	public partial class Form1 : Form
	{
		Graphics g;

		LineDrawer drawer;

		public Form1()
		{
			InitializeComponent();

			this.Width = 1200;
			this.Height = 1000;

			pictureBox1.Width = 1010;
			pictureBox1.Height = 910;

			textBox1.Left = 1050;
			label1.Left = 1050;
			label2.Left = 1050;
			button1.Left = 1050;



			label2.ForeColor = Color.White;
			label2.Font = new Font(FontFamily.GenericSerif, 14);
			label2.Text = "Cant parse";

			var clr = Color.Black;
			var width = 1;
			g = pictureBox1.CreateGraphics();

			drawer = new LineDrawer(g, clr, width);
		}

		private void DrawLine(int x1, int y1, int x2, int y2)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			g.Clear(Color.White);

			if (!(int.TryParse(textBox1.Text, out var depth)))
			{
				label2.ForeColor = Color.Red;
				return;
			}
			label2.ForeColor = Color.White;

			var dx = 10;
			var dy = 10;

			var xMax = pictureBox1.Width;
			var yMax = pictureBox1.Height;

			Side(0, yMax - dy, xMax-dx, yMax - dy, (xMax - dx) / 2, 0 + dy, depth);
		}

		private void Side(float x1, float y1, float x2, float y2, float x3, float y3, int n)
		{
			if (n == 0)
			{
				drawer.Draw(x1, y1, x2, y2);
				drawer.Draw(x2, y2, x3, y3);
				drawer.Draw(x3, y3, x1, y1);

				return;
			}

			var nx1 = (x2 + x1) / 2;
			var ny1 = (y2 + y1) / 2;

			var nx2 = (x3 + x2) / 2;
			var ny2 = (y3 + y2) / 2;

			var nx3 = (x1 + x3) / 2;
			var ny3 = (y1 + y3) / 2;

			Side(x1, y1, nx1, ny1, nx3, ny3, n - 1);
			Side(x2, y2, nx1, ny1, nx2, ny2, n - 1);
			Side(x3, y3, nx2, ny2, nx3, ny3, n - 1);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
