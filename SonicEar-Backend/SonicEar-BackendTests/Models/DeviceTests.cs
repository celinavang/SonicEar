using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonicEar_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicEar_Backend.Models.Tests
{
    [TestClass()]
    public class DeviceTests
    {
        private readonly Device _d1 = new() { Id = 1, Location = "TestLocation" };
        private readonly Device _d2 = new() { Id = 1, Location = null};


        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            string expected = "Device: 1, Location: TestLocation";

            // Act
            string actual = _d1.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
         
        }


        [TestMethod()]
        public void VerifyLocationTest()
        {
            // Arrange
            _d1.VerifyLocation();

            // Act & assert
            Assert.ThrowsException<ArgumentNullException>(() => _d2.VerifyLocation());

        }
    }
}