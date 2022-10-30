using Lab7CSharp.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lab7CSharp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<Figure> figures = new List<Figure>();
        private Random rand = new Random();
        private Arc ReadArcData()
        {
            int width = Convert.ToInt32(textBox1.Text);
            int height = Convert.ToInt32(textBox2.Text);
            int x = rand.Next(pictureBox1.Width - width);
            int y = rand.Next(pictureBox1.Height - height);
            int startAngle = Convert.ToInt32(textBox3.Text);
            int sweepAngle = Convert.ToInt32(textBox4.Text);
            Color color = colorDialog1.Color;
            Arc arc = new Arc(x, y, width, height, startAngle, sweepAngle, new Pen(color, 5));
            return arc;
        }

        private Sector ReadSectorData()
        {
            int width = Convert.ToInt32(textBox1.Text);
            int height = Convert.ToInt32(textBox2.Text);
            int x = rand.Next(pictureBox1.Width - width);
            int y = rand.Next(pictureBox1.Height - height);
            int startAngle = Convert.ToInt32(textBox3.Text);
            int sweepAngle = Convert.ToInt32(textBox4.Text);
            Color color = colorDialog1.Color;

            Sector sector = new Sector(x, y, width, height, startAngle, sweepAngle, new Pen(color, 5));
            return sector;
        }

        private Ellipse ReadEllipseData()
        {
            int width = Convert.ToInt32(textBox5.Text);
            int height = Convert.ToInt32(textBox6.Text);
            int x = rand.Next(pictureBox1.Width - width);
            int y = rand.Next(pictureBox1.Height - height);
            Color color = colorDialog1.Color;
            Ellipse ellipse = new Ellipse(x, y, width, height, new Pen(color, 5));
            return ellipse;
        }

        private RoundedRectangle ReadRoundedRectangleData()
        {

            int width = Convert.ToInt32(textBox7.Text);
            int height = Convert.ToInt32(textBox8.Text);
            int x = rand.Next(pictureBox1.Width - width);
            int y = rand.Next(pictureBox1.Height - height);
            int radius = Convert.ToInt32(textBox9.Text);
            Color color = colorDialog1.Color;
            RoundedRectangle roundedRectangle = new RoundedRectangle(x, y, width, height, radius, new Pen(color, 5));
            return roundedRectangle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);

            foreach (var figure in figures)
            {
                figure.Draw(gr);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                figures.Add(ReadArcData());
            }
            else if (radioButton2.Checked)
            {
                figures.Add(ReadSectorData());

            }
            else if (radioButton3.Checked)
            {
                figures.Add(ReadEllipseData());
            }
            else if (radioButton4.Checked)
            {
                figures.Add(ReadRoundedRectangleData());
            }
            label2.Text = figures.Count.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Location = new Point(5, 12);
                panel1.Visible = true;
                groupBox3.Controls.Add(panel1);
                groupBox3.Text = "Параметри дуги";

            }
            else
            {
                groupBox3.Controls.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel1.Location = new Point(5, 12);
                panel1.Visible = true;
                groupBox3.Controls.Add(panel1);
                groupBox3.Text = "Параметри сектора";
            }
            else
            {
                groupBox3.Controls.Clear();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                panel2.Location = new Point(5, 12);
                panel2.Visible = true;
                groupBox3.Controls.Add(panel2);
                groupBox3.Text = "Параметри Еліпса";
            }
            else
            {
                groupBox3.Controls.Clear();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                panel3.Location = new Point(5, 12);
                panel3.Visible = true;
                groupBox3.Controls.Add(panel3);
                groupBox3.Text = "Параметри прям.";
            }
            else
            {
                groupBox3.Controls.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox10.Text);
            int step = Convert.ToInt32(textBox11.Text);
            Figure  figure = figures[index - 1];
            figure.Move(0, -step);
            this.button4_Click(this, new EventArgs());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox10.Text);
            int step = Convert.ToInt32(textBox11.Text);
            Figure figure = figures[index - 1];
            figure.Move(0, step);
            this.button4_Click(this, new EventArgs());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox10.Text);
            int step = Convert.ToInt32(textBox11.Text);
            Figure figure = figures[index - 1];
            figure.Move(-step, 0);
            this.button4_Click(this, new EventArgs());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox10.Text);
            int step = Convert.ToInt32(textBox11.Text);
            Figure figure = figures[index - 1];
            figure.Move(step, 0);
            this.button4_Click(this, new EventArgs());
        }
    }
}
