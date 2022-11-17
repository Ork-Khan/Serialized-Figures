using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialized_Shapes_2._0.Figures
{
    [Serializable()]
    public class Circle : Figure
    {
        public override LinkedList<Point> Points { get; set; }
        public override LinkedList<double> Sides { get; set; }
        public override Point Center { get; set; }
        public override double Area { get; set; }
        public override double Perimetr { get; set; }
        public double radius;
        public Circle(LinkedList<Point> points)
        {
            Points = points;
            CalcCenter();
            CalcSides();
            CalcArea();
            CalcPerimetr();
        }
        public override void CalcArea()
        {
            Area = Math.PI*radius*radius;
        }

        public override void CalcCenter()
        {
            Center = Points.First();
        }

        public override void CalcPerimetr()
        {
            Perimetr = Math.PI*radius*2;
        }

        public override void CalcSides()
        {
            radius=Center.DistanceBetween(Points.Last());
        }

        public override void MoveBy(double x, double y)
        {
            foreach (Point p in Points)
            {
                p.X += x;
                p.Y += y;
            }
        }

        public override void Rotate(double RotationParam)
        {
        }

        public override void Scale(double ScaleParam)
        {

            Points.Last().X = ScaleParam * (Points.Last().X - Center.X) + Center.X;
            Points.Last().Y = ScaleParam * (Points.Last().Y - Center.Y) + Center.Y;
            CalcSides();
            CalcPerimetr();
            CalcArea();
        }
    }
}
