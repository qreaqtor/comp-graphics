using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace laab3
{
	public partial class Form1 : Form
	{
		int Xstart, Xend, step;

		public Form1()
		{
			InitializeComponent();

			chart1.Series.Clear();

			chart1.ChartAreas[0].AxisX = new Axis
			{
				Title = "X"
			};

			chart1.ChartAreas[0].AxisY = new Axis
			{
				Title = "Y"
			};

		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			chart1.Series.Clear();

			Xstart = int.Parse(textBox3.Text);
			Xend = int.Parse(textBox4.Text);
			step = int.Parse(textBox5.Text);

			chart1.Series.Add(GetSeries(textBox1.Text, Color.Red));

			chart1.Series.Add(GetSeries(textBox2.Text, Color.Blue));
		}

		private Series GetSeries(string funcStr, Color color)
		{
			var s = new Series("y = " + funcStr);

			var e = new Expression(funcStr.Replace("x", "[x]"));

			for (int x = Xstart; x <= Xend; x += step)
			{
				e.Parameters["x"] = x;

				var y = e.Evaluate();

				s.Points.AddXY(x, y);
			}

			s.Color = color;

			s.ChartType = SeriesChartType.Line;

			s.BorderWidth = 3;

			s.MarkerStyle = MarkerStyle.Circle;

			s.MarkerColor = Color.Black;

			return s;
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}
	}
}
