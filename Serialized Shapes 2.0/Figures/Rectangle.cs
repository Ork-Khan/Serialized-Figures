using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialized_Shapes_2._0.Figures
{
    [Serializable()]
    public class Rectangle : Figure
    {
        public override LinkedList<Point> Points { get; set; }
        public override LinkedList<double> Sides { get; set; }
        public override Point Center { get; set; }
        public override double Area { get; set; }
        public override double Perimetr { get; set; }
        public Rectangle(LinkedList<Point> points)
        {
            Points = points;
            SortPoints();
            CalcSides();
            CalcCenter();
            CalcPerimetr();
            CalcArea();
        }
        public void SortPoints()
        {
            Point Decoy = Points.First();
            for(int i = 1; i < 4; i++)
            {
                if (Decoy.X != Points.ElementAt(i).X && Decoy.Y != Points.ElementAt(i).Y)
                {
                    double x=Points.ElementAt(i).X;
                    double y=Points.ElementAt(i).Y;
                    Points.ElementAt(i).X = Points.ElementAt(i + 1).X;
                    Points.ElementAt(i).Y = Points.ElementAt(i + 1).Y;
                    Points.ElementAt(i + 1).X = x;
                    Points.ElementAt(i + 1).Y = y;
                    break;
                }
                Decoy=Points.ElementAt(i);
            }
        }
        public override void CalcArea()
        {
            Area = Sides.First() * Sides.Last();
        }

        public override void CalcCenter()
        {
            double x = 0;
            double y = 0;
            foreach(Point p in Points)
            {
                x += p.X;
                y += p.Y;
            }
            Center = new Point(x / 4, y / 4);
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
            this.Sides= new LinkedList<double>();
            Point Decoy=Points.First();
            double distance;
            foreach (Point p in Points)
            {
                if(Decoy.X!=p.X || Decoy.Y != p.Y)
                {
                    distance = Decoy.DistanceBetween(p);
                    this.Sides.AddFirst(distance);
                    Decoy=p;
                }
            }
            distance = Decoy.DistanceBetween(Points.First());
            this.Sides.AddLast(distance);
        }

        public override void MoveBy(double x, double y)
        {
            foreach(Point point in Points)
            {
                point.X +=x;
                point.Y +=y;
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
            CalcArea();
            CalcPerimetr();
        }
    }
}
