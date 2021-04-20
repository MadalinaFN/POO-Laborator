using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasele_AbstractPoint_si_Point
{
    abstract public class AbstractPoint
    {
        public enum PointRepresentation { Polar, Rectangular }
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double R { get; set; }
        public abstract double A { get; set; }
        public void Move(double dx, double dy)
        {
            X += dx; Y += dy;
        }
        public void Rotate(double angle)
        {
            A += angle;
        }
        public override string ToString()
        {
            return "(" + X + ", " + Y + ")" + ":" + "[" + R + ", " + A + "] ";
        }
        protected static double RadiusGivenXy(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        protected static double AngleGivenXy(double x, double y)
        {
            return Math.Atan2(y, x);
        }
        protected static double XGivenRadiusAngle(double r, double a)
        {
            return r * Math.Cos(a);
        }
        protected static double YGivenRadiusAngle(double r, double a)
        {
            return r * Math.Sin(a);
        }
    }
    public class Point : AbstractPoint
    {
        private double radius, angle;
        public Point(PointRepresentation pr, double n1, double n2)
        {
            if (pr == PointRepresentation.Polar)
            {
                radius = n1; angle = n2;
            }
            else if (pr == PointRepresentation.Rectangular)
            {
                radius = RadiusGivenXy(n1, n2);
                angle = AngleGivenXy(n1, n2);
            }
            else
            {
                throw new Exception("Situație imprevizibilă!");
            }
        }
        public override double X
        {
            get
            {
                return XGivenRadiusAngle(radius, angle);
            }
            set
            {
                double yBefore = YGivenRadiusAngle(radius, angle);
                angle = AngleGivenXy(value, yBefore);
                radius = RadiusGivenXy(value, yBefore);
            }
        }
        public override double Y
        {
            get
            {
                return YGivenRadiusAngle(radius, angle);
            }
            set
            {
                double xBefore = XGivenRadiusAngle(radius, angle);
                angle = AngleGivenXy(xBefore, value);
                radius = RadiusGivenXy(xBefore, value);
            }
        }
        public override double R { get { return radius; } set { radius = value; } }
        public override double A { get { return angle; } set { angle = value; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPoint.PointRepresentation rect = AbstractPoint.PointRepresentation.Rectangular;
            AbstractPoint.PointRepresentation pol = AbstractPoint.PointRepresentation.Polar;
            Point x = new Point(rect, 3.4, 7.8);
            Point y = new Point(pol, 2.9, 5.6);

            Console.WriteLine($"Punctul x cu reprezentare rectangulara este {x}");
            Console.WriteLine($"Punctul y cu reprezentare polara este {y}");
            Console.WriteLine();
            x.Move(7.1, 3.4);
            Console.WriteLine($"Translatarea punctului x = {x}");
            y.Move(7.1, 3.4);
            Console.WriteLine($"Translatarea punctului y = {y}");
            Console.WriteLine();
            x.Rotate(5);
            Console.WriteLine($"Rotatia punctului x = {x}");
            y.Rotate(5);
            Console.WriteLine($"Rotatia punctului y = {y}");
            Console.WriteLine();
        }
    }
}
