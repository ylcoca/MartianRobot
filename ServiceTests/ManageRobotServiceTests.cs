using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace MartianRobot.Service.Tests
{
    [TestClass()]
    public class ManageRobotServiceTests
    {
        ManageRobotService service;
        Mock<IFile> _file;


        [TestMethod()]
        public void ReadSetUpFile_WhenInstructionsGreaterThan100Charact_ThrowException()
        {

            IEnumerable<string> list = new List<string>() { "5 3", "1 1 E", "FRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLL" };

            _file = new Mock<IFile>();
            _file.Setup(f => f.GetFile()).Returns(list);
            service = new ManageRobotService(_file.Object);
            Assert.ThrowsException<Exception>(() => service.ReadSetUpFile());
        }

        [TestMethod()]
        public void ReadSetUpFile_WhenCoordinatesGreaterThan50_ThrowException()
        {
            IEnumerable<string> list = new List<string>() { "5 3", "1 51 E", "RFR" };

            _file = new Mock<IFile>();
            _file.Setup(f => f.GetFile()).Returns(list);
            service = new ManageRobotService(_file.Object);
            Assert.ThrowsException<Exception>(() => service.ReadSetUpFile());
        }
    }
}