using NUnit.Framework;
using Tarkvara_arhitektuur_HW;
using System;
using Newtonsoft.Json;

namespace PointTests
{
    public class PointTests
    {
        readonly double x = 42;
        readonly double y = 11;
        private Point point;
        private Point newPoint;

        [SetUp]
        public void Setup()
        {
            point = new Point(x, y);
            newPoint = new Point(5, 10);
        }

        [Test]
        public void TestAbscissa()
        {
            Assert.That(x, Is.EqualTo(point.x));
        }
        [Test]
        public void TestOrdinate()
        {
            Assert.That(y, Is.EqualTo(point.y));
        }
        [Test]
        public void TestRho()
        {
            double rho = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            Assert.That(rho, Is.EqualTo(point.Rho()));
        }
        [Test]
        public void TestTheta()
        {
            double theta = Math.Atan2(y, x);
            Assert.That(theta, Is.EqualTo(point.Theta()));
        }
        [Test]
        public void TestDistance()
        {
            double distance = point.VectorTo(newPoint).Rho();
            Assert.That(distance, Is.EqualTo(point.Distance(newPoint)));
        }
        [Test]
        public void TestVectorTo()
        {      
            Point resultPoint = new Point(newPoint.x - point.x, newPoint.y - point.y);
            Assert.AreEqual(JsonConvert.SerializeObject(resultPoint), JsonConvert.SerializeObject(point.VectorTo(newPoint)));
        }
        [Test]
        public void TestTranslate()
        {
            Point resultPoint = new Point(point.x + 10, point.y + 20);
            Point pointDuplicate = new Point(point.x, point.y);
            pointDuplicate.Translate(10, 20);
            Assert.AreEqual(JsonConvert.SerializeObject(resultPoint), JsonConvert.SerializeObject(pointDuplicate));
        }
        [Test]
        public void TestScale()
        {
            Point resultPoint = new Point(point.x * 3, point.y * 3);
            Point pointDuplicate = new Point(point.x, point.y);
            pointDuplicate.Scale(3);
            Assert.AreEqual(JsonConvert.SerializeObject(resultPoint), JsonConvert.SerializeObject(pointDuplicate));
        }
        [Test]
        public void TestCentreRotate()
        {
            double angle = Math.PI / 4;
            double theta = (point.Theta() + angle) % (2 * Math.PI);
            Point pointDuplicate = new Point(point.x, point.y);
            pointDuplicate.CentreRotate(angle);
            Assert.That(theta, Is.EqualTo(pointDuplicate.Theta()));
        }
        [Test]
        public void TestRotate()
        {
            double angle = Math.PI / 4;
            Point pointDuplicate = new Point(point.x, point.y);
            double resultx = ((point.x - newPoint.x) * Math.Cos(angle)) - ((point.y - newPoint.y) * Math.Sin(angle)) + newPoint.x;
            double resulty = ((point.x - newPoint.x) * Math.Sin(angle)) + ((point.y - newPoint.y) * Math.Cos(angle)) + newPoint.y;
            pointDuplicate.Rotate(newPoint, angle);
            Assert.That(resultx, Is.EqualTo(pointDuplicate.x).Within(0.001));
            Assert.That(resulty, Is.EqualTo(pointDuplicate.y).Within(0.001));
        }
    }
}