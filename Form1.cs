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
    //class Piece:PictureBox
    //{
    //    public Piece(int x,int y)
    //    {
    //        this.BackColor = Color.Transparent; // 背景颜色
    //        this.Location = new Point(x, y); // 位置x，y是一个Point的实例对象
    //        this.Size = new Size(15, 15);// 大小
    //    }
    //}

    //class BlackPiece:Piece
    //{
    //    public BlackPiece(int x,int y):base(x,y)
    //    {
    //        this.Image = Properties.Resources.BlackChess0;
    //    }
    //}

    //class WhitePiece : Piece
    //{
    //    public WhitePiece(int x,int y):base(x,y)
    //    {
    //        this.Image = Properties.Resources.WhiteChess0;
    //    }
    //}

    public partial class Form1 : Form
    {
        private double horizontal;
        private double vertical;
        private double originalHorizontal;
        private double originalVertical;

        private int cnt = 0;
        private Image blackChess=Properties.Resources._24pixel_BlackChess0;
        private Image whiteChess = Properties.Resources._24pixel_WhiteChess0;
        

        private const double spaceOfEachCell = 40.0;
        private const double radiusOfChess = 8.0;
        private const int sizeOfChessPicture = 12;
        public Form1(string sss)
        {
            InitializeComponent();
        }

        public Point standardizing(double x,double y, int Correctedvalue)
        {
            //这个函数把取到的点向左上方平移，使得画的棋子的中心与网格交点重合
            //其中Correctvalue表示平移的距离大小
            Point returnPoint0 = new Point((int)(x * (int)spaceOfEachCell) + 50 - Correctedvalue, (int)(y * (int)spaceOfEachCell) + 50 - Correctedvalue);
            return returnPoint0;
        }
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            //pictureBox2.Parent = pictureBox1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e) { }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            //获取原始鼠标点击的坐标
            Point p0 = this.PointToClient(Control.MousePosition);
            string X = p0.X.ToString();
            string Y = p0.Y.ToString();
            textBox1.Text = X + "," + Y;

            originalHorizontal = Convert.ToDouble(p0.X);
            originalVertical = Convert.ToDouble(p0.Y);

            //将原始坐标转化为棋盘上的坐标，并使用四舍五入使得当鼠标点击格点附近时也转化为临近的棋盘格点坐标
            horizontal = Math.Round((originalHorizontal - 50) / spaceOfEachCell);
            vertical = Math.Round((originalVertical - 50) / spaceOfEachCell);
            textBox2.Text = horizontal.ToString() + "," + vertical.ToString();


            //改为在pictureBox1中画棋子
            Graphics g0 = pictureBox1.CreateGraphics();
            Rectangle rect = pictureBox1.ClientRectangle;

            Point optimizePointGDI = standardizing(horizontal, vertical,(int)radiusOfChess);
            //得一个向左上方平移后的优化过的点，这个点是GDI+画纯色棋子用的

            Point optimizePoint = standardizing(horizontal, vertical, sizeOfChessPicture);
            //也得一个向左上方平移后的优化过的点，这个点是贴棋子图片用的

            rect = new Rectangle(optimizePointGDI.X, optimizePointGDI.Y, 2 * (int)radiusOfChess, 2 * (int)radiusOfChess);
            
            Pen myRedPen = new Pen(Color.Red);
            //rect.Offset(0, 10);

            

            if (vertical >= 0 && vertical <= 14 && horizontal >= 0 && horizontal <= 14)
            {
                cnt++;
                if (cnt % 2 == 0)
                {
                    Brush bush = new SolidBrush(Color.White);
                    g0.FillEllipse(bush, rect);
                    //g0.DrawImage(whiteChess, optimizePoint);
                    g0.DrawImage(whiteChess, optimizePoint.X, optimizePoint.Y, (float)sizeOfChessPicture * 2, (float)sizeOfChessPicture * 2);
                    //后两个参数强制使程序显示原本的图像大小
                }
                else
                {
                    Brush bush = new SolidBrush(Color.Black);
                    g0.FillEllipse(bush, rect);
                    g0.DrawImage(blackChess, optimizePoint.X, optimizePoint.Y, (float)sizeOfChessPicture * 2, (float)sizeOfChessPicture * 2);
                }
            }

            g0.Dispose();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void PictureBox1_Click(object sender, EventArgs e) { }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen0 = new Pen(Color.Black, 1);
            for (int i = 0; i < 15; i++)
            {
                //25*14=350
                //30*14=520
                Point point1 = new Point((int)spaceOfEachCell * i + 50, 50);
                Point point2 = new Point((int)spaceOfEachCell * i + 50, 50 + (int)spaceOfEachCell * 14);
                g.DrawLine(pen0, point1, point2);
            }
            for (int i = 0; i < 15; i++)
            {
                Point point3 = new Point(50, (int)spaceOfEachCell * i + 50);
                Point point4 = new Point(50 + (int)spaceOfEachCell * 14, (int)spaceOfEachCell * i + 50);
                g.DrawLine(pen0, point3, point4);
            }
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e) { }

        private void ClearTest_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
