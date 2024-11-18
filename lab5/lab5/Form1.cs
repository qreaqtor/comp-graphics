using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
	public partial class Form1 : Form
	{
		OpenFileDialog ofd;

		Bitmap imgBmp;

		public Form1()
		{
			InitializeComponent();

			dataGridView1.AllowUserToAddRows = false;

			dataGridView1.RowHeadersVisible = false;

			pictureBox1.BorderStyle = BorderStyle.FixedSingle;
			pictureBox2.BorderStyle = BorderStyle.FixedSingle;

			var row = dataGridView1.RowTemplate;
			row.Height = 40;
			row.MinimumHeight = 40;

			var curDir = AppDomain.CurrentDomain.BaseDirectory;
			var initDir = Path.GetFullPath(Path.Combine(curDir, @"..\..\..\images"));

			if (!Directory.Exists(initDir))
			{
				initDir = curDir;
			}

			ofd = new OpenFileDialog
			{
				InitialDirectory = initDir,
				Filter = "All files (*.*)|*.*|jpg|*.jpg|png|*.png|bmp|*.bmp",
				RestoreDirectory = true
			};
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (ofd.ShowDialog() != DialogResult.OK) return;

			imgBmp = Image.FromFile(ofd.FileName) as Bitmap;

			pictureBox1.Image = imgBmp;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!(int.TryParse(textBox1.Text, out var x1) &&
				int.TryParse(textBox2.Text, out var y1) &&
				int.TryParse(textBox3.Text, out var x2) &&
				int.TryParse(textBox4.Text, out var y2)
				))
				return;

			var image = imgBmp;

			for (var i = x1; i < x2; i++)
			{
				for (var j = y1; j < y2; j++)
				{
					var cur = image.GetPixel(i, j);
					image.SetPixel(i, j, Color.FromArgb(cur.A, 255 - cur.R, 255 - cur.G, 255 - cur.B));
				}
			}

			pictureBox2.Image = image;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (!(int.TryParse(textBox1.Text, out var x1) &&
				int.TryParse(textBox2.Text, out var y1) &&
				int.TryParse(textBox3.Text, out var x2) &&
				int.TryParse(textBox4.Text, out var y2)
				))
				return;

			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();

			dataGridView1.ColumnCount = x2 - x1 + 1;
			dataGridView1.Columns[0].Name = "Y \\ X";
			dataGridView1.Columns[0].Frozen = true;

			for (int i = x1; i < x2; i++)
			{
				dataGridView1.Columns[i-x1+1].Name = i.ToString();
			}

			for (int j = y1; j < y2; j++)
			{
				var row = new string[x2-x1+1];
				row[0] = j.ToString();

				for (int i = x1; i< x2; i++)
				{
					var p = imgBmp.GetPixel(i, j);
					row[i-x1+1] = $"R: {p.R} \nG: {p.G} \nB: {p.B} \nL: {p.GetBrightness()}";
				}

				dataGridView1.Rows.Add(row);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
