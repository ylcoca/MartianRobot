using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace MartianRobot.Entities.Tests
{
    [TestClass()]
    public class PlanetTests
    {
        Planet planet;
        Point upperRightPoint;

        [TestInitialize]
        public void Initialize()
        {
            upperRightPoint = new Point(5, 3);
            Scent scent = new()
            { 
                _point = new Point(5,0)
            };

            planet = new Planet(upperRightPoint);
            planet.AddScent(scent);
        }

        [TestMethod()]
        public void HasMatchingScent_WhenScentFound_ReturnTrue()
        {
            Scent scent = new()
            {
                _point = new Point(5, 0)
            };
           var found = planet.HasMatchingScent(scent);
            Assert.IsTrue(found);
        }

        [TestMethod()]
        public void HasMatchingScent_WhenScentNotFound_ReturnFalse()
        {
            Scent scent = new()
            {
                _point = new Point(5, 1)
            };
            var found = planet.HasMatchingScent(scent);
            Assert.IsFalse(found);
        }
    }
}