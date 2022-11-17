using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialized_Shapes_2._0.Figures
{
    [Serializable()]
    public abstract class Figure
    {
        public abstract LinkedList<Point> Points { get; set; }
        public abstract LinkedList<double> Sides { get; set; }
        public abstract void CalcSides();
        public abstract void CalcCenter();
        public abstract Point Center { get; set; }
        public abstract void CalcArea();
        public abstract double Area { get; set; }

        public abstract void CalcPerimetr();
        public abstract double Perimetr { get; set; }
        public abstract void MoveBy(double x, double y);
        public abstract void Scale(double ScaleParam);
        public abstract void Rotate(double RotationParam);
        public override string ToString()
        {
            string result = "";
            result+=this.GetType().Name;
            result += $" Area={this.Area} Perimetr={this.Perimetr}";
            return result;
        }
    }
}
