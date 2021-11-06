using System;
namespace Tarkvara_arhitektuur_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(10, 20);
            Point point2 = new Point(-20, 60);
            Console.Write("Kaugus kahe punkti vahel: ");
            Console.WriteLine(point1.Distance(point2));
            Console.WriteLine("------------------------");
            Console.WriteLine("Koordinaadid:");
            Point point3 = new Point(15, 0);
            Point centre = new Point();
            point3.Rotate(centre, Math.PI / 3);
            //point3.CentreRotate(Math.PI / 3);
            Console.WriteLine(point3.Result());
            
            Console.ReadLine();
        }
    }
}
