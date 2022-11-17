using Serialized_Shapes_2._0.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Serialized_Shapes_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Figure> Figures= new LinkedList<Figure>();
            int FirstMenu;
            string JPath = @"FigureData.json";
            if (!System.IO.File.Exists(JPath))
            {
                System.IO.File.Create(JPath);
            }
            //DeJason(JPath, ref Figures);
            DeJason(JPath, ref Figures);
            while (true)
            {
                IOputs.MenuText("1) show all figures\r\n2) create a figure\r\n3) change figure:\r\n4) save to file\r\n0) exit\r\n");
                IOputs.RightInput(out FirstMenu);
                switch (FirstMenu)
                {
                    case 1:
                        {
                            ShowFigures(ref Figures);
                            break;
                        }///Deserialization of json file to List of figures then Writing figures from list to Console
                    case 2:
                        {
                            CreateFigure(ref Figures);
                            break;
                        }///Creating and filling List of Figures
                    case 3:
                        {
                            ChangeFigure(ref Figures);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("saving...");
                            Jason(JPath, Figures);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("byee");
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a number from Menu");
                            IOputs.RightInput(out FirstMenu);
                            break;
                        }
                }
            }
        }
        static void CreateFigure(ref LinkedList<Figure> figures)
        {
            if (figures == null) figures=new LinkedList<Figure>();
            IOputs.MenuText("Choose the figure type you want to create\r\n1)Rectangle\r\n2)Circle\r\n3)Triangle\r\n");
            int CreateMenu;
            IOputs.RightInput(out CreateMenu);
            LinkedList<Point> Ps=new LinkedList<Point>();
            switch (CreateMenu)
            {
                case 1:
                    {
                        IOputs.GivenPoints(4,ref Ps);
                        Rectangle rec = new Rectangle(Ps);
                        figures.AddLast(rec);
                        break;
                    }///creating rectangle
                case 2:
                    {
                        IOputs.GivenPoints(2,ref Ps);
                        Circle cir = new Circle(Ps);
                        figures.AddLast(cir);

                        break;
                    }///creating circle
                case 3:
                    {
                        IOputs.GivenPoints(3,ref Ps);
                        Triangle tri= new Triangle(Ps);
                        figures.AddLast(tri);
                        break;
                    }///creating Triangle
                default:
                    {
                        Console.WriteLine("Please enter a number from Menu");
                        IOputs.RightInput(out CreateMenu);
                        break;
                    }
            }
        }
        static void ShowFigures( ref LinkedList<Figure> figures)
        {
            try
            {
                for (int i = 0; i < figures.Count; i++)
                {
                    Console.WriteLine($"{i} " + figures.ElementAt(i).ToString());
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("You have no Figures. Please create one");
                CreateFigure(ref figures);
            }
        }
        static void ChangeFigure(ref LinkedList<Figure> figures)
        {
            Console.WriteLine("which figure do you want to change");
            ShowFigures(ref figures);
            int FigNum;
            IOputs.RightInput(out FigNum);
            IOputs.MenuText("What do you want to change\r\n1)Move\r\n2)Scale\r\n3)Rotate\r\n");
            int ChangeMenu;
            IOputs.RightInput(out ChangeMenu);
            switch (ChangeMenu)
            {
                case 1:
                    {
                        Console.WriteLine("enter coordinates ");
                        double a, b;
                        IOputs.RightInput(out a);
                        IOputs.RightInput(out b);
                        figures.ElementAt(FigNum).MoveBy(a, b);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("enter scale parametr");
                        double a;
                        IOputs.RightInput(out a);
                        figures.ElementAt(FigNum).Scale(a);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("enter degree of rotation");
                        double a;
                        IOputs.RightInput(out a);
                        figures.ElementAt(FigNum).Rotate(a);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("please enter proper number from menu");
                        break;
                    }
            }
        }
        static void Jason(string Path, LinkedList<Figure> figures)
        {
            using(TextWriter writer = new StreamWriter(Path))
            {
                string Serialized= JsonConvert.SerializeObject(figures, (new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented }));
                writer.WriteLine(Serialized);
            }
        }
        static void DeJason(string Path,ref LinkedList<Figure> figures)
        {
            using(TextReader reader = new StreamReader(Path))
            {
                Newtonsoft.Json.JsonSerializer jsonserializer = Newtonsoft.Json.JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented });
                figures = (LinkedList<Figure>)jsonserializer.Deserialize(reader, typeof(LinkedList<Figure>));
            }
        }
    }
}
