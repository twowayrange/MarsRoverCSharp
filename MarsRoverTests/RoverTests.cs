using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition ()
        {
            Rover newRover = new Rover(300);
            Assert.AreEqual(300, newRover.Position);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(300);
            Assert.AreEqual(newRover.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(300);
            Assert.AreEqual(newRover.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover newRover = new Rover(300);
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER")};
            Message newMessage = new Message("Hi", commands);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Rover newRover = new Rover(300);
            Command[] commands = { new Command("MOVE") };
            Message newMessage = new Message("Hi", commands);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover newRover = new Rover(300);
            Command[] commands = { new Command("MOVE", 200) };
            Message newMessage = new Message("Hi", commands);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "NORMAL");
        }
    }
}
