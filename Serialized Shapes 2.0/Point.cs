using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialized_Shapes_2._0
{
    [Serializable()]
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double DistanceBetween(Point P)
        {
            return Math.Sqrt((X-P.X)*(X-P.X)+(Y-P.Y)*(Y-P.Y));
        }
    }
}
