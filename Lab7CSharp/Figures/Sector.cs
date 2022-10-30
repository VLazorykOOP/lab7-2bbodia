using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp.Figures
{
    public class Sector : Figure
    {

        private int width;
        private int height;
        private int startAngle;
        private int sweepAngle;

        public Sector(int x, int y, int width, int height, int startAngle, int sweepAngle, Pen pen) : base(x, y, pen)
        {
            this.width = width;
            this.height = height;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }
        
        public override void Draw(Graphics g)
        {
            g.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
        }
    }
}
