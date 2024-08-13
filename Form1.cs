using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Opengl2d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void drawPoligono(int lados, bool prencimento) 
        {

            int radius = 80;
            float n = 360 / lados;

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Color3(Color.White);
            if (prencimento)
            {
                GL.Begin(PrimitiveType.Triangles);
            }
            else
            {
                GL.Begin(PrimitiveType.LineLoop);
            }
            for (float i = 0; i < 360; i += n) {
                double degInRad = i * (3.1416 / 180);
                GL.Color3(Color.Red);
                GL.Vertex2(Math.Cos(degInRad) * radius, Math.Sin(degInRad) * radius);
                GL.Color3(Color.Blue);
                GL.Vertex2(0, 0);
                if (!prencimento)
                {
                    GL.Color3(Color.Red);
                    GL.Vertex2(Math.Cos(degInRad) * radius, Math.Sin(degInRad) * radius);
                }
                float d = i + n;
                degInRad = d * (3.1416 / 180);
                GL.Color3(Color.Green);
                GL.Vertex2(Math.Cos(degInRad) * radius, Math.Sin(degInRad) * radius);
                if (!prencimento)
                {
                    GL.Color3(Color.Green);
                    GL.Vertex2(Math.Cos(degInRad) * radius, Math.Sin(degInRad) * radius);
                    GL.Color3(Color.Blue);
                    GL.Vertex2(0, 0);
                }
            }
            GL.End();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int lados = 180;
            try
            {
                int.TryParse(numericUpDown2.Value.ToString(), out lados);
            }
            catch { MessageBox.Show("Não deu certo"); }

            glControl5.MakeCurrent();
            GL.LoadIdentity();
            GL.Ortho(-100, 100, -100, 100, -1, 1);
            GL.ClearColor(Color.Black);

            drawPoligono(lados, true);
            glControl5.SwapBuffers();

            glControl6.MakeCurrent();
            GL.LoadIdentity();
            GL.Ortho(-100, 100, -100, 100, -1, 1);
            GL.ClearColor(Color.Black);

            drawPoligono(lados, false);
            glControl6.SwapBuffers();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
