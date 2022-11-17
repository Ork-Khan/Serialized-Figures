using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialized_Shapes_2._0
{
    static class IOputs
    {
        public static void GivenPoints(int times,ref LinkedList<Point> Points)
        {
            double x,y;
            for(int i = 0; i < times; i++)
            {
                Console.Write("X:");
                RightInput(out x);
                Console.Write("Y:");
                RightInput(out y);
                Point point = new Point(x, y);
                Points.AddLast(point);
            }
        } ///fills Given list with Points taken from user
        public static void MenuText(string Context)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Context);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void RightInput(out int Inp)
        {
            bool IsItInt=int.TryParse(Console.ReadLine(), out Inp);
            if (!IsItInt)
            {
                Console.WriteLine("Please enter appropriate number");
                RightInput(out Inp);
            }
        } ///take right input for int
        public static void RightInput(out double Inp)
        {
            bool IsItDouble = double.TryParse(Console.ReadLine(), out Inp);
            if (!IsItDouble)
            {
                Console.WriteLine("Please enter appropriate number");
                RightInput(out Inp);
            }
        } ///take right input for double
    }
}
