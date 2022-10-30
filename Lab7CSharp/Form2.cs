using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Lab7CSharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!PaintFunction())
            {
                timer.Stop();
            }
        }

        Pen pen = new Pen(Color.Black);
        Timer timer = new Timer() { Interval = 25 };


        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
            button1.BackColor = colorDialog1.Color;
        }
        private void PaintStart(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            g.DrawLine(new Pen(Color.Black), new Point(0, pictureBox1.Height / 2), new Point(pictureBox1.Width, pictureBox1.Height / 2));
            g.DrawString("0", new Font("Arial", 16), new SolidBrush(Color.Black), 0, pictureBox1.Height / 2 + 10);
            g.DrawString("4", new Font("Arial", 16), new SolidBrush(Color.Black), pictureBox1.Width - 30, pictureBox1.Height / 2 + 10);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PaintStart(g);

            
        }
        private float Function(float x)
        {
            if (x == 0) return 0;
            return (float)(Math.Sin(x) / x);
        }

        float x = 0;

        PointF prev;
        PointF current = new PointF();
        public bool PaintFunction()
        {
            x += 0.05f;
            float abscis = pictureBox1.Height / 2;
            float scale = pictureBox1.Width / 4;
            Graphics g = pictureBox1.CreateGraphics();
            current = new PointF(x, Function(x));
            var scalePoints = new PointF[]
            {
                new PointF(prev.X * scale, abscis - prev.Y * scale),
                new PointF(current.X * scale, abscis - current.Y * scale)
            };
            g.DrawLines(pen, scalePoints);
            prev = current;

            return x * scale < pictureBox1.Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.White);
            PaintStart(graph);
            if (timer.Enabled) timer.Stop();
            x = 0.05f;
            prev = new PointF(x, Function(x));
            timer.Start();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }
    }
}
