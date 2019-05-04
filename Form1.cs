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
        //图形绘制数据
        private const int sizeOfBorad = 15;
        private const double spaceOfEachCell = 40.0;
        private const double radiusOfChess = 8.0;
        private const int sizeOfChessPicture = 12;

        //整个棋盘
        private int[,] checkerBoard = new int[sizeOfBorad,sizeOfBorad];

        //各种状态
        //private enum globalStatus{
        //    WHITE_OFF=1,        //白棋先手
        //    BLACK_OFF,          //黑棋先手
        //    BLACK,              //放在棋盘里表示黑棋
        //    WHITE               //放在棋盘里表示白棋
        //}

        private double horizontal;
        private double vertical;
        private double originalHorizontal;
        private double originalVertical;

        //游戏数据
        private int offensive;
        private int defensive;
        private int cnt = 0;        //步数记录器
        private int cheak = 0;      //落子顺序判定器

        //四种棋子图片
        private Image blackChess = Properties.Resources._24pixel_BlackChess0;
        private Image whiteChess = Properties.Resources._24pixel_WhiteChess0;
        private Image presentBlackChess=Properties.Resources._24pixel_BlackChess0_Present;
        private Image presentWhiteChess = Properties.Resources._24pixel_WhiteChess0_Present;

        
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            initializeBoard();
        }

        public Form1(int a)
        {
            if(a==Common.WHITE_OFF)
            {
                offensive = Common.WHITE_OFF;
                defensive = Common.BLACK_OFF;
                cheak = 0;
            }
            else
            {
                offensive = Common.BLACK_OFF;
                defensive = Common.WHITE_OFF;
                cheak = 1;
            }
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            initializeBoard();
            this.Show();
        }

        public void initializeBoard()
        {
            //这个函数初始化棋盘
            for (int i = 0; i < sizeOfBorad; i++)
            {
                for (int j = 0; j < sizeOfBorad; j++)
                {
                    checkerBoard[i,j] = 0;
                }
            }
        }

        public Point standardizing(Point p, int Correctedvalue)
        {
            //这个函数把取到的棋盘上的（不是原始的）点向左上方平移，使得画的棋子的中心与网格交点重合
            //其中Correctvalue表示平移的距离大小
            Point returnPoint0 = new Point(p.X * (int)spaceOfEachCell + 50 - Correctedvalue, p.Y * (int)spaceOfEachCell + 50 - Correctedvalue);
            return returnPoint0;
        }

        public void setTextBox(TextBox b, Point p)
        {
            //在指定的TextBox中显示坐标数据
            string X = p.X.ToString();
            string Y = p.Y.ToString();
            b.Text = X + "," + Y;
        }

        public Point optimizePoints(Point p)
        {
            //将原始坐标转化为棋盘上的坐标，并使用四舍五入使得当鼠标点击格点附近时也转化为临近的棋盘格点坐标
            double h = Math.Round((Convert.ToDouble(p.X) - 50) / spaceOfEachCell);
            double v = Math.Round((Convert.ToDouble(p.Y) - 50) / spaceOfEachCell);
            Point ans = new Point(Convert.ToInt16(h), Convert.ToInt16(v));
            return ans;
        }

        public bool ChessMove(Point p,int a)
        {

            if (p.Y >= 0 && p.Y <= sizeOfBorad-1 && p.X >= 0 && p.X <= sizeOfBorad-1)
            {
                if (checkerBoard[p.X, p.Y] == 0)
                {

                    //落子
                    checkerBoard[p.X, p.Y] = a;

                    //改为在pictureBox1中画棋子
                    Graphics g0 = pictureBox1.CreateGraphics();
                    Rectangle rect = pictureBox1.ClientRectangle;

                    Point optimizePointGDI = standardizing(p, (int)radiusOfChess);
                    //得一个向左上方平移后的优化过的点，这个点是GDI+画纯色棋子用的

                    Point optimizePoint = standardizing(p, sizeOfChessPicture);
                    //也得一个向左上方平移后的优化过的点，这个点是贴棋子图片用的


                    for (int i = 0; i < sizeOfBorad; i++)
                    {
                        for (int j = 0; j < sizeOfBorad; j++)
                        {
                            Point temp = new Point(i, j);
                            Point tempGDI = standardizing(temp, (int)radiusOfChess);
                            Point tempP = standardizing(temp, sizeOfChessPicture);
                            rect = new Rectangle(tempGDI.X, tempGDI.Y, 2 * (int)radiusOfChess, 2 * (int)radiusOfChess);

                            //if(p.X == i && p.Y == j)
                            //{
                            //    g0.DrawImage((checkerBoard[i, j] == Common.BLACK) ? presentBlackChess : presentWhiteChess, optimizePoint.X, optimizePoint.Y, (float)sizeOfChessPicture * 2, (float)sizeOfChessPicture * 2);
                            //    continue;
                            //}
                            
                            if (checkerBoard[i, j] == Common.BLACK)
                            {

                                Brush bush = new SolidBrush(Color.Black);
                                g0.FillEllipse(bush, rect);
                                //g0.DrawImage(blackChess, optimizePoint);
                                g0.DrawImage(blackChess, tempP.X, tempP.Y, (float)sizeOfChessPicture * 2, (float)sizeOfChessPicture * 2);
                                //后两个参数强制使程序显示原本的图像大小
                            }
                            else if (checkerBoard[i, j] == Common.WHITE)
                            {
                                Brush bush = new SolidBrush(Color.White);
                                g0.FillEllipse(bush, rect);
                                g0.DrawImage(whiteChess, tempP.X, tempP.Y, (float)sizeOfChessPicture * 2, (float)sizeOfChessPicture * 2);
                            }
                        }
                    }

                    g0.Dispose();

                    return true;
                }
            }
            return false;
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            //获取原始鼠标点击的坐标
            Point p0 = this.PointToClient(Control.MousePosition);
            setTextBox(textBox1, p0);
            Point optP0 = optimizePoints(p0);
            setTextBox(textBox2, optP0);

            
            if (cheak % 2 == Common.WHITE_OFF)
            {
                if (ChessMove(optP0, Common.WHITE))
                {
                    cnt++;
                    cheak++;
                }
            }
            else
            {
                if (ChessMove(optP0, Common.BLACK))
                {
                    cnt++;
                    cheak++;
                }
            }
        }

        

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen0 = new Pen(Color.Black, 1);
            for (int i = 0; i < sizeOfBorad; i++)
            {
                //25*14=350
                //30*14=520
                Point point1 = new Point((int)spaceOfEachCell * i + 50, 50);
                Point point2 = new Point((int)spaceOfEachCell * i + 50, 50 + (int)spaceOfEachCell * (sizeOfBorad - 1));
                g.DrawLine(pen0, point1, point2);
            }
            for (int i = 0; i < sizeOfBorad; i++)
            {
                Point point3 = new Point(50, (int)spaceOfEachCell * i + 50);
                Point point4 = new Point(50 + (int)spaceOfEachCell * (sizeOfBorad - 1), (int)spaceOfEachCell * i + 50);
                g.DrawLine(pen0, point3, point4);
            }
        }


        private void ClearTest_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            initializeBoard();
            //if (pictureBox1.Image != null)
            //{
            //    pictureBox1.Image.Dispose();
            //    pictureBox1.Image = null;
            //}
        }


        //以下代码是防设计器报错的，无实际意义
        private void Form1_Load(object sender, EventArgs e) { }
        private void PictureBox1_Click(object sender, EventArgs e) { }
        private void Form1_Paint(object sender, PaintEventArgs e) { }
    }
}
