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
        //画布宽度
        private int weight = 500;
        //画布高度
        private int height = 250;
        //画布距离左边的长度
        private int left = 200;
        //画布距离上边的长度
        private int top = 200;
        //放大倍率
        private float big = 1.1f;
        //竖的格子数
        private int hGrid = 25;
        //横的格子数
        private int wGrid = 50;

        private int count = 10;

        private Point point = new Point()
        {
            X = 350,
            Y = 225,
        };

        private int cardio = 1000;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen p1 = new Pen(Color.Red, 2);
            Pen p2 = new Pen(Color.Black, 1);
            g.DrawRectangle(p1, new Rectangle(left, top, weight, height));

            var list = new List<MyPoint>();
            for (int i = 1; i <= wGrid; i++)
            {
                list.Add(new MyPoint(new PointF(left + count * i, top), new PointF(left + count * i, height+top)));
            }
            for (int i = 1; i <= hGrid; i++)
            {
                list.Add(new MyPoint(new PointF(left, top + count * i), new PointF(left+weight, top + count * i)));
            }

            foreach (var item in list)
            {
                g.DrawLine(p2, item.Left, item.Right);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen p1 = new Pen(Color.Red, 2);
            Pen p2 = new Pen(Color.Black, 1);
            g.DrawRectangle(p1, new Rectangle(left, top, weight, height));

            var list1 = new List<MyPoint>();
            for (int i = 1; i <= wGrid; i++)
            {
                list1.Add(new MyPoint(new PointF(left + count * i, top), new PointF(left + count * i, height + top)));
            }
            var list2 = new List<MyPoint>();
            for (int i = 1; i <= hGrid; i++)
            {
                list2.Add(new MyPoint(new PointF(left, top + count * i), new PointF(left + weight, top + count * i)));
            }
            var listC1 = new PointF[cardio];
            for (int i = 0; i < cardio; i++)
            {
                listC1[i] = new PointF(i + left, i % 30 + top);
            }

            var list3 = list1.Select(x =>
            {
                return new MyPoint(new PointF((x.Left.X-left) * big - point.X*(big-1) + left, (x.Left.Y-top) * big - point.Y * (big - 1) + top), new PointF((x.Right.X-left) * big - point.X * (big - 1) + left, (x.Right.Y-top) * big - point.Y * (big - 1) + top));
            });
            var list4 = list2.Select(x =>
            {
                return new MyPoint(new PointF((x.Left.X - left) * big - point.X * (big - 1) + left, (x.Left.Y - top) * big - point.Y * (big - 1) + top), new PointF((x.Right.X - left) * big - point.X * (big - 1) + left, (x.Right.Y - top) * big - point.Y * (big - 1) + top));
            });

            var listC2 = listC1.Select(x =>
            {
                return new PointF((x.X - left) * big - point.X + left, (x.Y - top) * big - point.Y + top);
            }).ToArray();

            var list5 = list3.Where(x => x.Left.X < weight + left && x.Left.X > left);
            var list6 = list4.Where(x => x.Left.Y < top + height && x.Left.Y > top);

            var listC3 = listC2.Where(x => x.Y < top + height && x.Y > top);

            var list7 = list5.Select(x =>
            {
                return new MyPoint(new PointF(x.Left.X, top), new PointF(x.Right.X, top + height));
            });

            var list8 = list6.Select(x =>
            {
                return new MyPoint(new PointF(left, x.Left.Y), new PointF(left+weight, x.Right.Y));
            });

            foreach (var item in list3)
            {
                g.DrawLine(p2, item.Left, item.Right);
            }
            foreach (var item in list4)
            {
                g.DrawLine(p2, item.Left, item.Right);
            }

            g.DrawLines(p2, listC2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
        }
    }
}
