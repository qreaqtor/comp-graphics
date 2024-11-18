using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace lab2
{

    class Game : GameWindow
    {
        Vector3 clr;

        Vector3[] p;

        Vector3 centre;

		BeginMode mode;

        Action move;

        int znak;

        int n;
        float r;

		public Game()
        : base(800, 600, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;

            var scale = 0.5f;

            n = 5;
            r = 0.5f * scale;

			centre = new Vector3(0f, 0f, 4f);

            move = new Action(() => moveCurve(0.1f)); // движение по кривой

            //var target = new Vector3(0.5f, 0.5f, 4.0f); // вокруг чего вращать
            //move = new Action(() => moveAround(10, target)); // вращение вокруг target

            //move = new Action(() => moveAround(10, centre)); // вращение вокруг центра фигура

            p = getPolygonPoints();

            mode = BeginMode.Polygon;

			clr = new Vector3(1.0f, 0.0f, 1.0f);

            znak = 1;
		}

        private Vector3[] getPolygonPoints()
        {
			var p = new Vector3[n];

			var angle = (double)360 / n;
			var step = Math.PI * angle / 180;

			for (var i = 0; i < n; i++)
			{
				var y = (float)(r * Math.Sin(step * i) + centre.Y);

				var x = (float)(r * Math.Cos(step * i) + centre.X);

				p[i] = new Vector3(x, y, centre.Z);
			}

            return p;
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
                Exit();

            move();
		}

		// Поворачиваем точку t(x,y) на угол (deg) относительно точки t0(x,y)
		private void moveAround(int deg, Vector3 target)
        {
			// Переводим угол поворота из градусов в радианы
			var rad = (Math.PI / 180) * deg;

            for (int i = 0; i< p.Length; i++)
            {
                p[i] = new Vector3(
                    (float)(target.X + (p[i].X - target.X) * Math.Cos(rad) - (p[i].Y - target.Y) * Math.Sin(rad)),
					(float)(target.Y + (p[i].X - target.X) * Math.Sin(rad) + (p[i].Y - target.Y) * Math.Cos(rad)),
                    p[i].Z
                );
			}
		}

        private void moveCurve(float dx)
        {
			if ((centre.X < -1) || (centre.X > 1))
                znak = -znak;

			centre.X = centre.X + dx * znak;
            centre.Y = centre.X * centre.X;

			p = getPolygonPoints();
        }

		protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

			draw();

			SwapBuffers();
        }

		private void draw()
        {
			GL.Begin(mode);

			for (int i = 0; i < p.Length; i++)
			{
				GL.Color3(clr);
				GL.Vertex3(p[i]);
			}

			GL.End();
		}
    }
}
