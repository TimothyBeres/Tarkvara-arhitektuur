using NUnit.Framework;
using System;
using Tarkvara_arhitektuur_HW;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RouteTests
{
    public class RouteTests
    {
        private Route route;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestCreateRoute()
        {
            route = new Route();
            Assert.IsNotNull(route.GetPoints());
        }
        [Test]
        public void TestAddPoint()
        {
            route = new Route();
            route.AddPoint(10, 20, 2);
            Assert.IsEmpty(route.GetPoints());
            
            route.AddPoint(10, 40, -2);
            Assert.IsEmpty(route.GetPoints());

            route.AddPoint(10, 20, 0);
            route.AddPoint(10, 15, 0);
            Assert.AreEqual(2, route.GetPoints().Count);
        }
        [Test]
        public void TestRemovePoint()
        {
            route = new Route();
            route.AddPoint(10, 20, 0);
            route.RemovePoint(1);
            Assert.AreEqual(1, route.GetPoints().Count);

            route.RemovePoint(-1);
            Assert.AreEqual(1, route.GetPoints().Count);

            route.RemovePoint(0);
            Assert.IsEmpty(route.GetPoints());

            Point staysInRoute = new Point(8, 2);
            route.AddPoint(5, 7, 0);
            route.AddPoint(8, 2, 1);
            route.RemovePoint(0);
            Assert.AreEqual(1, route.GetPoints().Count);
            Assert.AreEqual(JsonConvert.SerializeObject(route.GetPoints()[0]), JsonConvert.SerializeObject(staysInRoute));

        }
        [Test]
        public void TestGetLength()
        {
            route = new Route();
            for (int i = 0; i < 4; i++)
            {
                
            }
        }

    }
}
