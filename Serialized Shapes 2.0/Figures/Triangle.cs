using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Serialized_Shapes_2._0.Figures
{
    [Serializable()]
    public class Triangle : Figure
    {
        public override LinkedList<Point> Points { get; set; }
        public override LinkedList<double> Sides { get; set; }
        public override Point Center { get; set; }
        public override double Area { get; set; }
        public override double Perimetr { get; set; }
        public Triangle(LinkedList<Point> points)
        {
            Points=points;
            CalcCenter();
            CalcSides();
            CalcPerimetr();
            CalcArea();
        }
        public override void CalcArea()
        {
            double SemiPerimetr = Perimetr / 2;
            double cal = SemiPerimetr;
            foreach(double s in Sides)
            {
                cal *= SemiPerimetr - s;
            }
            Area = cal;
        }

        public override void CalcCenter()
        {
            double XCoor = 0;
            double YCoor = 0;
            foreach (Point p in Points)
            {
                XCoor += p.X;
                YCoor += p.Y;
            }
            Center = new Point(XCoor/3, YCoor/3);
        }

        public override void CalcPerimetr()
        {
            Perimetr = 0;
            foreach(double s in Sides)
            {
                Perimetr += s;
            }
        }

        public override void CalcSides()
        {
            Sides = new LinkedList<double>();
            Point Decoy = Points.First();
            double distance;
            foreach (Point p in Points)
            {
                if (Decoy.X != p.X || Decoy.Y != p.Y)
                {
                    distance = Decoy.DistanceBetween(p);
                    this.Sides.AddFirst(distance);
                    Decoy = p;
                }
            }
            distance = Decoy.DistanceBetween(Points.First());
            this.Sides.AddLast(distance);
        }

        public override void MoveBy(double x, double y)
        {
            foreach (Point p in Points)
            {
                p.X += x;
                p.Y += y;
            }
            CalcCenter();
        }

        public override void Rotate(double RotationParam)
        {
            foreach (Point P in Points)
            {
                double oldX = P.X;
                P.X = Center.X + Math.Cos(RotationParam) * (P.X - Center.X) - Math.Sin(RotationParam) * (P.Y - Center.Y);
                P.Y = Center.Y + Math.Sin(RotationParam) * (oldX - Center.X) + Math.Cos(RotationParam) * (P.Y - Center.Y);
            }
        }

        public override void Scale(double ScaleParam)
        {
            foreach (Point p in Points)
            {
                p.X = ScaleParam * (p.X - Center.X) + Center.X;
                p.Y = ScaleParam * (p.Y - Center.Y) + Center.Y;
            }
            CalcSides();
            CalcPerimetr();
            CalcArea();
        }
    }
}
