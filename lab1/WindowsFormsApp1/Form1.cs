using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics g;

        IDraw drawer;

        Element draw;

        public Form1()
        {
            InitializeComponent();

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            listBox1.Hide();

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            listBox1.Show();

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;

            radioButton1.Checked = true;

            draw = Element.line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clr = Color.Red;
            var brush = Brushes.Blue;

            setDrawer(clr, brush);

            drawer.Draw(g, clr, brush);
        }

        private void setDrawer(Color clr, Brush brush)
        {
            var width = int.Parse(textBox5.Text);
            if (width < 1) width = 1;
            
            switch (this.draw)
            {
                case Element.line:
                    drawer = new LineDrawer(
                    new Point
                    {
                        X = int.Parse(textBox1.Text),
                        Y = int.Parse(textBox3.Text)
                    },
                    new Point
                    {
                        X = int.Parse(textBox2.Text),
                        Y = int.Parse(textBox4.Text)
                    },
                    width
                    );
                    break;
                case Element.ellipse:
                    drawer = new EllipseDrawer(
                    new Point
                    {
                        X = int.Parse(textBox1.Text),
                        Y = int.Parse(textBox2.Text)
                    },
                    new Size
                    {
                        Width = int.Parse(textBox3.Text),
                        Height = int.Parse(textBox4.Text)
                    },
                    width
                    );
                    break;
                case Element.polygon:
                    var points = new List<Point>();
                    foreach(var p in listBox1.Items)
                    {
                        points.Add((Point)p);
                    }
                    drawer = new PolygonDrawer(points.ToArray(), width);
                    break;
                case Element.regPolygon:
                    drawer = new RegularPolygonDrawer(
                        new Point
                        {
                            X = int.Parse(textBox1.Text),
                            Y = int.Parse(textBox3.Text)
                        },
                        int.Parse(textBox2.Text),
                        int.Parse(textBox4.Text),
                        width
                        );
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var clr = Color.White;
            var brush = Brushes.White;

            drawer.Draw(g, clr, brush);
            listBox1.Items.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.draw = Element.line;

            label1.Text = "Начало X";
            label2.Text = "Начало X";
            label3.Text = "Конец X";
            label4.Text = "Конец Y";
            label5.Text= "Ширина";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.draw = Element.ellipse;

            label1.Text = "Центр X";
            label2.Text = "Центр Y";
            label3.Text = "Радиус X";
            label4.Text = "Радиус Y";
            label5.Text = "Ширина";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.draw = Element.regPolygon;

            label1.Text = "Центр X";
            label2.Text = "Центр Y";
            label3.Text = "Радиус";
            label4.Text = "Кол-во граней";
            label5.Text = "Ширина";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.draw = Element.polygon;

            label1.Text = "Коорд. X";
            label2.Text = "Коорд. Y";
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var p = new Point(int.Parse(textBox1.Text), int.Parse(textBox3.Text));

            listBox1.Items.Add(p);
        }
    }
}
