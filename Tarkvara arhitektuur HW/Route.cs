using System;
using System.Collections.Generic;
using System.Text;

namespace Tarkvara_arhitektuur_HW
{
    public class Route
    {
        private List<Point> points;
        public Route ()
        {
            CreateRoute();
        }
        public List<Point> GetPoints()
        {
            return points;
        }
        private void CreateRoute()
        {
            points = new List<Point>();
        }
        public void AddPoint(double x, double y, int index)
        {
            if (index < 0 || index > points.Count)
            {
                return;
            }
            points.Insert(index, new Point(x, y));
        }
        
        public void RemovePoint(int index)
        {
            if (index < 0 || index >= points.Count)
            {
                return;
            }
            points.RemoveAt(index);
        }
        public double GetLength()
        {
            if(points.Count <= 1)
            {
                return 0;
            }
            double routeDistance = 0;
            for(int i = 0; i < points.Count - 1; i++)
            {
                routeDistance += points[i].Distance(points[i + 1]);
            }
            return routeDistance;
        }
    }
}
