using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardTest
{
    public partial class Form1 : Form
    {
        private double horizontal;
        private double vertical;
        private double originalHorizontal;
        private double originalVertical;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen0 = new Pen(Color.Black, 1);
            for (int i = 0; i < 15; i++)
            {
                //25*14=350
                //30*14=520
                Point point1 = new Point(30 * i + 50, 50);
                Point point2 = new Point(30 * i + 50, 470);
                g.DrawLine(pen0, point1, point2);
            }
            for(int i = 0; i < 15; i++)
            {
                Point point3 = new Point(50, 30 * i + 50);
                Point point4 = new Point(470, 30 * i + 50);
                g.DrawLine(pen0, point3, point4);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p0 = this.PointToClient(Control.MousePosition);
            string X = p0.X.ToString();
            string Y = p0.Y.ToString();
            textBox1.Text = X + "," + Y;
            coordinate.Text = X + "," + Y;

            originalHorizontal = Convert.ToDouble(p0.X);
            originalVertical = Convert.ToDouble(p0.Y);

            horizontal = Math.Round((originalHorizontal - 50 )/ 30.0);
            vertical = Math.Round((originalVertical - 50 )/ 30.0);
            coordinateeee.Text = horizontal.ToString() + "," + vertical.ToString();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}
