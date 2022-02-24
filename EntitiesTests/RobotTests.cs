using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace MartianRobot.Entities.Tests
{
    [TestClass()]
    public class RobotTests
    {
        Robot robot;
        Point upperRightPoint;
        Point startLocation;
        Planet planet;

        [TestInitialize]
        public void Initialize()
        {
            upperRightPoint = new Point(5,3);
            startLocation = new Point(1,1);

            planet = new Planet(upperRightPoint);

            robot = new Robot(planet, startLocation, Orientation.E);

        }


        [TestMethod()]
        public void InstructionString_WhenROnDirE_TurnSouth()
        {
            robot.InstructionString("R");
            Assert.AreEqual(Orientation.S,robot.GetOrientation());
        }

        [TestMethod()]
        public void InstructionString_WhenLOnDirE_TurnNorth()
        {
            robot.InstructionString("L");
            Assert.AreEqual(Orientation.N, robot.GetOrientation());
        }

        [TestMethod()]
        public void InstructionString_WhenMoveFOrwardEast_XIncrements()
        {
            robot.InstructionString("F");
            Assert.AreEqual(2, robot.GetLocation().X);
        }

        [TestMethod()]
        public void InstructionString_WhenMoveFOrwardSouth_YIDecrements()
        {
            robot = new Robot(planet, startLocation, Orientation.S);
            robot.InstructionString("F");
            Assert.AreEqual(0, robot.GetLocation().Y);
        }

        [TestMethod()]
        public void InstructionString_WhenMoveFOrwardWest_XDecrements()
        {
            robot = new Robot(planet, startLocation, Orientation.W);
            robot.InstructionString("F");
            Assert.AreEqual(0, robot.GetLocation().X);
        }

        [TestMethod()]
        public void InstructionString_WhenMoveFOrwardNorth_YIncrements()
        {
            robot = new Robot(planet, startLocation, Orientation.N);
            robot.InstructionString("F");
            Assert.AreEqual(2, robot.GetLocation().Y);
        }

        [TestMethod()]
        public void IsLost_WhenXGreaterThanUpperBound_LostIsTrue()
        {
            robot.SetLocation(new Point(6, 3));

            var result  = robot.IsLost();
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsLost_WhenYGreaterThanUpperBound_LostIsTrue()
        {
            robot.SetLocation(new Point(5, 4));

            var result = robot.IsLost();
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsLost_WhenYLowerThanZero_LostIsTrue()
        {
            robot.SetLocation(new Point(5, -4));

            var result = robot.IsLost();
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsLost_WhenXLowerThanZero_LostIsTrue()
        {
            robot.SetLocation(new Point(-5, 4));

            var result = robot.IsLost();
            Assert.IsTrue(result);
        }
    }
}