using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MyPoint
    {
        public MyPoint()
        {

        }

        public MyPoint(PointF left, PointF right)
        {
            Left = left;
            Right = right;
        }

        public PointF Left { get; set; }
        public PointF Right { get; set; }
    }
}
