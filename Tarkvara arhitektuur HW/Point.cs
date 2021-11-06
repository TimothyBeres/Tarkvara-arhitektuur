using System;
using System.Collections.Generic;
using System.Text;

namespace Tarkvara_arhitektuur_HW
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point (double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }
        public string Result()
        {
            string result = $"x: {x}@y: {y}@rho: {Rho()}@theta: {Theta()}";

            return result.Replace("@", Environment.NewLine);
        }
        public double Rho()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        public double Theta()
        {
            return Math.Atan2(y, x);
        }
        public double Distance(Point point)
        {
            return VectorTo(point).Rho();
        }
        public Point VectorTo(Point point)
        {
            return new Point(point.x - x, point.y - y);
        }

        /* Commands */
        public void Translate(double dx, double dy)
        {
            x += dx;
            y += dy;
        }
        public void Scale(double factor)
        {
            x *= factor;
            y *= factor;
        }
        public void CentreRotate(double angle)
        {
            double temp_x = Rho() * Math.Cos(Theta() + angle);
            double temp_y = Rho() * Math.Sin(Theta() + angle);
            x = temp_x;
            y = temp_y;
        }
        public void Rotate(Point point, double angle)
        {
            Translate(-point.x, -point.y);
            CentreRotate(angle);
            Translate(point.x, point.y);
        }
    }
}
